using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class AdoptionForm : Form
    {
        // --- STATIC SHARED LIST (mirrors SharedAnimals / SharedProducts pattern) ---
        public static EventHandler AdoptionsChanged;
        public static List<Adoption> SharedAdoptions = new List<Adoption>();
        private BindingSource bsAdoptions = new BindingSource();

        // --- STYLING CONSTANTS ---
        private readonly Color PillBackground = ColorTranslator.FromHtml("#E9E7E0");
        private readonly Color PillText       = ColorTranslator.FromHtml("#2A332E");
        private readonly Color IconColor      = ColorTranslator.FromHtml("#8A938D");

        public AdoptionForm()
        {
            InitializeComponent();
            this.Load += AdoptionForm_Load;

            if (this.btnNewAdoption != null)
                this.btnNewAdoption.Click += BtnNewAdoption_Click;
        }

        // Designer wires AdoptionsForm_Load (plural) — keep wrapper
        private void AdoptionsForm_Load(object sender, EventArgs e)
        {
            AdoptionForm_Load(sender, e);
        }

        private void AdoptionForm_Load(object sender, EventArgs e)
        {
            // Seed sample adoptions once per session, linked to real SharedAnimals/SharedCustomers IDs
            if (SharedAdoptions.Count == 0)
            {
                // Ensure animals and customers are seeded first
                if (AnimalsForm.SharedAnimals.Count == 0)
                {
                    AnimalsForm.SharedAnimals.Add(new Animal { ID = 1, Name = "Buddy",  Type = "Dog",  Age = "3 Years", HealthStatus = "Vaccinated",    Status = "Available" });
                    AnimalsForm.SharedAnimals.Add(new Animal { ID = 2, Name = "Mittens",Type = "Cat",  Age = "2 Years", HealthStatus = "Needs Vaccine", Status = "Sick"      });
                    AnimalsForm.SharedAnimals.Add(new Animal { ID = 3, Name = "Rex",    Type = "Dog",  Age = "5 Years", HealthStatus = "Vaccinated",    Status = "Adopted"   });
                    AnimalsForm.SharedAnimals.Add(new Animal { ID = 4, Name = "Tweety", Type = "Bird", Age = "1 Year",  HealthStatus = "Vaccinated",    Status = "Available" });
                }
                if (CustomersForm.SharedCustomers.Count == 0)
                {
                    CustomersForm.SharedCustomers.Add(new Customer { ID = 1, Name = "Ahmed Ali",     Phone = "091-234-5678", Email = "ahmed.ali@email.com",    JoinDate = new DateTime(2022, 3, 15)  });
                    CustomersForm.SharedCustomers.Add(new Customer { ID = 2, Name = "Sara Mohamed",  Phone = "092-876-5432", Email = "sara.m@email.com",        JoinDate = new DateTime(2023, 1, 8)   });
                    CustomersForm.SharedCustomers.Add(new Customer { ID = 3, Name = "Khalid Omar",   Phone = "091-998-1122", Email = "khalid.omar@email.com",   JoinDate = new DateTime(2021, 11, 20) });
                    CustomersForm.SharedCustomers.Add(new Customer { ID = 4, Name = "Fatima Hassan", Phone = "093-445-6677", Email = "fatima.h@email.com",      JoinDate = new DateTime(2023, 6, 1)   });
                    CustomersForm.SharedCustomers.Add(new Customer { ID = 5, Name = "Yusuf Ibrahim", Phone = "091-332-9988", Email = "yusuf.ibrahim@email.com", JoinDate = new DateTime(2022, 9, 14)  });
                }

                // Rex (ID=3) is already "Adopted" — seed that record
                SharedAdoptions.Add(new Adoption
                {
                    ID           = 1,
                    AnimalID     = 3,
                    AnimalName   = "Rex",
                    CustomerID   = 2,
                    CustomerName = "Sara Mohamed",
                    CustomerPhone= "092-876-5432",
                    AdoptionDate = new DateTime(2023, 10, 24),
                    FeePaid      = 150m
                });
            }

            SetupGrid();
            RefreshGrid();
        }

        // -------------------- SetupGrid --------------------
        private void SetupGrid()
        {
            dgvAdoptions.AutoGenerateColumns = false;

            // Bind existing designer columns to Adoption properties via DataPropertyName
            ColAdoptionId.DataPropertyName = "ID";
            ColAnimalName.DataPropertyName = "AnimalName";
            ColCustomer.DataPropertyName   = "CustomerName";
            ColPhone.DataPropertyName      = "CustomerPhone";
            ColDate.DataPropertyName       = "AdoptionDate";
            // ColActions has no bound property — painted manually

            dgvAdoptions.DataSource = bsAdoptions;
        }

        // -------------------- RefreshGrid --------------------
        private void RefreshGrid()
        {
            bsAdoptions.DataSource = SharedAdoptions.ToList();
            dgvAdoptions.Refresh();

            // Update pagination info
            if (lblPaginationInfo != null)
                lblPaginationInfo.Text = $"Showing 1 to {SharedAdoptions.Count} of {SharedAdoptions.Count} results";
        }

        // -------------------- GetNextAdoptionId --------------------
        private int GetNextAdoptionId()
        {
            return SharedAdoptions.Count == 0 ? 1 : SharedAdoptions.Max(a => a.ID) + 1;
        }

        // -------------------- New Adoption --------------------
        private void BtnNewAdoption_Click(object sender, EventArgs e)
        {
            using (var reg = new RegisterAdoptionForm())
            {
                reg.StartPosition = FormStartPosition.CenterParent;
                var result = reg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var adoption = new Adoption
                    {
                        ID           = GetNextAdoptionId(),
                        AnimalID     = reg.SelectedAnimalID,
                        AnimalName   = reg.AnimalName,
                        CustomerID   = reg.SelectedCustomerID,
                        CustomerName = reg.CustomerName,
                        CustomerPhone= reg.Phone,
                        AdoptionDate = DateTime.Today,
                        FeePaid      = reg.FeePaid ? 150m : 0m
                    };
                    SharedAdoptions.Add(adoption);
                    RefreshGrid();
                    AdoptionsChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        // --- ROUNDED CORNERS (REGION MASKING) HELPER FOR PANELS ---
        private void Panel_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;

            int radius = 16;

            if (ctrl.Name == "pnlSearchBox") radius = 20;
            else if ((ctrl is Button && ctrl.Name.StartsWith("btnPage")) || ctrl.Name == "btnPrev" || ctrl.Name == "btnNext") radius = 6;
            else if (ctrl is Button && ctrl.Name == "btnNewAdoption") radius = 10;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

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

        // --- DATAGRIDVIEW CELL PAINTING (PILLS & ICONS) ---
        private void dgvAdoptions_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Paint Adoption ID Column (Pill) — show "#AD-001" style from numeric ID
            if (e.ColumnIndex == dgvAdoptions.Columns["ColAdoptionId"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                string idText = e.Value != null ? $"#AD-{e.Value:D3}" : "";
                if (!string.IsNullOrEmpty(idText))
                {
                    int pillHeight = 30;
                    int pillWidth  = 85;

                    int rectY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
                    int rectX = e.CellBounds.X + 10;

                    Rectangle pillRect = new Rectangle(rectX, rectY, pillWidth, pillHeight);

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = 15;
                        path.AddArc(pillRect.X, pillRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(pillRect.Right - (radius * 2), pillRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(pillRect.Right - (radius * 2), pillRect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
                        path.AddArc(pillRect.X, pillRect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        using (SolidBrush brush = new SolidBrush(PillBackground))
                            e.Graphics.FillPath(brush, path);
                    }

                    TextRenderer.DrawText(e.Graphics, idText,
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        pillRect, PillText,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
            // Paint Date Column — formatted as "MMM d, yyyy"
            else if (e.ColumnIndex == dgvAdoptions.Columns["ColDate"].Index)
            {
                e.PaintBackground(e.CellBounds, true);
                if (e.Value is DateTime dt)
                {
                    TextRenderer.DrawText(e.Graphics, dt.ToString("MMM d, yyyy"),
                        e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
                }
                e.Handled = true;
            }
            // Paint Actions Column (Eye Icon)
            else if (e.ColumnIndex == dgvAdoptions.Columns["ColActions"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int centerX = e.CellBounds.X + (e.CellBounds.Width / 2);
                int centerY = e.CellBounds.Y + (e.CellBounds.Height / 2);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(IconColor, 2f))
                {
                    Rectangle eyeRect = new Rectangle(centerX - 10, centerY - 6, 20, 12);
                    e.Graphics.DrawEllipse(pen, eyeRect);

                    using (SolidBrush pupilBrush = new SolidBrush(IconColor))
                        e.Graphics.FillEllipse(pupilBrush, centerX - 3, centerY - 3, 6, 6);
                }
                e.Handled = true;
            }
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e) { }
        private void lblSubtitle_Click(object sender, EventArgs e) { }
        private void lblUserProfile_Click(object sender, EventArgs e) { }
    }
}
