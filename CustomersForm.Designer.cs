namespace AnimalsShalterProject
{
    partial class CustomersForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTopBar       = new System.Windows.Forms.Panel();
            this.lblPageTitle    = new System.Windows.Forms.Label();
            this.lblSubtitle     = new System.Windows.Forms.Label();
            this.pnlContent      = new System.Windows.Forms.Panel();
            this.pnlDataContainer = new System.Windows.Forms.Panel();
            this.dgvCustomers    = new System.Windows.Forms.DataGridView();
            this.pnlToolbar      = new System.Windows.Forms.Panel();
            this.pnlSearchBox    = new System.Windows.Forms.Panel();
            this.txtSearch       = new System.Windows.Forms.TextBox();
            this.btnAddCustomer  = new System.Windows.Forms.Button();

            this.pnlTopBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDataContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlTopBar  (title + subtitle)
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(250, 248, 245);
            this.pnlTopBar.Controls.Add(this.lblSubtitle);
            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1200, 80);
            this.pnlTopBar.TabIndex = 0;

            // lblPageTitle
            this.lblPageTitle.AutoSize  = true;
            this.lblPageTitle.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(42, 51, 46);
            this.lblPageTitle.Location  = new System.Drawing.Point(52, 15);
            this.lblPageTitle.Name      = "lblPageTitle";
            this.lblPageTitle.TabIndex  = 0;
            this.lblPageTitle.Text      = "Customers";

            // lblSubtitle
            this.lblSubtitle.AutoSize  = true;
            this.lblSubtitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(138, 147, 141);
            this.lblSubtitle.Location  = new System.Drawing.Point(55, 55);
            this.lblSubtitle.Name      = "lblSubtitle";
            this.lblSubtitle.TabIndex  = 1;
            this.lblSubtitle.Text      = "Manage shelter supporters, adopters, and contacts";

            // 
            // pnlContent  (fills the rest of the form)
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(250, 248, 245);
            this.pnlContent.Controls.Add(this.pnlDataContainer);
            this.pnlContent.Controls.Add(this.pnlToolbar);
            this.pnlContent.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name    = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30, 0, 30, 30);
            this.pnlContent.TabIndex = 1;

            // 
            // pnlToolbar  (search + add button row)
            // 
            this.pnlToolbar.Controls.Add(this.btnAddCustomer);
            this.pnlToolbar.Controls.Add(this.pnlSearchBox);
            this.pnlToolbar.Dock    = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Name    = "pnlToolbar";
            this.pnlToolbar.Size    = new System.Drawing.Size(1140, 70);
            this.pnlToolbar.TabIndex = 0;

            // pnlSearchBox
            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.Location  = new System.Drawing.Point(0, 15);
            this.pnlSearchBox.Name      = "pnlSearchBox";
            this.pnlSearchBox.Padding   = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlSearchBox.Size      = new System.Drawing.Size(300, 40);
            this.pnlSearchBox.TabIndex  = 0;
            this.pnlSearchBox.Paint    += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);

            // txtSearch
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor   = System.Drawing.Color.FromArgb(138, 147, 141);
            this.txtSearch.Name        = "txtSearch";
            this.txtSearch.TabIndex    = 0;
            this.txtSearch.Text        = "Search customers...";

            // btnAddCustomer
            this.btnAddCustomer.Anchor                  = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCustomer.BackColor               = System.Drawing.Color.FromArgb(69, 115, 87);
            this.btnAddCustomer.Cursor                  = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.FlatStyle               = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.Font                    = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddCustomer.ForeColor               = System.Drawing.Color.White;
            this.btnAddCustomer.Location                = new System.Drawing.Point(990, 12);
            this.btnAddCustomer.Name                    = "btnAddCustomer";
            this.btnAddCustomer.Size                    = new System.Drawing.Size(150, 45);
            this.btnAddCustomer.TabIndex                = 1;
            this.btnAddCustomer.Text                    = "+ Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Paint                  += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);

            // 
            // pnlDataContainer  (white card that holds the grid)
            // 
            this.pnlDataContainer.BackColor = System.Drawing.Color.White;
            this.pnlDataContainer.Controls.Add(this.dgvCustomers);
            this.pnlDataContainer.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataContainer.Name    = "pnlDataContainer";
            this.pnlDataContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDataContainer.TabIndex = 1;
            this.pnlDataContainer.Paint  += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);

            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows    = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor       = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.CellBorderStyle       = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            // Header style — identical to dgvAnimals
            dataGridViewCellStyle1.Alignment         = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor         = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font              = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor         = System.Drawing.Color.FromArgb(42, 51, 46);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(42, 51, 46);
            dataGridViewCellStyle1.WrapMode          = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.ColumnHeadersHeight    = 40;

            // Row style — identical to dgvAnimals
            dataGridViewCellStyle2.Alignment         = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor         = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font              = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor         = System.Drawing.Color.FromArgb(42, 51, 46);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(250, 248, 245);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(42, 51, 46);
            dataGridViewCellStyle2.WrapMode          = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle       = dataGridViewCellStyle2;

            this.dgvCustomers.Dock                   = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.GridColor              = System.Drawing.Color.FromArgb(239, 239, 239);
            this.dgvCustomers.Name                   = "dgvCustomers";
            this.dgvCustomers.ReadOnly               = true;
            this.dgvCustomers.RowHeadersVisible      = false;
            this.dgvCustomers.RowHeadersWidth        = 51;
            this.dgvCustomers.RowTemplate.Height     = 50;
            this.dgvCustomers.SelectionMode          = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.TabIndex               = 0;

            // 
            // CustomersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(250, 248, 245);
            this.ClientSize          = new System.Drawing.Size(1200, 749);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopBar);
            this.Font                = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize         = new System.Drawing.Size(1000, 700);
            this.Name                = "CustomersForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Customers";

            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            this.pnlDataContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Panel pnlDataContainer;
        private System.Windows.Forms.DataGridView dgvCustomers;
    }
}