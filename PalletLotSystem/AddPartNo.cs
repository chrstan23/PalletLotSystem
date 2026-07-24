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
    public partial class AddPartNo : Form{
        String connStr = Config.ConnectionString;

        public AddPartNo(){
            InitializeComponent();
        }

        private void Add(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string partNo = txtPartNo.Text.Trim().ToUpper();
                    string checkQuery = "SELECT COUNT(*) FROM tbl_partnumber WHERE partNumber = @partNo";

                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn)){
                        checkCmd.Parameters.AddWithValue("@partNo", partNo);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0){
                            MessageBox.Show("Part Number already exists. ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            txtPartNo.Clear();
                            txtPartNo.Focus();
                        }else{

                            DialogResult result = MessageBox.Show("Are you sure with the new Part Number details?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if(result == DialogResult.No){
                                return;

                            }


                            string query = "INSERT INTO tbl_partnumber (partNumber) VALUES (@partNo)";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                                cmd.Parameters.AddWithValue("@partNo", partNo);

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Part Number has been added.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPartNo.Text)){
                MessageBox.Show("Please enter Part Number!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartNo.Clear();
                txtPartNo.Focus();
                return;
            }
                Add();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
