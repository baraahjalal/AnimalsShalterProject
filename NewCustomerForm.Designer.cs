


namespace AnimalsShalterProject
{
    partial class NewCustomerForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlNameInput = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlPhoneInput = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.pnlEmailInput = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // NewCustomerForm Base
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(450, 550);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // 
            // pnlHeader (Green Header)
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
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
            this.btnClose.Location = new System.Drawing.Point(400, 10);
            this.btnClose.Size = new System.Drawing.Size(30, 30);

            // 
            // Inputs (White Rounded Panels with borderless TextBoxes)
            // 
            this.lblName.Text = "Full Name";
            this.lblName.Location = new System.Drawing.Point(40, 110);
            this.lblName.AutoSize = true;

            this.pnlNameInput.BackColor = System.Drawing.Color.White;
            this.pnlNameInput.Location = new System.Drawing.Point(40, 135);
            this.pnlNameInput.Size = new System.Drawing.Size(370, 45);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Location = new System.Drawing.Point(15, 12);
            this.txtName.Size = new System.Drawing.Size(340, 22);
            this.pnlNameInput.Controls.Add(this.txtName);

            this.lblPhone.Text = "Phone Number";
            this.lblPhone.Location = new System.Drawing.Point(40, 195);
            this.lblPhone.AutoSize = true;

            this.pnlPhoneInput.BackColor = System.Drawing.Color.White;
            this.pnlPhoneInput.Location = new System.Drawing.Point(40, 220);
            this.pnlPhoneInput.Size = new System.Drawing.Size(370, 45);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Location = new System.Drawing.Point(15, 12);
            this.txtPhone.Size = new System.Drawing.Size(340, 22);
            this.pnlPhoneInput.Controls.Add(this.txtPhone);

            this.lblEmail.Text = "Email Address";
            this.lblEmail.Location = new System.Drawing.Point(40, 280);
            this.lblEmail.AutoSize = true;

            this.pnlEmailInput.BackColor = System.Drawing.Color.White;
            this.pnlEmailInput.Location = new System.Drawing.Point(40, 305);
            this.pnlEmailInput.Size = new System.Drawing.Size(370, 45);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Location = new System.Drawing.Point(15, 12);
            this.txtEmail.Size = new System.Drawing.Size(340, 22);
            this.pnlEmailInput.Controls.Add(this.txtEmail);

            // 
            // Action Buttons
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Bold", 10F);
            this.btnSave.Text = "Save Customer";
            this.btnSave.Location = new System.Drawing.Point(250, 470);
            this.btnSave.Size = new System.Drawing.Size(160, 45);

            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(40, 470);
            this.btnCancel.Size = new System.Drawing.Size(100, 45);

            // Final Assembly
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlNameInput);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.pnlPhoneInput);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.pnlEmailInput);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlNameInput;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlPhoneInput;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Panel pnlEmailInput;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
    }
}