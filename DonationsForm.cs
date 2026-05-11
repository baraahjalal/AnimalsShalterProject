using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsShalterProject
{
    public partial class DonationsForm : Form
    {
        private static readonly Color ColorGreen = Color.FromArgb(69, 115, 87);
        private static readonly Color ColorLightGreen = Color.FromArgb(200, 225, 210);

        public static EventHandler DonationsChanged;
        public static List<Donation> SharedDonations = new List<Donation>();
        private BindingSource bsDonations = new BindingSource();

        public DonationsForm()
        {
            InitializeComponent();
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            // تطبيق الحواف الدائرية
            this.Load += (s, e) => {
                ApplyRoundedCorners(pnlStat1, 15);
                ApplyRoundedCorners(pnlStat2, 15);
                ApplyRoundedCorners(pnlStat3, 15);
                ApplyRoundedCorners(btnWeek, 10);
                ApplyRoundedCorners(btnMonth, 10);
                ApplyRoundedCorners(btnAllTime, 10);
            };

            // تخصيص رسم الجدول
            dgvDonations.CellPainting += DgvDonations_CellPainting;
            dgvDonations.CellFormatting += DgvDonations_CellFormatting;

            // Add New Donation Button
            Button btnNewDonation = new Button();
            btnNewDonation.Text = "+ New Donation";
            btnNewDonation.Size = new Size(130, 35);
            btnNewDonation.FlatStyle = FlatStyle.Flat;
            btnNewDonation.BackColor = ColorGreen;
            btnNewDonation.ForeColor = Color.White;
            btnNewDonation.Location = new Point(pnlFilters.Width - 150, 10);
            btnNewDonation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewDonation.Cursor = Cursors.Hand;
            btnNewDonation.Click += BtnNewDonation_Click;
            pnlFilters.Controls.Add(btnNewDonation);

            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvDonations.AutoGenerateColumns = false;
            dgvDonations.Columns.Clear();
            dgvDonations.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColAvatar", HeaderText = "", Width = 50 });
            dgvDonations.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColDonor", HeaderText = "Donor Name", DataPropertyName = "DonorName", FillWeight = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvDonations.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColAmount", HeaderText = "Amount", DataPropertyName = "Amount" });
            dgvDonations.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColCategory", HeaderText = "Category", DataPropertyName = "Category" });
            dgvDonations.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColDate", HeaderText = "Date", DataPropertyName = "DonationDate" });
        }

        private void DgvDonations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvDonations.Columns[e.ColumnIndex].Name == "ColAmount" && e.Value is decimal val)
            {
                e.Value = $"{val:N0} LYD";
                e.FormattingApplied = true;
            }
            if (dgvDonations.Columns[e.ColumnIndex].Name == "ColDate" && e.Value is DateTime dt)
            {
                e.Value = dt.ToString("MMM dd, yyyy");
                e.FormattingApplied = true;
            }
        }

        private void LoadData()
        {
            if (SharedDonations.Count == 0)
            {
                var c1 = CustomersForm.SharedCustomers.FirstOrDefault();
                var c2 = CustomersForm.SharedCustomers.Skip(1).FirstOrDefault() ?? c1;
                var c3 = CustomersForm.SharedCustomers.Skip(2).FirstOrDefault() ?? c1;

                if (c1 != null)
                {
                    DateTime today = DateTime.Today;
                    DateTime thisMonth = new DateTime(today.Year, today.Month, 5);
                    DateTime lastMonth = today.AddMonths(-1);

                    SharedDonations.Add(new Donation { ID = 1, CustomerID = c1.ID, DonorName = c1.Name, Amount = 450, Category = "Medicine", DonationDate = lastMonth });
                    SharedDonations.Add(new Donation { ID = 2, CustomerID = c2.ID, DonorName = c2.Name, Amount = 1200, Category = "Food", DonationDate = thisMonth });
                    SharedDonations.Add(new Donation { ID = 3, CustomerID = c3.ID, DonorName = c3.Name, Amount = 300, Category = "General", DonationDate = today });
                }
            }
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            bsDonations.DataSource = SharedDonations.ToList();
            dgvDonations.DataSource = bsDonations;
            UpdateStatCards();
        }

        private void UpdateStatCards()
        {
            pnlStat1.Controls.Clear();
            pnlStat2.Controls.Clear();
            pnlStat3.Controls.Clear();

            decimal totalDonations = SharedDonations.Sum(d => d.Amount);
            decimal thisMonthTotal = SharedDonations.Where(d => d.DonationDate.Month == DateTime.Today.Month && d.DonationDate.Year == DateTime.Today.Year).Sum(d => d.Amount);
            int totalCount = SharedDonations.Count;

            AddStatLabels(pnlStat1, "Total Donations", $"{totalDonations:N0} LYD", "");
            AddStatLabels(pnlStat2, "This Month", $"{thisMonthTotal:N0} LYD", "");
            AddStatLabels(pnlStat3, "Number of Donations", totalCount.ToString(), "");
        }

        private int GetNextDonationId()
        {
            return SharedDonations.Count == 0 ? 1 : SharedDonations.Max(d => d.ID) + 1;
        }

        private void BtnNewDonation_Click(object sender, EventArgs e)
        {
            using (Form inlineForm = new Form())
            {
                inlineForm.Text = "New Donation";
                inlineForm.Size = new Size(400, 350);
                inlineForm.StartPosition = FormStartPosition.CenterParent;
                inlineForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inlineForm.MaximizeBox = false;
                inlineForm.MinimizeBox = false;
                inlineForm.BackColor = Color.White;

                Label lblCust = new Label { Text = "Customer:", Location = new Point(20, 20), AutoSize = true };
                ComboBox cmbCustomer = new ComboBox { Location = new Point(120, 20), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                cmbCustomer.DataSource = CustomersForm.SharedCustomers.ToList();
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "ID";

                Label lblAmt = new Label { Text = "Amount (LYD):", Location = new Point(20, 60), AutoSize = true };
                TextBox txtAmount = new TextBox { Location = new Point(120, 60), Width = 200 };

                Label lblCat = new Label { Text = "Category:", Location = new Point(20, 100), AutoSize = true };
                ComboBox cmbCategory = new ComboBox { Location = new Point(120, 100), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                cmbCategory.Items.AddRange(new object[] { "General", "Food", "Medicine", "Shelter", "Equipment", "Other" });
                cmbCategory.SelectedIndex = 0;

                Label lblDate = new Label { Text = "Date:", Location = new Point(20, 140), AutoSize = true };
                DateTimePicker dtpDate = new DateTimePicker { Location = new Point(120, 140), Width = 200 };

                Button btnSave = new Button { Text = "Save", Location = new Point(120, 200), Width = 80, DialogResult = DialogResult.OK, BackColor = ColorGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                Button btnCancel = new Button { Text = "Cancel", Location = new Point(220, 200), Width = 80, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };

                inlineForm.Controls.AddRange(new Control[] { lblCust, cmbCustomer, lblAmt, txtAmount, lblCat, cmbCategory, lblDate, dtpDate, btnSave, btnCancel });
                inlineForm.AcceptButton = btnSave;
                inlineForm.CancelButton = btnCancel;

                inlineForm.FormClosing += (s, ev) =>
                {
                    if (inlineForm.DialogResult == DialogResult.OK)
                    {
                        if (cmbCustomer.SelectedItem == null)
                        {
                            MessageBox.Show("Please select a customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ev.Cancel = true;
                            return;
                        }
                        if (!decimal.TryParse(txtAmount.Text, out decimal amt) || amt <= 0)
                        {
                            MessageBox.Show("Please enter a valid amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ev.Cancel = true;
                            return;
                        }
                    }
                };

                if (inlineForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedCust = (Customer)cmbCustomer.SelectedItem;
                    decimal amt = decimal.Parse(txtAmount.Text);
                    
                    Donation newDonation = new Donation
                    {
                        ID = GetNextDonationId(),
                        CustomerID = selectedCust.ID,
                        DonorName = selectedCust.Name,
                        Amount = amt,
                        Category = cmbCategory.SelectedItem.ToString(),
                        DonationDate = dtpDate.Value
                    };

                    SharedDonations.Add(newDonation);
                    RefreshGrid();
                    DonationsChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void AddStatLabels(Panel p, string title, string val, string badge)
        {
            Label lblT = new Label { Text = title, Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray, Location = new Point(15, 15), AutoSize = true };
            Label lblV = new Label { Text = val, Font = new Font("Segoe UI Bold", 16F), Location = new Point(15, 40), AutoSize = true };
            Label lblB = new Label { Text = badge, Font = new Font("Segoe UI Bold", 8F), ForeColor = ColorGreen, BackColor = ColorLightGreen, Location = new Point(15, 75), Padding = new Padding(5, 2, 5, 2), AutoSize = true };
            if (string.IsNullOrEmpty(badge)) lblB.Visible = false;
            p.Controls.AddRange(new Control[] { lblT, lblV, lblB });
        }

        // --- الرسم المخصص للجدول ---
        private void DgvDonations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // رسم الأفاتار الدائري (العمود الأول)
            if (e.ColumnIndex == 0)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle r = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 10, 35, 35);
                using (SolidBrush b = new SolidBrush(ColorLightGreen)) {
                    e.Graphics.FillEllipse(b, r);
                }
                e.Handled = true;
            }

            // رسم الـ Badge (عمود الفئة)
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                string text = e.Value.ToString();
                Size sz = TextRenderer.MeasureText(text, dgvDonations.Font);
                Rectangle r = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 15, sz.Width + 10, 25);
                
                using (GraphicsPath path = GetRoundedPath(r, 10))
                using (SolidBrush b = new SolidBrush(ColorLightGreen)) {
                    e.Graphics.FillPath(b, path);
                    e.Graphics.DrawString(text, dgvDonations.Font, Brushes.DarkGreen, e.CellBounds.X + 15, e.CellBounds.Y + 20);
                }
                e.Handled = true;
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius, radius, 180, 90);
            path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void ApplyRoundedCorners(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using (GraphicsPath path = GetRoundedPath(new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius))
                ctrl.Region = new Region(path);
        }
    }
}
