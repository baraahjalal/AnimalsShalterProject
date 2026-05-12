using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class RegisterAdoptionForm : Form
    {
        private readonly Color ColorInputBorder = ColorTranslator.FromHtml("#D3D8D5");
        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");

        // كومبو النوع — يُنشأ برمجياً
        private ComboBox cmbAnimalType;
        private Label lblAnimalType;

        // حقل البحث عن الزبون — يُنشأ برمجياً
        private TextBox txtCustomerSearch;
        private Label lblCustomerSearch;

        public string AnimalName { get; private set; }
        public string CustomerName { get; private set; }
        public string Phone { get; private set; }
        public string DateFormatted { get; private set; }
        public bool FeePaid { get; private set; }
        public int SelectedAnimalID { get; private set; }
        public int SelectedCustomerID { get; private set; }
        public string AdoptionId { get; private set; }

        public RegisterAdoptionForm()
        {
            InitializeComponent();
            this.Load += RegisterAdoptionForm_Load;
            this.btnClose.Click += btnClose_Click;
            this.btnCancel.Click += btnClose_Click;
            this.btnConfirm.Click += BtnConfirm_Click;
        }

        private void RegisterAdoptionForm_Load(object sender, EventArgs e)
        {
            ApplyRoundedRegion(this, 15);

            // ← نوسع الـ form عشان نضيف الحقول الجديدة
            this.ClientSize = new Size(480, 620);

            BuildAnimalTypeFilter();
            BuildCustomerSearch();

            // التاريخ تلقائياً اليوم — مخفي
            dtpDate.Value = DateTime.Today;
            pnlDate.Visible = false;
            lblDate.Visible = false;

            PopulateAnimalTypes();
            PopulateCustomers("");
        }

        // -------------------- Animal Type Filter --------------------
        private void BuildAnimalTypeFilter()
        {
            // Label النوع
            lblAnimalType = new Label
            {
                Text = "Animal Type",
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#2A332E"),
                Location = new Point(30, 95),
                AutoSize = true,
            };
            this.Controls.Add(lblAnimalType);
            lblAnimalType.BringToFront();

            // ComboBox النوع
            cmbAnimalType = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                ForeColor = ColorTranslator.FromHtml("#2A332E"),
                BackColor = Color.FromArgb(250, 248, 245),
                FormattingEnabled = true,
                Location = new Point(30, 115),
                Size = new Size(420, 28),
            };
            cmbAnimalType.SelectedIndexChanged += (s, ev) => FilterAnimalsByType();
            this.Controls.Add(cmbAnimalType);
            cmbAnimalType.BringToFront();

            // نزيح lblAnimal و pnlAnimal للأسفل
            lblAnimal.Location = new Point(30, 158);
            pnlAnimal.Location = new Point(30, 178);
        }

        private void PopulateAnimalTypes()
        {
            var types = AnimalsForm.SharedAnimals
                .Where(a => !string.Equals(a.Status, "Adopted", StringComparison.OrdinalIgnoreCase))
                .Select(a => a.Type)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            cmbAnimalType.Items.Clear();
            cmbAnimalType.Items.Add("All Types");
            foreach (var t in types)
                cmbAnimalType.Items.Add(t);

            cmbAnimalType.SelectedIndex = 0;
        }

        private void FilterAnimalsByType()
        {
            string selectedType = cmbAnimalType.SelectedItem?.ToString();

            var filtered = AnimalsForm.SharedAnimals
                .Where(a => !string.Equals(a.Status, "Adopted", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (selectedType != "All Types" && !string.IsNullOrEmpty(selectedType))
                filtered = filtered.Where(a => a.Type == selectedType).ToList();

            cmbAnimal.DataSource = null;
            cmbAnimal.DataSource = filtered;
            cmbAnimal.DisplayMember = "Name";
            cmbAnimal.ValueMember = "ID";

            if (cmbAnimal.Items.Count > 0)
                cmbAnimal.SelectedIndex = 0;
        }

        // -------------------- Customer Search --------------------
        private void BuildCustomerSearch()
        {
            // نزيح الكونترولز الموجودة للأسفل
            lblCustomer.Location = new Point(30, 240);
            pnlCustomer.Location = new Point(30, 260);
            lblDate.Location = new Point(30, 320);
            pnlDate.Location = new Point(30, 340);
            lblFee.Location = new Point(30, 400);
            flpFee.Location = new Point(30, 420);

            // Label البحث
            lblCustomerSearch = new Label
            {
                Text = "Search Customer (name or phone)",
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#2A332E"),
                Location = new Point(30, 310),
                AutoSize = true,
            };
            this.Controls.Add(lblCustomerSearch);
            lblCustomerSearch.BringToFront();

            // TextBox البحث
            txtCustomerSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.Gray,
                BackColor = Color.FromArgb(250, 248, 245),
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(30, 330),
                Size = new Size(420, 28),
                Text = "Type to search...",
            };
            txtCustomerSearch.Enter += (s, ev) =>
            {
                if (txtCustomerSearch.Text == "Type to search...")
                {
                    txtCustomerSearch.Text = "";
                    txtCustomerSearch.ForeColor = ColorTranslator.FromHtml("#2A332E");
                }
            };
            txtCustomerSearch.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCustomerSearch.Text))
                {
                    txtCustomerSearch.Text = "Type to search...";
                    txtCustomerSearch.ForeColor = Color.Gray;
                }
            };
            txtCustomerSearch.TextChanged += (s, ev) =>
            {
                if (txtCustomerSearch.Text != "Type to search...")
                    PopulateCustomers(txtCustomerSearch.Text.Trim());
            };
            this.Controls.Add(txtCustomerSearch);
            txtCustomerSearch.BringToFront();

            // نزيح lblCustomer و pnlCustomer تحت search
            lblCustomer.Location = new Point(30, 368);
            pnlCustomer.Location = new Point(30, 388);
            lblFee.Location = new Point(30, 445);
            flpFee.Location = new Point(30, 465);
        }

        private void PopulateCustomers(string search)
        {
            var customers = CustomersForm.SharedCustomers.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(search))
                customers = customers.Where(c =>
                    (c.Name ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.Phone ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);

            cmbCustomer.DataSource = null;
            cmbCustomer.DataSource = customers.ToList();
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "ID";

            if (cmbCustomer.Items.Count > 0)
                cmbCustomer.SelectedIndex = 0;
        }

        // -------------------- Confirm --------------------
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (cmbAnimal.SelectedItem == null)
            {
                MessageBox.Show("Please select an animal.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbCustomer.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedAnimal = cmbAnimal.SelectedItem as Animal;
            var selectedCustomer = cmbCustomer.SelectedItem as Customer;

            if (selectedAnimal == null || selectedCustomer == null) return;

            if (string.Equals(selectedAnimal.Status, "Adopted", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    $"'{selectedAnimal.Name}' has already been adopted.",
                    "Already Adopted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SelectedAnimalID = selectedAnimal.ID;
            SelectedCustomerID = selectedCustomer.ID;
            AnimalName = selectedAnimal.Name;
            CustomerName = selectedCustomer.Name;
            Phone = selectedCustomer.Phone ?? "";
            DateFormatted = DateTime.Today.ToString("MMM d, yyyy");
            FeePaid = rbPaid.Checked;
            AdoptionId = "#AD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            var animal = AnimalsForm.SharedAnimals.FirstOrDefault(a => a.ID == SelectedAnimalID);
            if (animal != null)
                animal.Status = "Adopted";

            AnimalsForm.AnimalsChanged?.Invoke(this, EventArgs.Empty);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void ApplyRoundedRegion(Control ctrl, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(ctrl.Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(ctrl.Width - (radius * 2), ctrl.Height - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(0, ctrl.Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();
                ctrl.Region = new Region(path);
            }
        }

        private void InputPanel_PaintRoundedBorder(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;
            int radius = 8;
            ApplyRoundedRegion(pnl, radius);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc(rect.Right - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc(rect.Right - (radius * 2), rect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseFigure();
                using (Pen pen = new Pen(ColorInputBorder, 1.5f))
                    e.Graphics.DrawPath(pen, path);
            }
        }

        private void Control_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;
            int radius = 8;
            ApplyRoundedRegion(ctrl, radius);
            if (ctrl.Name == "btnCancel")
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    Rectangle rect = new Rectangle(0, 0, ctrl.Width - 1, ctrl.Height - 1);
                    path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(rect.Right - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(rect.Right - (radius * 2), rect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
                    path.CloseFigure();
                    using (Pen pen = new Pen(ColorInputBorder, 1.5f))
                        e.Graphics.DrawPath(pen, path);
                }
            }
        }
    }
}