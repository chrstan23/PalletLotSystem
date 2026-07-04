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
    public partial class PalletLogs : Form{
        String connStr = Config.ConnectionString;

        public PalletLogs(){
            InitializeComponent();

            DisplayPalletLogs();

            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
        }

        //DISPLATING ALL PALLET LOGS ON TBL_PALLETLOGS
        private void DisplayPalletLogs(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                try{
                    conn.Open();

                    string query = "SELECT employeeInName AS `Employee In`, location AS `Pallet Location`, palletId AS `Pallet ID`, palletNo AS `Pallet No.`, partNo1 AS `Part No. 1`, qty1 AS `Quantity 1`, partNo2 AS `Part No. 2`, qty2 AS `Quantity 2`, partNo3 AS `Part No. 3`, qty3 AS `Quantity 3`, partNo4 AS `Part No. 4`, qty4 AS `Quantity 4`, partNo5 AS `Part No. 5`, qty5 AS `Quantity 5`, dateIn AS `Date In`, timeIn AS `Time In`, employeeOutName AS `Employee Out`, dateOut AS `Date Out`, timeOut AS `Time Out` FROM tbl_palletlogs ORDER BY id DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPalletLogs.DataSource = dt;
                    dgvPalletLogs.RowHeadersVisible = false;
                    dgvPalletLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvPalletLogs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPalletLogs.Columns["Employee In"].FillWeight = 130;
                    dgvPalletLogs.Columns["Pallet ID"].FillWeight = 220;
                    dgvPalletLogs.Columns["Pallet Location"].FillWeight = 130;
                    dgvPalletLogs.Columns["Employee Out"].FillWeight = 130;
                    dgvPalletLogs.ReadOnly = true;
                    dgvPalletLogs.AllowUserToAddRows = false;
                    dgvPalletLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPalletLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    dgvPalletLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                    dgvPalletLogs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
                    dgvPalletLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    dgvPalletLogs.GridColor = Color.LightGray;
                    dgvPalletLogs.CellFormatting += dgvPalletLogs_CellFormatting;

                }catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //FILTER THE PALLET LOGS DEPENDING ON THE DATE IN
        private void FilterPalletLogs(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){
                try{
                    conn.Open();

                    string fromDate = dtpFrom.Value.ToString("MM-dd-yyyy");
                    string toDate = dtpTo.Value.ToString("MM-dd-yyyy");
                    string query = "SELECT employeeInName AS `Employee In`, location AS `Pallet Location`, palletId AS `Pallet ID`, palletNo AS `Pallet No.`, partNo1 AS `Part No. 1`, qty1 AS `Quantity 1`, partNo2 AS `Part No. 2`, qty2 AS `Quantity 2`, partNo3 AS `Part No. 3`, qty3 AS `Quantity 3`, partNo4 AS `Part No. 4`, qty4 AS `Quantity 4`, partNo5 AS `Part No. 5`, qty5 AS `Quantity 5`, dateIn AS `Date In`, timeIn AS `Time In`, employeeOutName AS `Employee Out`, dateOut AS `Date Out`, timeOut AS `Time Out` FROM tbl_palletlogs WHERE STR_TO_DATE(dateIn, '%m-%d-%Y') BETWEEN STR_TO_DATE(@fromDate, '%m-%d-%Y') AND STR_TO_DATE(@toDate, '%m-%d-%Y') ORDER BY id DESC";

                    using(MySqlDataAdapter da = new MySqlDataAdapter(query, conn)){
                        da.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
                        da.SelectCommand.Parameters.AddWithValue("@toDate", toDate);

                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        dgvPalletLogs.DataSource = dt;

                    }
                }
                catch (Exception ex){
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e){
            if (dtpFrom.Value.Date > dtpTo.Value.Date){
                MessageBox.Show("1st Date cannot be later that 2nd Date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            FilterPalletLogs();
        }

        private void btnClear_Click(object sender, EventArgs e){
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;

            DisplayPalletLogs();
        }


        //EXPORTING THE DISPLAYED DATA ON DGV
        private void ExportToCsv(){
            try{
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "CSV File (*.csv) | *.csv";
                sfd.FileName = "PalletLogs_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder sb = new StringBuilder();

                for(int i = 0; i < dgvPalletLogs.Columns.Count; i++){
                    sb.Append(dgvPalletLogs.Columns[i].HeaderText);

                    if (i < dgvPalletLogs.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();

                foreach (DataGridViewRow row in dgvPalletLogs.Rows){
                    if (row.IsNewRow)
                        continue;
                    for (int i = 0; i < dgvPalletLogs.Columns.Count; i++){
                        string value = "";

                        if(row.Cells[i].Value != null)
                            value = row.Cells[i].Value.ToString();

                        value = "\"" + value.Replace("\"", "\"\"") + "\"";

                        sb.Append(value);

                        if (i < dgvPalletLogs.Columns.Count - 1)
                            sb.Append(",");
                    }

                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show("CSV Exported Successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch (Exception ex){
                MessageBox.Show("Export error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e){
            DialogResult result = MessageBox.Show("Are you sure you want to export this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes){
            ExportToCsv();

            }else{
                return;
            }

        }

        //REMOVING 0 VALUE ON THE DGV
        private void dgvPalletLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e){
            string columnName = dgvPalletLogs.Columns[e.ColumnIndex].Name;

            if (columnName.StartsWith("Quantity")){
                if (e.Value != null && e.Value.ToString() == "0"){
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e){
            this.Close();
        }

        
    }
}
