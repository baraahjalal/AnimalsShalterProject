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
        }

        private void EnsureDataLoaded()
        {
            if (AnimalsForm.SharedAnimals.Count == 0)
            {
                AnimalsForm.SharedAnimals.Add(new Animal { ID = 1, Name = "Buddy", Type = "Dog", Age = "3 Years", HealthStatus = "Vaccinated", Status = "Available" });
                AnimalsForm.SharedAnimals.Add(new Animal { ID = 2, Name = "Mittens", Type = "Cat", Age = "2 Years", HealthStatus = "Needs Vaccine", Status = "Sick" });
                AnimalsForm.SharedAnimals.Add(new Animal { ID = 3, Name = "Rex", Type = "Dog", Age = "5 Years", HealthStatus = "Vaccinated", Status = "Adopted" });
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
                CustomersForm.SharedCustomers.Add(new Customer { ID = 1, Name = "Ahmed Ali", Phone = "091-234-5678", Email = "ahmed.ali@email.com", JoinDate = new DateTime(2022, 3, 15) });
                CustomersForm.SharedCustomers.Add(new Customer { ID = 2, Name = "Sara Mohamed", Phone = "092-876-5432", Email = "sara.m@email.com", JoinDate = new DateTime(2023, 1, 8) });
                CustomersForm.SharedCustomers.Add(new Customer { ID = 3, Name = "Khalid Omar", Phone = "091-998-1122", Email = "khalid.omar@email.com", JoinDate = new DateTime(2021, 11, 20) });
                CustomersForm.SharedCustomers.Add(new Customer { ID = 4, Name = "Fatima Hassan", Phone = "093-445-6677", Email = "fatima.h@email.com", JoinDate = new DateTime(2023, 6, 1) });
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
            if (AnimalsForm.SharedAnimals != null)
            {
                var upcoming = AnimalsForm.SharedAnimals
                    .Where(a => a.VaccineDate.HasValue
                        && a.VaccineDate.Value.Date >= DateTime.Today
                        && a.VaccineDate.Value.Date <= DateTime.Today.AddDays(7))
                    .Select(a => a.Name)
                    .ToList();

                if (upcoming.Any())
                    MessageBox.Show(
                        "مواعيد تطعيم قادمة خلال 7 أيام:\n" + string.Join("\n", upcoming),
                        "تذكير التطعيم");
            }

            pnlMainContent.Controls.Clear();
            pnlMainContent.Controls.Add(tlpDashboard);
            pnlMainContent.Controls.Add(flpStats);

            RefreshDashboardStats();
            RefreshRecentAdoptions();
            RefreshLowStockAlerts();
        }

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

            // يعرض بس الحيوانات المتبناة — يتطابق مع رقم Adopted فوق
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
                };

                var lblName = new Label
                {
                    Text = product.Name,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    ForeColor = ColorTextPrimary,
                    Left = 10,
                    Top = 8,
                    AutoSize = true,
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
                };

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