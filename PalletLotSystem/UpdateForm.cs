using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem
{
    public partial class UpdateForm : Form
    {
        String connStr = "Server=localhost; user=root; password=root; database=christian; port=3306";

        private Layout layoutForm;

        public UpdateForm(Layout layout, string palletNo)
        {
            InitializeComponent();
            layoutForm = layout;

            lblPallet.Text = palletNo;
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

                    string lastWord = GetLastWord(description);

                    if (description != "" && !lastWord.Equals(palletNo, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Pallet Id does not Match! Please enter correct Pallet Id.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
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
                }

                    
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private string GetLastWord(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            string[] words = text.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return words[words.Length - 1];
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
    }
}