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
        // --- STATIC SHARED LIST (mirrors AnimalsForm.SharedAnimals pattern) ---
        public static EventHandler CustomersChanged;
        public static List<Customer> SharedCustomers = new List<Customer>();
        private BindingSource bsCustomers = new BindingSource();

        // --- STYLING CONSTANTS (copied exactly from AnimalsForm) ---
        private readonly Color ColorPrimaryGreen  = ColorTranslator.FromHtml("#457357");
        private readonly Color ColorTextPrimary   = ColorTranslator.FromHtml("#2A332E");
        private readonly Color ColorTextSecondary = ColorTranslator.FromHtml("#8A938D");

        public CustomersForm()
        {
            InitializeComponent();

            // Wire events
            this.btnAddCustomer.Click += BtnAddCustomer_Click;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvCustomers.CellMouseClick += DgvCustomers_CellMouseClick;
            this.dgvCustomers.CellPainting   += DgvCustomers_CellPainting;

            this.Load += CustomersForm_Load;
        }

        // -------------------- Load --------------------
        private void CustomersForm_Load(object sender, EventArgs e)
        {
            if (SharedCustomers.Count == 0)
            {
                SharedCustomers.Add(new Customer { ID = 1, Name = "Ahmed Ali",      Phone = "091-234-5678", Email = "ahmed.ali@email.com",      JoinDate = new DateTime(2022, 3, 15) });
                SharedCustomers.Add(new Customer { ID = 2, Name = "Sara Mohamed",   Phone = "092-876-5432", Email = "sara.m@email.com",          JoinDate = new DateTime(2023, 1, 8)  });
                SharedCustomers.Add(new Customer { ID = 3, Name = "Khalid Omar",    Phone = "091-998-1122", Email = "khalid.omar@email.com",     JoinDate = new DateTime(2021, 11, 20) });
                SharedCustomers.Add(new Customer { ID = 4, Name = "Fatima Hassan",  Phone = "093-445-6677", Email = "fatima.h@email.com",        JoinDate = new DateTime(2023, 6, 1)  });
                SharedCustomers.Add(new Customer { ID = 5, Name = "Yusuf Ibrahim",  Phone = "091-332-9988", Email = "yusuf.ibrahim@email.com",   JoinDate = new DateTime(2022, 9, 14) });
            }

            SetupGrid();
            RefreshGrid();
        }

        // -------------------- SetupGrid (called once) --------------------
        private void SetupGrid()
        {
            dgvCustomers.AutoGenerateColumns = false;

            dgvCustomers.Columns.Clear();

            // Hidden ID column
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "ColId", HeaderText = "ID",
                DataPropertyName = "ID", Visible = false
            };
            dgvCustomers.Columns.Add(colId);

            var colName = new DataGridViewTextBoxColumn
            {
                Name = "ColName", HeaderText = "Customer Name",
                DataPropertyName = "Name"
            };
            dgvCustomers.Columns.Add(colName);

            var colPhone = new DataGridViewTextBoxColumn
            {
                Name = "ColPhone", HeaderText = "Phone",
                DataPropertyName = "Phone"
            };
            dgvCustomers.Columns.Add(colPhone);

            var colEmail = new DataGridViewTextBoxColumn
            {
                Name = "ColEmail", HeaderText = "Email",
                DataPropertyName = "Email"
            };
            dgvCustomers.Columns.Add(colEmail);

            var colJoin = new DataGridViewTextBoxColumn
            {
                Name = "ColJoinDate", HeaderText = "Join Date",
                DataPropertyName = "JoinDate"
            };
            dgvCustomers.Columns.Add(colJoin);

            var colActions = new DataGridViewTextBoxColumn
            {
                Name = "ColActions", HeaderText = "Actions"
            };
            dgvCustomers.Columns.Add(colActions);

            dgvCustomers.DataSource = bsCustomers;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // -------------------- RefreshGrid --------------------
        private void RefreshGrid()
        {
            string search = txtSearch.Text?.Trim();
            IEnumerable<Customer> q = SharedCustomers;

            if (!string.IsNullOrWhiteSpace(search) && search != "Search customers...")
            {
                q = q.Where(c =>
                    (c.Name  ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (c.Phone ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            bsCustomers.DataSource = q.ToList();
            dgvCustomers.Refresh();
        }

        // -------------------- GetNextCustomerId --------------------
        private int GetNextCustomerId()
        {
            return SharedCustomers.Count == 0 ? 1 : SharedCustomers.Max(c => c.ID) + 1;
        }

        // -------------------- Search --------------------
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        // -------------------- Add Customer --------------------
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
                        var c = new Customer
                        {
                            ID       = GetNextCustomerId(),
                            Name     = dlg.CustomerName,
                            Phone    = dlg.CustomerPhone,
                            Email    = dlg.CustomerEmail,
                            JoinDate = DateTime.Today
                        };
                        SharedCustomers.Add(c);
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

        // -------------------- Cell Click: Edit / Delete --------------------
        private void DgvCustomers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgvCustomers.Columns[e.ColumnIndex];
            if (col.Name != "ColActions") return;

            Rectangle cellRect = dgvCustomers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int relativeX = e.X - cellRect.X;
            bool isEdit   = relativeX < cellRect.Width / 2;

            var bound = dgvCustomers.Rows[e.RowIndex].DataBoundItem as Customer;
            if (bound == null) return;

            int id = bound.ID;

            if (isEdit)
            {
                var customer = SharedCustomers.FirstOrDefault(c => c.ID == id);
                if (customer == null) return;

                try
                {
                    using (var dlg = new NewCustomerForm())
                    {
                        dlg.StartPosition = FormStartPosition.CenterParent;
                        dlg.SetTitle("Edit Customer");
                        dlg.LoadCustomerData(customer.ID, customer.Name, customer.Phone, customer.Email);

                        if (dlg.ShowDialog(this) == DialogResult.OK)
                        {
                            customer.Name  = dlg.CustomerName;
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
                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this customer?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                var toRemove = SharedCustomers.FirstOrDefault(c => c.ID == id);
                if (toRemove != null)
                {
                    SharedCustomers.Remove(toRemove);
                    RefreshGrid();
                    CustomersChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        // -------------------- Cell Painting (Actions column icons) --------------------
        private void DgvCustomers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgvCustomers.Columns[e.ColumnIndex];
            if (col.Name != "ColActions") return;

            e.PaintBackground(e.CellBounds, true);

            int centerX = e.CellBounds.X + (e.CellBounds.Width / 2) - 10;
            int centerY = e.CellBounds.Y + (e.CellBounds.Height / 2);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Left half: pencil/edit icon
            using (Pen pen = new Pen(ColorTextSecondary, 2f))
            {
                Point p1 = new Point(centerX - 4, centerY + 4);
                Point p2 = new Point(centerX + 4, centerY - 4);
                e.Graphics.DrawLine(pen, p1, p2);

                Point[] tip = {
                    new Point(centerX - 6, centerY + 6),
                    new Point(centerX - 4, centerY + 4),
                    new Point(centerX - 6, centerY + 4)
                };
                using (SolidBrush brush = new SolidBrush(ColorTextSecondary))
                    e.Graphics.FillPolygon(brush, tip);
            }

            // Right half: delete X icon
            int dx = centerX + 18;
            using (Pen redPen = new Pen(Color.FromArgb(211, 47, 47), 2f))
            {
                e.Graphics.DrawLine(redPen, dx - 4, centerY - 4, dx + 4, centerY + 4);
                e.Graphics.DrawLine(redPen, dx + 4, centerY - 4, dx - 4, centerY + 4);
            }

            e.Handled = true;
        }

        // -------------------- Paint helpers (copied from AnimalsForm) --------------------
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
