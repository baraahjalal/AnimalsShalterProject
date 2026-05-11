using System;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class NewCustomerForm : Form
    {
        // --- Output properties (read by caller after DialogResult.OK) ---
        public string CustomerName  => txtName.Text.Trim();
        public string CustomerPhone => txtPhone.Text.Trim();
        public string CustomerEmail => txtEmail.Text.Trim();

        public NewCustomerForm()
        {
            InitializeComponent();

            // Wire Save → DialogResult.OK, Cancel/Close → DialogResult.Cancel
            btnSave.Click   += (s, e) => Save();
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnClose.Click  += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        // --- Called by CustomersForm for Edit mode ---
        public void LoadCustomerData(int id, string name, string phone, string email)
        {
            txtName.Text  = name  ?? "";
            txtPhone.Text = phone ?? "";
            txtEmail.Text = email ?? "";
        }

        // --- Allows caller to change the header title (Add vs Edit) ---
        public void SetTitle(string title)
        {
            lblHeaderTitle.Text = title;
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Full Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone Number is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
