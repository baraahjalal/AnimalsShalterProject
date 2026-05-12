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
            // تذكير التطعيم
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
        }

        private void RefreshDashboardStats()
        {
            // Card 1 — Total Animals
            lblStatValue1.Text = AnimalsForm.SharedAnimals?.Count.ToString() ?? "0";

            // Card 2 — Adopted
            lblStatValue2.Text = AnimalsForm.SharedAnimals?
                .Count(a => a.Status == "Adopted").ToString() ?? "0";

            // Card 3 — Products
            lblStatValue3.Text = ProductsForm.SharedProducts?.Count.ToString() ?? "0";

            // Card 4 — Total Sales
            decimal totalSales = SalesForm.SharedSales?.Sum(s => s.TotalAmount) ?? 0;
            lblStatValue4.Text = totalSales.ToString("F2") + " LYD";
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

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
        }

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
