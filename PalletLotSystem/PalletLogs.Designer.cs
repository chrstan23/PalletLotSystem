namespace PalletLotSystem
{
    partial class PalletLogs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dvgPalletLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPalletLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgPalletLogs
            // 
            this.dvgPalletLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPalletLogs.Location = new System.Drawing.Point(6, 68);
            this.dvgPalletLogs.Name = "dvgPalletLogs";
            this.dvgPalletLogs.Size = new System.Drawing.Size(769, 296);
            this.dvgPalletLogs.TabIndex = 0;
            // 
            // PalletLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 369);
            this.Controls.Add(this.dvgPalletLogs);
            this.Name = "PalletLogs";
            this.Text = "PalletLogs";
            ((System.ComponentModel.ISupportInitialize)(this.dvgPalletLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgPalletLogs;
    }
}