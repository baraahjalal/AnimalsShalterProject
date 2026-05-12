using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class MainForm : Form
    {
        private Button _activeButton;
        private Panel pnlVaccineAlerts;

        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");
        private readonly Color ColorCardBackground = ColorTranslator.FromHtml("#FFFFFF");
        private readonly Color ColorFormBackground = ColorTranslator.FromHtml("#FAF8F5");
        private readonly Color ColorTextPrimary = ColorTranslator.FromHtml("#2A332E");
        private readonly Color ColorTextSecondary = ColorTranslator.FromHtml("#8A938D");

        public MainForm()
        {
            InitializeComponent();
            SetupUI();
            EnsureDataLoaded();
            ApplyRoundedCornersToCards();
            WireEvents();
            ShowDashboard();
        }

        private void SetupUI()
        {
            this.Text = "PawShelter Management System";
            this.WindowState = FormWindowState.Maximized;
            lblDate.Text = DateTime.Now.ToString("dddd, MMM dd, yyyy");
            lblWelcome.Text = $"Welcome, {Session.CurrentUser ?? "Admin"}";

            btnAddNewEntry.Text = "⏻  Logout";
            btnAddNewEntry.ForeColor = Color.FromArgb(198, 40, 40);
            btnAddNewEntry.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void EnsureDataLoaded()
        {
            if (AnimalsForm.SharedAnimals.Count == 0)
            {
                AnimalsForm.SharedAnimals.Add(new Animal { ID = 1, Name = "Buddy", Type = "Dog", Age = "3 Years", HealthStatus = "Vaccinated", Status = "Available", IsVaccinated = true, LastVaccineDate = DateTime.Today.AddDays(-20), VaccineDate = DateTime.Today.AddDays(10) });
                AnimalsForm.SharedAnimals.Add(new Animal { ID = 2, Name = "Mittens", Type = "Cat", Age = "2 Years", HealthStatus = "Needs Vaccine", Status = "Sick", IsVaccinated = false, LastVaccineDate = DateTime.Today, VaccineDate = DateTime.Today.AddMonths(1) });
                AnimalsForm.SharedAnimals.Add(new Animal { ID = 3, Name = "Rex", Type = "Dog", Age = "5 Years", HealthStatus = "Vaccinated", Status = "Adopted", IsVaccinated = true, LastVaccineDate = DateTime.Today.AddDays(-35), VaccineDate = DateTime.Today.AddDays(-5) });
                AnimalsForm.SharedAnimals.Add(new Animal { ID = 4, Name = "Tweety", Type = "Bird", Age = "1 Year", HealthStatus = "Vaccinated", Status = "Available" });
            }

            if (ProductsForm.SharedProducts.Count == 0)
            {
                ProductsForm.SharedProducts.Add(new Product { ID = 1, Name = "Premium Dog Food", Category = "Food", Price = 120m, Stock = 85, Status = "In Stock" });
                ProductsForm.SharedProducts.Add(new Product { ID = 2, Name = "Cat Litter 10kg", Category = "Food", Price = 45m, Stock = 3, Status = "Low Stock" });
                ProductsForm.SharedProducts.Add(new Product { ID = 3, Name = "Squeaky Toy", Category = "Toys", Price = 15m, Stock = 60, Status = "In Stock" });
                ProductsForm.SharedProducts.Add(new Product { ID = 4, Name = "Flea Shampoo", Category = "Medical", Price = 35m, Stock = 2, Status = "Low Stock" });
                ProductsForm.SharedProducts.Add(new Product { ID = 5, Name = "Dog Leash", Category = "Accessories", Price = 25m, Stock = 40, Status = "In Stock" });
            }

            if (CustomersForm.SharedCustomers.Count == 0)
            {
                CustomersForm.SharedCustomers.Add(new Customer { ID = 1, Name = "Ahmed Ali", Phone = "091-234-5678", Email = "", JoinDate = new DateTime(2022, 3, 15) });
                CustomersForm.SharedCustomers.Add(new Customer { ID = 2, Name = "Sara Mohamed", Phone = "092-876-5432", Email = "", JoinDate = new DateTime(2023, 1, 8) });
                CustomersForm.SharedCustomers.Add(new Customer { ID = 3, Name = "Khalid Omar", Phone = "091-998-1122", Email = "", JoinDate = new DateTime(2021, 11, 20) });
                CustomersForm.SharedCustomers.Add(new Customer { ID = 4, Name = "Fatima Hassan", Phone = "093-445-6677", Email = "", JoinDate = new DateTime(2023, 6, 1) });
            }

            if (AdoptionForm.SharedAdoptions.Count == 0)
            {
                AdoptionForm.SharedAdoptions.Add(new Adoption { ID = 1, AnimalID = 3, AnimalName = "Rex", CustomerID = 1, CustomerName = "Ahmed Ali", AdoptionDate = DateTime.Today.AddDays(-5), FeePaid = 50m });
            }
        }

        private void WireEvents()
        {
            btnDashboard.Click += (s, e) => { SetActiveButton(btnDashboard); ShowDashboard(); };
            btnAnimals.Click += (s, e) => { SetActiveButton(btnAnimals); SwitchView(new AnimalsForm()); };
            btnProducts.Click += (s, e) => { SetActiveButton(btnProducts); SwitchView(new ProductsForm()); };
            btnSales.Click += (s, e) => { SetActiveButton(btnSales); SwitchView(new SalesForm()); };
            btnAdoptions.Click += (s, e) => { SetActiveButton(btnAdoptions); SwitchView(new AdoptionForm()); };
            btnDonations.Click += (s, e) => { SetActiveButton(btnDonations); SwitchView(new DonationsForm()); };
            btnCustomers.Click += (s, e) => { SetActiveButton(btnCustomers); SwitchView(new CustomersForm()); };

            btnAddNewEntry.Click += (s, e) =>
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    Session.CurrentUser = null;
                    var loginForm = new LoginForm();
                    loginForm.Show();
                    this.Close();
                }
            };
        }

        public void SwitchView(Control view)
        {
            pnlMainContent.Controls.Clear();
            if (view is Form form)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(form);
                form.Show();
            }
            else
            {
                view.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(view);
            }
        }

        private void ShowDashboard()
        {
            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(tlpDashboard);
            pnlMainContent.Controls.Add(flpStats);

            BuildVaccineAlertsPanel();

            RefreshDashboardStats();
            RefreshRecentAdoptions();
            RefreshLowStockAlerts();
            RefreshVaccineAlerts();
            WireStatCards();
        }

        // -------------------- Stat Cards Clickable --------------------
        private void WireStatCards()
        {
            MakeCardClickable(pnlStatCard1, () => { SetActiveButton(btnAnimals); SwitchView(new AnimalsForm()); });
            MakeCardClickable(pnlStatCard2, () => { SetActiveButton(btnAnimals); SwitchView(new AnimalsForm()); });
            MakeCardClickable(pnlStatCard3, () => { SetActiveButton(btnProducts); SwitchView(new ProductsForm()); });
            MakeCardClickable(pnlStatCard4, () => { SetActiveButton(btnSales); SwitchView(new SalesForm()); });
            MakeCardClickable(pnlAlerts, () => { SetActiveButton(btnProducts); SwitchView(new ProductsForm()); });
        }

        private void MakeCardClickable(Panel panel, Action onClick)
        {
            if (panel == null) return;
            panel.Cursor = Cursors.Hand;
            panel.Click += (s, e) => onClick();
            foreach (Control child in panel.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.Click += (s, e) => onClick();
            }
        }

        // -------------------- Vaccine Alerts --------------------
        private void BuildVaccineAlertsPanel()
        {
            if (pnlVaccineAlerts != null && pnlMainContent.Controls.Contains(pnlVaccineAlerts))
                pnlMainContent.Controls.Remove(pnlVaccineAlerts);

            pnlVaccineAlerts = new Panel
            {
                BackColor = Color.FromArgb(255, 235, 238),
                Width = 300,
                Height = 0,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Padding = new Padding(12),
                BorderStyle = BorderStyle.None,
            };

            pnlVaccineAlerts.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(183, 28, 28), 2f))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Rectangle rect = new Rectangle(1, 1, pnlVaccineAlerts.Width - 2, pnlVaccineAlerts.Height - 2);
                    int r = 10;
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                        path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
                        path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
                        path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
                        path.CloseFigure();
                        pnlVaccineAlerts.Region = new Region(path);
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            pnlMainContent.Controls.Add(pnlVaccineAlerts);
            pnlVaccineAlerts.BringToFront();
        }

        public void RefreshVaccineAlertsPublic() => RefreshVaccineAlerts();

        private void RefreshVaccineAlerts()
        {
            if (pnlVaccineAlerts == null) return;
            pnlVaccineAlerts.Controls.Clear();

            var toShow = AnimalsForm.SharedAnimals?
                .Where(a => (a.Type == "Dog" || a.Type == "Cat")
                         && a.VaccineDate.HasValue
                         && (a.VaccineDate.Value.Date - DateTime.Today).Days <= 14)
                .OrderBy(a => a.VaccineDate.Value.Date)
                .ToList();

            if (toShow == null || toShow.Count == 0)
            {
                pnlVaccineAlerts.Visible = false;
                return;
            }

            pnlVaccineAlerts.Visible = true;

            int top = 10;

            var lblTitle = new Label
            {
                Text = "🔴  Vaccine Reminders",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(183, 28, 28),
                Left = 12,
                Top = top,
                Width = 276,
                Height = 22,
            };
            pnlVaccineAlerts.Controls.Add(lblTitle);
            top += 26;

            var sep = new Panel
            {
                Left = 12,
                Top = top,
                Width = 276,
                Height = 1,
                BackColor = Color.FromArgb(220, 180, 180),
            };
            pnlVaccineAlerts.Controls.Add(sep);
            top += 8;

            foreach (var a in toShow)
            {
                int daysLeft = (a.VaccineDate.Value.Date - DateTime.Today).Days;
                string icon = daysLeft < 0 ? "⛔" : daysLeft == 0 ? "🔔" : "⚠️";
                string days = daysLeft < 0 ? $"Overdue {-daysLeft}d"
                             : daysLeft == 0 ? "TODAY"
                             : $"{daysLeft} days left";

                var row = new Label
                {
                    Text = $"{icon} {a.Name} ({a.Type})  •  {a.VaccineDate.Value:MMM dd}  •  {days}",
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = daysLeft < 0
                        ? Color.FromArgb(183, 28, 28)
                        : Color.FromArgb(109, 0, 26),
                    Left = 12,
                    Top = top,
                    Width = 276,
                    Height = 30,
                    TextAlign = ContentAlignment.MiddleLeft,
                };
                pnlVaccineAlerts.Controls.Add(row);
                top += 32;
            }

            pnlVaccineAlerts.Height = top + 10;
            pnlVaccineAlerts.Left = pnlMainContent.Width - pnlVaccineAlerts.Width - 20;
            pnlVaccineAlerts.Top = 20;
        }

        // -------------------- Dashboard Stats --------------------
        private void RefreshDashboardStats()
        {
            lblStatValue1.Text = AnimalsForm.SharedAnimals?.Count.ToString() ?? "0";
            lblStatValue2.Text = AnimalsForm.SharedAnimals?.Count(a => a.Status == "Adopted").ToString() ?? "0";
            lblStatValue3.Text = ProductsForm.SharedProducts?.Count.ToString() ?? "0";
            decimal totalSales = SalesForm.SharedSales?.Sum(s => s.TotalAmount) ?? 0;
            lblStatValue4.Text = totalSales.ToString("F2") + " LYD";
        }

        private void RefreshRecentAdoptions()
        {
            dgvRecentAdoptions.Rows.Clear();

            var adoptedAnimals = AnimalsForm.SharedAnimals?
                .Where(a => string.Equals(a.Status, "Adopted", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (adoptedAnimals == null || adoptedAnimals.Count == 0)
            {
                dgvRecentAdoptions.Rows.Add("No adopted animals yet", "-", "-", "-");
                return;
            }

            foreach (var animal in adoptedAnimals)
            {
                var adoption = AdoptionForm.SharedAdoptions?
                    .FirstOrDefault(a => a.AnimalID == animal.ID);

                dgvRecentAdoptions.Rows.Add(
                    animal.Name,
                    adoption?.CustomerName ?? "-",
                    adoption?.AdoptionDate.ToString("MMM dd, yyyy") ?? "-",
                    "Adopted ✓"
                );
            }
        }

        private void RefreshLowStockAlerts()
        {
            var toRemove = pnlAlerts.Controls
                .Cast<Control>()
                .Where(c => c.Name != "lblAlertsTitle")
                .ToList();
            foreach (var c in toRemove)
                pnlAlerts.Controls.Remove(c);

            var lowStock = ProductsForm.SharedProducts?
                .Where(p => p.Stock < 5)
                .OrderBy(p => p.Stock)
                .ToList();

            if (lowStock == null || lowStock.Count == 0)
            {
                var lblOk = new Label
                {
                    Text = "✅ All products are well stocked",
                    Font = new Font("Segoe UI", 9f),
                    ForeColor = ColorPrimaryGreen,
                    AutoSize = false,
                    Width = pnlAlerts.Width - 40,
                    Height = 30,
                    Left = 20,
                    Top = 70,
                };
                pnlAlerts.Controls.Add(lblOk);
                return;
            }

            int top = 70;
            foreach (var product in lowStock)
            {
                var pnl = new Panel
                {
                    Left = 20,
                    Top = top,
                    Width = pnlAlerts.Width - 40,
                    Height = 52,
                    BackColor = product.Stock == 0
                        ? Color.FromArgb(255, 235, 238)
                        : Color.FromArgb(255, 243, 205),
                    Cursor = Cursors.Hand,
                };

                var lblName = new Label
                {
                    Text = product.Name,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    ForeColor = ColorTextPrimary,
                    Left = 10,
                    Top = 8,
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                };

                var lblStock = new Label
                {
                    Text = product.Stock == 0
                        ? "⚠️ Out of Stock"
                        : $"⚠️ Only {product.Stock} left",
                    Font = new Font("Segoe UI", 8f),
                    ForeColor = product.Stock == 0
                        ? Color.FromArgb(198, 40, 40)
                        : Color.FromArgb(230, 81, 0),
                    Left = 10,
                    Top = 28,
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                };

                // كل row في Low Stock يفتح Products
                pnl.Click += (s, e) => { SetActiveButton(btnProducts); SwitchView(new ProductsForm()); };
                lblName.Click += (s, e) => { SetActiveButton(btnProducts); SwitchView(new ProductsForm()); };
                lblStock.Click += (s, e) => { SetActiveButton(btnProducts); SwitchView(new ProductsForm()); };

                pnl.Controls.Add(lblName);
                pnl.Controls.Add(lblStock);
                pnlAlerts.Controls.Add(pnl);
                top += 62;
            }
        }

        private void SetActiveButton(Button btn)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.FromArgb(69, 115, 87);
                _activeButton.Font = new Font("Segoe UI Semibold", 10F);
            }
            btn.BackColor = Color.FromArgb(86, 138, 106);
            btn.Font = new Font("Segoe UI Bold", 10F);
            _activeButton = btn;
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }

        private void ApplyRoundedCornersToCards()
        {
            ApplyRoundedCorners(pnlStatCard1, 12);
            ApplyRoundedCorners(pnlStatCard2, 12);
            ApplyRoundedCorners(pnlStatCard3, 12);
            ApplyRoundedCorners(pnlStatCard4, 12);
            ApplyRoundedCorners(pnlAdoptionsTable, 12);
            ApplyRoundedCorners(pnlAlerts, 12);
        }

        private void ApplyRoundedCorners(Control control, int cornerRadius)
        {
            if (control == null) return;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(control.Width - (cornerRadius * 2), 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(control.Width - (cornerRadius * 2), control.Height - (cornerRadius * 2), cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, control.Height - (cornerRadius * 2), cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseAllFigures();
                control.Region = new Region(path);
            }
        }

        private void StatCard_Paint(object sender, PaintEventArgs e)
        {
            Panel card = sender as Panel;
            if (card == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen shadowPen = new Pen(Color.FromArgb(240, 240, 240), 1))
            {
                e.Graphics.DrawLine(shadowPen, card.Width - 1, 0, card.Width - 1, card.Height - 1);
                e.Graphics.DrawLine(shadowPen, 0, card.Height - 1, card.Width - 1, card.Height - 1);
            }
        }
    }
}