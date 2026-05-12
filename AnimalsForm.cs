using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class AnimalsForm : Form
    {
        public static EventHandler AnimalsChanged;

        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");
        private readonly Color ColorTextPrimary = ColorTranslator.FromHtml("#2A332E");
        private readonly Color ColorTextSecondary = ColorTranslator.FromHtml("#8A938D");

        private readonly Color StatusAvailableBG = ColorTranslator.FromHtml("#D1E7DD");
        private readonly Color StatusAvailableText = ColorTranslator.FromHtml("#0F5132");
        private readonly Color StatusAdoptedBG = ColorTranslator.FromHtml("#FFF3CD");
        private readonly Color StatusAdoptedText = ColorTranslator.FromHtml("#664D03");
        private readonly Color StatusSickBG = ColorTranslator.FromHtml("#F8D7DA");
        private readonly Color StatusSickText = ColorTranslator.FromHtml("#842029");

        public static List<Animal> SharedAnimals = new List<Animal>();
        private BindingSource bs = new BindingSource();

        public AnimalsForm()
        {
            InitializeComponent();

            this.btnAddAnimal.Click += BtnAddAnimal_Click;
            this.Load += AnimalsForm_Load;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvAnimals.CellMouseClick += DgvAnimals_CellMouseClick;
            this.dgvAnimals.CellFormatting += DgvAnimals_CellFormatting;
            this.dgvAnimals.CellPainting += dgvAnimals_CellPainting;

            this.rbAll.CheckedChanged += FilterRadio_CheckedChanged;
            this.rbAvailable.CheckedChanged += FilterRadio_CheckedChanged;
            this.rbAdopted.CheckedChanged += FilterRadio_CheckedChanged;
            this.rbSick.CheckedChanged += FilterRadio_CheckedChanged;

            this.rbAll.CheckedChanged += FilterChip_CheckedChanged;
            this.rbAvailable.CheckedChanged += FilterChip_CheckedChanged;
            this.rbAdopted.CheckedChanged += FilterChip_CheckedChanged;
            this.rbSick.CheckedChanged += FilterChip_CheckedChanged;
        }

        private void AnimalsForm_Load(object sender, EventArgs e)
        {
            if (this.Controls.Find("lblDate", true).FirstOrDefault() is Label lblDate)
                lblDate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy");

            if (string.IsNullOrEmpty(Session.CurrentUser))
                Session.CurrentUser = UsersStore.Users.FirstOrDefault();

            if (this.Controls.Find("lblUserProfile", true).FirstOrDefault() is Label lblProfile)
                lblProfile.Text = Session.CurrentUser + " ?";

            if (SharedAnimals.Count == 0)
            {
                SharedAnimals.Add(new Animal { ID = 1, Name = "Buddy", Type = "Dog", Age = "3 Years", HealthStatus = "Vaccinated", Status = "Available" });
                SharedAnimals.Add(new Animal { ID = 2, Name = "Mittens", Type = "Cat", Age = "2 Years", HealthStatus = "Needs Vaccine", Status = "Sick" });
                SharedAnimals.Add(new Animal { ID = 3, Name = "Rex", Type = "Dog", Age = "5 Years", HealthStatus = "Vaccinated", Status = "Adopted" });
                SharedAnimals.Add(new Animal { ID = 4, Name = "Tweety", Type = "Bird", Age = "1 Year", HealthStatus = "Vaccinated", Status = "Available" });
            }

            SetupGrid();
            RefreshGrid();
        }

        private void SetupGrid()
        {
            bs.DataSource = typeof(Animal);
            dgvAnimals.AutoGenerateColumns = false;
            dgvAnimals.Columns.Clear();

            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColId", HeaderText = "ID", DataPropertyName = "ID", Visible = false });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColName", HeaderText = "Animal Name", DataPropertyName = "Name" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColSpecies", HeaderText = "Species/Breed", DataPropertyName = "Type" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColAge", HeaderText = "Age", DataPropertyName = "Age" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColHealth", HeaderText = "HealthStatus", DataPropertyName = "HealthStatus", Visible = false });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColStatus", HeaderText = "Status", DataPropertyName = "Status" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { Name = "ColActions", HeaderText = "Actions" });

            dgvAnimals.DataSource = bs;
            dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RefreshGrid()
        {
            string search = txtSearch.Text?.Trim();
            IEnumerable<Animal> q = SharedAnimals;

            if (!rbAll.Checked)
            {
                if (rbAvailable.Checked) q = q.Where(a => string.Equals(a.Status, "Available", StringComparison.OrdinalIgnoreCase));
                else if (rbAdopted.Checked) q = q.Where(a => string.Equals(a.Status, "Adopted", StringComparison.OrdinalIgnoreCase));
                else if (rbSick.Checked) q = q.Where(a => string.Equals(a.Status, "Sick", StringComparison.OrdinalIgnoreCase)
                                                             || (a.Status ?? "").IndexOf("Care", StringComparison.OrdinalIgnoreCase) >= 0
                                                             || (a.Status ?? "").IndexOf("Treatment", StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrWhiteSpace(search) && search != "Search animals...")
                q = q.Where(a => (a.Name ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                              || (a.Type ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);

            bs.DataSource = q.ToList();
        }

        // ← هذي الـ method الجديدة — تحدث الداشبورد لو مفتوح
        private void NotifyDashboard()
        {
            var mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            mainForm?.RefreshVaccineAlertsPublic();
        }

        private int GetNextId()
        {
            return SharedAnimals.Count == 0 ? 1 : SharedAnimals.Max(a => a.ID) + 1;
        }

        private void Panel_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;
            int CornerRadius = 16;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, CornerRadius * 2, CornerRadius * 2, 180, 90);
                path.AddArc(ctrl.Width - (CornerRadius * 2), 0, CornerRadius * 2, CornerRadius * 2, 270, 90);
                path.AddArc(ctrl.Width - (CornerRadius * 2), ctrl.Height - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 0, 90);
                path.AddArc(0, ctrl.Height - (CornerRadius * 2), CornerRadius * 2, CornerRadius * 2, 90, 90);
                path.CloseAllFigures();
                ctrl.Region = new Region(path);
            }
        }

        private void dgvAnimals_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dgvAnimals.Columns[e.ColumnIndex].Name == "ColStatus")
            {
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(status))
                {
                    Color pillBGColor = Color.LightGray;
                    Color pillTextColor = Color.Black;

                    if (status.Equals("Available", StringComparison.OrdinalIgnoreCase)) { pillBGColor = StatusAvailableBG; pillTextColor = StatusAvailableText; }
                    else if (status.Equals("Adopted", StringComparison.OrdinalIgnoreCase)) { pillBGColor = StatusAdoptedBG; pillTextColor = StatusAdoptedText; }
                    else if (status.Equals("Sick", StringComparison.OrdinalIgnoreCase)
                          || status.IndexOf("Care", StringComparison.OrdinalIgnoreCase) >= 0) { pillBGColor = StatusSickBG; pillTextColor = StatusSickText; }

                    int pillHeight = 28;
                    int pillWidth = Math.Min(120, e.CellBounds.Width - 20);
                    int rectY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
                    int rectX = e.CellBounds.X + 15;
                    Rectangle pillRect = new Rectangle(rectX, rectY, pillWidth, pillHeight);

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = pillHeight / 2;
                        path.AddArc(pillRect.X, pillRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(pillRect.Right - (radius * 2), pillRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(pillRect.Right - (radius * 2), pillRect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
                        path.AddArc(pillRect.X, pillRect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();
                        using (SolidBrush brush = new SolidBrush(pillBGColor))
                            e.Graphics.FillPath(brush, path);
                    }

                    TextRenderer.DrawText(e.Graphics, status,
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        pillRect, pillTextColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
        }

        private void FilterChip_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null) return;
            if (rb.Checked) { rb.BackColor = ColorPrimaryGreen; rb.ForeColor = Color.White; rb.FlatAppearance.BorderColor = ColorPrimaryGreen; }
            else { rb.BackColor = Color.Transparent; rb.ForeColor = ColorTextSecondary; rb.FlatAppearance.BorderColor = Color.LightGray; }
        }

        private void BtnAddAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addForm = new AddEditeAnimalForm())
                {
                    addForm.StartPosition = FormStartPosition.CenterParent;
                    if (addForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshGrid();
                        AnimalsChanged?.Invoke(this, EventArgs.Empty);
                        NotifyDashboard(); // ← تحديث الداشبورد
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Add Animal form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void FilterRadio_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null && rb.Checked)
                RefreshGrid();
        }

        private string[] GetSelectedStatusFilter()
        {
            if (rbAll.Checked) return null;
            if (rbAvailable.Checked) return new[] { "Available" };
            if (rbAdopted.Checked) return new[] { "Adopted" };
            if (rbSick.Checked) return new[] { "Sick", "In Care", "Needs Treatment" };
            return null;
        }

        private void DgvAnimals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAnimals.Columns[e.ColumnIndex].Name == "ColStatus" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status.Equals("Available", StringComparison.OrdinalIgnoreCase)) { e.CellStyle.BackColor = StatusAvailableBG; e.CellStyle.ForeColor = StatusAvailableText; e.CellStyle.SelectionBackColor = ControlPaint.Light(StatusAvailableBG); }
                else if (status.Equals("Adopted", StringComparison.OrdinalIgnoreCase)) { e.CellStyle.BackColor = StatusAdoptedBG; e.CellStyle.ForeColor = StatusAdoptedText; e.CellStyle.SelectionBackColor = ControlPaint.Light(StatusAdoptedBG); }
                else if (status.Equals("Sick", StringComparison.OrdinalIgnoreCase)) { e.CellStyle.ForeColor = Color.Red; }
                else if (status.Equals("Treatment", StringComparison.OrdinalIgnoreCase)
                      || status.Equals("Needs Treatment", StringComparison.OrdinalIgnoreCase)) { e.CellStyle.ForeColor = Color.Orange; }
            }
        }

        private void DgvAnimals_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvAnimals.Columns[e.ColumnIndex].Name != "ColActions") return;

            Rectangle cellRect = dgvAnimals.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            bool isEdit = (e.X - cellRect.X) < cellRect.Width / 2;

            var bound = dgvAnimals.Rows[e.RowIndex].DataBoundItem as Animal;
            if (bound == null) return;
            int id = bound.ID;

            if (isEdit)
            {
                var animal = SharedAnimals.FirstOrDefault(a => a.ID == id);
                if (animal == null) return;

                using (var editForm = new AddEditeAnimalForm())
                {
                    editForm.LoadAnimalData(animal.ID, animal.Name, animal.Type, animal.Age, animal.HealthStatus, animal.Status);
                    editForm.LoadVaccineData(animal.IsVaccinated, animal.LastVaccineDate);
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    if (editForm.ShowDialog(this) == DialogResult.OK)
                    {
                        RefreshGrid();
                        AnimalsChanged?.Invoke(this, EventArgs.Empty);
                        NotifyDashboard(); // ← تحديث الداشبورد
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this animal?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

                var toRemove = SharedAnimals.FirstOrDefault(a => a.ID == id);
                if (toRemove != null)
                {
                    SharedAnimals.Remove(toRemove);
                    RefreshGrid();
                    AnimalsChanged?.Invoke(this, EventArgs.Empty);
                    NotifyDashboard(); // ← تحديث الداشبورد
                }
            }
        }

        private void LblUserProfile_Click(object sender, EventArgs e)
        {
            using (var dlg = new Form())
            {
                dlg.Text = "Select User";
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.Size = new Size(300, 200);
                var lb = new ListBox { Dock = DockStyle.Fill };
                lb.Items.AddRange(UsersStore.Users.ToArray());
                dlg.Controls.Add(lb);
                var btn = new Button { Text = "Select", Dock = DockStyle.Bottom, Height = 36 };
                btn.Click += (s, ea) => dlg.DialogResult = DialogResult.OK;
                dlg.Controls.Add(btn);
                if (dlg.ShowDialog(this) == DialogResult.OK && lb.SelectedItem != null)
                {
                    Session.CurrentUser = lb.SelectedItem.ToString();
                    if (this.Controls.Find("lblUserProfile", true).FirstOrDefault() is Label lblProfile)
                        lblProfile.Text = Session.CurrentUser + " ?";
                }
            }
        }
    }
}