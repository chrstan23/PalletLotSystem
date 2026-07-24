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
    public partial class SearchPartNo : Form{
        string connStr = Config.ConnectionString;

        public SearchPartNo(){
            InitializeComponent();
            LoadPartNumbers();
            ApplyUserPermission();
        }

        private void ApplyUserPermission(){
            if (UserSession.Privilege < 2){
                btnAdd.Visible = true;
            }
        }

        private void SearchPart(){
            string partNo = txtPartNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(partNo)){
                MessageBox.Show("Please enter a Part Number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPartNo.Focus();
                return;
            }
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string query = @"SELECT dateReceived AS `Date Received`, palletNo AS `Pallet Number`, partNo1 AS `PartNumber`, qty1 AS `Quantity`, location AS `Location` FROM tbl_pallet WHERE partNo1 = @partNo
                                        UNION ALL SELECT dateReceived, palletNo, partNo2, qty2, location FROM tbl_pallet WHERE partNo2 = @partNo
                                        UNION ALL SELECT dateReceived, palletNo, partNo3, qty3, location FROM tbl_pallet WHERE partNo3 = @partNo
                                        UNION ALL SELECT dateReceived, palletNo, partNo4, qty4, location FROM tbl_pallet WHERE partNo4 = @partNo
                                        UNION ALL SELECT dateReceived, palletNo, partNo5, qty5, location FROM tbl_pallet WHERE partNo5 = @partNo ORDER BY `Date Received` ASC, `Pallet Number` ASC;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@partNo", partNo);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0){
                            MessageBox.Show("No pallet contains this Part Number.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dgvSearch.DataSource = null;
                            return;
                        }

                        dgvSearch.DataSource = dt;
                        dgvSearch.RowHeadersVisible = false;
                        dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvSearch.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvSearch.ReadOnly = true;
                        dgvSearch.AllowUserToAddRows = false;
                        dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvSearch.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        dgvSearch.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                        dgvSearch.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);


                    }
                }catch (Exception ex){
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void LoadPartNumbers(){
            AutoCompleteStringCollection partList = new AutoCompleteStringCollection();

            using (MySqlConnection conn = new MySqlConnection(connStr)){
                conn.Open();

                string query = "SELECT partNumber FROM tbl_partnumber ORDER BY partNumber";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader()){
                    while (reader.Read()){
                        partList.Add(reader["partNumber"].ToString());
                    }
                }
            }
            
            txtPartNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPartNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPartNo.AutoCompleteCustomSource = partList;

        }

        private void btnBack_Click(object sender, EventArgs e){
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e){
            SearchPart();
        }

        private void btnClear_Click(object sender, EventArgs e){
            txtPartNo.Clear();

            dgvSearch.DataSource = null;
            dgvSearch.Rows.Clear();
            dgvSearch.Columns.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e){
            using(AddPartNo add = new AddPartNo()){
                add.ShowDialog();

            }
            
        }
    }
}
