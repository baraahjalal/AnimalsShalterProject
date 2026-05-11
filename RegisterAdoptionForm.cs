using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class RegisterAdoptionForm : Form
    {
        // --- STYLING CONSTANTS ---
        private readonly Color ColorInputBorder = ColorTranslator.FromHtml("#D3D8D5");
        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");

        // Exposed properties for the created adoption
        public string AdoptionId { get; private set; }
        public string AnimalName { get; private set; }
        public string CustomerName { get; private set; }
        public string Phone { get; private set; }
        public string DateFormatted { get; private set; }
        public bool FeePaid { get; private set; }

        public RegisterAdoptionForm()
        {
            InitializeComponent();
            this.Load += RegisterAdoptionForm_Load;

            // Wire buttons
            this.btnClose.Click += btnClose_Click;
            this.btnCancel.Click += btnClose_Click;
            this.btnConfirm.Click += BtnConfirm_Click;
        }

        private void RegisterAdoptionForm_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to the form itself
            ApplyRoundedRegion(this, 15);

            // Populate animals from in-memory list
            cmbAnimal.Items.Clear();
            foreach (var a in AnimalsForm.SharedAnimals)
            {
                cmbAnimal.Items.Add(a.Name);
            }
            if (cmbAnimal.Items.Count > 0) cmbAnimal.SelectedIndex = 0;

            // Populate customers from UsersStore
            cmbCustomer.Items.Clear();
            foreach (var u in UsersStore.Users)
            {
                cmbCustomer.Items.Add(u);
            }
            if (cmbCustomer.Items.Count > 0) cmbCustomer.SelectedIndex = 0;

            // Set default date
            dtpDate.Value = DateTime.Now;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Basic validation
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

            // Assign properties
            AdoptionId = "#AD-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            AnimalName = cmbAnimal.SelectedItem.ToString();
            CustomerName = cmbCustomer.SelectedItem.ToString();
            Phone = ""; // Phone not collected here (could extend UI)
            DateFormatted = dtpDate.Value.ToString("MMM d, yyyy");
            FeePaid = rbPaid.Checked;

            // Optionally mark the animal as Adopted in SharedAnimals
            var animal = AnimalsForm.SharedAnimals.FirstOrDefault(a => string.Equals(a.Name, AnimalName, StringComparison.OrdinalIgnoreCase));
            if (animal != null)
            {
                animal.Status = "Adopted";
            }

            // Notify listeners via AnimalsForm delegate
            AnimalsForm.AnimalsChanged?.Invoke(this, EventArgs.Empty);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // --- FORM CLOSING EVENT ---
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- ROUNDED CORNERS (REGION MASKING) HELPER ---
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

        // --- CUSTOM BORDER DRAWING FOR INPUT PANELS ---
        private void InputPanel_PaintRoundedBorder(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            int radius = 8; // Inner radius for inputs
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
                {
                    e.Graphics.DrawPath(pen, path);
                }
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
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}
