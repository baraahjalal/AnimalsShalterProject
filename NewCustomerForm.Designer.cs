namespace AnimalsShalterProject
{
    partial class NewCustomerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlNameInput = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlPhoneInput = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.pnlDateInput = new System.Windows.Forms.Panel();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();

            this.SuspendLayout();

            this.BackColor = System.Drawing.Color.FromArgb(250, 248, 245);
            this.ClientSize = new System.Drawing.Size(450, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(69, 115, 87);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;

            this.lblHeaderTitle.Text = "Add New Customer";
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Bold", 16F);
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 25);
            this.lblHeaderTitle.AutoSize = true;

            this.btnClose.Text = "✕";
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(405, 10);
            this.btnClose.Size = new System.Drawing.Size(30, 30);

            this.lblName.Text = "Full Name";
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(40, 105);
            this.lblName.AutoSize = true;

            this.pnlNameInput.BackColor = System.Drawing.Color.White;
            this.pnlNameInput.Location = new System.Drawing.Point(40, 128);
            this.pnlNameInput.Size = new System.Drawing.Size(370, 45);

            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(15, 12);
            this.txtName.Size = new System.Drawing.Size(340, 22);
            this.pnlNameInput.Controls.Add(this.txtName);

            this.lblPhone.Text = "Phone Number";
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhone.Location = new System.Drawing.Point(40, 190);
            this.lblPhone.AutoSize = true;

            this.pnlPhoneInput.BackColor = System.Drawing.Color.White;
            this.pnlPhoneInput.Location = new System.Drawing.Point(40, 213);
            this.pnlPhoneInput.Size = new System.Drawing.Size(370, 45);

            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(15, 12);
            this.txtPhone.Size = new System.Drawing.Size(340, 22);
            this.pnlPhoneInput.Controls.Add(this.txtPhone);

            this.lblDate.Text = "Join Date";
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(40, 275);
            this.lblDate.AutoSize = true;

            this.pnlDateInput.BackColor = System.Drawing.Color.White;
            this.pnlDateInput.Location = new System.Drawing.Point(40, 298);
            this.pnlDateInput.Size = new System.Drawing.Size(370, 45);

            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJoinDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpJoinDate.Location = new System.Drawing.Point(15, 10);
            this.dtpJoinDate.Size = new System.Drawing.Size(340, 22);
            this.dtpJoinDate.Value = System.DateTime.Today;
            this.pnlDateInput.Controls.Add(this.dtpJoinDate);

            this.btnSave.BackColor = System.Drawing.Color.FromArgb(69, 115, 87);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Bold", 10F);
            this.btnSave.Text = "Save Customer";
            this.btnSave.Location = new System.Drawing.Point(250, 355);
            this.btnSave.Size = new System.Drawing.Size(160, 45);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;

            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(211, 216, 213);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(40, 355);
            this.btnCancel.Size = new System.Drawing.Size(100, 45);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlNameInput);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.pnlPhoneInput);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.pnlDateInput);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlNameInput;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlPhoneInput;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Panel pnlDateInput;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDate;
    }
}