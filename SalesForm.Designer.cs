namespace AnimalsShalterProject
{
    partial class SalesForm
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
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.ColSaleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlTotalCard = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.flpCartItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlProductSelect = new System.Windows.Forms.Panel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.pnlProductInput = new System.Windows.Forms.Panel();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.pnlCustomerSelect = new System.Windows.Forms.Panel();
            this.pnlCustomerInput = new System.Windows.Forms.Panel();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlSidebarFooter = new System.Windows.Forms.Panel();
            this.btnCompleteSale = new System.Windows.Forms.Button();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTaxValue = new System.Windows.Forms.Label();
            this.lblTaxLabel = new System.Windows.Forms.Label();
            this.lblSubtotalValue = new System.Windows.Forms.Label();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlTableContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTotalCard.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlProductSelect.SuspendLayout();
            this.pnlProductInput.SuspendLayout();
            this.pnlCustomerSelect.SuspendLayout();
            this.pnlCustomerInput.SuspendLayout();
            this.pnlSidebarFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlTableContainer);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMain.Size = new System.Drawing.Size(800, 749);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlTableContainer
            // 
            this.pnlTableContainer.BackColor = System.Drawing.Color.White;
            this.pnlTableContainer.Controls.Add(this.dgvSales);
            this.pnlTableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableContainer.Location = new System.Drawing.Point(30, 200);
            this.pnlTableContainer.Name = "pnlTableContainer";
            this.pnlTableContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTableContainer.Size = new System.Drawing.Size(740, 519);
            this.pnlTableContainer.TabIndex = 2;
            this.pnlTableContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.AllowUserToResizeRows = false;
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSales.ColumnHeadersHeight = 50;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSaleId,
            this.ColCustomer,
            this.ColDate,
            this.ColItems,
            this.ColTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.EnableHeadersVisualStyles = false;
            this.dgvSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dgvSales.Location = new System.Drawing.Point(20, 20);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowHeadersWidth = 51;
            this.dgvSales.RowTemplate.Height = 45;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(700, 479);
            this.dgvSales.TabIndex = 0;
            this.dgvSales.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSales_CellPainting);
            // 
            // ColSaleId
            // 
            this.ColSaleId.HeaderText = "ID";
            this.ColSaleId.MinimumWidth = 6;
            this.ColSaleId.Name = "ColSaleId";
            this.ColSaleId.ReadOnly = true;
            // 
            // ColCustomer
            // 
            this.ColCustomer.HeaderText = "Customer";
            this.ColCustomer.MinimumWidth = 6;
            this.ColCustomer.Name = "ColCustomer";
            this.ColCustomer.ReadOnly = true;
            // 
            // ColDate
            // 
            this.ColDate.HeaderText = "Date";
            this.ColDate.MinimumWidth = 6;
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            // 
            // ColItems
            // 
            this.ColItems.HeaderText = "Items";
            this.ColItems.MinimumWidth = 6;
            this.ColItems.Name = "ColItems";
            this.ColItems.ReadOnly = true;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total";
            this.ColTotal.MinimumWidth = 6;
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.pnlSearchBox);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(30, 130);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 10, 0, 20);
            this.pnlSearch.Size = new System.Drawing.Size(740, 70);
            this.pnlSearch.TabIndex = 1;
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSearchBox.Location = new System.Drawing.Point(0, 10);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlSearchBox.Size = new System.Drawing.Size(350, 40);
            this.pnlSearchBox.TabIndex = 0;
            this.pnlSearchBox.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.txtSearch.Location = new System.Drawing.Point(15, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(320, 18);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search sales...";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.pnlTotalCard);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(30, 30);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(740, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlTotalCard
            // 
            this.pnlTotalCard.BackColor = System.Drawing.Color.White;
            this.pnlTotalCard.Controls.Add(this.lblTotalAmount);
            this.pnlTotalCard.Controls.Add(this.lblTotalTitle);
            this.pnlTotalCard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlTotalCard.Location = new System.Drawing.Point(506, 0);
            this.pnlTotalCard.Name = "pnlTotalCard";
            this.pnlTotalCard.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTotalCard.Size = new System.Drawing.Size(234, 100);
            this.pnlTotalCard.TabIndex = 1;
            this.pnlTotalCard.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(17, 45);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(120, 37);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "450 LYD";
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblTotalTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(110, 19);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "Total sales today";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(284, 41);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Sales Management";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.flpCartItems);
            this.pnlSidebar.Controls.Add(this.pnlProductSelect);
            this.pnlSidebar.Controls.Add(this.pnlCustomerSelect);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Controls.Add(this.pnlSidebarFooter);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSidebar.Location = new System.Drawing.Point(800, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(20);
            this.pnlSidebar.Size = new System.Drawing.Size(400, 749);
            this.pnlSidebar.TabIndex = 1;
            // 
            // flpCartItems
            // 
            this.flpCartItems.AutoScroll = true;
            this.flpCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCartItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCartItems.Location = new System.Drawing.Point(20, 230);
            this.flpCartItems.Name = "flpCartItems";
            this.flpCartItems.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpCartItems.Size = new System.Drawing.Size(360, 299);
            this.flpCartItems.TabIndex = 3;
            this.flpCartItems.WrapContents = false;
            // 
            // pnlProductSelect
            // 
            this.pnlProductSelect.Controls.Add(this.btnAddItem);
            this.pnlProductSelect.Controls.Add(this.pnlProductInput);
            this.pnlProductSelect.Controls.Add(this.lblProduct);
            this.pnlProductSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductSelect.Location = new System.Drawing.Point(20, 140);
            this.pnlProductSelect.Name = "pnlProductSelect";
            this.pnlProductSelect.Size = new System.Drawing.Size(360, 90);
            this.pnlProductSelect.TabIndex = 2;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(315, 30);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(45, 45);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "+";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_PaintRounded);
            // 
            // pnlProductInput
            // 
            this.pnlProductInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlProductInput.Controls.Add(this.cmbProduct);
            this.pnlProductInput.Location = new System.Drawing.Point(0, 30);
            this.pnlProductInput.Name = "pnlProductInput";
            this.pnlProductInput.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlProductInput.Size = new System.Drawing.Size(305, 45);
            this.pnlProductInput.TabIndex = 1;
            this.pnlProductInput.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbProduct
            // 
            this.cmbProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(15, 12);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(275, 25);
            this.cmbProduct.TabIndex = 0;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblProduct.Location = new System.Drawing.Point(0, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblProduct.Size = new System.Drawing.Size(84, 25);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "Select Product";
            // 
            // pnlCustomerSelect
            // 
            this.pnlCustomerSelect.Controls.Add(this.pnlCustomerInput);
            this.pnlCustomerSelect.Controls.Add(this.lblCustomer);
            this.pnlCustomerSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomerSelect.Location = new System.Drawing.Point(20, 60);
            this.pnlCustomerSelect.Name = "pnlCustomerSelect";
            this.pnlCustomerSelect.Size = new System.Drawing.Size(360, 80);
            this.pnlCustomerSelect.TabIndex = 1;
            // 
            // pnlCustomerInput
            // 
            this.pnlCustomerInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlCustomerInput.Controls.Add(this.cmbCustomer);
            this.pnlCustomerInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomerInput.Location = new System.Drawing.Point(0, 25);
            this.pnlCustomerInput.Name = "pnlCustomerInput";
            this.pnlCustomerInput.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.pnlCustomerInput.Size = new System.Drawing.Size(360, 45);
            this.pnlCustomerInput.TabIndex = 1;
            this.pnlCustomerInput.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_PaintRoundedBorder);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.cmbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(15, 12);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(330, 25);
            this.cmbCustomer.TabIndex = 0;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblCustomer.Location = new System.Drawing.Point(0, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblCustomer.Size = new System.Drawing.Size(58, 25);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblSidebarTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblSidebarTitle.Size = new System.Drawing.Size(108, 40);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "New Sale";
            // 
            // pnlSidebarFooter
            // 
            this.pnlSidebarFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(237)))), ((int)(((byte)(228)))));
            this.pnlSidebarFooter.Controls.Add(this.btnCompleteSale);
            this.pnlSidebarFooter.Controls.Add(this.lblTotalValue);
            this.pnlSidebarFooter.Controls.Add(this.lblTotalLabel);
            this.pnlSidebarFooter.Controls.Add(this.lblTaxValue);
            this.pnlSidebarFooter.Controls.Add(this.lblTaxLabel);
            this.pnlSidebarFooter.Controls.Add(this.lblSubtotalValue);
            this.pnlSidebarFooter.Controls.Add(this.lblSubtotalLabel);
            this.pnlSidebarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSidebarFooter.Location = new System.Drawing.Point(20, 529);
            this.pnlSidebarFooter.Name = "pnlSidebarFooter";
            this.pnlSidebarFooter.Size = new System.Drawing.Size(360, 200);
            this.pnlSidebarFooter.TabIndex = 4;
            this.pnlSidebarFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // btnCompleteSale
            // 
            this.btnCompleteSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnCompleteSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompleteSale.FlatAppearance.BorderSize = 0;
            this.btnCompleteSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCompleteSale.ForeColor = System.Drawing.Color.White;
            this.btnCompleteSale.Location = new System.Drawing.Point(20, 130);
            this.btnCompleteSale.Name = "btnCompleteSale";
            this.btnCompleteSale.Size = new System.Drawing.Size(320, 50);
            this.btnCompleteSale.TabIndex = 6;
            this.btnCompleteSale.Text = "Complete Sale";
            this.btnCompleteSale.UseVisualStyleBackColor = false;
            this.btnCompleteSale.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_PaintRounded);
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.lblTotalValue.Location = new System.Drawing.Point(180, 80);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(160, 40);
            this.lblTotalValue.TabIndex = 5;
            this.lblTotalValue.Text = "0 LYD";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTotalLabel.Location = new System.Drawing.Point(20, 88);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(55, 25);
            this.lblTotalLabel.TabIndex = 4;
            this.lblTotalLabel.Text = "Total";
            // 
            // lblTaxValue
            // 
            this.lblTaxValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblTaxValue.Location = new System.Drawing.Point(240, 50);
            this.lblTaxValue.Name = "lblTaxValue";
            this.lblTaxValue.Size = new System.Drawing.Size(100, 20);
            this.lblTaxValue.TabIndex = 3;
            this.lblTaxValue.Text = "0 LYD";
            this.lblTaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTaxLabel
            // 
            this.lblTaxLabel.AutoSize = true;
            this.lblTaxLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblTaxLabel.Location = new System.Drawing.Point(20, 50);
            this.lblTaxLabel.Name = "lblTaxLabel";
            this.lblTaxLabel.Size = new System.Drawing.Size(58, 19);
            this.lblTaxLabel.TabIndex = 2;
            this.lblTaxLabel.Text = "Tax (0%)";
            // 
            // lblSubtotalValue
            // 
            this.lblSubtotalValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblSubtotalValue.Location = new System.Drawing.Point(240, 20);
            this.lblSubtotalValue.Name = "lblSubtotalValue";
            this.lblSubtotalValue.Size = new System.Drawing.Size(100, 20);
            this.lblSubtotalValue.TabIndex = 1;
            this.lblSubtotalValue.Text = "0 LYD";
            this.lblSubtotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblSubtotalLabel.Location = new System.Drawing.Point(20, 20);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(60, 19);
            this.lblSubtotalLabel.TabIndex = 0;
            this.lblSubtotalLabel.Text = "Subtotal";
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 749);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "SalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Management";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlTableContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTotalCard.ResumeLayout(false);
            this.pnlTotalCard.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlProductSelect.ResumeLayout(false);
            this.pnlProductSelect.PerformLayout();
            this.pnlProductInput.ResumeLayout(false);
            this.pnlCustomerSelect.ResumeLayout(false);
            this.pnlCustomerSelect.PerformLayout();
            this.pnlCustomerInput.ResumeLayout(false);
            this.pnlSidebarFooter.ResumeLayout(false);
            this.pnlSidebarFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlTotalCard;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlTableContainer;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Panel pnlCustomerSelect;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Panel pnlCustomerInput;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Panel pnlProductSelect;
        private System.Windows.Forms.Panel pnlProductInput;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.FlowLayoutPanel flpCartItems;
        private System.Windows.Forms.Panel pnlSidebarFooter;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblTaxLabel;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button btnCompleteSale;
    }
}