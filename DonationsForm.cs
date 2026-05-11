using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class DonationsForm : Form
    {
        private static readonly Color ColorGreen = Color.FromArgb(69, 115, 87);
        private static readonly Color ColorLightGreen = Color.FromArgb(200, 225, 210);

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

            // إعداد الأعمدة
            dgvDonations.Columns.Add("ColAvatar", "");
            dgvDonations.Columns.Add("ColDonor", "Donor Name");
            dgvDonations.Columns.Add("ColAmount", "Amount");
            dgvDonations.Columns.Add("ColCategory", "Category");
            dgvDonations.Columns.Add("ColDate", "Date");

            dgvDonations.Columns[0].Width = 50;
            dgvDonations.Columns[1].FillWeight = 150;
        }

        private void LoadData()
        {
            // بيانات تجريبية
            dgvDonations.Rows.Add(null, "Sarah Ahmed", "450 LYD", "Medicine", "Oct 24, 2023");
            dgvDonations.Rows.Add(null, "John Smith", "1,200 LYD", "Food", "Oct 22, 2023");
            dgvDonations.Rows.Add(null, "Omar Ali", "300 LYD", "General", "Oct 20, 2023");

            // تعبئة الإحصائيات
            AddStatLabels(pnlStat1, "Total Donations", "4,250 LYD", "+12%");
            AddStatLabels(pnlStat2, "Monthly Goal", "10,000 LYD", "42%");
            AddStatLabels(pnlStat3, "Total Donors", "128", "+5");
        }

        private void AddStatLabels(Panel p, string title, string val, string badge)
        {
            Label lblT = new Label { Text = title, Font = new Font("Segoe UI", 9F), ForeColor = Color.Gray, Location = new Point(15, 15), AutoSize = true };
            Label lblV = new Label { Text = val, Font = new Font("Segoe UI Bold", 16F), Location = new Point(15, 40), AutoSize = true };
            Label lblB = new Label { Text = badge, Font = new Font("Segoe UI Bold", 8F), ForeColor = ColorGreen, BackColor = ColorLightGreen, Location = new Point(15, 75), Padding = new Padding(5, 2, 5, 2), AutoSize = true };
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
