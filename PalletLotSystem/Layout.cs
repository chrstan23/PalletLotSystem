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
        private void UpdateBoxColor(string location, string palletId, string status)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;

                    if (btn.Name == location)
                    {
                        btn.Text = GetButtonDisplayText(palletId);
                        btn.Tag = palletId;

                        if (status == "EMPTY")
                        {
                            btn.BackColor = Color.Lime;
                        }
                        else if (status == "OCCUPIED")
                        {
                            btn.BackColor = Color.Orange;
                        }

                        break;
                    }
                }
            }
        }

        //  DISPLAYING PALLETID TO BUTTON
        private string GetButtonDisplayText(string palletId)
        {
            if (string.IsNullOrWhiteSpace(palletId))
                return "";

            return palletId.Trim();
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
                            string location = reader["location"].ToString();
                            string palletId = reader["palletId"].ToString();
                            string status = reader["status"].ToString();

                            UpdateBoxColor(location, palletId, status);
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

            string location = btn.Name;
            string palletId = "";

            if (btn.Tag != null)
            {
                palletId = btn.Tag.ToString();
            }

            UpdateForm update = new UpdateForm(this, location, palletId);

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