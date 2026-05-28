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
    public partial class UpdateForm : Form{

        String connStr = "Server=localhost; user=root; password=root; database=christian; port=3306";

        private Layout layoutForm;


        public UpdateForm(Layout layout){
            InitializeComponent();

            layoutForm = layout;
        }

        private void btnSave_Click(object sender, EventArgs e){
            string barcode = txtBarcode.Text.Trim();

            if (barcode == ""){
                MessageBox.Show("Please enter Pallet ID.");

                return;
            }
                UpdatePalletStatus(barcode);

        }

        private void UpdatePalletStatus(string palletNo){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string query = "SELECT status FROM tbl_pallet WHERE palletNo = @palletNo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);

                        object result = cmd.ExecuteScalar();

                        if (result != null){
                            string currentStatus = result.ToString();

                            string newStatus = "";

                            if (currentStatus == "EMPTY"){
                                newStatus = "OCCUPIED";
                            }else if (currentStatus == "OCCUPIED"){
                                newStatus = "EMPTY";
                            }

                            string updateQuery = "UPDATE tbl_pallet SET status = @status WHERE palletNo = @palletNo";

                            using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn)){
                                updateCmd.Parameters.AddWithValue("@status", newStatus);
                                updateCmd.Parameters.AddWithValue("@palletNo", palletNo);

                                updateCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Pallet updated successfully!");

                            layoutForm.LoadPalletStatus();

                            txtBarcode.Clear();
                            txtBarcode.Focus();
                        }else{
                            MessageBox.Show("Pallet not found!");
                        }
                    }

                }catch(Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text.Trim();

                if (barcode == "")
                {
                    MessageBox.Show("Please enter Pallet ID.");

                    return;
                }
                UpdatePalletStatus(barcode);

            }
        }


    }
}
