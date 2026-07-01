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
    public partial class WithdrawForm : Form{
        String connstr = Config.ConnectionString;
        public WithdrawForm(){
            InitializeComponent();
        }

        private void FetchPartNumbers(){
            using (MySqlConnection conn = new MySqlConnection(connstr)){
                conn.Open();

                string query = "SELECT * FROM tbl_pallet WHERE location = @location";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)){
                    cmd.Parameters.AddWithValue("@location", lblPalletNo);

                    using (MySqlDataReader reader = cmd.ExecuteReader()){
                        if (reader.Read()){
                            cmbPartNo.Items.Clear();

                            for (int i = 0; i < 5; i++){
                                string partNo = reader["partNo" + i].ToString();

                                if (!string.IsNullOrWhiteSpace(partNo)){
                                    cmbPartNo.Items.Add(partNo);
                                }
                            }
                        }
                    }
                }
                
            }

            if (cmbPartNo.Items.Count > 0)
                cmbPartNo.SelectedIndex = 0;
        }

        private void WithdrawForm_Load(object sender, EventArgs e)
        {

        }
    }
}
