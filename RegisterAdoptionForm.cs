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
        private readonly Color ColorInputBorder  = ColorTranslator.FromHtml("#D3D8D5");
        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");

        // --- Output properties (read by AdoptionForm after DialogResult.OK) ---
        public string AnimalName   { get; private set; }
        public string CustomerName { get; private set; }
        public string Phone        { get; private set; }
        public string DateFormatted { get; private set; }
        public bool   FeePaid      { get; private set; }

        // --- NEW: ID-based output for Adoption record ---
        public int SelectedAnimalID   { get; private set; }
        public int SelectedCustomerID { get; private set; }

        // Keep old AdoptionId property for backward compatibility with any caller
        public string AdoptionId { get; private set; }

        public RegisterAdoptionForm()
        {
            InitializeComponent();
            this.Load += RegisterAdoptionForm_Load;

            this.btnClose.Click   += btnClose_Click;
            this.btnCancel.Click  += btnClose_Click;
            this.btnConfirm.Click += BtnConfirm_Click;
        }

        private void RegisterAdoptionForm_Load(object sender, EventArgs e)
        {
            ApplyRoundedRegion(this, 15);

            // --- Change A: Populate animals from SharedAnimals, ONLY non-adopted ones ---
            cmbAnimal.DataSource    = null;
            cmbAnimal.Items.Clear();
            var availableAnimals = AnimalsForm.SharedAnimals
                .Where(a => !string.Equals(a.Status, "Adopted", StringComparison.OrdinalIgnoreCase))
                .ToList();
            cmbAnimal.DataSource    = availableAnimals;
            cmbAnimal.DisplayMember = "Name";
            cmbAnimal.ValueMember   = "ID";
            if (cmbAnimal.Items.Count > 0) cmbAnimal.SelectedIndex = 0;

            // --- Change B: Populate customers from SharedCustomers (not UsersStore) ---
            cmbCustomer.DataSource    = null;
            cmbCustomer.Items.Clear();
            var customers = CustomersForm.SharedCustomers.ToList();
            cmbCustomer.DataSource    = customers;
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember   = "ID";
            if (cmbCustomer.Items.Count > 0) cmbCustomer.SelectedIndex = 0;

            dtpDate.Value = DateTime.Now;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // Validation
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

            var selectedAnimal   = cmbAnimal.SelectedItem   as Animal;
            var selectedCustomer = cmbCustomer.SelectedItem as Customer;

            if (selectedAnimal == null || selectedCustomer == null) return;

            // --- Defensive double-adoption check ---
            if (string.Equals(selectedAnimal.Status, "Adopted", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    $"'{selectedAnimal.Name}' has already been adopted and cannot be selected.",
                    "Already Adopted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Assign output properties
            SelectedAnimalID   = selectedAnimal.ID;
            SelectedCustomerID = selectedCustomer.ID;

            AnimalName    = selectedAnimal.Name;
            CustomerName  = selectedCustomer.Name;
            Phone         = selectedCustomer.Phone ?? "";
            DateFormatted = dtpDate.Value.ToString("MMM d, yyyy");
            FeePaid       = rbPaid.Checked;
            AdoptionId    = "#AD-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Mark animal as Adopted in SharedAnimals
            var animal = AnimalsForm.SharedAnimals.FirstOrDefault(a => a.ID == SelectedAnimalID);
            if (animal != null)
                animal.Status = "Adopted";

            // Notify AnimalsForm listeners
            AnimalsForm.AnimalsChanged?.Invoke(this, EventArgs.Empty);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

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
