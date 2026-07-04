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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPalletNo
            // 
            this.lblPalletNo.AutoSize = true;
            this.lblPalletNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNo.Location = new System.Drawing.Point(36, 104);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(85, 21);
            this.lblPalletNo.TabIndex = 0;
            this.lblPalletNo.Text = "Pallet No:";
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(127, 104);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(67, 21);
            this.lblDisplay.TabIndex = 1;
            this.lblDisplay.Text = "Display";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNo.Location = new System.Drawing.Point(36, 132);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(117, 21);
            this.lblPartNo.TabIndex = 2;
            this.lblPartNo.Text = "Part Number: ";
            // 
            // cmbPartNo
            // 
            this.cmbPartNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPartNo.FormattingEnabled = true;
            this.cmbPartNo.Location = new System.Drawing.Point(149, 131);
            this.cmbPartNo.Name = "cmbPartNo";
            this.cmbPartNo.Size = new System.Drawing.Size(154, 28);
            this.cmbPartNo.TabIndex = 3;
            this.cmbPartNo.SelectedIndexChanged += new System.EventHandler(this.cmbPartNo_SelectedIndexChanged);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(36, 195);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(81, 21);
            this.lblQty.TabIndex = 4;
            this.lblQty.Text = "Quantity:";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(123, 194);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(154, 26);
            this.txtQty.TabIndex = 5;
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.BackColor = System.Drawing.Color.SkyBlue;
            this.btnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWithdraw.Location = new System.Drawing.Point(39, 242);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(115, 32);
            this.btnWithdraw.TabIndex = 6;
            this.btnWithdraw.Text = "WITHDRAW";
            this.btnWithdraw.UseVisualStyleBackColor = false;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(170, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailable.Location = new System.Drawing.Point(36, 167);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(157, 21);
            this.lblAvailable.TabIndex = 8;
            this.lblAvailable.Text = "Available Quantity:";
            // 
            // lblAvailQty
            // 
            this.lblAvailQty.AutoSize = true;
            this.lblAvailQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailQty.Location = new System.Drawing.Point(199, 166);
            this.lblAvailQty.Name = "lblAvailQty";
            this.lblAvailQty.Size = new System.Drawing.Size(35, 21);
            this.lblAvailQty.TabIndex = 9;
            this.lblAvailQty.Text = "qty";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(347, 77);
            this.pnlHeader.TabIndex = 32;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(242, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "WITHDRAW PARTS";
            // 
            // WithdrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 317);
            this.Controls.Add(this.pnlHeader);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WithdrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WithdrawForm";
            this.Load += new System.EventHandler(this.WithdrawForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
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
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
    }
}