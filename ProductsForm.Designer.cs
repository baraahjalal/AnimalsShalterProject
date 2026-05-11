namespace AnimalsShalterProject
{
    partial class ProductsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTableContainer = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStockLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStatValue = new System.Windows.Forms.Panel();
            this.lblStatValueTitle = new System.Windows.Forms.Label();
            this.lblStatValue = new System.Windows.Forms.Label();
            this.pnlStatLow = new System.Windows.Forms.Panel();
            this.lblStatLowTitle = new System.Windows.Forms.Label();
            this.lblStatLow = new System.Windows.Forms.Label();
            this.pnlStatTotal = new System.Windows.Forms.Panel();
            this.lblStatTotalTitle = new System.Windows.Forms.Label();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlCategoryInput = new System.Windows.Forms.Panel();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlQtyInput = new System.Windows.Forms.Panel();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.pnlPriceInput = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pnlNameInput = new System.Windows.Forms.Panel();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.btnCloseSidebar = new System.Windows.Forms.Button();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlSidebarFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.pnlStatValue.SuspendLayout();
            this.pnlStatLow.SuspendLayout();
            this.pnlStatTotal.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlCategoryInput.SuspendLayout();
            this.pnlQtyInput.SuspendLayout();
            this.pnlPriceInput.SuspendLayout();
            this.pnlNameInput.SuspendLayout();
            this.pnlSidebarFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlTableContainer);
            this.pnlMain.Controls.Add(this.lblProductsTitle);
            this.pnlMain.Controls.Add(this.pnlStats);
            this.pnlMain.Controls.Add(this.lblHeaderTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMain.Size = new System.Drawing.Size(850, 749);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlTableContainer
            // 
            this.pnlTableContainer.BackColor = System.Drawing.Color.White;
            this.pnlTableContainer.Controls.Add(this.dgvProducts);
            this.pnlTableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableContainer.Location = new System.Drawing.Point(30, 246);
            this.pnlTableContainer.Name = "pnlTableContainer";
            this.pnlTableContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTableContainer.Size = new System.Drawing.Size(790, 473);
            this.pnlTableContainer.TabIndex = 3;
            this.pnlTableContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeight = 50;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColId,
            this.ColName,
            this.ColPrice,
            this.ColStockLevel,
            this.ColStatus,
            this.ColActions});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dgvProducts.Location = new System.Drawing.Point(20, 20);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 60;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(750, 433);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProducts_CellPainting);
            // 
            // ColId
            // 
            this.ColId.HeaderText = "ID";
            this.ColId.MinimumWidth = 6;
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Product Name";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColPrice
            // 
            this.ColPrice.HeaderText = "Price";
            this.ColPrice.MinimumWidth = 6;
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            // 
            // ColStockLevel
            // 
            this.ColStockLevel.HeaderText = "Stock Level";
            this.ColStockLevel.MinimumWidth = 6;
            this.ColStockLevel.Name = "ColStockLevel";
            this.ColStockLevel.ReadOnly = true;
            // 
            // ColStatus
            // 
            this.ColStatus.HeaderText = "Status";
            this.ColStatus.MinimumWidth = 6;
            this.ColStatus.Name = "ColStatus";
            this.ColStatus.ReadOnly = true;
            // 
            // ColActions
            // 
            this.ColActions.HeaderText = "Actions";
            this.ColActions.MinimumWidth = 6;
            this.ColActions.Name = "ColActions";
            this.ColActions.ReadOnly = true;
            // 
            // lblProductsTitle
            // 
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblProductsTitle.Location = new System.Drawing.Point(30, 201);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.lblProductsTitle.Size = new System.Drawing.Size(120, 45);
            this.lblProductsTitle.TabIndex = 2;
            this.lblProductsTitle.Text = "All Products";
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.pnlStatValue);
            this.pnlStats.Controls.Add(this.pnlStatLow);
            this.pnlStats.Controls.Add(this.pnlStatTotal);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(30, 81);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlStats.Size = new System.Drawing.Size(790, 120);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlStatValue
            // 
            this.pnlStatValue.BackColor = System.Drawing.Color.White;
            this.pnlStatValue.Controls.Add(this.lblStatValueTitle);
            this.pnlStatValue.Controls.Add(this.lblStatValue);
            this.pnlStatValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStatValue.Location = new System.Drawing.Point(440, 0);
            this.pnlStatValue.Name = "pnlStatValue";
            this.pnlStatValue.Padding = new System.Windows.Forms.Padding(20);
            this.pnlStatValue.Size = new System.Drawing.Size(200, 100);
            this.pnlStatValue.TabIndex = 2;
            this.pnlStatValue.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // lblStatValueTitle
            // 
            this.lblStatValueTitle.AutoSize = true;
            this.lblStatValueTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatValueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblStatValueTitle.Location = new System.Drawing.Point(20, 20);
            this.lblStatValueTitle.Name = "lblStatValueTitle";
            this.lblStatValueTitle.Size = new System.Drawing.Size(112, 19);
            this.lblStatValueTitle.TabIndex = 1;
            this.lblStatValueTitle.Text = "Total Stock Value";
            // 
            // lblStatValue
            // 
            this.lblStatValue.AutoSize = true;
            this.lblStatValue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblStatValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblStatValue.Location = new System.Drawing.Point(17, 45);
            this.lblStatValue.Name = "lblStatValue";
            this.lblStatValue.Size = new System.Drawing.Size(143, 37);
            this.lblStatValue.TabIndex = 0;
            this.lblStatValue.Text = "1,240 LYD";
            // 
            // pnlStatLow
            // 
            this.pnlStatLow.BackColor = System.Drawing.Color.White;
            this.pnlStatLow.Controls.Add(this.lblStatLowTitle);
            this.pnlStatLow.Controls.Add(this.lblStatLow);
            this.pnlStatLow.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStatLow.Location = new System.Drawing.Point(220, 0);
            this.pnlStatLow.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.pnlStatLow.Name = "pnlStatLow";
            this.pnlStatLow.Padding = new System.Windows.Forms.Padding(20);
            this.pnlStatLow.Size = new System.Drawing.Size(220, 100);
            this.pnlStatLow.TabIndex = 1;
            this.pnlStatLow.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // lblStatLowTitle
            // 
            this.lblStatLowTitle.AutoSize = true;
            this.lblStatLowTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatLowTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblStatLowTitle.Location = new System.Drawing.Point(20, 20);
            this.lblStatLowTitle.Name = "lblStatLowTitle";
            this.lblStatLowTitle.Size = new System.Drawing.Size(71, 19);
            this.lblStatLowTitle.TabIndex = 1;
            this.lblStatLowTitle.Text = "Low Stock";
            // 
            // lblStatLow
            // 
            this.lblStatLow.AutoSize = true;
            this.lblStatLow.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblStatLow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblStatLow.Location = new System.Drawing.Point(17, 45);
            this.lblStatLow.Name = "lblStatLow";
            this.lblStatLow.Size = new System.Drawing.Size(33, 37);
            this.lblStatLow.TabIndex = 0;
            this.lblStatLow.Text = "3";
            // 
            // pnlStatTotal
            // 
            this.pnlStatTotal.BackColor = System.Drawing.Color.White;
            this.pnlStatTotal.Controls.Add(this.lblStatTotalTitle);
            this.pnlStatTotal.Controls.Add(this.lblStatTotal);
            this.pnlStatTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStatTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlStatTotal.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.pnlStatTotal.Name = "pnlStatTotal";
            this.pnlStatTotal.Padding = new System.Windows.Forms.Padding(20);
            this.pnlStatTotal.Size = new System.Drawing.Size(220, 100);
            this.pnlStatTotal.TabIndex = 0;
            this.pnlStatTotal.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // lblStatTotalTitle
            // 
            this.lblStatTotalTitle.AutoSize = true;
            this.lblStatTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblStatTotalTitle.Location = new System.Drawing.Point(20, 20);
            this.lblStatTotalTitle.Name = "lblStatTotalTitle";
            this.lblStatTotalTitle.Size = new System.Drawing.Size(96, 19);
            this.lblStatTotalTitle.TabIndex = 1;
            this.lblStatTotalTitle.Text = "Total Products";
            // 
            // lblStatTotal
            // 
            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblStatTotal.Location = new System.Drawing.Point(17, 45);
            this.lblStatTotal.Name = "lblStatTotal";
            this.lblStatTotal.Size = new System.Drawing.Size(33, 37);
            this.lblStatTotal.TabIndex = 0;
            this.lblStatTotal.Text = "8";
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(30, 30);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblHeaderTitle.Size = new System.Drawing.Size(308, 51);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Inventory / Products";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.pnlCategoryInput);
            this.pnlSidebar.Controls.Add(this.lblCategory);
            this.pnlSidebar.Controls.Add(this.pnlQtyInput);
            this.pnlSidebar.Controls.Add(this.lblQuantity);
            this.pnlSidebar.Controls.Add(this.pnlPriceInput);
            this.pnlSidebar.Controls.Add(this.lblPrice);
            this.pnlSidebar.Controls.Add(this.pnlNameInput);
            this.pnlSidebar.Controls.Add(this.lblProductName);
            this.pnlSidebar.Controls.Add(this.btnCloseSidebar);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Controls.Add(this.pnlSidebarFooter);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebar.Location = new System.Drawing.Point(850, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(30);
            this.pnlSidebar.Size = new System.Drawing.Size(350, 749);
            this.pnlSidebar.TabIndex = 1;
            // 
            // pnlCategoryInput
            // 
            this.pnlCategoryInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlCategoryInput.Controls.Add(this.cmbCategory);
            this.pnlCategoryInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCategoryInput.Location = new System.Drawing.Point(30, 382);
            this.pnlCategoryInput.Name = "pnlCategoryInput";
            this.pnlCategoryInput.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlCategoryInput.Size = new System.Drawing.Size(290, 45);
            this.pnlCategoryInput.TabIndex = 9;
            this.pnlCategoryInput.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Food",
            "Toys",
            "Medical",
            "Accessories"});
            this.cmbCategory.Location = new System.Drawing.Point(15, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(260, 25);
            this.cmbCategory.TabIndex = 0;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblCategory.Location = new System.Drawing.Point(30, 347);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblCategory.Size = new System.Drawing.Size(54, 35);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Category";
            // 
            // pnlQtyInput
            // 
            this.pnlQtyInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlQtyInput.Controls.Add(this.txtQuantity);
            this.pnlQtyInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQtyInput.Location = new System.Drawing.Point(30, 302);
            this.pnlQtyInput.Name = "pnlQtyInput";
            this.pnlQtyInput.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlQtyInput.Size = new System.Drawing.Size(290, 45);
            this.pnlQtyInput.TabIndex = 7;
            this.pnlQtyInput.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtQuantity.Location = new System.Drawing.Point(15, 12);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(260, 18);
            this.txtQuantity.TabIndex = 0;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblQuantity.Location = new System.Drawing.Point(30, 267);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblQuantity.Size = new System.Drawing.Size(53, 35);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantity";
            // 
            // pnlPriceInput
            // 
            this.pnlPriceInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlPriceInput.Controls.Add(this.txtPrice);
            this.pnlPriceInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPriceInput.Location = new System.Drawing.Point(30, 222);
            this.pnlPriceInput.Name = "pnlPriceInput";
            this.pnlPriceInput.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlPriceInput.Size = new System.Drawing.Size(290, 45);
            this.pnlPriceInput.TabIndex = 5;
            this.pnlPriceInput.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtPrice.Location = new System.Drawing.Point(15, 12);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(260, 18);
            this.txtPrice.TabIndex = 0;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblPrice.Location = new System.Drawing.Point(30, 187);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblPrice.Size = new System.Drawing.Size(33, 35);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price";
            // 
            // pnlNameInput
            // 
            this.pnlNameInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlNameInput.Controls.Add(this.txtProductName);
            this.pnlNameInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNameInput.Location = new System.Drawing.Point(30, 142);
            this.pnlNameInput.Name = "pnlNameInput";
            this.pnlNameInput.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlNameInput.Size = new System.Drawing.Size(290, 45);
            this.pnlNameInput.TabIndex = 3;
            this.pnlNameInput.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.txtProductName.Location = new System.Drawing.Point(15, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(260, 18);
            this.txtProductName.TabIndex = 0;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblProductName.Location = new System.Drawing.Point(30, 107);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblProductName.Size = new System.Drawing.Size(84, 35);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Product Name";
            // 
            // btnCloseSidebar
            // 
            this.btnCloseSidebar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseSidebar.FlatAppearance.BorderSize = 0;
            this.btnCloseSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSidebar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCloseSidebar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.btnCloseSidebar.Location = new System.Drawing.Point(290, 30);
            this.btnCloseSidebar.Name = "btnCloseSidebar";
            this.btnCloseSidebar.Size = new System.Drawing.Size(30, 30);
            this.btnCloseSidebar.TabIndex = 1;
            this.btnCloseSidebar.Text = "✕";
            this.btnCloseSidebar.UseVisualStyleBackColor = true;
            this.btnCloseSidebar.Click += new System.EventHandler(this.btnCloseSidebar_Click);
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(30, 30);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 47);
            this.lblSidebarTitle.Size = new System.Drawing.Size(194, 77);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "Add new product";
            // 
            // pnlSidebarFooter
            // 
            this.pnlSidebarFooter.Controls.Add(this.btnCancel);
            this.pnlSidebarFooter.Controls.Add(this.btnSaveProduct);
            this.pnlSidebarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSidebarFooter.Location = new System.Drawing.Point(30, 659);
            this.pnlSidebarFooter.Name = "pnlSidebarFooter";
            this.pnlSidebarFooter.Size = new System.Drawing.Size(290, 60);
            this.pnlSidebarFooter.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnCancel.Location = new System.Drawing.Point(0, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCloseSidebar_Click);
            this.btnCancel.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_PaintRounded);
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnSaveProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveProduct.FlatAppearance.BorderSize = 0;
            this.btnSaveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProduct.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveProduct.ForeColor = System.Drawing.Color.White;
            this.btnSaveProduct.Location = new System.Drawing.Point(110, 10);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(180, 40);
            this.btnSaveProduct.TabIndex = 1;
            this.btnSaveProduct.Text = "Save Product";
            this.btnSaveProduct.UseVisualStyleBackColor = false;
            this.btnSaveProduct.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_PaintRounded);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 749);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory / Products";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStatValue.ResumeLayout(false);
            this.pnlStatValue.PerformLayout();
            this.pnlStatLow.ResumeLayout(false);
            this.pnlStatLow.PerformLayout();
            this.pnlStatTotal.ResumeLayout(false);
            this.pnlStatTotal.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlCategoryInput.ResumeLayout(false);
            this.pnlQtyInput.ResumeLayout(false);
            this.pnlQtyInput.PerformLayout();
            this.pnlPriceInput.ResumeLayout(false);
            this.pnlPriceInput.PerformLayout();
            this.pnlNameInput.ResumeLayout(false);
            this.pnlNameInput.PerformLayout();
            this.pnlSidebarFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlStatTotal;
        private System.Windows.Forms.Label lblStatTotalTitle;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Panel pnlStatLow;
        private System.Windows.Forms.Label lblStatLowTitle;
        private System.Windows.Forms.Label lblStatLow;
        private System.Windows.Forms.Panel pnlStatValue;
        private System.Windows.Forms.Label lblStatValueTitle;
        private System.Windows.Forms.Label lblStatValue;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Panel pnlTableContainer;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStockLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColActions;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Button btnCloseSidebar;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel pnlNameInput;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Panel pnlPriceInput;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Panel pnlQtyInput;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Panel pnlCategoryInput;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Panel pnlSidebarFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveProduct;
    }
}