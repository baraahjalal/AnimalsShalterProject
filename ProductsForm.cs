using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class ProductsForm : Form
    {
        // --- STYLING CONSTANTS ---
        private readonly Color GoodStockColor = ColorTranslator.FromHtml("#457357");
        private readonly Color LowStockColor = ColorTranslator.FromHtml("#D32F2F");
        private readonly Color ProgressBarBg = ColorTranslator.FromHtml("#EFEFEF");
        private readonly Color PillBackgroundGood = ColorTranslator.FromHtml("#E8F5E9");
        private readonly Color PillTextGood = ColorTranslator.FromHtml("#2E7D32");
        private readonly Color PillBackgroundLow = ColorTranslator.FromHtml("#FFEBEE");
        private readonly Color PillTextLow = ColorTranslator.FromHtml("#C62828");
        private readonly Color IconColor = ColorTranslator.FromHtml("#8A938D");
        private readonly Color BorderMuted = ColorTranslator.FromHtml("#D3D8D5");

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            // Dummy Data
            // Format: ID, Name, Price, Stock (as int for progress calculation), Status, Actions
            dgvProducts.Rows.Add("#P-001", "Premium Dog Food", "120 LYD", 85, "In Stock", "");
            dgvProducts.Rows.Add("#P-002", "Cat Litter 10kg", "45 LYD", 15, "Low Stock", "");
            dgvProducts.Rows.Add("#P-003", "Squeaky Toy", "15 LYD", 60, "In Stock", "");
            dgvProducts.Rows.Add("#P-004", "Flea Shampoo", "35 LYD", 5, "Low Stock", "");
            dgvProducts.Rows.Add("#P-005", "Dog Leash", "25 LYD", 40, "In Stock", "");
        }

        private void btnCloseSidebar_Click(object sender, EventArgs e)
        {
            // Simply hide sidebar for now
            pnlSidebar.Visible = false;
        }

        // --- ROUNDED CORNERS FOR PANELS & BUTTONS ---
        private void Panel_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;

            int radius = 16;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(ctrl.Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(ctrl.Width - (radius * 2), ctrl.Height - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(0, ctrl.Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();

                ctrl.Region = new Region(path);

                // Draw accent borders for stats cards
                if (ctrl.Name == "pnlStatTotal" || ctrl.Name == "pnlStatValue")
                {
                    using (Pen pen = new Pen(GoodStockColor, 6f))
                    {
                        e.Graphics.DrawLine(pen, 0, 0, 0, ctrl.Height);
                    }
                }
                else if (ctrl.Name == "pnlStatLow")
                {
                    using (Pen pen = new Pen(LowStockColor, 6f))
                    {
                        e.Graphics.DrawLine(pen, 0, 0, 0, ctrl.Height);
                    }
                }
            }
        }

        private void InputPanel_PaintRoundedBorder(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;

            int radius = 10;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(ctrl.Width - (radius * 2) - 1, 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(ctrl.Width - (radius * 2) - 1, ctrl.Height - (radius * 2) - 1, radius * 2, radius * 2, 0, 90);
                path.AddArc(0, ctrl.Height - (radius * 2) - 1, radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();

                ctrl.Region = new Region(path);

                using (Pen pen = new Pen(BorderMuted, 1.5f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void Button_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;

            int radius = 10;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(ctrl.Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(ctrl.Width - (radius * 2), ctrl.Height - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(0, ctrl.Height - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();

                ctrl.Region = new Region(path);
                
                if (ctrl.Name == "btnCancel")
                {
                    using (Pen pen = new Pen(Color.FromArgb(211, 216, 213), 2f))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
        }

        // --- DATAGRIDVIEW CELL PAINTING (PROGRESS BARS & PILLS) ---
        private void dgvProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore headers

            // Paint Stock Level (Progress Bar)
            if (e.ColumnIndex == dgvProducts.Columns["ColStockLevel"].Index)
            {
                e.PaintBackground(e.CellBounds, true); // Paint selection bg

                if (e.Value != null && int.TryParse(e.Value.ToString(), out int stockValue))
                {
                    int maxStock = 100; // Assume 100 is max capacity
                    int barHeight = 8;
                    int barWidth = e.CellBounds.Width - 40;
                    
                    int rectY = e.CellBounds.Y + (e.CellBounds.Height - barHeight) / 2;
                    int rectX = e.CellBounds.X + 20; // Padding left

                    Rectangle bgRect = new Rectangle(rectX, rectY, barWidth, barHeight);
                    
                    // Determine color based on stock level
                    Color barColor = stockValue < 20 ? LowStockColor : GoodStockColor;
                    
                    int fillWidth = (int)((double)stockValue / maxStock * barWidth);
                    if (fillWidth > barWidth) fillWidth = barWidth;
                    Rectangle fillRect = new Rectangle(rectX, rectY, fillWidth, barHeight);

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    
                    // Draw background track
                    using (GraphicsPath path = GetRoundedRectPath(bgRect, barHeight / 2))
                    using (SolidBrush brush = new SolidBrush(ProgressBarBg))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    // Draw fill progress
                    if (fillWidth > 0)
                    {
                        using (GraphicsPath path = GetRoundedRectPath(fillRect, barHeight / 2))
                        using (SolidBrush brush = new SolidBrush(barColor))
                        {
                            e.Graphics.FillPath(brush, path);
                        }
                    }

                    // Draw text value next to it (optional, but looks good)
                    string textValue = stockValue.ToString();
                    Rectangle textRect = new Rectangle(rectX + barWidth + 5, e.CellBounds.Y, 30, e.CellBounds.Height);
                    TextRenderer.DrawText(e.Graphics, textValue, e.CellStyle.Font, textRect, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
            // Paint Status Column (Pill)
            else if (e.ColumnIndex == dgvProducts.Columns["ColStatus"].Index)
            {
                e.PaintBackground(e.CellBounds, true); 

                string status = e.Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(status))
                {
                    bool isGood = status.ToLower().Contains("in stock");
                    Color bgColor = isGood ? PillBackgroundGood : PillBackgroundLow;
                    Color txtColor = isGood ? PillTextGood : PillTextLow;

                    int pillHeight = 26;
                    int pillWidth = 90;
                    int rectY = e.CellBounds.Y + (e.CellBounds.Height - pillHeight) / 2;
                    int rectX = e.CellBounds.X + 10;

                    Rectangle pillRect = new Rectangle(rectX, rectY, pillWidth, pillHeight);

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (GraphicsPath path = GetRoundedRectPath(pillRect, pillHeight / 2))
                    using (SolidBrush brush = new SolidBrush(bgColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    TextRenderer.DrawText(e.Graphics, status,
                        new Font("Segoe UI", 8F, FontStyle.Bold),
                        pillRect,
                        txtColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                e.Handled = true;
            }
            // Paint Actions Column (Edit Icon)
            else if (e.ColumnIndex == dgvProducts.Columns["ColActions"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                // Draw a simple pencil/edit icon
                int centerX = e.CellBounds.X + (e.CellBounds.Width / 2) - 10;
                int centerY = e.CellBounds.Y + (e.CellBounds.Height / 2);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(IconColor, 2f))
                {
                    // Pencil body
                    Point p1 = new Point(centerX - 4, centerY + 4);
                    Point p2 = new Point(centerX + 4, centerY - 4);
                    e.Graphics.DrawLine(pen, p1, p2);
                    
                    // Pencil tip
                    Point[] tip = { new Point(centerX - 6, centerY + 6), new Point(centerX - 4, centerY + 4), new Point(centerX - 6, centerY + 4) };
                    using (SolidBrush brush = new SolidBrush(IconColor))
                    {
                        e.Graphics.FillPolygon(brush, tip);
                    }
                }
                e.Handled = true;
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }
            
            int r2 = radius * 2;
            path.AddArc(rect.X, rect.Y, r2, r2, 180, 90);
            path.AddArc(rect.Right - r2, rect.Y, r2, r2, 270, 90);
            path.AddArc(rect.Right - r2, rect.Bottom - r2, r2, r2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r2, r2, r2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
