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
using System.IO;

namespace PalletLotSystem{
    public partial class PartsLog : Form{
        String connStr = Config.ConnectionString;

        public PartsLog(){
            InitializeComponent();
            DisplayPartLogs();
        }

        //DISPLAYING LOGS OF WITHDRAWN PARTNUMBERS
        private void DisplayPartLogs(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                try{
                    conn.Open();

                    string query = "SELECT palletNo AS `Pallet No`, palletId AS `Pallet Id`, location AS `Location`, partNo AS `Part No`, withdrawQty AS `Withdraw Quantity`, remainingQty AS `Remaining Quantity`, employeeName AS `Employee Name`, dateWithdraw AS `Date Withdrawn`, timeWithdraw AS `Time Withdrawn` FROM tbl_partlogs ORDER BY id DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPartLogs.DataSource = dt;
                    dgvPartLogs.RowHeadersVisible = false;
                    dgvPartLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPartLogs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPartLogs.ReadOnly = true;
                    dgvPartLogs.AllowUserToAddRows = false;
                    dgvPartLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPartLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    dgvPartLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                    dgvPartLogs.DefaultCellStyle.ForeColor = Color.Black;
                    dgvPartLogs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                    dgvPartLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    dgvPartLogs.GridColor = Color.LightGray;

                }catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //FILTERING PARTNUMBER LOGS USING PALLETNO
        private void FilterPartLogs(){
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string palletNo = txtPalletNo.Text.Trim();
                    string query = @"SELECT palletNo AS `Pallet No`, palletId AS `Pallet Id`, location AS `Location`, partNo AS `Part No`, withdrawQty AS `Withdraw Quantity`, remainingQty AS `Remaining Quantity`, employeeName AS `Employee Name`, dateWithdraw AS `Date Withdrawn`, timeWithdraw AS `Time Withdrawn` FROM tbl_partlogs WHERE palletNo = @palletNo ORDER BY id DESC";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@palletNo", palletNo);

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvPartLogs.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //EXPORTING DATA DISPLAYED ON DGV
        private void ExportPartLogsToCSV(){
            if (dgvPartLogs.Rows.Count == 0){
                MessageBox.Show("There is no data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = "PartLogs_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK){
                try{
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8)){
                        
                        for (int i = 0; i < dgvPartLogs.Columns.Count; i++){
                            sw.Write("\"" + dgvPartLogs.Columns[i].HeaderText + "\"");

                            if (i < dgvPartLogs.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.WriteLine();

                        
                        foreach (DataGridViewRow row in dgvPartLogs.Rows){
                            if (row.IsNewRow)
                                continue;

                            for (int i = 0; i < dgvPartLogs.Columns.Count; i++){
                                string value = "";

                                if (row.Cells[i].Value != null)
                                    value = row.Cells[i].Value.ToString().Replace("\"", "\"\"");

                                sw.Write("\"" + value + "\"");

                                if (i < dgvPartLogs.Columns.Count - 1)
                                    sw.Write(",");
                            }

                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("Part logs exported successfully!",
                        "Export Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }catch (Exception ex){
                    MessageBox.Show("Export failed: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        //TRIGGER OF FILTERING PARTNUMBERS
        private void btnFilter_Click(object sender, EventArgs e){
            FilterPartLogs();
            txtPalletNo.Clear();

        }

        private void btnBack_Click(object sender, EventArgs e){
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e){
            DisplayPartLogs();
        }

        private void btnExport_Click(object sender, EventArgs e){
            ExportPartLogsToCSV();
        }
    }
}
