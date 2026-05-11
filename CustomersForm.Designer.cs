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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.flpCustomerList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.lblShowing = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // CustomersForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.Controls.Add(this.flpCustomerList);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomersForm";

            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnAddCustomer);
            this.pnlHeader.Controls.Add(this.pnlSearch);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 100;

            this.lblTitle.Text = "Customers";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Bold", 22F);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.AutoSize = true;

            this.lblSubtitle.Text = "Manage shelter supporters, adopters, and contacts.";
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(24, 60);
            this.lblSubtitle.AutoSize = true;

            // pnlSearch (Rounded Container)
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(225)))));
            this.pnlSearch.Location = new System.Drawing.Point(520, 25);
            this.pnlSearch.Size = new System.Drawing.Size(240, 38);
            this.pnlSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;

            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(225)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Text = "Search customers...";
            this.txtSearch.Location = new System.Drawing.Point(10, 10);
            this.txtSearch.Size = new System.Drawing.Size(220, 18);
            this.pnlSearch.Controls.Add(this.txtSearch);

            // btnAddCustomer
            this.btnAddCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI Bold", 9.5F);
            this.btnAddCustomer.Text = "+ Add Customer";
            this.btnAddCustomer.Location = new System.Drawing.Point(775, 25);
            this.btnAddCustomer.Size = new System.Drawing.Size(150, 38);
            this.btnAddCustomer.Anchor = System.Windows.Forms.AnchorStyles.Right;

            // 
            // flpCustomerList (Container for Cards)
            // 
            this.flpCustomerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCustomerList.AutoScroll = true;
            this.flpCustomerList.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);

            // 
            // pnlPagination
            // 
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Height = 60;
            this.pnlPagination.Controls.Add(this.lblShowing);
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.Controls.Add(this.btnPrev);

            this.lblShowing.Text = "Showing 1 to 3 of 124 customers";
            this.lblShowing.ForeColor = System.Drawing.Color.Gray;
            this.lblShowing.Location = new System.Drawing.Point(20, 22);
            this.lblShowing.AutoSize = true;

            this.btnNext.Text = ">";
            this.btnPrev.Text = "<";
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnPrev.Size = new System.Drawing.Size(35, 35);
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.Location = new System.Drawing.Point(900, 12);
            this.btnPrev.Location = new System.Drawing.Point(860, 12);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.FlowLayoutPanel flpCustomerList;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblShowing;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
    }
}