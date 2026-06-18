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
            ApplyUserPermissions();

        }

        private void ApplyUserPermissions(){
            if (UserSession.Privilege > 2)
            {
                btnIn.Enabled = false;
                btnOut.Enabled = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnCancel2.Enabled = true;
                lblHeader.Text = "VIEW PALLET DETAILS";
            }
        }

        private void LoadPalletData(string location){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                conn.Open();

                string query = "SELECT * FROM tbl_pallet WHERE location=@location";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@location", location);

                    using(MySqlDataReader reader = cmd.ExecuteReader()){
                        if (reader.Read()){
                            lblPallet.Text = location;
                            txtPalletNo.Text = reader["palletNo"].ToString();
                            txtPalletId.Text = reader["palletId"].ToString();
                        }
                    }
                }
            }
        }

        //VALIDATION FOR THE PALLET NO AND LOCATION
        private bool PalletIdLoc(){
            string palletId = txtPalletId.Text.Trim();
            string location = lblPallet.Text.Trim();

            if (!palletId.EndsWith(location)){
                MessageBox.Show("Pallet ID doesn't match its supposed location!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPalletId.Clear();
                txtPalletId.Focus();
                
                return false;
            }
            return true;
        }

        // SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e){
            string palletNo = txtPalletNo.Text.Trim();
            string palletId = txtPalletId.Text.Trim();

            if (palletNo == ""){
                MessageBox.Show("Please enter Pallet No.", "Validation",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPalletNo.Clear();
                txtPalletNo.Focus();
                return;
            }else if(palletId == ""){
                MessageBox.Show("Please enter Pallet ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPalletId.Clear();
                txtPalletId.Focus();
                return;
            }else if (!PalletIdLoc() || !ValidatePalletNo()){
                return;
            }else{

                PalletIdLoc();
                UpdatePalletStatus();

                this.Close();
            }
        }

        //INSERTING PALLET LOGS
        private void InsertPalletLog(string location, string palletNo, string palletId){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                conn.Open();

                string query =  "INSERT INTO tbl_palletlogs (employeeInName, location, palletNo, palletId, dateIn, timeIn) VALUES (@employeeName, @location, @palletNo, @palletId, @dateIn, @timeIn)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@employeeName", UserSession.FullName);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@palletNo", palletNo);
                    cmd.Parameters.AddWithValue("@palletId", palletId);
                    cmd.Parameters.AddWithValue("@dateIn", DateTime.Now.ToString("MM-dd-yyy"));
                    cmd.Parameters.AddWithValue("@timeIn", DateTime.Now.ToString("HH:mm"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // UPDATE LOGIC
        private void UpdatePalletStatus(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                try{
                    conn.Open();

                    // GET DESCRIPTION INPUT
                    string palletNo = txtPalletNo.Text.Trim();
                    string palletId = txtPalletId.Text.Trim();
                    string location = lblPallet.Text;

                    string newStatus = "";

                    // DETERMINE STATUS
                    if (palletNo == ""){
                        newStatus = "EMPTY";
                    }else{
                        newStatus = "OCCUPIED";
                    }

                    // UPDATE DATABASE
                    string updateQuery = @"UPDATE tbl_pallet SET palletNo = @palletNo, palletId = @palletId, status = @status WHERE location = @location";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);
                        cmd.Parameters.AddWithValue("@palletId", palletId);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@location", location);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0){
                            InsertPalletLog(location, palletNo, palletId);

                            MessageBox.Show("Pallet updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // REFRESH LAYOUT
                            layoutForm.LoadPalletStatus();
                            layoutForm.LoadStatistics();

                            txtPalletNo.Clear();

                            txtPalletNo.Focus();

                        }else{
                            MessageBox.Show("Pallet not found!");
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private bool ValidatePalletNo(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                conn.Open();

                string query = "SELECT location FROM tbl_pallet WHERE palletNo = @palletNo AND status = 'OCCUPIED' AND location <> @location";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@palletNo", txtPalletNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@location", lblPallet.Text.Trim());

                    object result = cmd.ExecuteScalar();

                    if (result != null){
                        MessageBox.Show("Pallet No " + txtPalletNo.Text.Trim() + " is already occupied at " + result.ToString(), "Duplicate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPalletNo.Clear();
                        txtPalletNo.Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        // CANCEL
        private void btnCancel_Click(object sender, EventArgs e){
            btnIn.Visible = true;
            btnOut.Visible = true;
            btnCancel2.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            txtPalletNo.Enabled = false;
            txtPalletId.Enabled = false;

        }

        //FOR SCANNING THE BARCODE PALLET ID
        private void txtPalletId_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter){
                btnSave.PerformClick();
                
            }
        }

        //FOR CHECKING IF BUTTON IS OCCUPIED AND CHANGE THE BUTTON VISIBILITY
        private void btnIn_Click(object sender, EventArgs e){

            if (txtPalletNo.Text != ""){
                MessageBox.Show("Pallet is still Occupied", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }else{
                txtPalletNo.Enabled = true;
                txtPalletId.Enabled = true;
                btnSave.Enabled = true;
                txtPalletNo.Focus();
                btnIn.Visible = false;
                btnOut.Visible = false;
                btnSave.Visible = true;
                btnCancel2.Visible = false;
                btnCancel.Visible = true;

            }
        }

        private void PalletOutLog(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                try{
                    conn.Open();

                    string query = "UPDATE tbl_palletlogs SET employeeOutName = @employeeOutName, dateOut = @dateOut, timeOut = @timeOut WHERE location = @location AND palletNo = @palletNo AND palletId = @palletId ORDER BY id DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){

                        cmd.Parameters.AddWithValue("@employeeOutName", UserSession.FullName);
                        cmd.Parameters.AddWithValue("@dateOut", DateTime.Now.ToString("MM-dd-yyyy"));
                        cmd.Parameters.AddWithValue("@timeOut", DateTime.Now.ToString("HH:mm"));
                        cmd.Parameters.AddWithValue("@location", lblPallet.Text.Trim());
                        cmd.Parameters.AddWithValue("@palletNo", txtPalletNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@palletId", txtPalletId.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        //FUNCTION FOR GETTING THE OUT THE PALLET
        private void ClearPallet(){
            using  (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string updateQuery = @"UPDATE tbl_pallet SET palletNo='', status='EMPTY', palletId='' WHERE location= @location";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn)){
                        cmd.Parameters.AddWithValue("@location", lblPallet.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0){
                            MessageBox.Show("Pallet cleared successfully!");

                            layoutForm.LoadStatistics();
                            layoutForm.LoadPalletStatus();
                            txtPalletNo.Text = "";
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
            if (string.IsNullOrWhiteSpace(txtPalletNo.Text)){

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
                txtPalletId.Focus();
                txtPalletId.SelectAll();
                ValidatePalletNo();
            }
        }

        private void btnCancel2_Click(object sender, EventArgs e){

            this.Close();
        }
    }
}