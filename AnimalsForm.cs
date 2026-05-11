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
        // static delegate field to notify changes in the animals list
        public static EventHandler AnimalsChanged;

        // --- STYLING CONSTANTS ---
        private readonly Color ColorPrimaryGreen = ColorTranslator.FromHtml("#457357");
        private readonly Color ColorTextPrimary = ColorTranslator.FromHtml("#2A332E");
        private readonly Color ColorTextSecondary = ColorTranslator.FromHtml("#8A938D");

        // Status Colors
        private readonly Color StatusAvailableBG = ColorTranslator.FromHtml("#D1E7DD");
        private readonly Color StatusAvailableText = ColorTranslator.FromHtml("#0F5132");
        private readonly Color StatusAdoptedBG = ColorTranslator.FromHtml("#FFF3CD");
        private readonly Color StatusAdoptedText = ColorTranslator.FromHtml("#664D03");
        private readonly Color StatusSickBG = ColorTranslator.FromHtml("#F8D7DA");
        private readonly Color StatusSickText = ColorTranslator.FromHtml("#842029");

        // Shared in-memory list for the session
        public static List<Animal> SharedAnimals = new List<Animal>();
        private BindingSource bs = new BindingSource();

        public AnimalsForm()
        {
            InitializeComponent();

            // Wire up events
            this.btnAddAnimal.Click += BtnAddAnimal_Click;

            // Data interactions
            this.Load += AnimalsForm_Load;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.dgvAnimals.CellMouseClick += DgvAnimals_CellMouseClick;
            this.dgvAnimals.CellFormatting += DgvAnimals_CellFormatting;
            this.dgvAnimals.CellPainting += dgvAnimals_CellPainting;

            // Ensure filters refresh data when changed
            this.rbAll.CheckedChanged += FilterRadio_CheckedChanged;
            this.rbAvailable.CheckedChanged += FilterRadio_CheckedChanged;
            this.rbAdopted.CheckedChanged += FilterRadio_CheckedChanged;
            this.rbSick.CheckedChanged += FilterRadio_CheckedChanged;

            // Visual handlers
            this.rbAll.CheckedChanged += FilterChip_CheckedChanged;
            this.rbAvailable.CheckedChanged += FilterChip_CheckedChanged;
            this.rbAdopted.CheckedChanged += FilterChip_CheckedChanged;
            this.rbSick.CheckedChanged += FilterChip_CheckedChanged;
        }

        private void AnimalsForm_Load(object sender, EventArgs e)
        {
            // Set current date to top-right label if present
            if (this.Controls.Find("lblDate", true).FirstOrDefault() is Label lblDate)
            {
                lblDate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy");
            }

            // If session has current user, show it, else default
            if (string.IsNullOrEmpty(Session.CurrentUser))
                Session.CurrentUser = UsersStore.Users.FirstOrDefault();

            if (this.Controls.Find("lblUserProfile", true).FirstOrDefault() is Label lblProfile)
            {
                lblProfile.Text = Session.CurrentUser + " ?";
            }

            // Add some dummy animals if list is empty
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

        private void LblUserProfile_Click(object sender, EventArgs e)
        {
            // Show a simple selection dialog with available users
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
                    {
                        lblProfile.Text = Session.CurrentUser + " ?";
                    }
                }
            }
        }

        private void SetupGrid()
        {
            // Configure binding
            bs.DataSource = typeof(Animal);
            dgvAnimals.AutoGenerateColumns = false;

            // Clear existing columns and create columns matching the designer names
            dgvAnimals.Columns.Clear();

            // Hidden ID
            var colId = new DataGridViewTextBoxColumn { Name = "ColId", HeaderText = "ID", DataPropertyName = "ID", Visible = false };
            dgvAnimals.Columns.Add(colId);

            var colName = new DataGridViewTextBoxColumn { Name = "ColName", HeaderText = "Animal Name", DataPropertyName = "Name" };
            dgvAnimals.Columns.Add(colName);

            var colSpecies = new DataGridViewTextBoxColumn { Name = "ColSpecies", HeaderText = "Species/Breed", DataPropertyName = "Type" };
            dgvAnimals.Columns.Add(colSpecies);

            var colAge = new DataGridViewTextBoxColumn { Name = "ColAge", HeaderText = "Age", DataPropertyName = "Age" };
            dgvAnimals.Columns.Add(colAge);

            // Health hidden column to store HealthStatus
            var colHealth = new DataGridViewTextBoxColumn { Name = "ColHealth", HeaderText = "HealthStatus", DataPropertyName = "HealthStatus", Visible = false };
            dgvAnimals.Columns.Add(colHealth);

            var colStatus = new DataGridViewTextBoxColumn { Name = "ColStatus", HeaderText = "Status", DataPropertyName = "Status" };
            dgvAnimals.Columns.Add(colStatus);

            var colActions = new DataGridViewTextBoxColumn { Name = "ColActions", HeaderText = "Actions" };
            dgvAnimals.Columns.Add(colActions);

            dgvAnimals.DataSource = bs;
            dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RefreshGrid()
        {
            // Apply search/filter
            string search = txtSearch.Text?.Trim();
            IEnumerable<Animal> q = SharedAnimals;

            // Filter by status radio
            if (!rbAll.Checked)
            {
                if (rbAvailable.Checked) q = q.Where(a => string.Equals(a.Status, "Available", StringComparison.OrdinalIgnoreCase));
                else if (rbAdopted.Checked) q = q.Where(a => string.Equals(a.Status, "Adopted", StringComparison.OrdinalIgnoreCase));
                else if (rbSick.Checked) q = q.Where(a => string.Equals(a.Status, "Sick", StringComparison.OrdinalIgnoreCase) || (a.Status ?? "").IndexOf("Care", StringComparison.OrdinalIgnoreCase) >= 0 || (a.Status ?? "").IndexOf("Treatment", StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrWhiteSpace(search) && search != "Search animals...")
            {
                q = q.Where(a => (a.Name ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || (a.Type ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            bs.DataSource = q.ToList();
        }

        private int GetNextId()
        {
            return SharedAnimals.Count == 0 ? 1 : SharedAnimals.Max(a => a.ID) + 1;
        }

        // -------------------- Designer paint helper --------------------
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

        // -------------------- DATAGRIDVIEW CELL PAINTING (STATUS PILLS) --------------------
        private void dgvAnimals_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Only affect the Status column and ignore headers (RowIndex < 0)
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dgvAnimals.Columns[e.ColumnIndex].Name == "ColStatus")
            {
                e.PaintBackground(e.CellBounds, true); // Paint selection background if selected

                string status = e.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(status))
                {
                    Color pillBGColor = Color.LightGray;
                    Color pillTextColor = Color.Black;

                    if (status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                    {
                        pillBGColor = StatusAvailableBG;
                        pillTextColor = StatusAvailableText;
                    }
                    else if (status.Equals("Adopted", StringComparison.OrdinalIgnoreCase))
                    {
                        pillBGColor = StatusAdoptedBG;
                        pillTextColor = StatusAdoptedText;
                    }
                    else if (status.Equals("Sick", StringComparison.OrdinalIgnoreCase) || status.IndexOf("Care", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        pillBGColor = StatusSickBG;
                        pillTextColor = StatusSickText;
                    }

                    // Setup Pill Rectangle
                    int pillHeight = 28;
                    int pillWidth = Math.Min(120, e.CellBounds.Width - 20);

                    // Center the pill in the cell
                    int rectY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
                    int rectX = e.CellBounds.X + 15; // Padding left

                    Rectangle pillRect = new Rectangle(rectX, rectY, pillWidth, pillHeight);

                    // Draw Rounded Rectangle
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
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                    }

                    // Draw Text
                    TextRenderer.DrawText(e.Graphics, status,
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        pillRect,
                        pillTextColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                e.Handled = true; // Tell the grid we finished drawing this cell
            }
        }

        // -------------------- Designer filter visual handler --------------------
        private void FilterChip_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    rb.BackColor = ColorPrimaryGreen;
                    rb.ForeColor = Color.White;
                    rb.FlatAppearance.BorderColor = ColorPrimaryGreen;
                }
                else
                {
                    rb.BackColor = Color.Transparent;
                    rb.ForeColor = ColorTextSecondary;
                    rb.FlatAppearance.BorderColor = Color.LightGray;
                }
            }
        }

        // -------------------- Add Animal --------------------
        private void BtnAddAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addForm = new AddEditeAnimalForm())
                {
                    addForm.StartPosition = FormStartPosition.CenterParent;
                    var result = addForm.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        // Refresh in-memory list display
                        RefreshGrid();

                        // notify subscribers about the change
                        AnimalsChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Add Animal form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------- Search --------------------
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string txt = txtSearch.Text?.Trim();
            if (txt == "Search animals...") txt = null; // placeholder guard
            RefreshGrid();
        }

        // -------------------- Filters --------------------
        private void FilterRadio_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                // reload with new filter
                RefreshGrid();
            }
        }

        private string[] GetSelectedStatusFilter()
        {
            if (rbAll.Checked) return null;
            if (rbAvailable.Checked) return new[] { "Available" };
            if (rbAdopted.Checked) return new[] { "Adopted" };
            if (rbSick.Checked) return new[] { "Sick", "In Care", "Needs Treatment" };
            return null;
        }

        // -------------------- Cell Formatting (Status badges) --------------------
        private void DgvAnimals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAnimals.Columns[e.ColumnIndex].Name == "ColStatus" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status.Equals("Available", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = StatusAvailableBG;
                    e.CellStyle.ForeColor = StatusAvailableText;
                    e.CellStyle.SelectionBackColor = ControlPaint.Light(StatusAvailableBG);
                }
                else if (status.Equals("Adopted", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = StatusAdoptedBG;
                    e.CellStyle.ForeColor = StatusAdoptedText;
                    e.CellStyle.SelectionBackColor = ControlPaint.Light(StatusAdoptedBG);
                }
                else if (status.Equals("Sick", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (status.Equals("Treatment", StringComparison.OrdinalIgnoreCase) || status.Equals("Needs Treatment", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
            }
        }

        // -------------------- Actions: Edit / Delete --------------------
        private void DgvAnimals_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ensure valid row/column
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgvAnimals.Columns[e.ColumnIndex];
            if (col.Name != "ColActions") return;

            // Determine left/right half click to choose Edit or Delete
            Rectangle cellRect = dgvAnimals.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int relativeX = e.X - cellRect.X;

            bool isEdit = relativeX < cellRect.Width / 2;

            int id = -1;
            // get id from bound item
            var bound = dgvAnimals.Rows[e.RowIndex].DataBoundItem as Animal;
            if (bound != null) id = bound.ID;

            if (isEdit)
            {
                // Edit logic
                if (id < 0) return;

                var animal = SharedAnimals.FirstOrDefault(a => a.ID == id);
                if (animal == null) return;

                using (var editForm = new AddEditeAnimalForm())
                {
                    editForm.LoadAnimalData(animal.ID, animal.Name, animal.Type, animal.Age, animal.HealthStatus, animal.Status);
                    editForm.StartPosition = FormStartPosition.CenterParent;
                    var result = editForm.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        // Update in-memory and refresh
                        RefreshGrid();

                        // notify subscribers about the change
                        AnimalsChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            else
            {
                // Delete logic
                if (id < 0) return;

                var confirm = MessageBox.Show("Are you sure you want to delete this animal?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                // Remove from in-memory list and refresh
                var toRemove = SharedAnimals.FirstOrDefault(a => a.ID == id);
                if (toRemove != null)
                {
                    SharedAnimals.Remove(toRemove);
                    RefreshGrid();

                    // notify subscribers about the change
                    AnimalsChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
