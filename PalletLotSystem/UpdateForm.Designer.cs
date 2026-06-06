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
            this.txtPalletId = new System.Windows.Forms.TextBox();
            this.lblPallet = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.txtPalletNo = new System.Windows.Forms.TextBox();
            this.lblPalletNo = new System.Windows.Forms.Label();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(116, 126);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(74, 89);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 9;
            this.lblLocation.Text = "Location:";
            // 
            // lblPalletId
            // 
            this.lblPalletId.AutoSize = true;
            this.lblPalletId.Location = new System.Drawing.Point(75, 35);
            this.lblPalletId.Name = "lblPalletId";
            this.lblPalletId.Size = new System.Drawing.Size(50, 13);
            this.lblPalletId.TabIndex = 7;
            this.lblPalletId.Text = "Pallet ID:";
            // 
            // txtPalletId
            // 
            this.txtPalletId.Enabled = false;
            this.txtPalletId.Location = new System.Drawing.Point(131, 32);
            this.txtPalletId.Name = "txtPalletId";
            this.txtPalletId.Size = new System.Drawing.Size(163, 20);
            this.txtPalletId.TabIndex = 1;
            this.txtPalletId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPalletId_KeyDown);
            // 
            // lblPallet
            // 
            this.lblPallet.AutoSize = true;
            this.lblPallet.Location = new System.Drawing.Point(133, 89);
            this.lblPallet.Name = "lblPallet";
            this.lblPallet.Size = new System.Drawing.Size(77, 13);
            this.lblPallet.TabIndex = 10;
            this.lblPallet.Text = "Pallet Location";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(67, 126);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 0;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(170, 126);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "OUT";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtPalletNo
            // 
            this.txtPalletNo.Enabled = false;
            this.txtPalletNo.Location = new System.Drawing.Point(131, 58);
            this.txtPalletNo.Name = "txtPalletNo";
            this.txtPalletNo.Size = new System.Drawing.Size(163, 20);
            this.txtPalletNo.TabIndex = 2;
            this.txtPalletNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPalletNo_KeyDown);
            // 
            // lblPalletNo
            // 
            this.lblPalletNo.AutoSize = true;
            this.lblPalletNo.Location = new System.Drawing.Point(75, 61);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(53, 13);
            this.lblPalletNo.TabIndex = 8;
            this.lblPalletNo.Text = "Pallet No:";
            // 
            // btnCancel2
            // 
            this.btnCancel2.Location = new System.Drawing.Point(269, 126);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(75, 23);
            this.btnCancel2.TabIndex = 4;
            this.btnCancel2.Text = "CANCEL";
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 198);
            this.Controls.Add(this.btnCancel2);
            this.Controls.Add(this.txtPalletNo);
            this.Controls.Add(this.lblPalletNo);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lblPallet);
            this.Controls.Add(this.txtPalletId);
            this.Controls.Add(this.lblPalletId);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPalletId;
        private System.Windows.Forms.TextBox txtPalletId;
        private System.Windows.Forms.TextBox txtPalletNo;
        private System.Windows.Forms.Label lblPallet;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Label lblPalletNo;
        private System.Windows.Forms.Button btnCancel;

    }
}