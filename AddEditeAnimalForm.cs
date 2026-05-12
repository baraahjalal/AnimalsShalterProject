using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class AddEditeAnimalForm : Form
    {
        private readonly Color ColorInputBorder = ColorTranslator.FromHtml("#D3D8D5");
        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");

        public int AnimalId { get; private set; } = -1;
        public string AnimalName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }
        public string AnimalType
        {
            get => cmbType.SelectedItem?.ToString();
            set { if (value != null && cmbType.Items.Contains(value)) cmbType.SelectedItem = value; else cmbType.Text = value; }
        }
        public string AnimalAge
        {
            get => txtAge.Text;
            set => txtAge.Text = value;
        }
        public string HealthStatus
        {
            get => cmbHealth.SelectedItem?.ToString();
            set { if (value != null && cmbHealth.Items.Contains(value)) cmbHealth.SelectedItem = value; else cmbHealth.Text = value; }
        }
        public string Status
        {
            get => cmbStatus.SelectedItem?.ToString();
            set { if (value != null && cmbStatus.Items.Contains(value)) cmbStatus.SelectedItem = value; else cmbStatus.Text = value; }
        }

        public AddEditeAnimalForm()
        {
            InitializeComponent();
            this.Load += AddEditeAnimalForm_Load;
            this.btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AnimalName))
            {
                MessageBox.Show("Please enter a name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.AnimalId >= 0)
            {
                var existing = AnimalsForm.SharedAnimals.FirstOrDefault(a => a.ID == this.AnimalId);
                if (existing != null)
                {
                    existing.Name = this.AnimalName;
                    existing.Type = this.AnimalType;
                    existing.Age = this.AnimalAge;
                    existing.HealthStatus = this.HealthStatus;
                    existing.Status = this.Status;
                    AnimalsForm.AnimalsChanged?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                int newId = AnimalsForm.SharedAnimals.Count == 0 ? 1 : AnimalsForm.SharedAnimals.Max(a => a.ID) + 1;
                var newAnimal = new Animal
                {
                    ID = newId,
                    Name = this.AnimalName,
                    Type = this.AnimalType,
                    Age = this.AnimalAge,
                    HealthStatus = this.HealthStatus,
                    Status = this.Status
                };
                AnimalsForm.SharedAnimals.Add(newAnimal);
                AnimalsForm.AnimalsChanged?.Invoke(this, EventArgs.Empty);
            }

            MessageBox.Show("Animal saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void LoadAnimalData(int id, string name, string type, string age, string healthStatus, string status)
        {
            this.AnimalId = id;
            this.AnimalName = name;
            this.AnimalType = type;
            this.AnimalAge = age;
            this.HealthStatus = healthStatus;
            this.Status = status;

            this.lblTitle.Text = (id >= 0) ? "Edit Animal" : "Add New Animal";
        }

        private void AddEditeAnimalForm_Load(object sender, EventArgs e)
        {
            ApplyRoundedRegion(this, 16);

            // لما يكون Add mode — اضبط Status على Available تلقائياً وأخفيه
            if (AnimalId < 0)
            {
                cmbStatus.SelectedItem = "Available";
                cmbStatus.Enabled = false;
                lblTxtStatus.Text = "Status (Auto: Available for new animals)";
                lblTxtStatus.ForeColor = ColorTranslator.FromHtml("#8A938D");
            }
            // لما يكون Edit mode وحيوان Adopted — منع تغيير Status
            else if (string.Equals(cmbStatus.SelectedItem?.ToString(), "Adopted", StringComparison.OrdinalIgnoreCase))
            {
                cmbStatus.Enabled = false;
                lblTxtStatus.Text = "Status (Locked: Adopted animals cannot be changed)";
                lblTxtStatus.ForeColor = Color.FromArgb(211, 47, 47);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void AddEditeAnimalForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int radius = 16;
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc(rect.Right - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc(rect.Right - (radius * 2), rect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseFigure();
                using (Pen pen = new Pen(ColorInputBorder, 1f))
                    e.Graphics.DrawPath(pen, path);
            }
        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}