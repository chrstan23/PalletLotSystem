using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem{
    public partial class WithdrawForm : Form{
        String connStr = Config.ConnectionString;
        private string palletNo;
        private string palletId;
        private string location;

        //CLASS FOR GETTERS AND SETTER OF PARTNUMBER AND ITS SLOT
        public class PartItem
        {
            public int Slot { get; set; }
            public string PartNo { get; set; }

            public override string ToString(){
                return PartNo;
            }
        }

        public WithdrawForm(string palletNo){
            InitializeComponent();
            this.palletNo = palletNo;
            FetchPartNumbers();
        }

        //FETCHING PARTNUMBERS DEPENDING ON THE PALLETNO
        private void FetchPartNumbers(){
            try{
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                conn.Open();

                string query = "SELECT * FROM tbl_pallet WHERE palletNo = @palletNo";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@palletNo", palletNo);

                    using (MySqlDataReader reader = cmd.ExecuteReader()){
                        if (reader.Read()){
                            palletId = reader["palletId"].ToString();
                            location = reader["location"].ToString();
                            lblDisplay.Text = reader["palletNo"].ToString();
                            cmbPartNo.Items.Clear();

                            for (int i = 1; i <= 5; i++){
                                string partNo = reader["partNo" + i].ToString();

                                if (!string.IsNullOrWhiteSpace(partNo)){
                                    cmbPartNo.Items.Add(new PartItem()
                                    {
                                        Slot = i,
                                        PartNo = partNo
                                    });
                                }
                            }
                        }
                    }
                }
            }

            if (cmbPartNo.Items.Count > 0)
                cmbPartNo.SelectedIndex = 0;
        }catch (Exception ex){
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WithdrawForm_Load(object sender, EventArgs e)
        {

        }

        //DISPLAYING QUANTITY OF SELECTED PARTNUMBER ON THE COMBOBOX
        private void cmbPartNo_SelectedIndexChanged(object sender, EventArgs e){
            if (cmbPartNo.SelectedItem == null)
                return;

            PartItem item = (PartItem)cmbPartNo.SelectedItem;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "Select qty" + item.Slot + " FROM tbl_pallet WHERE palletNo=@palletNo";

                    using(MySqlCommand cmd = new MySqlCommand(query, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);
                        object result = cmd.ExecuteScalar();

                        if(result != null){
                            lblAvailQty.Text = result.ToString();
                        }else{
                            lblAvailQty.Text = "0";
                        }
                    }
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.Close();
        }

        
        private void btnWithdraw_Click(object sender, EventArgs e){
            if (cmbPartNo.SelectedItem == null){
                MessageBox.Show("Please select a part number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQty.Text.Trim())){
                MessageBox.Show("Please enter quantity to withdraw!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                return;

            }

            int withdrawQty;

            if (!int.TryParse(txtQty.Text.Trim(), out withdrawQty)){
                MessageBox.Show("Invalid Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Clear();
                txtQty.Focus();
                return;
            }

            PartItem item = (PartItem)cmbPartNo.SelectedItem;
            int currentQty = Convert.ToInt32(lblAvailQty.Text);

            if (withdrawQty <= 0){
                MessageBox.Show("Quantity must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Clear();
                txtQty.Focus();
                return;

            }

            //FORMULA FOR CHECKING THE WITHDRAW INPUT TO THE REMAINING QTY
            int remainingQty = currentQty - withdrawQty;

            if (withdrawQty > currentQty){
                MessageBox.Show("Withdraw quantity should not be greater than the remaining quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Clear();
                txtQty.Focus();
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to withdraw " + withdrawQty + " pc(s) of " + item.PartNo + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.No){
                return;

            }

            //UPDATING PARTNUMBER QUANTITY ON TBL_PALLET AFTER WITHDRAWING PARTS
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                conn.Open();

                string query;

                if(remainingQty == 0){
                    query = "UPDATE tbl_pallet SET partNo" + item.Slot + " = '', qty" + item.Slot + "= '0' WHERE palletNo=@palletNo";
                }else{
                    query = "UPDATE tbl_pallet SET qty" + item.Slot + " =@qty WHERE palletNo=@palletNo";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    if(remainingQty >= 0)
                        cmd.Parameters.AddWithValue("@qty", remainingQty);
                    cmd.Parameters.AddWithValue("@palletNo", palletNo);
                    cmd.ExecuteNonQuery();
                    }
                }

            InsertPartLog(withdrawQty, remainingQty);
            CheckIfPalletIsEmpty();


            FetchPartNumbers();
            txtQty.Clear();
            this.Close();


        }

        //LOGGING THE PARTNUMBERS WITHDRAWN IN THE PALLETS
        private void InsertPartLog(int withdrawQty, int remainingQty){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    PartItem item = (PartItem)cmbPartNo.SelectedItem;

                    string query = @"SELECT palletId, location FROM tbl_pallet WHERE palletNo=@palletNo";

                    string palletId = "";
                    string location = "";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);

                        using(MySqlDataReader reader = cmd.ExecuteReader()){
                            if (reader.Read()){
                                palletId = reader["palletId"].ToString();
                                location = reader["location"].ToString();

                            }
                        }
                    }

                    string insertQuery = @"INSERT INTO tbl_partlogs (palletNo, palletId, location, partNo, withdrawQty, remainingQty, employeeName, dateWithdraw, timeWithdraw) VALUES (@palletNo, @palletId, @location, @partNo, @withdrawQty, @remainingQty, @employeeName, @dateWithdraw, @timeWithdraw)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);
                        cmd.Parameters.AddWithValue("@palletId", palletId);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@partNo", item.PartNo);
                        cmd.Parameters.AddWithValue("@withdrawQty", withdrawQty);
                        cmd.Parameters.AddWithValue("@remainingQty", remainingQty);
                        cmd.Parameters.AddWithValue("@employeeName", UserSession.FullName);
                        cmd.Parameters.AddWithValue("@dateWithdraw", DateTime.Now.ToString("MM-dd-yyyy"));
                        cmd.Parameters.AddWithValue("@timeWithdraw", DateTime.Now.ToString("HH:mm:ss"));

                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //CHECKING IF ALL THE PARTS ARE WITHDRAWN ON THE PALLET
        private void CheckIfPalletIsEmpty(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string query = @"SELECT qty1, qty2, qty3, qty4, qty5 FROM tbl_pallet WHERE palletNo = @palletNo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);

                        using (MySqlDataReader reader = cmd.ExecuteReader()){
                            if (!reader.Read())
                                return;

                            bool isEmpty = true;

                            for (int i = 1; i <= 5; i++){
                                int qty = Convert.ToInt32(reader["qty" + i]);

                                if (qty > 0){
                                    isEmpty = false;
                                    break;
                                }
                            }

                            if (!isEmpty)
                                return;
                        }
                    }

                    MessageBox.Show("All parts have been withdrawn. Pallet has been marked as EMPTY.", "Pallet Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PalletOutLog();
                    ClearPallet();

                }catch (Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //CLEAR ALL PALLET DETAILS IF THE PALLET IS EMPTY
        private void ClearPallet(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string query = @"UPDATE tbl_pallet SET palletNo = '', palletId = '', status = 'EMPTY', partNo1 = '', qty1 = 0, partNo2 = '', qty2 = 0, partNo3 = '', qty3 = 0, partNo4 = '', qty4 = 0, partNo5 = '', qty5 = 0 WHERE palletNo = @palletNo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //LOGGING THE PALLET OUT AFTER BEING EMPTY
        private void PalletOutLog(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string query = @"UPDATE tbl_palletlogs SET employeeOutName = @employeeOutName, dateOut = @dateOut, timeOut = @timeOut WHERE location = @location AND palletNo = @palletNo AND palletId = @palletId ORDER BY id DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                        cmd.Parameters.AddWithValue("@employeeOutName", UserSession.FullName);
                        cmd.Parameters.AddWithValue("@dateOut", DateTime.Now.ToString("MM-dd-yyyy"));
                        cmd.Parameters.AddWithValue("@timeOut", DateTime.Now.ToString("HH:mm"));

                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);
                        cmd.Parameters.AddWithValue("@palletId", palletId);

                        cmd.ExecuteNonQuery();
                    }
                }catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
