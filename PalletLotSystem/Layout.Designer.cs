namespace PalletLotSystem
{
    partial class Layout
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
            this.A1 = new System.Windows.Forms.Button();
            this.A2 = new System.Windows.Forms.Button();
            this.A3 = new System.Windows.Forms.Button();
            this.A4 = new System.Windows.Forms.Button();
            this.A5 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // A1
            // 
            this.A1.BackColor = System.Drawing.SystemColors.Control;
            this.A1.Location = new System.Drawing.Point(68, 103);
            this.A1.Name = "A1";
            this.A1.Size = new System.Drawing.Size(50, 50);
            this.A1.TabIndex = 0;
            this.A1.UseVisualStyleBackColor = false;
            // 
            // A2
            // 
            this.A2.BackColor = System.Drawing.SystemColors.Control;
            this.A2.Location = new System.Drawing.Point(143, 103);
            this.A2.Name = "A2";
            this.A2.Size = new System.Drawing.Size(50, 50);
            this.A2.TabIndex = 1;
            this.A2.UseVisualStyleBackColor = false;
            // 
            // A3
            // 
            this.A3.BackColor = System.Drawing.SystemColors.Control;
            this.A3.Location = new System.Drawing.Point(213, 103);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(50, 50);
            this.A3.TabIndex = 2;
            this.A3.UseVisualStyleBackColor = false;
            // 
            // A4
            // 
            this.A4.BackColor = System.Drawing.SystemColors.Control;
            this.A4.Location = new System.Drawing.Point(288, 103);
            this.A4.Name = "A4";
            this.A4.Size = new System.Drawing.Size(50, 50);
            this.A4.TabIndex = 3;
            this.A4.UseVisualStyleBackColor = false;
            // 
            // A5
            // 
            this.A5.BackColor = System.Drawing.SystemColors.Control;
            this.A5.Location = new System.Drawing.Point(363, 103);
            this.A5.Name = "A5";
            this.A5.Size = new System.Drawing.Size(50, 50);
            this.A5.TabIndex = 4;
            this.A5.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(309, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(392, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 244);
            this.Controls.Add(this.A1);
            this.Controls.Add(this.A2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.A3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.A4);
            this.Controls.Add(this.A5);
            this.Name = "Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layout";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button A1;
        private System.Windows.Forms.Button A2;
        private System.Windows.Forms.Button A3;
        private System.Windows.Forms.Button A4;
        private System.Windows.Forms.Button A5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLogout;
    }
}