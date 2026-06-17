using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem{
    public partial class Layout : Form{
        String connStr = "server=localhost; user=root; password=root; database=christian; port=3306";

        public Layout(){
            InitializeComponent();
            LoadPalletStatus();
            LoadStatistics();
            RegisterPalletButtons();
            lblUsername.Text = UserSession.FullName;
            LayoutDesign();
        }

        // CHANGE COLOR USING BUTTON NAME
        private void UpdatePallet(string location, string palletNo, string palletId, string status){
            foreach (Control ctrl in this.Controls){
                if (ctrl is Button){
                    Button btn = (Button)ctrl;

                    if (btn.Name == location){
                        btn.Text = GetButtonDisplayText(palletNo);
                        break;
                    }
                }
            }
        }

        public void LoadStatistics(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    int total = 0;
                    int occupied = 0;
                    int empty = 0;

                    string query = "SELECT COUNT(*) AS TotalPallets, SUM(CASE WHEN `status` = 'OCCUPIED' THEN 1 ELSE 0 END) AS OccupiedPallets, SUM(CASE WHEN `status` = 'EMPTY' THEN 1 ELSE 0 END) AS EmptyPallets FROM tbl_pallet";

                    using(MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader()){
                        if (reader.Read()){
                            total = Convert.ToInt32(reader["TotalPallets"]);
                            occupied = Convert.ToInt32(reader["OccupiedPallets"]);
                            empty = Convert.ToInt32(reader["EmptyPallets"]);
                        }
                    }

                    double utilization = 0;
                    if (total > 0){
                        utilization = ((double)occupied / total) * 100;
                    }

                    lblTotalPallets.Text = total.ToString();
                    lblOccupiedPallets.Text = occupied.ToString();
                    lblEmptyPallets.Text = empty.ToString();
                    lblUtilizationPallets.Text = (utilization.ToString("0.00") + "%");

                }
                catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        //  DISPLAYING PALLETID TO BUTTON
        private string GetButtonDisplayText(string palletNo){
            if (string.IsNullOrWhiteSpace(palletNo))
                return "";

            return palletNo.Trim();
        }

        // LOAD FROM DATABASE
        public void LoadPalletStatus(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                try{
                    conn.Open();

                    string query = "SELECT * FROM tbl_pallet";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader()){
                        while (reader.Read()){
                            string location = reader["location"].ToString();
                            string palletNo = reader["palletNo"].ToString();
                            string palletId = reader["palletId"].ToString();
                            string status = reader["status"].ToString();

                            UpdatePallet(location, palletNo, palletId, status);
                        }
                    }
                }catch (Exception ex){
                    MessageBox.Show(
                        "Database Error: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        // OPEN UPDATE FORM
        private void PalletButton_Click(object sender, EventArgs e){

            Button btn = (Button)sender;
            UpdateForm update = new UpdateForm(this, btn.Name);
            update.ShowDialog();
        }

        private void RegisterPalletButtons(){
            foreach (Control ctrl in this.Controls){
                if (ctrl is Button){
                    Button btn = (Button)ctrl;

                    if (btn.Name.StartsWith("A")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(204, 255, 153);

                    }else if (btn.Name.StartsWith("B")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(202, 237, 251);

                    }else if (btn.Name.StartsWith("C")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(202, 237, 251);

                    }else if (btn.Name.StartsWith("D")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(131, 204, 235);

                    }else if (btn.Name.StartsWith("E")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(131, 204, 251);

                    }else if (btn.Name.StartsWith("F")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(71, 211, 89);

                    }else if (btn.Name.StartsWith("G")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(71, 211, 89);

                    }else if (btn.Name.StartsWith("H")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(255, 255, 255);

                    }else if (btn.Name.StartsWith("I")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(255, 255, 255);

                    }else if (btn.Name.StartsWith("J")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(255, 255, 255);

                    }else if (btn.Name.StartsWith("K")){
                        btn.Click += PalletButton_Click;
                        btn.UseVisualStyleBackColor = false;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.BackColor = Color.FromArgb(255, 255, 255);

                    }
                }
            }
        }
        
        private void btnBack_Click(object sender, EventArgs e){
            this.Close();
        }

        private void LayoutDesign(){
            this.pnlOccupied.BackColor = Color.FromArgb(189, 252, 185);
            this.lblOccupiedPallets.ForeColor = Color.FromArgb(23, 129, 15);

            this.pnlEmpty.BackColor = Color.FromArgb(173, 216, 250);
            this.lblEmptyPallets.ForeColor = Color.FromArgb(1, 17, 236);

            this.pnlTotal.BackColor = Color.FromArgb(249, 203, 134);
            this.lblTotalPallets.ForeColor = Color.FromArgb(255, 137, 0);

            this.pnlUtilization.BackColor = Color.FromArgb(220, 220, 220);

            this.pnlAA.BackColor = Color.FromArgb(211, 211, 211);
            this.pnlBC.BackColor = Color.FromArgb(211, 211, 211);
            this.pnlDE.BackColor = Color.FromArgb(211, 211, 211);
            this.pnlFG.BackColor = Color.FromArgb(211, 211, 211);
            this.pnlHI.BackColor = Color.FromArgb(211, 211, 211);
            this.pnlJK.BackColor = Color.FromArgb(211, 211, 211);
            this.pnlBlock1.BackColor = Color.FromArgb(211, 211, 211);
            this.pnlBlock2.BackColor = Color.FromArgb(211, 211, 211);
        }

        private void Layout_Load(object sender, EventArgs e)
        {

        }
    }
}