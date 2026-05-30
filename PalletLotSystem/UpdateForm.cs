using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem
{
    public partial class UpdateForm : Form
    {
        String connStr = "Server=localhost; user=root; password=root; database=christian; port=3306";

        private Layout layoutForm;

        public UpdateForm(Layout layout)
        {
            InitializeComponent();
            layoutForm = layout;
        }

        // SAVE BUTTON
        private void btnSave_Click(object sender, EventArgs e)
        {
            string palletNo = txtBarcode.Text.Trim();

            if (palletNo == "")
            {
                MessageBox.Show("Please enter Pallet ID.");
                return;
            }

            UpdatePalletStatus(palletNo);
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

                    string updateQuery = @"UPDATE tbl_pallet SET description = @description, status = @status WHERE palletNo = @palletNo";

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

                            txtBarcode.Clear();
                            txtPalletId.Clear();

                            txtBarcode.Focus();
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

        // ENTER KEY SUPPORT
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        // CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}