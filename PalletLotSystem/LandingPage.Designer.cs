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
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLayout
            // 
            this.btnLayout.BackColor = System.Drawing.Color.Black;
            this.btnLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayout.ForeColor = System.Drawing.Color.White;
            this.btnLayout.Location = new System.Drawing.Point(54, 35);
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Size = new System.Drawing.Size(100, 32);
            this.btnLayout.TabIndex = 0;
            this.btnLayout.Text = "LAYOUT";
            this.btnLayout.UseVisualStyleBackColor = false;
            this.btnLayout.Click += new System.EventHandler(this.btnLayout_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.Black;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(186, 35);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(100, 32);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "HISTORY";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Location = new System.Drawing.Point(124, 88);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 35);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(340, 146);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LandingPage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLayout;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnLogout;
    }
}