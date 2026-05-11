namespace AnimalsShalterProject
{
    partial class RecordDonationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlActionBar = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlNotes = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlAmount = new System.Windows.Forms.Panel();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.pnlDonorName = new System.Windows.Forms.Panel();
            this.txtDonorName = new System.Windows.Forms.TextBox();
            this.lblDonorName = new System.Windows.Forms.Label();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlActionBar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlNotes.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.pnlAmount.SuspendLayout();
            this.pnlDonorName.SuspendLayout();
            this.pnlTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlActionBar);
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlTitleBar);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(480, 540);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlActionBar
            // 
            this.pnlActionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlActionBar.Controls.Add(this.btnCancel);
            this.pnlActionBar.Controls.Add(this.btnSave);
            this.pnlActionBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionBar.Location = new System.Drawing.Point(0, 470);
            this.pnlActionBar.Name = "pnlActionBar";
            this.pnlActionBar.Padding = new System.Windows.Forms.Padding(28, 0, 28, 0);
            this.pnlActionBar.Size = new System.Drawing.Size(480, 70);
            this.pnlActionBar.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.btnCancel.Location = new System.Drawing.Point(448, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(570, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "  Save Donation";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.pnlNotes);
            this.pnlBody.Controls.Add(this.lblNotes);
            this.pnlBody.Controls.Add(this.pnlDate);
            this.pnlBody.Controls.Add(this.lblDate);
            this.pnlBody.Controls.Add(this.pnlCategory);
            this.pnlBody.Controls.Add(this.lblCategory);
            this.pnlBody.Controls.Add(this.pnlAmount);
            this.pnlBody.Controls.Add(this.lblAmount);
            this.pnlBody.Controls.Add(this.pnlDonorName);
            this.pnlBody.Controls.Add(this.lblDonorName);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 80);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(28, 20, 28, 0);
            this.pnlBody.Size = new System.Drawing.Size(480, 460);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlNotes
            // 
            this.pnlNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.pnlNotes.Controls.Add(this.txtNotes);
            this.pnlNotes.Location = new System.Drawing.Point(28, 366);
            this.pnlNotes.Name = "pnlNotes";
            this.pnlNotes.Padding = new System.Windows.Forms.Padding(12, 8, 8, 8);
            this.pnlNotes.Size = new System.Drawing.Size(420, 80);
            this.pnlNotes.TabIndex = 8;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtNotes.Location = new System.Drawing.Point(12, 8);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(400, 64);
            this.txtNotes.TabIndex = 4;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblNotes.Location = new System.Drawing.Point(28, 344);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(108, 17);
            this.lblNotes.TabIndex = 9;
            this.lblNotes.Text = "Notes (Optional)";
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.pnlDate.Controls.Add(this.dtpDate);
            this.pnlDate.Location = new System.Drawing.Point(28, 286);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.pnlDate.Size = new System.Drawing.Size(420, 40);
            this.pnlDate.TabIndex = 6;
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Location = new System.Drawing.Point(8, 2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(404, 25);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.Value = new System.DateTime(2026, 5, 11, 0, 0, 0, 0);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblDate.Location = new System.Drawing.Point(28, 264);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(96, 17);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "Donation Date";
            // 
            // pnlCategory
            // 
            this.pnlCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.pnlCategory.Controls.Add(this.cmbCategory);
            this.pnlCategory.Location = new System.Drawing.Point(28, 206);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.pnlCategory.Size = new System.Drawing.Size(420, 40);
            this.pnlCategory.TabIndex = 4;
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbCategory.Items.AddRange(new object[] {
            "General",
            "Food",
            "Medicine",
            "Shelter",
            "Equipment",
            "Other"});
            this.cmbCategory.Location = new System.Drawing.Point(8, 2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(404, 25);
            this.cmbCategory.TabIndex = 2;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblCategory.Location = new System.Drawing.Point(28, 184);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(64, 17);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Category";
            // 
            // pnlAmount
            // 
            this.pnlAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.pnlAmount.Controls.Add(this.txtAmount);
            this.pnlAmount.Location = new System.Drawing.Point(28, 126);
            this.pnlAmount.Name = "pnlAmount";
            this.pnlAmount.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlAmount.Size = new System.Drawing.Size(420, 40);
            this.pnlAmount.TabIndex = 2;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtAmount.Location = new System.Drawing.Point(12, 0);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(408, 18);
            this.txtAmount.TabIndex = 1;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblAmount.Location = new System.Drawing.Point(28, 104);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(92, 17);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.Text = "Amount (LYD)";
            // 
            // pnlDonorName
            // 
            this.pnlDonorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.pnlDonorName.Controls.Add(this.txtDonorName);
            this.pnlDonorName.Location = new System.Drawing.Point(28, 46);
            this.pnlDonorName.Name = "pnlDonorName";
            this.pnlDonorName.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlDonorName.Size = new System.Drawing.Size(420, 40);
            this.pnlDonorName.TabIndex = 0;
            // 
            // txtDonorName
            // 
            this.txtDonorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.txtDonorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDonorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonorName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDonorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtDonorName.Location = new System.Drawing.Point(12, 0);
            this.txtDonorName.Name = "txtDonorName";
            this.txtDonorName.Size = new System.Drawing.Size(408, 18);
            this.txtDonorName.TabIndex = 0;
            // 
            // lblDonorName
            // 
            this.lblDonorName.AutoSize = true;
            this.lblDonorName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblDonorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblDonorName.Location = new System.Drawing.Point(28, 24);
            this.lblDonorName.Name = "lblDonorName";
            this.lblDonorName.Size = new System.Drawing.Size(86, 17);
            this.lblDonorName.TabIndex = 13;
            this.lblDonorName.Text = "Donor Name";
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.pnlTitleBar.Controls.Add(this.btnClose);
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Padding = new System.Windows.Forms.Padding(24, 0, 16, 0);
            this.pnlTitleBar.Size = new System.Drawing.Size(480, 80);
            this.pnlTitleBar.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(710, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 36);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 26);
            this.lblTitle.TabIndex = 101;
            this.lblTitle.Text = "Record Donation";
            // 
            // RecordDonationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 540);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecordDonationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record Donation";
            this.pnlMain.ResumeLayout(false);
            this.pnlActionBar.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlNotes.ResumeLayout(false);
            this.pnlNotes.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            this.pnlAmount.ResumeLayout(false);
            this.pnlAmount.PerformLayout();
            this.pnlDonorName.ResumeLayout(false);
            this.pnlDonorName.PerformLayout();
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel        pnlMain;
        private System.Windows.Forms.Panel        pnlTitleBar;
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Button       btnClose;
        private System.Windows.Forms.Panel        pnlBody;
        private System.Windows.Forms.Label        lblDonorName;
        private System.Windows.Forms.Panel        pnlDonorName;
        private System.Windows.Forms.TextBox      txtDonorName;
        private System.Windows.Forms.Label        lblAmount;
        private System.Windows.Forms.Panel        pnlAmount;
        private System.Windows.Forms.TextBox      txtAmount;
        private System.Windows.Forms.Label        lblCategory;
        private System.Windows.Forms.Panel        pnlCategory;
        private System.Windows.Forms.ComboBox     cmbCategory;
        private System.Windows.Forms.Label        lblDate;
        private System.Windows.Forms.Panel        pnlDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label        lblNotes;
        private System.Windows.Forms.Panel        pnlNotes;
        private System.Windows.Forms.TextBox      txtNotes;
        private System.Windows.Forms.Panel        pnlActionBar;
        private System.Windows.Forms.Button       btnSave;
        private System.Windows.Forms.Button       btnCancel;
    }
}