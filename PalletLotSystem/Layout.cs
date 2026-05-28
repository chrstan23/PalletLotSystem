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
            LoadPalletStatus();

        }
        

        //private void CheckPalletStatus(string palletNo){
        //    using (MySqlConnection conn = new MySqlConnection(connStr)){
        //        try{
        //            conn.Open();

        //            string query = "SELECT status FROM tbl_pallet WHERE palletNo = @palletNo";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn)){
        //                cmd.Parameters.AddWithValue("@palletNo", palletNo);


        //                object result = cmd.ExecuteScalar();

        //                if (result != null){
        //                    string currentStatus = result.ToString();
        //                    string newStatus = "";

        //                    if (currentStatus == "EMPTY"){
        //                        newStatus = "OCCUPIED";
        //                    }else if (currentStatus == "OCCUPIED"){
        //                        newStatus = "EMPTY";
        //                    }

        //                    string updateQuery = "UPDATE tbl_pallet SET status= @status WHERE palletNo = @palletNo";

        //                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn)){
        //                        updateCmd.Parameters.AddWithValue("@status", newStatus);
        //                        updateCmd.Parameters.AddWithValue("@palletNo", palletNo);

        //                        updateCmd.ExecuteNonQuery();

        //                    }
                            
        //                    UpdateBoxColor(palletNo, newStatus);
        //                }else{
        //                    MessageBox.Show("Pallet not Found!", "Error");
        //                }
        //            }

        //        }
        //        catch(Exception ex){
        //            MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void UpdateBoxColor(string palletNo, string status){
            foreach (Control ctrl in this.Controls){
                if (ctrl is Button){
                    Button btn = (Button)ctrl;

                    if (btn.Text == palletNo){
                        if (status == "EMPTY"){
                            btn.BackColor = Color.Red;
                        }else if (status == "OCCUPIED"){
                            btn.BackColor = Color.DeepSkyBlue;
                        }

                        break;
                    }
                }
            }
        }

        public void LoadPalletStatus(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string query = "SELECT * from tbl_pallet";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn)){

                        using (MySqlDataReader reader = cmd.ExecuteReader()){

                            while (reader.Read()){

                                string palletNo = reader["palletNo"].ToString();
                                string status = reader["status"].ToString();

                                UpdateBoxColor(palletNo, status);
                            }
                        }
                    }
                }
                catch(Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e){

            UpdateForm update = new UpdateForm(this);
            //this.Hide();
            //update.Show();
            //update.FormClosed += (s, args) => this.Show();
            update.ShowDialog();
        }
    }
}
