using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class CustomersForm : Form
    {
        public static EventHandler CustomersChanged;
        public static List<Customer> SharedCustomers = new List<Customer>();
        private BindingSource bsCustomers = new BindingSource();

        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");
        private readonly Color ColorTextPrimary = ColorTranslator.FromHtml("#2A332E");
        private readonly Color ColorTextSecondary = ColorTranslator.FromHtml("#8A938D");

        private TabControl tabHistory;
        private DataGridView dgvHistoryAdoptions;
        private DataGridView dgvHistorySales;
        private DataGridView dgvHistoryDonations;
        private Label lblNoSelection;

        public CustomersForm()
        {
            InitializeComponent();

            this.btnAddCustomer.Click += BtnAddCustomer_Click;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvCustomers.CellMouseClick += DgvCustomers_CellMouseClick;
            this.dgvCustomers.CellPainting += DgvCustomers_CellPainting;
            this.dgvCustomers.SelectionChanged += DgvCustomers_SelectionChanged;

            this.Load += CustomersForm_Load;
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            if (SharedCustomers.Count == 0)
            {
                SharedCustomers.Add(new Customer { ID = 1, Name = "Ahmed Ali", Phone = "091-234-5678", Email = "ahmed.ali@email.com", JoinDate = new DateTime(2022, 3, 15) });
                SharedCustomers.Add(new Customer { ID = 2, Name = "Sara Mohamed", Phone = "092-876-5432", Email = "sara.m@email.com", JoinDate = new DateTime(2023, 1, 8) });
                SharedCustomers.Add(new Customer { ID = 3, Name = "Khalid Omar", Phone = "091-998-1122", Email = "khalid.omar@email.com", JoinDate = new DateTime(2021, 11, 20) });
                SharedCustomers.Add(new Customer { ID = 4, Name = "Fatima Hassan", Phone = "093-445-6677", Email = "fatima.h@email.com", JoinDate = new DateTime(2023, 6, 1) });
                SharedCustomers.Add(new Customer { ID = 5, Name = "Yusuf Ibrahim", Phone = "091-332-9988", Email = "yusuf.ibrahim@email.com", JoinDate = new DateTime(2022, 9, 14) });
            }

            SetupGrid();
            RefreshGrid();
            SetupHistoryPanel();
        }

        private void SetupGrid()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColId", HeaderText = "ID", DataPropertyName = "ID", Visible = false });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColName", HeaderText = "Customer Name", DataPropertyName = "Name" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColPhone", HeaderText = "Phone", DataPropertyName = "Phone" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColEmail", HeaderText = "Email", DataPropertyName = "Email" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColJoinDate", HeaderText = "Join Date", DataPropertyName = "JoinDate" });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColActions", HeaderText = "Actions" });

            dgvCustomers.DataSource = bsCustomers;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupHistoryPanel()
        {
            // تصغير الجدول للنصف العلوي
            dgvCustomers.Dock = DockStyle.None;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.Height = this.ClientSize.Height / 2 - 60;
            dgvCustomers.Width = this.ClientSize.Width - dgvCustomers.Left * 2;

            // label "اختر زبون" يظهر في البداية
            lblNoSelection = new Label
            {
                Text = "👆 Select a customer to view their history",
                Font = new Font("Segoe UI", 11f),
                ForeColor = ColorTextSecondary,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Left = dgvCustomers.Left,
                Top = dgvCustomers.Bottom + 10,
                Width = dgvCustomers.Width,
                Height = this.ClientSize.Height - dgvCustomers.Bottom - 20,
                Visible = true
            };
            this.Controls.Add(lblNoSelection);
            lblNoSelection.BringToFront();

            // TabControl مخفي في البداية
            tabHistory = new TabControl
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Left = dgvCustomers.Left,
                Top = dgvCustomers.Bottom + 10,
                Width = dgvCustomers.Width,
                Height = this.ClientSize.Height - dgvCustomers.Bottom - 20,
                Font = new Font("Segoe UI", 9f),
                Visible = false  // ← مخفي في البداية
            };

            // Tab 1 — Adoptions
            var tabAdoptions = new TabPage("🐾 Adoptions");
            dgvHistoryAdoptions = CreateHistoryGrid();
            dgvHistoryAdoptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Animal", DataPropertyName = "AnimalName", FillWeight = 40 });
            dgvHistoryAdoptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "AdoptionDate", FillWeight = 30 });
            dgvHistoryAdoptions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fee (LYD)", DataPropertyName = "FeePaid", FillWeight = 30 });
            tabAdoptions.Controls.Add(dgvHistoryAdoptions);
            tabHistory.TabPages.Add(tabAdoptions);

            // Tab 2 — Purchases
            var tabSales = new TabPage("🛒 Purchases");
            dgvHistorySales = CreateHistoryGrid();
            dgvHistorySales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "SaleDate", FillWeight = 40 });
            dgvHistorySales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total (LYD)", DataPropertyName = "TotalAmount", FillWeight = 60 });
            tabSales.Controls.Add(dgvHistorySales);
            tabHistory.TabPages.Add(tabSales);

            // Tab 3 — Donations
            var tabDonations = new TabPage("💚 Donations");
            dgvHistoryDonations = CreateHistoryGrid();
            dgvHistoryDonations.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "DonationDate", FillWeight = 35 });
            dgvHistoryDonations.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Amount (LYD)", DataPropertyName = "Amount", FillWeight = 35 });
            dgvHistoryDonations.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = "Category", FillWeight = 30 });
            tabDonations.Controls.Add(dgvHistoryDonations);
            tabHistory.TabPages.Add(tabDonations);

            this.Controls.Add(tabHistory);
            tabHistory.BringToFront();
        }

        private DataGridView CreateHistoryGrid()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 9f),
                RowTemplate = { Height = 36 },
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(240, 240, 240),
                EnableHeadersVisualStyles = false,
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimaryGreen;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            return dgv;
        }

        private void DgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (tabHistory == null) return;

            if (dgvCustomers.SelectedRows.Count == 0)
            {
                // أخفي الـ tabs وأظهر رسالة الاختيار
                tabHistory.Visible = false;
                lblNoSelection.Visible = true;
                return;
            }

            var bound = dgvCustomers.SelectedRows[0].DataBoundItem as Customer;
            if (bound == null) return;

            int cid = bound.ID;

            // أظهر الـ tabs وأخفي رسالة الاختيار
            lblNoSelection.Visible = false;
            tabHistory.Visible = true;

            dgvHistoryAdoptions.DataSource = AdoptionForm.SharedAdoptions?
                .Where(a => a.CustomerID == cid).ToList();

            dgvHistorySales.DataSource = SalesForm.SharedSales?
                .Where(s => s.CustomerID == cid).ToList();

            dgvHistoryDonations.DataSource = DonationsForm.SharedDonations?
                .Where(d => d.CustomerID == cid).ToList();
        }

        private void RefreshGrid()
        {
            string search = txtSearch.Text?.Trim();
            IEnumerable<Customer> q = SharedCustomers;

            if (!string.IsNullOrWhiteSpace(search) && search != "Search customers...")
                q = q.Where(c =>
                    (c.Name ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.Phone ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);

            bsCustomers.DataSource = q.ToList();
            dgvCustomers.Refresh();
        }

        private int GetNextCustomerId()
        {
            return SharedCustomers.Count == 0 ? 1 : SharedCustomers.Max(c => c.ID) + 1;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) => RefreshGrid();

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new NewCustomerForm())
                {
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.SetTitle("Add New Customer");

                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        SharedCustomers.Add(new Customer
                        {
                            ID = GetNextCustomerId(),
                            Name = dlg.CustomerName,
                            Phone = dlg.CustomerPhone,
                            Email = dlg.CustomerEmail,
                            JoinDate = DateTime.Today
                        });
                        RefreshGrid();
                        CustomersChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Add Customer form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCustomers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvCustomers.Columns[e.ColumnIndex].Name != "ColActions") return;

            Rectangle cellRect = dgvCustomers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            bool isEdit = (e.X - cellRect.X) < cellRect.Width / 2;

            var bound = dgvCustomers.Rows[e.RowIndex].DataBoundItem as Customer;
            if (bound == null) return;

            var customer = SharedCustomers.FirstOrDefault(c => c.ID == bound.ID);
            if (customer == null) return;

            if (isEdit)
            {
                try
                {
                    using (var dlg = new NewCustomerForm())
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.SetTitle("Edit Customer");
                        dlg.LoadCustomerData(customer.ID, customer.Name, customer.Phone, customer.Email);

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            customer.Name = dlg.CustomerName;
                            customer.Phone = dlg.CustomerPhone;
                            customer.Email = dlg.CustomerEmail;
                            RefreshGrid();
                            CustomersChanged?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open Edit Customer form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SharedCustomers.Remove(customer);
                    RefreshGrid();
                    CustomersChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void DgvCustomers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvCustomers.Columns[e.ColumnIndex].Name != "ColActions") return;

            e.PaintBackground(e.CellBounds, true);

            int centerX = e.CellBounds.X + (e.CellBounds.Width / 2) - 10;
            int centerY = e.CellBounds.Y + (e.CellBounds.Height / 2);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(ColorTextSecondary, 2f))
            {
                e.Graphics.DrawLine(pen, new Point(centerX - 4, centerY + 4), new Point(centerX + 4, centerY - 4));
                using (SolidBrush brush = new SolidBrush(ColorTextSecondary))
                    e.Graphics.FillPolygon(brush, new Point[] {
                        new Point(centerX - 6, centerY + 6),
                        new Point(centerX - 4, centerY + 4),
                        new Point(centerX - 6, centerY + 4)
                    });
            }

            int dx = centerX + 18;
            using (Pen redPen = new Pen(Color.FromArgb(211, 47, 47), 2f))
            {
                e.Graphics.DrawLine(redPen, dx - 4, centerY - 4, dx + 4, centerY + 4);
                e.Graphics.DrawLine(redPen, dx + 4, centerY - 4, dx - 4, centerY + 4);
            }

            e.Handled = true;
        }

        private void Panel_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;
            int radius = 16;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
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
    }
}