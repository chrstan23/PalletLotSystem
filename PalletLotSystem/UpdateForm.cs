using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem{
    public partial class UpdateForm : Form{

        String connStr = "Server=localhost; user=root; password=root; database=christian; port=3306";

        private Layout layoutForm;

        public UpdateForm(Layout layout, string location){
            InitializeComponent();
            layoutForm = layout;

            LoadPalletData(location);

        }

        private void LoadPalletData(string location)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT * FROM tbl_pallet WHERE location=@location";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@location", location);

                    using(MySqlDataReader reader = cmd.ExecuteReader()){
                        if (reader.Read()){
                            lblPallet.Text = location;
                            txtPalletId.Text = reader["palletId"].ToString();
                            txtPalletNo.Text = reader["palletNo"].ToString();
                        }
                    }
                }
            }
        }

        //VALIDATION FOR THE PALLET NO AND LOCATION
        private bool PalletNoLoc()
        {
            string palletNo = txtPalletNo.Text.Trim();
            string location = lblPallet.Text.Trim();

            if (!palletNo.EndsWith(location))
            {
                MessageBox.Show("Pallet No doesn't match its supposed location!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPalletNo.Clear();
                txtPalletNo.Focus();
                
                return false;
            }
            return true;
        }

        // SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e){
            string palletId = txtPalletId.Text.Trim();
            string palletNo = txtPalletNo.Text.Trim();

            if (palletId == ""){
                MessageBox.Show("Please enter Pallet ID.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if(palletNo == ""){
                MessageBox.Show("Please enter Pallet No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (!PalletNoLoc()){
                return;
            }else{

                PalletNoLoc();
                UpdatePalletStatus();

                this.Close();
            }
        }

        //INSERTING PALLET LOGS
        private void InsertPalletLog(string location, string palletId, string palletNo)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query =  "INSERT INTO tbl_palletlogs (employeeInName, location, palletId, palletNo, dateIn, timeIn) VALUES (@employeeName, @location, @palletId, @palletNo, @dateIn, @timeIn)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@employeeName", UserSession.FullName);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@palletId", palletId);
                    cmd.Parameters.AddWithValue("@palletNo", palletNo);
                    cmd.Parameters.AddWithValue("@dateIn", DateTime.Now.ToString("MM-dd-yyy"));
                    cmd.Parameters.AddWithValue("@timeIn", DateTime.Now.ToString("HH:mm"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // UPDATE LOGIC
        private void UpdatePalletStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // GET DESCRIPTION INPUT
                    string palletId = txtPalletId.Text.Trim();
                    string palletNo = txtPalletNo.Text.Trim();
                    string location = lblPallet.Text;

                    string newStatus = "";

                    // DETERMINE STATUS
                    if (palletId == "")
                    {
                        newStatus = "EMPTY";
                    }
                    else
                    {
                        newStatus = "OCCUPIED";
                    }

                    // UPDATE DATABASE
                    string updateQuery = @"UPDATE tbl_pallet SET palletId = @palletId, palletNo = @palletNo, status = @status WHERE location = @location";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@palletId", palletId);
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@location", location);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            InsertPalletLog(location, palletId, palletNo);

                            MessageBox.Show("Pallet updated successfully!");

                            // REFRESH LAYOUT
                            layoutForm.LoadPalletStatus();

                            txtPalletId.Clear();

                            txtPalletId.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Pallet not found!");
                        }
                    }
                }



                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        // CANCEL
        private void btnCancel_Click(object sender, EventArgs e){
            btnIn.Visible = true;
            btnOut.Visible = true;
            btnCancel2.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            txtPalletId.Enabled = false;
            txtPalletNo.Enabled = false;

        }

        //FOR SCANNING THE BARCODE PALLET ID
        private void txtPalletId_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter){
                //btnSave.PerformClick();
                txtPalletNo.Focus();
            }
        }

        //FOR CHECKING IF BUTTON IS OCCUPIED AND CHANGE THE BUTTON VISIBILITY
        private void btnIn_Click(object sender, EventArgs e){

            if (txtPalletId.Text != ""){
                MessageBox.Show("Pallet is still Occupied", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }else{
                txtPalletId.Enabled = true;
                txtPalletNo.Enabled = true;
                btnSave.Enabled = true;
                txtPalletId.Focus();
                btnIn.Visible = false;
                btnOut.Visible = false;
                btnSave.Visible = true;
                btnCancel2.Visible = false;
                btnCancel.Visible = true;

            }
        }

        private void PalletOutLog()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE tbl_palletlogs SET employeeOutName = @employeeOutName, dateOut = @dateOut, timeOut = @timeOut WHERE location = @location AND palletId = @palletId AND palletNo = @palletNo ORDER BY id DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeOutName", UserSession.FullName);
                        cmd.Parameters.AddWithValue("@dateOut", DateTime.Now.ToString("MM-dd-yyyy"));
                        cmd.Parameters.AddWithValue("@timeOut", DateTime.Now.ToString("HH:mm"));
                        cmd.Parameters.AddWithValue("@location", lblPallet.Text.Trim());
                        cmd.Parameters.AddWithValue("@palletId", txtPalletId.Text.Trim());
                        cmd.Parameters.AddWithValue("@palletNo", txtPalletNo.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
                
            }
        }

        //FUNCTION FOR GETTING THE OUT THE PALLET
        private void ClearPallet(){
            using  (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string updateQuery = @"UPDATE tbl_pallet SET palletId='', status='EMPTY', palletNo='' WHERE location= @location";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn)){
                        cmd.Parameters.AddWithValue("@location", lblPallet.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0){
                            MessageBox.Show("Pallet cleared successfully!");

                            layoutForm.LoadPalletStatus();
                            txtPalletId.Text = "";
                            this.Close();
                        }else{
                            MessageBox.Show("Pallet not found!");
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e){
            if (string.IsNullOrWhiteSpace(txtPalletId.Text)){

                MessageBox.Show("The pallet is still empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to take out this pallet?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No){
                return;
            }

            PalletOutLog();
            ClearPallet();
        }

        private void txtPalletNo_KeyDown(object sender, KeyEventArgs e){

            if (e.KeyCode == Keys.Enter){
                btnSave.PerformClick();
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e){

            this.Close();
        }
    }
}