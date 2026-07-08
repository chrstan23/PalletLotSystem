namespace PalletLotSystem
{
    partial class LandingPage
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
            this.btnLayout = new System.Windows.Forms.Button();
            this.btnPalletLogs = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPartLogs = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLayout
            // 
            this.btnLayout.BackColor = System.Drawing.Color.Black;
            this.btnLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayout.ForeColor = System.Drawing.Color.White;
            this.btnLayout.Location = new System.Drawing.Point(39, 107);
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Size = new System.Drawing.Size(115, 32);
            this.btnLayout.TabIndex = 0;
            this.btnLayout.Text = "LAYOUT";
            this.btnLayout.UseVisualStyleBackColor = false;
            this.btnLayout.Click += new System.EventHandler(this.btnLayout_Click);
            // 
            // btnPalletLogs
            // 
            this.btnPalletLogs.BackColor = System.Drawing.Color.Black;
            this.btnPalletLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPalletLogs.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPalletLogs.ForeColor = System.Drawing.Color.White;
            this.btnPalletLogs.Location = new System.Drawing.Point(180, 107);
            this.btnPalletLogs.Name = "btnPalletLogs";
            this.btnPalletLogs.Size = new System.Drawing.Size(115, 32);
            this.btnPalletLogs.TabIndex = 1;
            this.btnPalletLogs.Text = "PALLET LOGS";
            this.btnPalletLogs.UseVisualStyleBackColor = false;
            this.btnPalletLogs.Click += new System.EventHandler(this.btnPalletLogs_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(180, 158);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(115, 32);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnPartLogs
            // 
            this.btnPartLogs.BackColor = System.Drawing.Color.Black;
            this.btnPartLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartLogs.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartLogs.ForeColor = System.Drawing.Color.White;
            this.btnPartLogs.Location = new System.Drawing.Point(39, 158);
            this.btnPartLogs.Name = "btnPartLogs";
            this.btnPartLogs.Size = new System.Drawing.Size(115, 32);
            this.btnPartLogs.TabIndex = 3;
            this.btnPartLogs.Text = "PARTS LOGS";
            this.btnPartLogs.UseVisualStyleBackColor = false;
            this.btnPartLogs.Click += new System.EventHandler(this.btnPartLogs_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(340, 64);
            this.pnlHeader.TabIndex = 32;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 8);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(270, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "PALLET LOT SYSTEM";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(340, 220);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnPartLogs);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnPalletLogs);
            this.Controls.Add(this.btnLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LandingPage";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLayout;
        private System.Windows.Forms.Button btnPalletLogs;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPartLogs;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
    }
}