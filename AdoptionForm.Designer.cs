namespace AnimalsShalterProject
{
    partial class AdoptionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNewAdoption = new System.Windows.Forms.Button();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDataContainer = new System.Windows.Forms.Panel();
            this.dgvAdoptions = new System.Windows.Forms.DataGridView();
            this.ColAdoptionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAnimalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.lblPaginationInfo = new System.Windows.Forms.Label();
            this.flpPaginationButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnPage1 = new System.Windows.Forms.Button();
            this.btnPage2 = new System.Windows.Forms.Button();
            this.btnPage3 = new System.Windows.Forms.Button();
            this.lblEllipsis = new System.Windows.Forms.Label();
            this.btnPage9 = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlTopBar.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDataContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdoptions)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.flpPaginationButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1000, 80);
            this.pnlTopBar.TabIndex = 0;
            this.pnlTopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTopBar_Paint);
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.Location = new System.Drawing.Point(12, 37);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlSearchBox.Size = new System.Drawing.Size(300, 40);
            this.pnlSearchBox.TabIndex = 0;
            this.pnlSearchBox.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.txtSearch.Location = new System.Drawing.Point(15, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search adoptions...";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnNewAdoption);
            this.pnlHeader.Controls.Add(this.pnlSearchBox);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(30, 80);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(940, 100);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnNewAdoption
            // 
            this.btnNewAdoption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewAdoption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnNewAdoption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewAdoption.FlatAppearance.BorderSize = 0;
            this.btnNewAdoption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewAdoption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNewAdoption.ForeColor = System.Drawing.Color.White;
            this.btnNewAdoption.Location = new System.Drawing.Point(740, 25);
            this.btnNewAdoption.Name = "btnNewAdoption";
            this.btnNewAdoption.Size = new System.Drawing.Size(180, 45);
            this.btnNewAdoption.TabIndex = 2;
            this.btnNewAdoption.Text = "+ New Adoption";
            this.btnNewAdoption.UseVisualStyleBackColor = false;
            this.btnNewAdoption.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblPageTitle.Location = new System.Drawing.Point(48, 27);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(203, 50);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Adoptions";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlDataContainer);
            this.pnlContent.Controls.Add(this.pnlHeader);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30, 80, 30, 30);
            this.pnlContent.Size = new System.Drawing.Size(1000, 750);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlDataContainer
            // 
            this.pnlDataContainer.BackColor = System.Drawing.Color.White;
            this.pnlDataContainer.Controls.Add(this.dgvAdoptions);
            this.pnlDataContainer.Controls.Add(this.pnlPagination);
            this.pnlDataContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataContainer.Location = new System.Drawing.Point(30, 180);
            this.pnlDataContainer.Name = "pnlDataContainer";
            this.pnlDataContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDataContainer.Size = new System.Drawing.Size(940, 540);
            this.pnlDataContainer.TabIndex = 2;
            this.pnlDataContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // dgvAdoptions
            // 
            this.dgvAdoptions.AllowUserToAddRows = false;
            this.dgvAdoptions.AllowUserToDeleteRows = false;
            this.dgvAdoptions.AllowUserToResizeRows = false;
            this.dgvAdoptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdoptions.BackgroundColor = System.Drawing.Color.White;
            this.dgvAdoptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAdoptions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAdoptions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdoptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvAdoptions.ColumnHeadersHeight = 50;
            this.dgvAdoptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAdoptionId,
            this.ColAnimalName,
            this.ColCustomer,
            this.ColPhone,
            this.ColDate,
            this.ColActions});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAdoptions.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvAdoptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdoptions.EnableHeadersVisualStyles = false;
            this.dgvAdoptions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dgvAdoptions.Location = new System.Drawing.Point(20, 20);
            this.dgvAdoptions.Name = "dgvAdoptions";
            this.dgvAdoptions.ReadOnly = true;
            this.dgvAdoptions.RowHeadersVisible = false;
            this.dgvAdoptions.RowHeadersWidth = 51;
            this.dgvAdoptions.RowTemplate.Height = 60;
            this.dgvAdoptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdoptions.Size = new System.Drawing.Size(900, 440);
            this.dgvAdoptions.TabIndex = 0;
            this.dgvAdoptions.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAdoptions_CellPainting);
            // 
            // ColAdoptionId
            // 
            this.ColAdoptionId.HeaderText = "Adoption ID";
            this.ColAdoptionId.MinimumWidth = 6;
            this.ColAdoptionId.Name = "ColAdoptionId";
            this.ColAdoptionId.ReadOnly = true;
            // 
            // ColAnimalName
            // 
            this.ColAnimalName.HeaderText = "Animal Name";
            this.ColAnimalName.MinimumWidth = 6;
            this.ColAnimalName.Name = "ColAnimalName";
            this.ColAnimalName.ReadOnly = true;
            // 
            // ColCustomer
            // 
            this.ColCustomer.HeaderText = "Customer Name";
            this.ColCustomer.MinimumWidth = 6;
            this.ColCustomer.Name = "ColCustomer";
            this.ColCustomer.ReadOnly = true;
            // 
            // ColPhone
            // 
            this.ColPhone.HeaderText = "Phone";
            this.ColPhone.MinimumWidth = 6;
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            // 
            // ColDate
            // 
            this.ColDate.HeaderText = "Date";
            this.ColDate.MinimumWidth = 6;
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            // 
            // ColActions
            // 
            this.ColActions.HeaderText = "Actions";
            this.ColActions.MinimumWidth = 6;
            this.ColActions.Name = "ColActions";
            this.ColActions.ReadOnly = true;
            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.lblPaginationInfo);
            this.pnlPagination.Controls.Add(this.flpPaginationButtons);
            this.pnlPagination.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPagination.Location = new System.Drawing.Point(20, 460);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(900, 60);
            this.pnlPagination.TabIndex = 1;
            // 
            // lblPaginationInfo
            // 
            this.lblPaginationInfo.AutoSize = true;
            this.lblPaginationInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaginationInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblPaginationInfo.Location = new System.Drawing.Point(0, 20);
            this.lblPaginationInfo.Name = "lblPaginationInfo";
            this.lblPaginationInfo.Size = new System.Drawing.Size(221, 23);
            this.lblPaginationInfo.TabIndex = 0;
            this.lblPaginationInfo.Text = "Showing 1 to 5 of 42 results";
            // 
            // flpPaginationButtons
            // 
            this.flpPaginationButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPaginationButtons.Controls.Add(this.btnPrev);
            this.flpPaginationButtons.Controls.Add(this.btnPage1);
            this.flpPaginationButtons.Controls.Add(this.btnPage2);
            this.flpPaginationButtons.Controls.Add(this.btnPage3);
            this.flpPaginationButtons.Controls.Add(this.lblEllipsis);
            this.flpPaginationButtons.Controls.Add(this.btnPage9);
            this.flpPaginationButtons.Controls.Add(this.btnNext);
            this.flpPaginationButtons.Location = new System.Drawing.Point(540, 10);
            this.flpPaginationButtons.Name = "flpPaginationButtons";
            this.flpPaginationButtons.Size = new System.Drawing.Size(360, 40);
            this.flpPaginationButtons.TabIndex = 1;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.btnPrev.Location = new System.Drawing.Point(3, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 30);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // btnPage1
            // 
            this.btnPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnPage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage1.FlatAppearance.BorderSize = 0;
            this.btnPage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Location = new System.Drawing.Point(84, 3);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(30, 30);
            this.btnPage1.TabIndex = 1;
            this.btnPage1.Text = "1";
            this.btnPage1.UseVisualStyleBackColor = false;
            this.btnPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // btnPage2
            // 
            this.btnPage2.BackColor = System.Drawing.Color.White;
            this.btnPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnPage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.btnPage2.Location = new System.Drawing.Point(120, 3);
            this.btnPage2.Name = "btnPage2";
            this.btnPage2.Size = new System.Drawing.Size(30, 30);
            this.btnPage2.TabIndex = 2;
            this.btnPage2.Text = "2";
            this.btnPage2.UseVisualStyleBackColor = false;
            this.btnPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // btnPage3
            // 
            this.btnPage3.BackColor = System.Drawing.Color.White;
            this.btnPage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnPage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.btnPage3.Location = new System.Drawing.Point(156, 3);
            this.btnPage3.Name = "btnPage3";
            this.btnPage3.Size = new System.Drawing.Size(30, 30);
            this.btnPage3.TabIndex = 3;
            this.btnPage3.Text = "3";
            this.btnPage3.UseVisualStyleBackColor = false;
            this.btnPage3.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // lblEllipsis
            // 
            this.lblEllipsis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEllipsis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.lblEllipsis.Location = new System.Drawing.Point(192, 0);
            this.lblEllipsis.Name = "lblEllipsis";
            this.lblEllipsis.Size = new System.Drawing.Size(20, 35);
            this.lblEllipsis.TabIndex = 4;
            this.lblEllipsis.Text = "...";
            this.lblEllipsis.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnPage9
            // 
            this.btnPage9.BackColor = System.Drawing.Color.White;
            this.btnPage9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPage9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnPage9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPage9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPage9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.btnPage9.Location = new System.Drawing.Point(218, 3);
            this.btnPage9.Name = "btnPage9";
            this.btnPage9.Size = new System.Drawing.Size(30, 30);
            this.btnPage9.TabIndex = 5;
            this.btnPage9.Text = "9";
            this.btnPage9.UseVisualStyleBackColor = false;
            this.btnPage9.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.btnNext.Location = new System.Drawing.Point(254, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 30);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // AdoptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.pnlContent);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "AdoptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adoptions Management";
            this.Load += new System.EventHandler(this.AdoptionsForm_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlDataContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdoptions)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.flpPaginationButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Button btnNewAdoption;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlDataContainer;
        private System.Windows.Forms.DataGridView dgvAdoptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdoptionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnimalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColActions;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Label lblPaginationInfo;
        private System.Windows.Forms.FlowLayoutPanel flpPaginationButtons;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPage1;
        private System.Windows.Forms.Button btnPage2;
        private System.Windows.Forms.Button btnPage3;
        private System.Windows.Forms.Label lblEllipsis;
        private System.Windows.Forms.Button btnPage9;
        private System.Windows.Forms.Button btnNext;
    }
}