using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class AdoptionForm : Form
    {
        // --- STYLING CONSTANTS ---
        private readonly Color PillBackground = ColorTranslator.FromHtml("#E9E7E0");
        private readonly Color PillText = ColorTranslator.FromHtml("#2A332E");
        private readonly Color IconColor = ColorTranslator.FromHtml("#8A938D");

        public AdoptionForm()
        {
            InitializeComponent();
            this.Load += AdoptionForm_Load;

            // Wire button click
            if (this.btnNewAdoption != null)
                this.btnNewAdoption.Click += BtnNewAdoption_Click;
        }

        // Designer references AdoptionsForm_Load (plural) so provide wrapper
        private void AdoptionsForm_Load(object sender, EventArgs e)
        {
            AdoptionForm_Load(sender, e);
        }

        private void AdoptionForm_Load(object sender, EventArgs e)
        {
            // Populate Dummy Data
            dgvAdoptions.Rows.Add("#AD-001", "Bella", "Sarah Jenkins", "(555) 123-4567", "Oct 24, 2023", "");
            dgvAdoptions.Rows.Add("#AD-002", "Max", "Michael Chen", "(555) 987-6543", "Oct 22, 2023", "");
            dgvAdoptions.Rows.Add("#AD-003", "Luna", "Emily Rodriguez", "(555) 456-7890", "Oct 20, 2023", "");
            dgvAdoptions.Rows.Add("#AD-004", "Charlie", "David Smith", "(555) 234-5678", "Oct 19, 2023", "");
            dgvAdoptions.Rows.Add("#AD-005", "Lucy", "Amanda White", "(555) 876-5432", "Oct 15, 2023", "");
            
            // Adjust last column to mimic action links
            if (dgvAdoptions.Columns.Contains("ColActions"))
                dgvAdoptions.Columns["ColActions"].Width = 80;
        }

        private void BtnNewAdoption_Click(object sender, EventArgs e)
        {
            using (var reg = new RegisterAdoptionForm())
            {
                reg.StartPosition = FormStartPosition.CenterParent;
                var result = reg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    // Optionally refresh grid or append a new row if reg exposes data
                    // Add the new adoption row using data from reg
                    try
                    {
                        var id = reg.AdoptionId;
                        var animal = reg.AnimalName;
                        var customer = reg.CustomerName;
                        var phone = reg.Phone ?? "";
                        var date = reg.DateFormatted;
                        dgvAdoptions.Rows.Insert(0, id, animal, customer, phone, date, "");
                    }
                    catch { }
                }
            }
        }

        // --- ROUNDED CORNERS (REGION MASKING) HELPER FOR PANELS ---
        private void Panel_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;

            int radius = 16;
            
            // Search box needs full pill shape
            if (ctrl.Name == "pnlSearchBox") radius = 20;
            // Pagination buttons need smaller radius
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
            if (e.RowIndex < 0) return; // Ignore headers

            // Paint Adoption ID Column (Pill)
            if (e.ColumnIndex == dgvAdoptions.Columns["ColAdoptionId"].Index)
            {
                e.PaintBackground(e.CellBounds, true); // Paint selection bg

                string id = e.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(id))
                {
                    int pillHeight = 30;
                    int pillWidth = 85;
                    
                    int rectY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
                    int rectX = e.CellBounds.X + 10; // Padding left

                    Rectangle pillRect = new Rectangle(rectX, rectY, pillWidth, pillHeight);

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        int radius = 15; // half of height
                        path.AddArc(pillRect.X, pillRect.Y, radius * 2, radius * 2, 180, 90);
                        path.AddArc(pillRect.Right - (radius * 2), pillRect.Y, radius * 2, radius * 2, 270, 90);
                        path.AddArc(pillRect.Right - (radius * 2), pillRect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
                        path.AddArc(pillRect.X, pillRect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
                        path.CloseFigure();

                        using (SolidBrush brush = new SolidBrush(PillBackground))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                    }

                    TextRenderer.DrawText(e.Graphics, id,
                        new Font("Segoe UI", 9F, FontStyle.Bold),
                        pillRect,
                        PillText,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

                e.Handled = true;
            }
            // Paint Actions Column (Eye Icon)
            else if (e.ColumnIndex == dgvAdoptions.Columns["ColActions"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                // Draw a simple eye icon using standard graphics
                int centerX = e.CellBounds.X + (e.CellBounds.Width / 2);
                int centerY = e.CellBounds.Y + (e.CellBounds.Height / 2);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(IconColor, 2f))
                {
                    // Draw outer eye shape (ellipse)
                    Rectangle eyeRect = new Rectangle(centerX - 10, centerY - 6, 20, 12);
                    e.Graphics.DrawEllipse(pen, eyeRect);
                    
                    // Draw inner pupil
                    using (SolidBrush pupilBrush = new SolidBrush(IconColor))
                    {
                        e.Graphics.FillEllipse(pupilBrush, centerX - 3, centerY - 3, 6, 6);
                    }
                }

                e.Handled = true;
            }
        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void lblUserProfile_Click(object sender, EventArgs e)
        {

        }
    }
}
