using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsShalterProject
{
    public partial class SalesForm : Form
    {
        private readonly Color BorderMuted = ColorTranslator.FromHtml("#D3D8D5");
        private readonly Color BrandGreen = ColorTranslator.FromHtml("#457357");
        private readonly Color SidebarFooterBg = ColorTranslator.FromHtml("#F1EDE4");
        private readonly Color TableHeaderBg = ColorTranslator.FromHtml("#457357");
        private readonly Color IconColor = ColorTranslator.FromHtml("#8A938D");
        
        public static EventHandler SalesChanged;
        public static List<Sale> SharedSales = new List<Sale>();
        private BindingSource bsSales = new BindingSource();
        private List<SaleDetail> _cartItems = new List<SaleDetail>();
        private int nextTempDetailId = 1;

        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            // E1.4 Seed Data
            if (SharedSales.Count == 0)
            {
                var c1 = CustomersForm.SharedCustomers.FirstOrDefault() ?? new Customer { ID = 1, Name = "Ahmed Ali" };
                var p1 = ProductsForm.SharedProducts.FirstOrDefault(p => p.Price == 120) ?? ProductsForm.SharedProducts.FirstOrDefault() ?? new Product { ID = 1, Name = "Premium Dog Food", Price = 120 };
                var p2 = ProductsForm.SharedProducts.FirstOrDefault(p => p.Price == 45) ?? ProductsForm.SharedProducts.Skip(1).FirstOrDefault() ?? new Product { ID = 2, Name = "Cat Litter", Price = 45 };

                var sampleSale = new Sale { ID = GetNextSaleId(), CustomerID = c1.ID, CustomerName = c1.Name, SaleDate = DateTime.Today };
                sampleSale.Details.Add(new SaleDetail { ID = 1, SaleID = sampleSale.ID, ProductID = p1.ID, ProductName = p1.Name, Quantity = 1, UnitPrice = p1.Price });
                sampleSale.Details.Add(new SaleDetail { ID = 2, SaleID = sampleSale.ID, ProductID = p2.ID, ProductName = p2.Name, Quantity = 1, UnitPrice = p2.Price });
                sampleSale.TotalAmount = sampleSale.Details.Sum(d => d.Subtotal);
                SharedSales.Add(sampleSale);
            }

            SetupSalesGrid();

            // E2.1 Customer Dropdown
            cmbCustomer.DataSource = CustomersForm.SharedCustomers.ToList();
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "ID";
            if (cmbCustomer.Items.Count > 0) cmbCustomer.SelectedIndex = 0;

            // E2.2 Product Dropdown
            cmbProduct.DataSource = ProductsForm.SharedProducts.Where(p => p.Stock > 0).ToList();
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "ID";
            if (cmbProduct.Items.Count > 0) cmbProduct.SelectedIndex = 0;

            btnAddItem.Click += BtnAddItem_Click;
            btnCompleteSale.Click += BtnCompleteSale_Click;
        }

        private void SetupSalesGrid()
        {
            dgvSales.AutoGenerateColumns = false;
            dgvSales.Columns["ColSaleId"].DataPropertyName = "ID";
            dgvSales.Columns["ColCustomer"].DataPropertyName = "CustomerName";
            dgvSales.Columns["ColDate"].DataPropertyName = "SaleDate";
            dgvSales.Columns["ColTotal"].DataPropertyName = "TotalAmount";
            // For ColItems, we need custom formatting since it's a list. We'll handle it in CellFormatting.
            dgvSales.CellFormatting += DgvSales_CellFormatting;
            RefreshSalesGrid();
        }

        private void RefreshSalesGrid()
        {
            bsSales.DataSource = SharedSales.ToList();
            dgvSales.DataSource = bsSales;
            
            decimal todayTotal = SharedSales.Where(s => s.SaleDate.Date == DateTime.Today).Sum(s => s.TotalAmount);
            lblTotalAmount.Text = $"{todayTotal:N2} LYD";
        }

        private void DgvSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            var colName = dgvSales.Columns[e.ColumnIndex].Name;

            if (colName == "ColSaleId" && e.Value is int id)
            {
                e.Value = $"#S-{id}";
                e.FormattingApplied = true;
            }
            else if (colName == "ColDate" && e.Value is DateTime dt)
            {
                e.Value = dt.ToString("MMM dd, yyyy");
                e.FormattingApplied = true;
            }
            else if (colName == "ColTotal" && e.Value is decimal total)
            {
                e.Value = $"{total:N2}";
                e.FormattingApplied = true;
            }
            else if (colName == "ColItems")
            {
                var sale = (Sale)dgvSales.Rows[e.RowIndex].DataBoundItem;
                int itemsCount = sale.Details.Sum(d => d.Quantity);
                e.Value = itemsCount == 1 ? "1 item" : $"{itemsCount} items";
                e.FormattingApplied = true;
            }
        }

        private int GetNextSaleId()
        {
            return SharedSales.Count == 0 ? 1001 : SharedSales.Max(s => s.ID) + 1;
        }

        private int GetNextDetailId()
        {
            int max = 0;
            foreach (var s in SharedSales)
                foreach (var d in s.Details)
                    if (d.ID > max) max = d.ID;
            return max + 1;
        }

        // --- CART ITEM RENDERER ---
        private void RenderCart()
        {
            flpCartItems.Controls.Clear();
            foreach (var item in _cartItems)
            {
                Panel pnlItem = new Panel();
                pnlItem.Width = flpCartItems.Width - 10;
                pnlItem.Height = 50;
                pnlItem.Margin = new Padding(0, 0, 0, 10);
                pnlItem.BackColor = Color.White;
                pnlItem.Paint += InputPanel_PaintRoundedBorder;

                Label lblName = new Label();
                lblName.Text = $"{item.Quantity}x {item.ProductName}";
                lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lblName.ForeColor = ColorTranslator.FromHtml("#2A332E");
                lblName.Location = new Point(15, 15);
                lblName.AutoSize = true;

                Label lblPrice = new Label();
                lblPrice.Text = item.Subtotal.ToString("0.00") + " LYD";
                lblPrice.Font = new Font("Segoe UI", 9F);
                lblPrice.ForeColor = BrandGreen;
                lblPrice.Location = new Point(pnlItem.Width - 80, 15);
                lblPrice.AutoSize = true;

                Label lblDelete = new Label();
                lblDelete.Text = "✕";
                lblDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                lblDelete.ForeColor = Color.FromArgb(200, 200, 200);
                lblDelete.Cursor = Cursors.Hand;
                lblDelete.Location = new Point(pnlItem.Width - 25, 14);
                lblDelete.AutoSize = true;
                lblDelete.Click += (s, e) => {
                    _cartItems.Remove(item);
                    RenderCart();
                    UpdateTotals();
                };
                lblDelete.MouseEnter += (s, e) => lblDelete.ForeColor = Color.Red;
                lblDelete.MouseLeave += (s, e) => lblDelete.ForeColor = Color.FromArgb(200, 200, 200);

                pnlItem.Controls.Add(lblName);
                pnlItem.Controls.Add(lblPrice);
                pnlItem.Controls.Add(lblDelete);

                flpCartItems.Controls.Add(pnlItem);
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedItem is Product selectedProduct)
            {
                // Verify stock
                int qtyToAdd = 1; // Always add 1 at a time as there's no qty input
                var existingItem = _cartItems.FirstOrDefault(d => d.ProductID == selectedProduct.ID);
                int currentCartQty = existingItem != null ? existingItem.Quantity : 0;
                
                // Live lookup from SharedProducts
                var liveProduct = ProductsForm.SharedProducts.FirstOrDefault(p => p.ID == selectedProduct.ID);
                if (liveProduct == null) return;

                if (currentCartQty + qtyToAdd > liveProduct.Stock)
                {
                    MessageBox.Show($"Not enough stock. Only {liveProduct.Stock} units available.", "Stock Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (existingItem != null)
                {
                    existingItem.Quantity += qtyToAdd;
                }
                else
                {
                    _cartItems.Add(new SaleDetail
                    {
                        ID = nextTempDetailId++,
                        ProductID = liveProduct.ID,
                        ProductName = liveProduct.Name,
                        Quantity = qtyToAdd,
                        UnitPrice = liveProduct.Price
                    });
                }

                RenderCart();
                UpdateTotals();
            }
        }

        private void UpdateTotals()
        {
            decimal subtotal = _cartItems.Sum(i => i.Subtotal);

            lblSubtotalValue.Text = subtotal.ToString("0.00") + " LYD";
            lblTaxValue.Text = "0.00 LYD";
            lblTotalValue.Text = subtotal.ToString("0.00") + " LYD";
        }

        private void BtnCompleteSale_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Re-verify stock for all items
            foreach (var item in _cartItems)
            {
                var liveProduct = ProductsForm.SharedProducts.FirstOrDefault(p => p.ID == item.ProductID);
                if (liveProduct == null || item.Quantity > liveProduct.Stock)
                {
                    MessageBox.Show($"Not enough stock for '{item.ProductName}'. Available: {liveProduct?.Stock ?? 0}", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var selectedCustomer = (Customer)cmbCustomer.SelectedItem;
            
            Sale newSale = new Sale
            {
                ID = GetNextSaleId(),
                CustomerID = selectedCustomer.ID,
                CustomerName = selectedCustomer.Name,
                SaleDate = DateTime.Today,
                TotalAmount = _cartItems.Sum(i => i.Subtotal)
            };

            foreach (var item in _cartItems)
            {
                var detail = new SaleDetail
                {
                    ID = GetNextDetailId(),
                    SaleID = newSale.ID,
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice // Snapshot
                };
                newSale.Details.Add(detail);

                // Decrement stock
                var liveProduct = ProductsForm.SharedProducts.FirstOrDefault(p => p.ID == item.ProductID);
                if (liveProduct != null)
                {
                    liveProduct.Stock -= item.Quantity;
                }
            }

            SharedSales.Add(newSale);
            SalesChanged?.Invoke(this, EventArgs.Empty);
            ProductsForm.ProductsChanged?.Invoke(this, EventArgs.Empty);

            MessageBox.Show($"Sale confirmed! Total: {newSale.TotalAmount:0.00} LYD", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear Cart
            _cartItems.Clear();
            RenderCart();
            UpdateTotals();
            RefreshSalesGrid();

            // Refresh Product Dropdown to reflect updated stock
            var currentProdId = cmbProduct.SelectedValue;
            cmbProduct.DataSource = ProductsForm.SharedProducts.Where(p => p.Stock > 0).ToList();
            if (currentProdId != null) cmbProduct.SelectedValue = currentProdId;
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
