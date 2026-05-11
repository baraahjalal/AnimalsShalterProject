using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class SalesForm : Form
    {
        // --- STYLING CONSTANTS ---
        private readonly Color BorderMuted = ColorTranslator.FromHtml("#D3D8D5");
        private readonly Color BrandGreen = ColorTranslator.FromHtml("#457357");
        private readonly Color SidebarFooterBg = ColorTranslator.FromHtml("#F1EDE4");
        private readonly Color TableHeaderBg = ColorTranslator.FromHtml("#457357");
        private readonly Color IconColor = ColorTranslator.FromHtml("#8A938D");
        
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            // Populate Dummy Data in DGV
            dgvSales.Rows.Add("#S-1001", "Ahmed Ali", "Oct 24, 2023", "2 items", "165.00");
            dgvSales.Rows.Add("#S-1002", "Sarah Jenkins", "Oct 24, 2023", "1 item", "45.00");
            dgvSales.Rows.Add("#S-1003", "Omar Hassan", "Oct 23, 2023", "3 items", "120.00");
            dgvSales.Rows.Add("#S-1004", "Fatima Zohra", "Oct 23, 2023", "1 item", "25.00");
            dgvSales.Rows.Add("#S-1005", "David Smith", "Oct 22, 2023", "4 items", "210.00");

            // Populate Combos
            cmbCustomer.Items.Add("Ahmed Ali");
            cmbCustomer.Items.Add("Sarah Jenkins");
            cmbCustomer.SelectedIndex = 0;

            cmbProduct.Items.Add("Premium Dog Food 5kg - 120 LYD");
            cmbProduct.Items.Add("Cat Litter 10kg - 45 LYD");
            cmbProduct.Items.Add("Dog Leash - 25 LYD");
            cmbProduct.SelectedIndex = 0;

            // Add dummy cart items
            AddCartItem("Premium Dog Food", "1", "120.00");
            AddCartItem("Cat Litter 10kg", "1", "45.00");
            UpdateTotals();

            // Wire up ADD button
            btnAddItem.Click += BtnAddItem_Click;
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex >= 0)
            {
                string[] parts = cmbProduct.SelectedItem.ToString().Split('-');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string price = parts[1].Trim().Replace("LYD", "").Trim();
                    AddCartItem(name, "1", price);
                    UpdateTotals();
                }
            }
        }

        // --- CART ITEM RENDERER ---
        private void AddCartItem(string name, string qty, string price)
        {
            Panel pnlItem = new Panel();
            pnlItem.Width = flpCartItems.Width - 10;
            pnlItem.Height = 50;
            pnlItem.Margin = new Padding(0, 0, 0, 10);
            pnlItem.BackColor = Color.White;
            pnlItem.Tag = price; // Store price for calc
            
            // Apply rounded border logic
            pnlItem.Paint += InputPanel_PaintRoundedBorder;

            Label lblName = new Label();
            lblName.Text = name;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.ForeColor = ColorTranslator.FromHtml("#2A332E");
            lblName.Location = new Point(15, 15);
            lblName.AutoSize = true;

            Label lblPrice = new Label();
            lblPrice.Text = price + " LYD";
            lblPrice.Font = new Font("Segoe UI", 9F);
            lblPrice.ForeColor = BrandGreen;
            lblPrice.Location = new Point(pnlItem.Width - 80, 15);
            lblPrice.AutoSize = true;

            // Delete icon
            Label lblDelete = new Label();
            lblDelete.Text = "✕";
            lblDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDelete.ForeColor = Color.FromArgb(200, 200, 200);
            lblDelete.Cursor = Cursors.Hand;
            lblDelete.Location = new Point(pnlItem.Width - 25, 14);
            lblDelete.AutoSize = true;
            lblDelete.Click += (s, e) => {
                flpCartItems.Controls.Remove(pnlItem);
                pnlItem.Dispose();
                UpdateTotals();
            };
            lblDelete.MouseEnter += (s, e) => lblDelete.ForeColor = Color.Red;
            lblDelete.MouseLeave += (s, e) => lblDelete.ForeColor = Color.FromArgb(200, 200, 200);

            pnlItem.Controls.Add(lblName);
            pnlItem.Controls.Add(lblPrice);
            pnlItem.Controls.Add(lblDelete);

            flpCartItems.Controls.Add(pnlItem);
        }

        private void UpdateTotals()
        {
            decimal subtotal = 0;
            foreach (Control c in flpCartItems.Controls)
            {
                if (c is Panel p && p.Tag != null)
                {
                    if (decimal.TryParse(p.Tag.ToString(), out decimal price))
                        subtotal += price;
                }
            }

            lblSubtotalValue.Text = subtotal.ToString("0.00") + " LYD";
            lblTaxValue.Text = "0.00 LYD";
            lblTotalValue.Text = subtotal.ToString("0.00") + " LYD";
        }

        // --- ROUNDED CORNERS FOR PANELS & BUTTONS ---
        private void Panel_PaintRounded(object sender, PaintEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl == null) return;

            int radius = 16;
            
            // Footer doesn't need top radius, but we'll do all for simplicity
            if (ctrl.Name == "pnlSidebarFooter") radius = 0; 
            if (ctrl.Name == "pnlTotalCard") radius = 16;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (radius > 0)
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

            // Custom border for the total card to give it an accent
            if (ctrl.Name == "pnlTotalCard")
            {
                using (Pen pen = new Pen(BrandGreen, 6f))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, ctrl.Height);
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
            }
        }

        // --- DATAGRIDVIEW CUSTOM PAINTING ---
        private void dgvSales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Custom paint for Header
            if (e.RowIndex == -1)
            {
                e.PaintBackground(e.CellBounds, true);
                
                // Ensure header background is solid BrandGreen
                using (SolidBrush brush = new SolidBrush(TableHeaderBg))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }

                // Draw Text
                if (e.Value != null)
                {
                    TextRenderer.DrawText(e.Graphics, e.Value.ToString(), e.CellStyle.Font, 
                        e.CellBounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                }
                e.Handled = true;
            }
            // Custom paint for rows to ensure subtle borders and clean look
            else if (e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                // Draw very subtle horizontal line at the bottom of each row
                using (Pen pen = new Pen(Color.FromArgb(239, 239, 239), 1f))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }

                e.Handled = true;
            }
        }
    }
}
