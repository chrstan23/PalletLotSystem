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
    public partial class Login : Form{
        String connStr = "server=localhost; user=root; password=root; database=christian; port=3306";

        public Login(){
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e){
            if(e.KeyCode == Keys.Enter){
                LoginFunc();
            }
        }

        public void LoginFunc()
        {
            string password = txtPassword.Text;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM tbl_users WHERE companyId=@companyId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@companyId", password);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        UserSession.FullName = reader["fullName"].ToString();
                        UserSession.CompanyId = reader["companyId"].ToString();

                        MessageBox.Show("Login Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Text = "";

                        LandingPage landing = new LandingPage();
                        this.Hide();
                        landing.Show();
                        landing.FormClosed += (s, args) => this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Text =  "";

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
