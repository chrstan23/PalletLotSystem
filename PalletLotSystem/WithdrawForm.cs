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
        String connstr = Config.ConnectionString;
        private string palletNo;

        public class PartItem
        {
            public int Slot { get; set; }
            public string PartNo { get; set; }

            public override string ToString()
            {
                return PartNo;
            }
        }

        public WithdrawForm(string palletNo){
            InitializeComponent();
            this.palletNo = palletNo;
            FetchPartNumbers();
        }

        private void FetchPartNumbers(){
            try{
            using (MySqlConnection conn = new MySqlConnection(connstr)){
                conn.Open();

                string query = "SELECT * FROM tbl_pallet WHERE palletNo = @palletNo";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@palletNo", palletNo);

                    using (MySqlDataReader reader = cmd.ExecuteReader()){
                        if (reader.Read()){
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

        private void cmbPartNo_SelectedIndexChanged(object sender, EventArgs e){
            if (cmbPartNo.SelectedItem == null)
                return;

            PartItem item = (PartItem)cmbPartNo.SelectedItem;

            using (MySqlConnection conn = new MySqlConnection(connstr))
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
                txtQty.Focus();
                return;
            }

            PartItem item = (PartItem)cmbPartNo.SelectedItem;
            int currentQty = Convert.ToInt32(lblAvailQty.Text);

            if (withdrawQty <= 0){
                MessageBox.Show("Quantity must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int remainingQty = currentQty - withdrawQty;

            DialogResult result = MessageBox.Show("Are you sure you want to withdraw " + withdrawQty + " pc(s) of " + item.PartNo + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.No){
                return;

            }

            using (MySqlConnection conn = new MySqlConnection(connstr)){
                conn.Open();

                string query;

                if(remainingQty == 0){
                    query = "UPDATE tbl_pallet SET partNo" + item.Slot + " = '', qty" + item.Slot + "= '0' WHERE pallet=@palletNo";
                }else{
                    query = "UPDATE tbl_pallet SET qty" + item.Slot + " =@qty WHERE palletNo=@palletNo";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    if(remainingQty > 0)
                        cmd.Parameters.AddWithValue("@qty", remainingQty);
                    cmd.Parameters.AddWithValue("@palletNo", palletNo);
                    cmd.ExecuteNonQuery();
                    }
                }
            MessageBox.Show("Withdrawal completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FetchPartNumbers();
            txtQty.Clear();

        }
    }
}
