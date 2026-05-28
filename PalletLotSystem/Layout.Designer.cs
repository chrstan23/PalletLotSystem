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
            this.btnA1 = new System.Windows.Forms.Button();
            this.btnA2 = new System.Windows.Forms.Button();
            this.btnA3 = new System.Windows.Forms.Button();
            this.btnA4 = new System.Windows.Forms.Button();
            this.btnA5 = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnA1
            // 
            this.btnA1.BackColor = System.Drawing.SystemColors.Control;
            this.btnA1.Enabled = false;
            this.btnA1.Location = new System.Drawing.Point(68, 103);
            this.btnA1.Name = "btnA1";
            this.btnA1.Size = new System.Drawing.Size(50, 50);
            this.btnA1.TabIndex = 0;
            this.btnA1.Text = "A1";
            this.btnA1.UseVisualStyleBackColor = false;
            // 
            // btnA2
            // 
            this.btnA2.BackColor = System.Drawing.SystemColors.Control;
            this.btnA2.Enabled = false;
            this.btnA2.Location = new System.Drawing.Point(143, 103);
            this.btnA2.Name = "btnA2";
            this.btnA2.Size = new System.Drawing.Size(50, 50);
            this.btnA2.TabIndex = 1;
            this.btnA2.Text = "A2";
            this.btnA2.UseVisualStyleBackColor = false;
            // 
            // btnA3
            // 
            this.btnA3.BackColor = System.Drawing.SystemColors.Control;
            this.btnA3.Enabled = false;
            this.btnA3.Location = new System.Drawing.Point(213, 103);
            this.btnA3.Name = "btnA3";
            this.btnA3.Size = new System.Drawing.Size(50, 50);
            this.btnA3.TabIndex = 2;
            this.btnA3.Text = "A3";
            this.btnA3.UseVisualStyleBackColor = false;
            // 
            // btnA4
            // 
            this.btnA4.BackColor = System.Drawing.SystemColors.Control;
            this.btnA4.Enabled = false;
            this.btnA4.Location = new System.Drawing.Point(288, 103);
            this.btnA4.Name = "btnA4";
            this.btnA4.Size = new System.Drawing.Size(50, 50);
            this.btnA4.TabIndex = 3;
            this.btnA4.Text = "A4";
            this.btnA4.UseVisualStyleBackColor = false;
            // 
            // btnA5
            // 
            this.btnA5.BackColor = System.Drawing.SystemColors.Control;
            this.btnA5.Enabled = false;
            this.btnA5.Location = new System.Drawing.Point(363, 103);
            this.btnA5.Name = "btnA5";
            this.btnA5.Size = new System.Drawing.Size(50, 50);
            this.btnA5.TabIndex = 4;
            this.btnA5.Text = "A5";
            this.btnA5.UseVisualStyleBackColor = false;
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
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 244);
            this.Controls.Add(this.btnA1);
            this.Controls.Add(this.btnA2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnA3);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnA4);
            this.Controls.Add(this.btnA5);
            this.Name = "Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layout";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnA1;
        private System.Windows.Forms.Button btnA2;
        private System.Windows.Forms.Button btnA3;
        private System.Windows.Forms.Button btnA4;
        private System.Windows.Forms.Button btnA5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLogout;
    }
}