namespace PalletLotSystem
{
    partial class WithdrawForm
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
            this.lblPalletNo = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblPartNo = new System.Windows.Forms.Label();
            this.cmbPartNo = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblAvailQty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPalletNo
            // 
            this.lblPalletNo.AutoSize = true;
            this.lblPalletNo.Location = new System.Drawing.Point(43, 39);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(53, 13);
            this.lblPalletNo.TabIndex = 0;
            this.lblPalletNo.Text = "Pallet No:";
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Location = new System.Drawing.Point(110, 39);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(41, 13);
            this.lblDisplay.TabIndex = 1;
            this.lblDisplay.Text = "Display";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.Location = new System.Drawing.Point(44, 58);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(72, 13);
            this.lblPartNo.TabIndex = 2;
            this.lblPartNo.Text = "Part Number: ";
            // 
            // cmbPartNo
            // 
            this.cmbPartNo.FormattingEnabled = true;
            this.cmbPartNo.Location = new System.Drawing.Point(113, 55);
            this.cmbPartNo.Name = "cmbPartNo";
            this.cmbPartNo.Size = new System.Drawing.Size(121, 21);
            this.cmbPartNo.TabIndex = 3;
            this.cmbPartNo.SelectedIndexChanged += new System.EventHandler(this.cmbPartNo_SelectedIndexChanged);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(43, 108);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(49, 13);
            this.lblQty.TabIndex = 4;
            this.lblQty.Text = "Quantity:";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(112, 105);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(121, 20);
            this.txtQty.TabIndex = 5;
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(41, 142);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(75, 23);
            this.btnWithdraw.TabIndex = 6;
            this.btnWithdraw.Text = "WITHDRAW";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(135, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(44, 83);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(95, 13);
            this.lblAvailable.TabIndex = 8;
            this.lblAvailable.Text = "Available Quantity:";
            // 
            // lblAvailQty
            // 
            this.lblAvailQty.AutoSize = true;
            this.lblAvailQty.Location = new System.Drawing.Point(145, 83);
            this.lblAvailQty.Name = "lblAvailQty";
            this.lblAvailQty.Size = new System.Drawing.Size(21, 13);
            this.lblAvailQty.TabIndex = 9;
            this.lblAvailQty.Text = "qty";
            // 
            // WithdrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblAvailQty);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.cmbPartNo);
            this.Controls.Add(this.lblPartNo);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.lblPalletNo);
            this.Name = "WithdrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WithdrawForm";
            this.Load += new System.EventHandler(this.WithdrawForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPalletNo;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblPartNo;
        private System.Windows.Forms.ComboBox cmbPartNo;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblAvailQty;
    }
}