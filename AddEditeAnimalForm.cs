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

        // حقول التطعيم — تُنشأ برمجياً
        private CheckBox chkVaccinated;
        private Label lblLastVaccine;
        private DateTimePicker dtpLastVaccine;
        private Label lblVaccineNote;

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
            cmbType.SelectedIndexChanged += CmbType_SelectedIndexChanged;
        }

        private void AddEditeAnimalForm_Load(object sender, EventArgs e)
        {
            ApplyRoundedRegion(this, 16);

            // Add mode — Status مقفول على Available
            if (AnimalId < 0)
            {
                cmbStatus.SelectedItem = "Available";
                cmbStatus.Enabled = false;
                lblTxtStatus.Text = "Status (Auto: Available for new animals)";
                lblTxtStatus.ForeColor = ColorTranslator.FromHtml("#8A938D");
            }
            else if (string.Equals(cmbStatus.SelectedItem?.ToString(), "Adopted", StringComparison.OrdinalIgnoreCase))
            {
                cmbStatus.Enabled = false;
                lblTxtStatus.Text = "Status (Locked: Adopted animals cannot be changed)";
                lblTxtStatus.ForeColor = Color.FromArgb(211, 47, 47);
            }

            // بناء حقول التطعيم
            BuildVaccineFields();

            // تحديث ظهور حقول التطعيم حسب النوع المختار
            UpdateVaccineVisibility();
        }

        private void BuildVaccineFields()
        {
            // الـ form حالياً ارتفاعه 570 — نوسعه ونضيف الحقول بعد Status

            // CheckBox — هل مطعم؟
            chkVaccinated = new CheckBox
            {
                Text = "Vaccinated?",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#2A332E"),
                Location = new Point(30, 435),
                AutoSize = true,
                Visible = false,
                Cursor = Cursors.Hand,
            };
            chkVaccinated.CheckedChanged += (s, e) => UpdateVaccineDateVisibility();
            this.Controls.Add(chkVaccinated);

            // Label — تاريخ آخر تطعيمة
            lblLastVaccine = new Label
            {
                Text = "Last Vaccine Date",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#2A332E"),
                Location = new Point(30, 470),
                AutoSize = true,
                Visible = false,
            };
            this.Controls.Add(lblLastVaccine);

            // DateTimePicker
            dtpLastVaccine = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(30, 495),
                Size = new Size(420, 35),
                Value = DateTime.Today,
                Visible = false,
            };
            this.Controls.Add(dtpLastVaccine);

            // Note — الموعد القادم
            lblVaccineNote = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9F),
                ForeColor = ColorPrimaryGreen,
                Location = new Point(30, 535),
                Size = new Size(420, 20),
                Visible = false,
            };
            this.Controls.Add(lblVaccineNote);

            // نوسع الـ form لما تظهر الحقول
            dtpLastVaccine.ValueChanged += (s, e) => UpdateVaccineNote();
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVaccineVisibility();
        }

        private void UpdateVaccineVisibility()
        {
            bool isDogOrCat = cmbType.SelectedItem?.ToString() == "Dog" ||
                              cmbType.SelectedItem?.ToString() == "Cat";

            chkVaccinated.Visible = isDogOrCat;
            lblLastVaccine.Visible = isDogOrCat;

            if (isDogOrCat)
            {
                this.ClientSize = new System.Drawing.Size(480, 640);
                UpdateVaccineDateVisibility();
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(480, 570);
                dtpLastVaccine.Visible = false;
                lblVaccineNote.Visible = false;
            }

            // نعيد تطبيق الـ rounded corners بعد تغيير الحجم
            ApplyRoundedRegion(this, 16);
        }

        private void UpdateVaccineDateVisibility()
        {
            bool isDogOrCat = cmbType.SelectedItem?.ToString() == "Dog" ||
                              cmbType.SelectedItem?.ToString() == "Cat";

            if (!isDogOrCat) return;

            // سواء مطعم أو لا — نعرض الـ DatePicker
            // لو مطعم: "آخر تطعيمة"، لو مش مطعم: "تاريخ التسجيل"
            dtpLastVaccine.Visible = true;
            lblVaccineNote.Visible = true;

            lblLastVaccine.Text = chkVaccinated.Checked
                ? "Last Vaccine Date (next will be calculated automatically)"
                : "Registration Date (first vaccine will be scheduled from this date)";

            UpdateVaccineNote();
        }

        private void UpdateVaccineNote()
        {
            if (dtpLastVaccine == null || lblVaccineNote == null) return;
            if (!dtpLastVaccine.Visible) return;

            DateTime nextVaccine = dtpLastVaccine.Value.AddMonths(1);
            int daysLeft = (nextVaccine.Date - DateTime.Today).Days;

            if (daysLeft < 0)
                lblVaccineNote.Text = $"⚠️ Next vaccine: {nextVaccine:MMM dd, yyyy} (Overdue by {-daysLeft} days)";
            else if (daysLeft == 0)
                lblVaccineNote.Text = $"🔔 Next vaccine: TODAY ({nextVaccine:MMM dd, yyyy})";
            else
                lblVaccineNote.Text = $"✅ Next vaccine: {nextVaccine:MMM dd, yyyy} ({daysLeft} days left)";

            lblVaccineNote.ForeColor = daysLeft < 0
                ? Color.FromArgb(198, 40, 40)
                : daysLeft <= 7
                    ? Color.FromArgb(230, 81, 0)
                    : ColorPrimaryGreen;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AnimalName))
            {
                MessageBox.Show("Please enter a name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool isDogOrCat = AnimalType == "Dog" || AnimalType == "Cat";

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

                    if (isDogOrCat && dtpLastVaccine != null && dtpLastVaccine.Visible)
                    {
                        existing.IsVaccinated = chkVaccinated.Checked;
                        existing.LastVaccineDate = dtpLastVaccine.Value.Date;
                        existing.VaccineDate = dtpLastVaccine.Value.Date.AddMonths(1);
                    }

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
                    Status = this.Status,
                };

                if (isDogOrCat && dtpLastVaccine != null && dtpLastVaccine.Visible)
                {
                    newAnimal.IsVaccinated = chkVaccinated.Checked;
                    newAnimal.LastVaccineDate = dtpLastVaccine.Value.Date;
                    newAnimal.VaccineDate = dtpLastVaccine.Value.Date.AddMonths(1);
                }

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

        // لتحميل بيانات التطعيم في Edit mode
        public void LoadVaccineData(bool isVaccinated, DateTime? lastVaccineDate)
        {
            if (chkVaccinated != null)
                chkVaccinated.Checked = isVaccinated;
            if (dtpLastVaccine != null && lastVaccineDate.HasValue)
                dtpLastVaccine.Value = lastVaccineDate.Value;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

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

        private void pnlBottom_Paint(object sender, PaintEventArgs e) { }
    }
}