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

namespace PalletLotSystem
{
    public partial class Layout : Form{
        String connStr = "server=localhost; user=root; password=root; database=christian; port=3306";

        public Layout(){
            InitializeComponent();

        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter){
                string barcode = txtBarcode.Text.Trim();
                CheckPalletStatus(barcode);
                txtBarcode.Text = "";
                e.SuppressKeyPress = true;
            }

        }

        private void CheckPalletStatus(string palletNo){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string query = "SELECT status FROM tbl_pallet WHERE palletNo = @palletNo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                        cmd.Parameters.AddWithValue("@palletNo", palletNo);


                        object result = cmd.ExecuteScalar();

                        if (result != null){
                            string status = result.ToString();
                            UpdateBoxColor(@palletNo, status);
                        }else{
                            MessageBox.Show("Pallet not Found!", "Error");
                        }
                    }

                }
                catch(Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateBoxColor(string palletNo, string status){
            foreach (Control ctrl in this.Controls){
                if (ctrl is Button){
                    Button btn = (Button)ctrl;

                    if (btn.Text == palletNo){
                        if (status == "EMPTY"){
                            btn.BackColor = Color.Red;
                        }else if (status == "OCCUPIED"){
                            btn.BackColor = Color.Green;
                        }

                        break;
                    }
                }
            }
        }
    }
}
