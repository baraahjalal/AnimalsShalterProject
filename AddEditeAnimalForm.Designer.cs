namespace AnimalsShalterProject
{
    partial class AddEditeAnimalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTxtName = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTxtType = new System.Windows.Forms.Label();
            this.pnlType = new System.Windows.Forms.Panel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblTxtAge = new System.Windows.Forms.Label();
            this.pnlAge = new System.Windows.Forms.Panel();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblTxtHealth = new System.Windows.Forms.Label();
            this.pnlHealth = new System.Windows.Forms.Panel();
            this.cmbHealth = new System.Windows.Forms.ComboBox();
            this.lblTxtStatus = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlType.SuspendLayout();
            this.pnlAge.SuspendLayout();
            this.pnlHealth.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlSeparator);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.btnClose.Location = new System.Drawing.Point(430, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(187, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Animal";
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeparator.Location = new System.Drawing.Point(0, 69);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(480, 1);
            this.pnlSeparator.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 482);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(480, 88);
            this.pnlBottom.TabIndex = 1;
            this.pnlBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottom_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnCancel.Location = new System.Drawing.Point(210, 28);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            this.btnCancel.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_PaintRounded);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(335, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Animal";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_PaintRounded);
            // 
            // lblTxtName
            // 
            this.lblTxtName.AutoSize = true;
            this.lblTxtName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTxtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTxtName.Location = new System.Drawing.Point(30, 95);
            this.lblTxtName.Name = "lblTxtName";
            this.lblTxtName.Size = new System.Drawing.Size(49, 19);
            this.lblTxtName.TabIndex = 2;
            this.lblTxtName.Text = "Name";
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlName.Controls.Add(this.txtName);
            this.pnlName.Location = new System.Drawing.Point(30, 120);
            this.pnlName.Name = "pnlName";
            this.pnlName.Padding = new System.Windows.Forms.Padding(12);
            this.pnlName.Size = new System.Drawing.Size(420, 42);
            this.pnlName.TabIndex = 3;
            this.pnlName.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(396, 18);
            this.txtName.TabIndex = 0;
            // 
            // lblTxtType
            // 
            this.lblTxtType.AutoSize = true;
            this.lblTxtType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTxtType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTxtType.Location = new System.Drawing.Point(30, 180);
            this.lblTxtType.Name = "lblTxtType";
            this.lblTxtType.Size = new System.Drawing.Size(41, 19);
            this.lblTxtType.TabIndex = 4;
            this.lblTxtType.Text = "Type";
            // 
            // pnlType
            // 
            this.pnlType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlType.Controls.Add(this.cmbType);
            this.pnlType.Location = new System.Drawing.Point(30, 205);
            this.pnlType.Name = "pnlType";
            this.pnlType.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlType.Size = new System.Drawing.Size(200, 42);
            this.pnlType.TabIndex = 5;
            this.pnlType.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Dog",
            "Cat",
            "Bird",
            "Other"});
            this.cmbType.Location = new System.Drawing.Point(12, 10);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(176, 25);
            this.cmbType.TabIndex = 0;
            // 
            // lblTxtAge
            // 
            this.lblTxtAge.AutoSize = true;
            this.lblTxtAge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTxtAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTxtAge.Location = new System.Drawing.Point(250, 180);
            this.lblTxtAge.Name = "lblTxtAge";
            this.lblTxtAge.Size = new System.Drawing.Size(36, 19);
            this.lblTxtAge.TabIndex = 6;
            this.lblTxtAge.Text = "Age";
            // 
            // pnlAge
            // 
            this.pnlAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlAge.Controls.Add(this.txtAge);
            this.pnlAge.Location = new System.Drawing.Point(250, 205);
            this.pnlAge.Name = "pnlAge";
            this.pnlAge.Padding = new System.Windows.Forms.Padding(12);
            this.pnlAge.Size = new System.Drawing.Size(200, 42);
            this.pnlAge.TabIndex = 7;
            this.pnlAge.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtAge.Location = new System.Drawing.Point(12, 12);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(176, 18);
            this.txtAge.TabIndex = 0;
            // 
            // lblTxtHealth
            // 
            this.lblTxtHealth.AutoSize = true;
            this.lblTxtHealth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTxtHealth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTxtHealth.Location = new System.Drawing.Point(30, 265);
            this.lblTxtHealth.Name = "lblTxtHealth";
            this.lblTxtHealth.Size = new System.Drawing.Size(97, 19);
            this.lblTxtHealth.TabIndex = 8;
            this.lblTxtHealth.Text = "Health Status";
            // 
            // pnlHealth
            // 
            this.pnlHealth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlHealth.Controls.Add(this.cmbHealth);
            this.pnlHealth.Location = new System.Drawing.Point(30, 290);
            this.pnlHealth.Name = "pnlHealth";
            this.pnlHealth.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlHealth.Size = new System.Drawing.Size(420, 42);
            this.pnlHealth.TabIndex = 9;
            this.pnlHealth.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbHealth
            // 
            this.cmbHealth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbHealth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbHealth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHealth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbHealth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHealth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbHealth.FormattingEnabled = true;
            this.cmbHealth.Items.AddRange(new object[] {
            "Healthy",
            "Needs Treatment",
            "Sick"});
            this.cmbHealth.Location = new System.Drawing.Point(12, 10);
            this.cmbHealth.Name = "cmbHealth";
            this.cmbHealth.Size = new System.Drawing.Size(396, 25);
            this.cmbHealth.TabIndex = 0;
            // 
            // lblTxtStatus
            // 
            this.lblTxtStatus.AutoSize = true;
            this.lblTxtStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTxtStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTxtStatus.Location = new System.Drawing.Point(30, 350);
            this.lblTxtStatus.Name = "lblTxtStatus";
            this.lblTxtStatus.Size = new System.Drawing.Size(49, 19);
            this.lblTxtStatus.TabIndex = 10;
            this.lblTxtStatus.Text = "Status";
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlStatus.Controls.Add(this.cmbStatus);
            this.pnlStatus.Location = new System.Drawing.Point(30, 375);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlStatus.Size = new System.Drawing.Size(420, 42);
            this.pnlStatus.TabIndex = 11;
            this.pnlStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Available",
            "Adopted",
            "In Care"});
            this.cmbStatus.Location = new System.Drawing.Point(12, 10);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(396, 25);
            this.cmbStatus.TabIndex = 0;
            // 
            // AddEditeAnimalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 570);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.lblTxtStatus);
            this.Controls.Add(this.pnlHealth);
            this.Controls.Add(this.lblTxtHealth);
            this.Controls.Add(this.pnlAge);
            this.Controls.Add(this.lblTxtAge);
            this.Controls.Add(this.pnlType);
            this.Controls.Add(this.lblTxtType);
            this.Controls.Add(this.pnlName);
            this.Controls.Add(this.lblTxtName);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddEditeAnimalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Animal";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AddEditeAnimalForm_Paint);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlType.ResumeLayout(false);
            this.pnlAge.ResumeLayout(false);
            this.pnlAge.PerformLayout();
            this.pnlHealth.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        
        private System.Windows.Forms.Label lblTxtName;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.TextBox txtName;
        
        private System.Windows.Forms.Label lblTxtType;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.ComboBox cmbType;
        
        private System.Windows.Forms.Label lblTxtAge;
        private System.Windows.Forms.Panel pnlAge;
        private System.Windows.Forms.TextBox txtAge;
        
        private System.Windows.Forms.Label lblTxtHealth;
        private System.Windows.Forms.Panel pnlHealth;
        private System.Windows.Forms.ComboBox cmbHealth;
        
        private System.Windows.Forms.Label lblTxtStatus;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
    }
}