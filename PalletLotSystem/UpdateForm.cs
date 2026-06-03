using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem
{
    public partial class UpdateForm : Form
    {
        String connStr = "Server=localhost; user=root; password=root; database=christian; port=3306";

        private Layout layoutForm;

        public UpdateForm(Layout layout, string palletNo, string description)
        {
            InitializeComponent();
            layoutForm = layout;

            lblPallet.Text = palletNo;
            txtPalletId.Text = description;

        }

        // SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            string palletNo = lblPallet.Text.Trim();

            if (palletNo == "")
            {
                MessageBox.Show("Please enter Pallet ID.");
                return;
            }
            else
            {
                UpdatePalletStatus(palletNo);

                this.Close();
            }

            
        }

        // UPDATE LOGIC
        private void UpdatePalletStatus(string palletNo)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                        // GET DESCRIPTION INPUT
                    string description = txtPalletId.Text.Trim();
                      
                    string newStatus = "";

                    // DETERMINE STATUS
                    if (description == "")
                    {
                        newStatus = "EMPTY";
                    }
                    else
                    {
                        newStatus = "OCCUPIED";
                    }

                    // UPDATE DATABASE
                    string updateQuery =
                        @"UPDATE tbl_pallet
                        SET description = @description,
                            status = @status
                        WHERE palletNo = @palletNo";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //FOR SCANNING THE BARCODE PALLET ID
        private void txtPalletId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtPalletId.Enabled = true;
            txtPalletId.Focus();
        }

        private void ClearPallet(){
            using  (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string updateQuery = @"UPDATE tbl_pallet SET description='', status='EMPTY' WHERE palletNo= @palletNo";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@palletNo", lblPallet.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Pallet cleared successfully!");

                            layoutForm.LoadPalletStatus();
                            txtPalletId.Text = "";
                            this.Close();
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

        private void btnClearPallet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPalletId.Text))
            {
                MessageBox.Show("The pallet is still empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to clear this pallet?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            ClearPallet();
        }
    }
}