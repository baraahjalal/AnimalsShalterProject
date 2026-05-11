using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class RecordDonationForm : Form
    {
        // ── لوحة الألوان ─────────────────────────────
        private static readonly Color ClrGreen  = Color.FromArgb(69, 115, 87);
        private static readonly Color ClrBeige  = Color.FromArgb(241, 237, 228);
        private static readonly Color ClrText   = Color.FromArgb(42, 51, 46);

        public RecordDonationForm()
        {
            InitializeComponent();
            SetupUI();
        }

        // ─────────────────────────────────────────────
        // إعداد الواجهة
        // ─────────────────────────────────────────────
        private void SetupUI()
        {
            // حواف دائرية للنافذة نفسها
            this.Load += (s, e) => ApplyFormRoundedCorners();

            // حواف دائرية لحقول الإدخال
            ApplyInputRounding();

            // أحداث الأزرار
            btnClose.Click  += (s, e) => this.Close();
            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click   += BtnSave_Click;

            // تأثير hover على زر Save
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(56, 96, 72);
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = ClrGreen;

            // Vertical centering للـ TextBox داخل Panel
            CenterTextBox(pnlDonorName, txtDonorName);
            CenterTextBox(pnlAmount,    txtAmount);

            // تحديد الفئة الافتراضية
            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────────
        // حدث حفظ التبرع
        // ─────────────────────────────────────────────
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // تحقق من الحقول المطلوبة
            if (string.IsNullOrWhiteSpace(txtDonorName.Text))
            {
                ShowError(pnlDonorName, "Donor name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAmount.Text) ||
                !decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                ShowError(pnlAmount, "Please enter a valid amount.");
                return;
            }

            // هنا يمكن إضافة منطق الحفظ في قاعدة البيانات لاحقاً
            MessageBox.Show(
                $"Donation of {amount:N0} LYD recorded successfully!\n" +
                $"Donor: {txtDonorName.Text}\n" +
                $"Category: {cmbCategory.SelectedItem}\n" +
                $"Date: {dtpDate.Value:MMM dd, yyyy}",
                "Donation Recorded",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ─────────────────────────────────────────────
        // مساعد خطأ التحقق
        // ─────────────────────────────────────────────
        private void ShowError(Panel field, string message)
        {
            // تلمّع حقل الخطأ بالأحمر مؤقتاً
            Color original = field.BackColor;
            field.BackColor = Color.FromArgb(255, 235, 235);

            var timer = new System.Windows.Forms.Timer { Interval = 1500 };
            timer.Tick += (s, e) => {
                field.BackColor = original;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();

            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ─────────────────────────────────────────────
        // مساعدات الرسوميات
        // ─────────────────────────────────────────────

        /// <summary>تطبيق حواف دائرية على النافذة (radius 15)</summary>
        private void ApplyFormRoundedCorners()
        {
            using (GraphicsPath path = RoundedRect(
                new Rectangle(0, 0, this.Width, this.Height), 15))
                this.Region = new Region(path);
        }

        /// <summary>تطبيق حواف دائرية على جميع حقول الإدخال</summary>
        private void ApplyInputRounding()
        {
            Panel[] inputPanels = {
                pnlDonorName, pnlAmount, pnlCategory, pnlDate, pnlNotes
            };
            foreach (var pnl in inputPanels)
            {
                pnl.Paint  += InputPanel_Paint;
                pnl.Resize += (s, e) => ApplyRoundedRegion(pnl, 10);
                ApplyRoundedRegion(pnl, 10);
            }

            ApplyRoundedRegion(btnSave,   12);
            ApplyRoundedRegion(btnCancel, 12);
        }

        private void InputPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel pnl)
                DrawRoundedPanel(pnl, e.Graphics, 10);
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.Left,          r.Top,           d, d, 180, 90);
            path.AddArc(r.Right - d,     r.Top,           d, d, 270, 90);
            path.AddArc(r.Right - d,     r.Bottom - d,    d, d,   0, 90);
            path.AddArc(r.Left,          r.Bottom - d,    d, d,  90, 90);
            path.CloseAllFigures();
            return path;
        }

        private static void ApplyRoundedRegion(Control ctrl, int radius)
        {
            if (ctrl.Width == 0 || ctrl.Height == 0) return;
            using (GraphicsPath path = RoundedRect(
                new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius))
                ctrl.Region = new Region(path);
        }

        private static void DrawRoundedPanel(Control panel, Graphics g, int radius)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = RoundedRect(
                new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), radius))
            using (SolidBrush br = new SolidBrush(panel.BackColor))
            {
                panel.Region = new Region(path);
                g.FillPath(br, path);
            }
        }

        /// <summary>توسيط الـ TextBox عمودياً داخل الـ Panel</summary>
        private static void CenterTextBox(Panel panel, TextBox txt)
        {
            txt.Top = (panel.Height - txt.Height) / 2;
        }

        // ─────────────────────────────────────────────
        // خصائص عامة للوصول للبيانات من النموذج الرئيسي
        // ─────────────────────────────────────────────
        public string DonorName   => txtDonorName.Text.Trim();
        public decimal Amount     => decimal.TryParse(txtAmount.Text, out var v) ? v : 0;
        public string Category    => cmbCategory.SelectedItem?.ToString() ?? "General";
        public DateTime DonationDate => dtpDate.Value;
        public string Notes       => txtNotes.Text.Trim();
    }
}
