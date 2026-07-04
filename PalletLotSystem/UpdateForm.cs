using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem{
    public partial class UpdateForm : Form{

        String connStr = Config.ConnectionString;

        private Layout layoutForm;

        private TextBox[] partNos;
        private TextBox[] qtys;

        public UpdateForm(Layout layout, string location){
            InitializeComponent();
            layoutForm = layout;

            partNos = new TextBox[] { txtPartNumber1, txtPartNumber2, txtPartNumber3, txtPartNumber4, txtPartNumber5 };
            qtys = new TextBox[] { txtQty1, txtQty2, txtQty3, txtQty4, txtQty5 };

            LoadPalletData(location);
            ApplyUserPermissions();

        }

        private void ApplyUserPermissions(){
            if (UserSession.Privilege > 2)
            {
                btnIn.Enabled = false;
                btnWithdraw.Enabled = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;
                btnCancel2.Enabled = true;
                lblHeader.Text = "VIEW PALLET DETAILS";
            }
        }

        //DISPLAY PALLET DETAILS IF THE PALLET IS OCCUPIED
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
                            for (int i = 0; i < partNos.Length; i++){
                                partNos[i].Text = reader["partNo" + (i + 1)].ToString();

                                int qty = Convert.ToInt32(reader["qty" + (i + 1)]);

                                qtys[i].Text = qty == 0 ? "" : qty.ToString();
                            }
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

        private bool ValidatePartNumbers()
        {
            // First Part Number and Quantity are required
            if (string.IsNullOrWhiteSpace(txtPartNumber1.Text) ||
                string.IsNullOrWhiteSpace(txtQty1.Text))
            {
                MessageBox.Show(
                    "Please enter at least one Part Number and Quantity.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(txtPartNumber1.Text))
                    txtPartNumber1.Focus();
                else
                    txtQty1.Focus();

                return false;
            }

            // Validate all Part Number / Quantity pairs
            for (int i = 0; i < partNos.Length; i++)
            {
                string partNo = partNos[i].Text.Trim();
                string qty = qtys[i].Text.Trim();

                // Part Number entered but Quantity is empty
                if (!string.IsNullOrWhiteSpace(partNo) &&
                    string.IsNullOrWhiteSpace(qty))
                {
                    MessageBox.Show(
                        "Please enter the quantity for Part Number " + (i + 1) + ".",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    qtys[i].Focus();
                    return false;
                }

                // Quantity entered but Part Number is empty
                if (string.IsNullOrWhiteSpace(partNo) &&
                    !string.IsNullOrWhiteSpace(qty))
                {
                    MessageBox.Show(
                        "Please enter the Part Number for Quantity " + (i + 1) + ".",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    partNos[i].Focus();
                    return false;
                }

                // If Quantity is entered, it must be numeric
                if (!string.IsNullOrWhiteSpace(qty))
                {
                    int number;

                    if (!int.TryParse(qty, out number))
                    {
                        MessageBox.Show(
                            "Quantity " + (i + 1) + " must contain numbers only.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        qtys[i].SelectAll();
                        qtys[i].Focus();
                        return false;
                    }

                    // Quantity must be greater than zero
                    if (number <= 0)
                    {
                        MessageBox.Show(
                            "Quantity " + (i + 1) + " must be greater than zero.",
                            "Validation",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        qtys[i].SelectAll();
                        qtys[i].Focus();
                        return false;
                    }
                }
            }

            // All validations passed
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
            }else if(!ValidatePartNumbers()){
                return;
            }else{

                DialogResult result = MessageBox.Show("Are you sure with the details of the Pallet?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No){
                    return;
                }
                PalletIdLoc();
                UpdatePalletStatus();

                this.Close();
            }
        }

        //INSERTING PALLET LOGS AFTER SUCCESSFUL IN
        private void InsertPalletLog(string location, string palletNo, string palletId){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                conn.Open();

                string query = "INSERT INTO tbl_palletlogs (employeeInName, location, palletNo, palletId, partNo1, qty1, partNo2, qty2, partNo3, qty3, partNo4, qty4, partNo5, qty5, dateIn, timeIn) VALUES (@employeeName, @location, @palletNo, @palletId, @partNo1, @qty1, @partNo2, @qty2, @partNo3, @qty3, @partNo4, @qty4, @partNo5, @qty5, @dateIn, @timeIn)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@employeeName", UserSession.FullName);
                    cmd.Parameters.AddWithValue("@location", location);
                    cmd.Parameters.AddWithValue("@palletNo", palletNo);
                    cmd.Parameters.AddWithValue("@palletId", palletId);

                    for (int i = 0; i < partNos.Length; i++){
                        cmd.Parameters.AddWithValue("@partNo" + (i + 1), partNos[i].Text.Trim());

                        int qty;
                        if (int.TryParse(qtys[i].Text.Trim(), out qty))
                            cmd.Parameters.AddWithValue("@qty" + (i + 1), qty);
                        else
                            cmd.Parameters.AddWithValue("@qty" + (i + 1), 0);
                    }
                        cmd.Parameters.AddWithValue("@dateIn", DateTime.Now.ToString("MM-dd-yyy"));
                    cmd.Parameters.AddWithValue("@timeIn", DateTime.Now.ToString("HH:mm"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // UPDATE PALLET DETAILS IF BEING OCCUPIED
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
                    string updateQuery = @"UPDATE tbl_pallet SET palletNo = @palletNo, palletId = @palletId, status = @status, partNo1 = @partNo1, qty1 = @qty1, partNo2 = @partNo2, qty2 = @qty2, partNo3 = @partNo3, qty3 = @qty3, partNo4 = @partNo4, qty4 = @qty4, partNo5 = @partNo5, qty5 = @qty5 WHERE location = @location";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);
                        cmd.Parameters.AddWithValue("@palletId", palletId);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@location", location);
                        for (int i = 0; i < partNos.Length; i++){
                            cmd.Parameters.AddWithValue("@partNo" + (i + 1), partNos[i].Text.Trim());
                            cmd.Parameters.AddWithValue("@qty" + (i + 1), qtys[i].Text.Trim());                            
                        }

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
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnWithdraw.Visible = true;
            btnCancel2.Visible = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            txtPalletNo.Enabled = false;
            txtPalletId.Enabled = false;
            txtPartNumber1.Enabled = false;
            txtPartNumber2.Enabled = false;
            txtPartNumber3.Enabled = false;
            txtPartNumber4.Enabled = false;
            txtPartNumber5.Enabled = false;
            txtQty1.Enabled = false;
            txtQty2.Enabled = false;
            txtQty3.Enabled = false;
            txtQty4.Enabled = false;
            txtQty5.Enabled = false;
            btnSave.Enabled = false;
            txtPalletNo.Text = "";
            txtPalletId.Text = "";
            txtPartNumber1.Text = "";
            txtPartNumber2.Text = "";
            txtPartNumber3.Text = "";
            txtPartNumber4.Text = "";
            txtPartNumber5.Text = "";
            txtQty1.Text = "";
            txtQty2.Text = "";
            txtQty3.Text = "";
            txtQty4.Text = "";
            txtQty5.Text = "";

        }

        //FOR SCANNING THE BARCODE PALLET ID
        private void txtPalletId_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter){
                txtPartNumber1.Focus();
                
            }
        }

        //FOR CHECKING IF BUTTON IS OCCUPIED AND CHANGE THE BUTTON VISIBILITY
        private void btnIn_Click(object sender, EventArgs e){

            if (txtPalletNo.Text != ""){
                MessageBox.Show("Pallet is still Occupied", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }else{
                txtPalletNo.Enabled = true;
                txtPalletId.Enabled = true;
                txtPartNumber1.Enabled = true;
                txtPartNumber2.Enabled = true;
                txtPartNumber3.Enabled = true;
                txtPartNumber4.Enabled = true;
                txtPartNumber5.Enabled = true;
                txtQty1.Enabled = true;
                txtQty2.Enabled = true;
                txtQty3.Enabled = true;
                txtQty4.Enabled = true;
                txtQty5.Enabled = true;
                btnSave.Enabled = true;
                txtPalletNo.Focus();
                btnIn.Visible = false;
                btnWithdraw.Visible = false;
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
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Pallet cleared successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            layoutForm.LoadStatistics();
                            layoutForm.LoadPalletStatus();
                            txtPalletNo.Text = "";
                            this.Close();
                        }else{
                            MessageBox.Show("Pallet not found!");
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnWithdraw_Click(object sender, EventArgs e){
            if (string.IsNullOrWhiteSpace(txtPalletNo.Text))
            {

                MessageBox.Show("The pallet is still empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            WithdrawForm withdraw = new WithdrawForm(txtPalletNo.Text.Trim());

            withdraw.ShowDialog();
            LoadPalletData(lblPallet.Text);

        }
    }
}