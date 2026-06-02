using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem
{
    public partial class Layout : Form
    {
        String connStr = "server=localhost; user=root; password=root; database=christian; port=3306";

        public Layout()
        {
            InitializeComponent();
            LoadPalletStatus();
            RegisterPalletButtons();
        }

        // CHANGE COLOR USING BUTTON NAME
        private void UpdateBoxColor(string palletNo, string description, string status)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;

                    if (btn.Name == palletNo)
                    {
                        btn.Text = GetButtonDisplayText(description);

                        if (status == "EMPTY")
                        {
                            btn.BackColor = Color.Red;
                        }
                        else if (status == "OCCUPIED")
                        {
                            btn.BackColor = Color.DeepSkyBlue;
                        }

                        break;
                    }
                }
            }
        }

        // FETCHING THE LAST WORD FOR PALLET DESCRIPTION
        private string GetButtonDisplayText(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return "";

            string[] words = description
                .Trim()
                .Split(
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries
                );

            return words[words.Length - 1];
        }

        // LOAD FROM DATABASE
        public void LoadPalletStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT * FROM tbl_pallet";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string palletNo = reader["palletNo"].ToString();
                            string description = reader["description"].ToString();
                            string status = reader["status"].ToString();

                            UpdateBoxColor(palletNo, description, status);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Database Error: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // OPEN UPDATE FORM
        

        private void PalletButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string palletNo = btn.Name;

            UpdateForm update = new UpdateForm(this, palletNo);

            update.ShowDialog();
        }

        private void RegisterPalletButtons()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;

                    if (btn.Name.StartsWith("A"))
                    {
                        btn.Click += PalletButton_Click;
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}