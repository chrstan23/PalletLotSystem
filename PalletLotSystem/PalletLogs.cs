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
using System.Text;

namespace PalletLotSystem
{
    public partial class PalletLogs : Form
    {
        String connStr = "server=localhost; user=root; password=root; database=christian; port=3306";

        public PalletLogs()
        {
            InitializeComponent();

            DisplayPalletLogs();
        }

        private void DisplayPalletLogs(){
            using (MySqlConnection conn = new MySqlConnection(connStr)){

                try{
                    conn.Open();

                    string query = "SELECT employeeInName AS `Employee In`, location AS `Pallet Location`, palletId AS `Pallet ID`, palletNo AS `Pallet No.`, dateIn AS `Date In`, timeIn AS `Time In`, employeeOutName AS `Employee Out`, dateOut AS `Date Out`, timeOut AS `Time Out` FROM tbl_palletlogs ORDER BY id DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPalletLogs.DataSource = dt;
                    dgvPalletLogs.RowHeadersVisible = false;
                    dgvPalletLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvPalletLogs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvPalletLogs.Columns["Employee In"].FillWeight = 130;
                    dgvPalletLogs.Columns["Pallet No."].FillWeight = 220;
                    dgvPalletLogs.Columns["Pallet Location"].FillWeight = 110;
                    dgvPalletLogs.Columns["Employee Out"].FillWeight = 130;
                    dgvPalletLogs.ReadOnly = true;
                    dgvPalletLogs.AllowUserToAddRows = false;
                    dgvPalletLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }catch (Exception e){
                    MessageBox.Show("Database Error " + e.Message);
                }
            }
        }

        private void ExportToCsv()
        {
            try
            {
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

                foreach (DataGridViewRow row in dgvPalletLogs.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    for (int i = 0; i < dgvPalletLogs.Columns.Count; i++)
                    {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToCsv();
        }
    }
}
