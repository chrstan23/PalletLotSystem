using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PalletLotSystem{
    public partial class Layout : Form{
        String connStr = Config.ConnectionString;

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

        //DISPLAY STATISTICS OF PALLETS
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
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //  DISPLAYING PALLETID TO BUTTON
        private string GetButtonDisplayText(string palletNo){
            if (string.IsNullOrWhiteSpace(palletNo))
                return "";

            palletNo = palletNo.Trim();

            if (palletNo.StartsWith("P-"))
            {
                return "P-\r\n" + palletNo.Substring(2);
            }

            return palletNo;
        }

        // LOAD FROM DATABASE
        public void LoadPalletStatus(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                try{
                    conn.Open();

                    string query = "SELECT location, palletNo, status, palletId FROM tbl_pallet";

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
                    MessageBox.Show("Database Error: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        // OPEN UPDATE FORM
        private void PalletButton_Click(object sender, EventArgs e){

            Button btn = (Button)sender;
            UpdateForm update = new UpdateForm(this, btn.Name);
            update.ShowDialog();
            LoadPalletStatus();
            LoadStatistics();
        }

        private void RegisterPalletButtons(){
            const string palletRows = "ABCDEFG";

            foreach (Control ctrl in this.Controls){
                Button btn = ctrl as Button;

                if (btn != null && palletRows.Contains(btn.Name[0].ToString())){
                    btn.Click += PalletButton_Click;

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

        }

        private void btnSearch_Click(object sender, EventArgs e){
            using (SearchPartNo search = new SearchPartNo()){
                search.ShowDialog();
            }            
        }

        private void Layout_Load(object sender, EventArgs e)
        {

        }
    }
}