namespace AnimalsShalterProject
{
    partial class RegisterAdoptionForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblAnimal = new System.Windows.Forms.Label();
            this.pnlAnimal = new System.Windows.Forms.Panel();
            this.cmbAnimal = new System.Windows.Forms.ComboBox();
            this.picAnimal = new System.Windows.Forms.PictureBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pnlCustomer = new System.Windows.Forms.Panel();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.picCustomer = new System.Windows.Forms.PictureBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.picDate = new System.Windows.Forms.PictureBox();
            this.lblFee = new System.Windows.Forms.Label();
            this.flpFee = new System.Windows.Forms.FlowLayoutPanel();
            this.rbPaid = new System.Windows.Forms.RadioButton();
            this.rbWaived = new System.Windows.Forms.RadioButton();
            this.pnlHeader.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlAnimal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimal)).BeginInit();
            this.pnlCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).BeginInit();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDate)).BeginInit();
            this.flpFee.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(201, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Register Adoption";
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
            this.pnlBottom.Controls.Add(this.btnConfirm);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 500);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(480, 80);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnCancel.Location = new System.Drawing.Point(190, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            this.btnCancel.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_PaintRounded);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(300, 20);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(150, 40);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm Adoption";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_PaintRounded);
            // 
            // lblAnimal
            // 
            this.lblAnimal.AutoSize = true;
            this.lblAnimal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblAnimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblAnimal.Location = new System.Drawing.Point(30, 95);
            this.lblAnimal.Name = "lblAnimal";
            this.lblAnimal.Size = new System.Drawing.Size(80, 15);
            this.lblAnimal.TabIndex = 2;
            this.lblAnimal.Text = "Select Animal";
            // 
            // pnlAnimal
            // 
            this.pnlAnimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlAnimal.Controls.Add(this.cmbAnimal);
            this.pnlAnimal.Controls.Add(this.picAnimal);
            this.pnlAnimal.Location = new System.Drawing.Point(30, 115);
            this.pnlAnimal.Name = "pnlAnimal";
            this.pnlAnimal.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAnimal.Size = new System.Drawing.Size(420, 42);
            this.pnlAnimal.TabIndex = 3;
            this.pnlAnimal.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbAnimal
            // 
            this.cmbAnimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbAnimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAnimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAnimal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAnimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbAnimal.FormattingEnabled = true;
            this.cmbAnimal.Location = new System.Drawing.Point(30, 10);
            this.cmbAnimal.Name = "cmbAnimal";
            this.cmbAnimal.Size = new System.Drawing.Size(380, 25);
            this.cmbAnimal.TabIndex = 0;
            // 
            // picAnimal
            // 
            this.picAnimal.Dock = System.Windows.Forms.DockStyle.Left;
            this.picAnimal.Location = new System.Drawing.Point(10, 10);
            this.picAnimal.Name = "picAnimal";
            this.picAnimal.Size = new System.Drawing.Size(20, 22);
            this.picAnimal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnimal.TabIndex = 1;
            this.picAnimal.TabStop = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblCustomer.Location = new System.Drawing.Point(30, 175);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(93, 15);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Select Customer";
            // 
            // pnlCustomer
            // 
            this.pnlCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlCustomer.Controls.Add(this.cmbCustomer);
            this.pnlCustomer.Controls.Add(this.picCustomer);
            this.pnlCustomer.Location = new System.Drawing.Point(30, 195);
            this.pnlCustomer.Name = "pnlCustomer";
            this.pnlCustomer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCustomer.Size = new System.Drawing.Size(420, 42);
            this.pnlCustomer.TabIndex = 5;
            this.pnlCustomer.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(30, 10);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(380, 25);
            this.cmbCustomer.TabIndex = 0;
            // 
            // picCustomer
            // 
            this.picCustomer.Dock = System.Windows.Forms.DockStyle.Left;
            this.picCustomer.Location = new System.Drawing.Point(10, 10);
            this.picCustomer.Name = "picCustomer";
            this.picCustomer.Size = new System.Drawing.Size(20, 22);
            this.picCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCustomer.TabIndex = 1;
            this.picCustomer.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblDate.Location = new System.Drawing.Point(30, 255);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 15);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Adoption Date";
            // 
            // pnlDate
            // 
            this.pnlDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlDate.Controls.Add(this.dtpDate);
            this.pnlDate.Controls.Add(this.picDate);
            this.pnlDate.Location = new System.Drawing.Point(30, 275);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Padding = new System.Windows.Forms.Padding(10);
            this.pnlDate.Size = new System.Drawing.Size(420, 42);
            this.pnlDate.TabIndex = 7;
            this.pnlDate.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.dtpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(30, 10);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(380, 25);
            this.dtpDate.TabIndex = 0;
            // 
            // picDate
            // 
            this.picDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.picDate.Location = new System.Drawing.Point(10, 10);
            this.picDate.Name = "picDate";
            this.picDate.Size = new System.Drawing.Size(20, 22);
            this.picDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDate.TabIndex = 1;
            this.picDate.TabStop = false;
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblFee.Location = new System.Drawing.Point(30, 335);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(114, 15);
            this.lblFee.TabIndex = 8;
            this.lblFee.Text = "Adoption Fee Status";
            // 
            // flpFee
            // 
            this.flpFee.Controls.Add(this.rbPaid);
            this.flpFee.Controls.Add(this.rbWaived);
            this.flpFee.Location = new System.Drawing.Point(30, 355);
            this.flpFee.Name = "flpFee";
            this.flpFee.Size = new System.Drawing.Size(420, 35);
            this.flpFee.TabIndex = 9;
            // 
            // rbPaid
            // 
            this.rbPaid.AutoSize = true;
            this.rbPaid.Checked = true;
            this.rbPaid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.rbPaid.Location = new System.Drawing.Point(3, 3);
            this.rbPaid.Name = "rbPaid";
            this.rbPaid.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.rbPaid.Size = new System.Drawing.Size(73, 23);
            this.rbPaid.TabIndex = 0;
            this.rbPaid.TabStop = true;
            this.rbPaid.Text = "Paid";
            this.rbPaid.UseVisualStyleBackColor = true;
            // 
            // rbWaived
            // 
            this.rbWaived.AutoSize = true;
            this.rbWaived.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbWaived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.rbWaived.Location = new System.Drawing.Point(82, 3);
            this.rbWaived.Name = "rbWaived";
            this.rbWaived.Size = new System.Drawing.Size(71, 23);
            this.rbWaived.TabIndex = 1;
            this.rbWaived.Text = "Waived";
            this.rbWaived.UseVisualStyleBackColor = true;
            // 
            // RegisterAdoptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 580);
            this.Controls.Add(this.flpFee);
            this.Controls.Add(this.lblFee);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pnlCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.pnlAnimal);
            this.Controls.Add(this.lblAnimal);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterAdoptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register Adoption";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlAnimal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnimal)).EndInit();
            this.pnlCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCustomer)).EndInit();
            this.pnlDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDate)).EndInit();
            this.flpFee.ResumeLayout(false);
            this.flpFee.PerformLayout();
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
        private System.Windows.Forms.Button btnConfirm;
        
        private System.Windows.Forms.Label lblAnimal;
        private System.Windows.Forms.Panel pnlAnimal;
        private System.Windows.Forms.ComboBox cmbAnimal;
        private System.Windows.Forms.PictureBox picAnimal;
        
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Panel pnlCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.PictureBox picCustomer;
        
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.PictureBox picDate;
        
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.FlowLayoutPanel flpFee;
        private System.Windows.Forms.RadioButton rbPaid;
        private System.Windows.Forms.RadioButton rbWaived;
    }
}