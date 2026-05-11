using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class ProductsForm : Form
    {
        // --- STATIC SHARED LIST (mirrors AnimalsForm.SharedAnimals pattern) ---
        public static EventHandler ProductsChanged;
        public static List<Product> SharedProducts = new List<Product>();
        private BindingSource bsProducts = new BindingSource();

        // Tracks whether we are editing an existing product (ID > 0) or adding new (0)
        private int _editingProductId = 0;

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

            // Wire buttons
            this.btnSaveProduct.Click += BtnSaveProduct_Click;
            this.btnCancel.Click += btnCloseSidebar_Click;

            // Wire cell-click for Edit / Delete actions
            this.dgvProducts.CellMouseClick += DgvProducts_CellMouseClick;

            this.Load += ProductsForm_Load;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            // Seed dummy data only once per session
            if (SharedProducts.Count == 0)
            {
                SharedProducts.Add(new Product { ID = 1, Name = "Premium Dog Food", Category = "Food",    Price = 120m, Stock = 85, Status = "In Stock"   });
                SharedProducts.Add(new Product { ID = 2, Name = "Cat Litter 10kg",  Category = "Food",    Price = 45m,  Stock = 15, Status = "Low Stock"  });
                SharedProducts.Add(new Product { ID = 3, Name = "Squeaky Toy",       Category = "Toys",    Price = 15m,  Stock = 60, Status = "In Stock"   });
                SharedProducts.Add(new Product { ID = 4, Name = "Flea Shampoo",      Category = "Medical", Price = 35m,  Stock = 5,  Status = "Low Stock"  });
                SharedProducts.Add(new Product { ID = 5, Name = "Dog Leash",         Category = "Accessories", Price = 25m, Stock = 40, Status = "In Stock" });
            }

            SetupGrid();
            RefreshGrid();

            // Hide sidebar on load; it opens when Add or Edit is triggered
            pnlSidebar.Visible = false;
        }

        // -------------------- Grid Setup (called once) --------------------
        private void SetupGrid()
        {
            dgvProducts.AutoGenerateColumns = false;

            // Assign DataPropertyName to the designer-created columns
            ColId.DataPropertyName         = "ID";
            ColName.DataPropertyName       = "Name";
            ColPrice.DataPropertyName      = "Price";
            ColStockLevel.DataPropertyName = "Stock";
            ColStatus.DataPropertyName     = "Status";
            // ColActions has no bound property — it is painted manually

            // Format price as "120 LYD"
            ColPrice.DefaultCellStyle.Format = "";  // we handle display via CellFormatting

            dgvProducts.DataSource = bsProducts;
        }

        // -------------------- Grid Refresh --------------------
        private void RefreshGrid()
        {
            bsProducts.DataSource = SharedProducts.ToList();
            dgvProducts.Refresh();
            UpdateStats();
        }

        // -------------------- Stats Labels --------------------
        private void UpdateStats()
        {
            lblStatTotal.Text = SharedProducts.Count.ToString();
            lblStatLow.Text   = SharedProducts.Count(p => p.Stock < 20).ToString();

            decimal totalValue = SharedProducts.Sum(p => p.Price * p.Stock);
            lblStatValue.Text = totalValue.ToString("N0") + " LYD";
        }

        // -------------------- GetNextProductId --------------------
        private int GetNextProductId()
        {
            return SharedProducts.Count == 0 ? 1 : SharedProducts.Max(p => p.ID) + 1;
        }

        // -------------------- Open Sidebar for Add --------------------
        private void OpenSidebarForAdd()
        {
            _editingProductId = 0;
            lblSidebarTitle.Text = "Add new product";
            txtProductName.Text  = "";
            txtPrice.Text        = "";
            txtQuantity.Text     = "";
            cmbCategory.SelectedIndex = -1;
            pnlSidebar.Visible = true;
        }

        // -------------------- Open Sidebar for Edit --------------------
        private void OpenSidebarForEdit(Product p)
        {
            _editingProductId    = p.ID;
            lblSidebarTitle.Text = "Edit product";
            txtProductName.Text  = p.Name;
            txtPrice.Text        = p.Price.ToString("0.##");
            txtQuantity.Text     = p.Stock.ToString();
            // Try to select matching category
            int idx = cmbCategory.Items.IndexOf(p.Category);
            cmbCategory.SelectedIndex = idx >= 0 ? idx : -1;
            pnlSidebar.Visible = true;
        }

        // -------------------- Save Product (Add or Edit) --------------------
        private void BtnSaveProduct_Click(object sender, EventArgs e)
        {
            string name = txtProductName.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string qtyText   = txtQuantity.Text.Trim();
            string category  = cmbCategory.SelectedItem?.ToString() ?? "";

            // Basic validation
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Product Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(qtyText, out int stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid Quantity (whole number).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = stock == 0 ? "Out of Stock" : stock < 20 ? "Low Stock" : "In Stock";

            if (_editingProductId == 0)
            {
                // --- ADD ---
                var newProduct = new Product
                {
                    ID       = GetNextProductId(),
                    Name     = name,
                    Category = category,
                    Price    = price,
                    Stock    = stock,
                    Status   = status
                };
                SharedProducts.Add(newProduct);
            }
            else
            {
                // --- EDIT ---
                var existing = SharedProducts.FirstOrDefault(p => p.ID == _editingProductId);
                if (existing != null)
                {
                    existing.Name     = name;
                    existing.Category = category;
                    existing.Price    = price;
                    existing.Stock    = stock;
                    existing.Status   = status;
                }
            }

            pnlSidebar.Visible = false;
            RefreshGrid();
            ProductsChanged?.Invoke(this, EventArgs.Empty);
        }

        // -------------------- Sidebar Close / Cancel --------------------
        private void btnCloseSidebar_Click(object sender, EventArgs e)
        {
            pnlSidebar.Visible = false;
        }

        // -------------------- Cell Click: Edit / Delete --------------------
        private void DgvProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dgvProducts.Columns[e.ColumnIndex];
            if (col.Name != "ColActions") return;

            // Left half = Edit, right half = Delete
            Rectangle cellRect  = dgvProducts.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            int relativeX       = e.X - cellRect.X;
            bool isEdit         = relativeX < cellRect.Width / 2;

            var bound = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (bound == null) return;

            int id = bound.ID;

            if (isEdit)
            {
                var product = SharedProducts.FirstOrDefault(p => p.ID == id);
                if (product != null)
                    OpenSidebarForEdit(product);
            }
            else
            {
                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                var toRemove = SharedProducts.FirstOrDefault(p => p.ID == id);
                if (toRemove != null)
                {
                    SharedProducts.Remove(toRemove);
                    RefreshGrid();
                    ProductsChanged?.Invoke(this, EventArgs.Empty);
                }
            }
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
            // Paint Price Column (format as "X LYD")
            else if (e.ColumnIndex == dgvProducts.Columns["ColPrice"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                if (e.Value != null)
                {
                    string priceText = e.Value + " LYD";
                    TextRenderer.DrawText(e.Graphics, priceText, e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor,
                        TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding);
                }
                e.Handled = true;
            }
            // Paint Actions Column (Edit Icon left | Delete icon right)
            else if (e.ColumnIndex == dgvProducts.Columns["ColActions"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int centerX = e.CellBounds.X + (e.CellBounds.Width / 2) - 10;
                int centerY = e.CellBounds.Y + (e.CellBounds.Height / 2);

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(IconColor, 2f))
                {
                    // Pencil body (left half = Edit)
                    Point p1 = new Point(centerX - 4, centerY + 4);
                    Point p2 = new Point(centerX + 4, centerY - 4);
                    e.Graphics.DrawLine(pen, p1, p2);
                    
                    // Pencil tip
                    Point[] tip = { new Point(centerX - 6, centerY + 6), new Point(centerX - 4, centerY + 4), new Point(centerX - 6, centerY + 4) };
                    using (SolidBrush brush = new SolidBrush(IconColor))
                    {
                        e.Graphics.FillPolygon(brush, tip);
                    }

                    // Trash icon (right half = Delete) — simple X
                    int dx = centerX + 18;
                    using (Pen redPen = new Pen(LowStockColor, 2f))
                    {
                        e.Graphics.DrawLine(redPen, dx - 4, centerY - 4, dx + 4, centerY + 4);
                        e.Graphics.DrawLine(redPen, dx + 4, centerY - 4, dx - 4, centerY + 4);
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
