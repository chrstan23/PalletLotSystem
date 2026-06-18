namespace PalletLotSystem
{
    partial class UpdateForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPalletId = new System.Windows.Forms.Label();
            this.txtPalletNo = new System.Windows.Forms.TextBox();
            this.lblPallet = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.txtPalletId = new System.Windows.Forms.TextBox();
            this.lblPalletNo = new System.Windows.Forms.Label();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SpringGreen;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(93, 224);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(226, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(60, 179);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(74, 20);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "Location:";
            // 
            // lblPalletId
            // 
            this.lblPalletId.AutoSize = true;
            this.lblPalletId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletId.Location = new System.Drawing.Point(60, 143);
            this.lblPalletId.Name = "lblPalletId";
            this.lblPalletId.Size = new System.Drawing.Size(73, 20);
            this.lblPalletId.TabIndex = 7;
            this.lblPalletId.Text = "Pallet ID:";
            // 
            // txtPalletNo
            // 
            this.txtPalletNo.Enabled = false;
            this.txtPalletNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalletNo.Location = new System.Drawing.Point(142, 108);
            this.txtPalletNo.Name = "txtPalletNo";
            this.txtPalletNo.Size = new System.Drawing.Size(163, 26);
            this.txtPalletNo.TabIndex = 1;
            this.txtPalletNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPalletNo_KeyDown);
            // 
            // lblPallet
            // 
            this.lblPallet.AutoSize = true;
            this.lblPallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPallet.Location = new System.Drawing.Point(143, 179);
            this.lblPallet.Name = "lblPallet";
            this.lblPallet.Size = new System.Drawing.Size(113, 20);
            this.lblPallet.TabIndex = 10;
            this.lblPallet.Text = "Pallet Location";
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.SpringGreen;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(44, 224);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 32);
            this.btnIn.TabIndex = 0;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnOut
            // 
            this.btnOut.BackColor = System.Drawing.Color.SkyBlue;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.Location = new System.Drawing.Point(168, 224);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(100, 32);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "OUT";
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtPalletId
            // 
            this.txtPalletId.Enabled = false;
            this.txtPalletId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalletId.Location = new System.Drawing.Point(142, 143);
            this.txtPalletId.Name = "txtPalletId";
            this.txtPalletId.Size = new System.Drawing.Size(163, 26);
            this.txtPalletId.TabIndex = 2;
            this.txtPalletId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPalletId_KeyDown);
            // 
            // lblPalletNo
            // 
            this.lblPalletNo.AutoSize = true;
            this.lblPalletNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPalletNo.Location = new System.Drawing.Point(60, 108);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(76, 20);
            this.lblPalletNo.TabIndex = 8;
            this.lblPalletNo.Text = "Pallet No:";
            // 
            // btnCancel2
            // 
            this.btnCancel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel2.ForeColor = System.Drawing.Color.Black;
            this.btnCancel2.Location = new System.Drawing.Point(290, 224);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(100, 32);
            this.btnCancel2.TabIndex = 4;
            this.btnCancel2.Text = "CANCEL";
            this.btnCancel2.UseVisualStyleBackColor = false;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(402, 77);
            this.pnlHeader.TabIndex = 11;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(323, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "UPDATE PALLET DETAILS";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 268);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.txtPalletId);
            this.Controls.Add(this.lblPalletNo);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lblPallet);
            this.Controls.Add(this.txtPalletNo);
            this.Controls.Add(this.lblPalletId);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateForm";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPalletId;
        private System.Windows.Forms.TextBox txtPalletNo;
        private System.Windows.Forms.TextBox txtPalletId;
        private System.Windows.Forms.Label lblPallet;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Label lblPalletNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;

    }
}