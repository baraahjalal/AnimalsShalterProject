using System;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class NewCustomerForm : Form
    {
        public string CustomerName => txtName.Text.Trim();
        public string CustomerPhone => txtPhone.Text.Trim();
        public string CustomerEmail => "";
        public DateTime CustomerJoinDate => DateTime.Today;

        public NewCustomerForm()
        {
            InitializeComponent();
            btnSave.Click += (s, e) => Save();
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnClose.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        public void LoadCustomerData(int id, string name, string phone, string email)
        {
            txtName.Text = name ?? "";
            txtPhone.Text = phone ?? "";
        }

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