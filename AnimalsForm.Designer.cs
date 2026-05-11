namespace AnimalsShalterProject
{
    partial class AnimalsForm
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
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlDataContainer = new System.Windows.Forms.Panel();
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSpecies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbAvailable = new System.Windows.Forms.RadioButton();
            this.rbAdopted = new System.Windows.Forms.RadioButton();
            this.rbSick = new System.Windows.Forms.RadioButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnAddAnimal = new System.Windows.Forms.Button();
            this.pnlTopBar.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlDataContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            this.flpFilters.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlTopBar.Controls.Add(this.lblPageTitle);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1200, 80);
            this.pnlTopBar.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            this.lblPageTitle.Location = new System.Drawing.Point(52, 27);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(131, 41);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Animals";
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.Color.White;
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.Location = new System.Drawing.Point(20, 44);
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
            this.txtSearch.Size = new System.Drawing.Size(270, 18);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search animals...";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlContent.Controls.Add(this.pnlDataContainer);
            this.pnlContent.Controls.Add(this.flpFilters);
            this.pnlContent.Controls.Add(this.pnlHeader);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(30, 0, 30, 30);
            this.pnlContent.Size = new System.Drawing.Size(1200, 669);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlDataContainer
            // 
            this.pnlDataContainer.BackColor = System.Drawing.Color.White;
            this.pnlDataContainer.Controls.Add(this.dgvAnimals);
            this.pnlDataContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataContainer.Location = new System.Drawing.Point(30, 160);
            this.pnlDataContainer.Name = "pnlDataContainer";
            this.pnlDataContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDataContainer.Size = new System.Drawing.Size(1140, 479);
            this.pnlDataContainer.TabIndex = 2;
            this.pnlDataContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.AllowUserToAddRows = false;
            this.dgvAnimals.AllowUserToDeleteRows = false;
            this.dgvAnimals.AllowUserToResizeRows = false;
            this.dgvAnimals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnimals.BackgroundColor = System.Drawing.Color.White;
            this.dgvAnimals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAnimals.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAnimals.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnimals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAnimals.ColumnHeadersHeight = 40;
            this.dgvAnimals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColSpecies,
            this.ColAge,
            this.ColGender,
            this.ColStatus,
            this.ColActions});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(51)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAnimals.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAnimals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnimals.EnableHeadersVisualStyles = false;
            this.dgvAnimals.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.dgvAnimals.Location = new System.Drawing.Point(20, 20);
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.ReadOnly = true;
            this.dgvAnimals.RowHeadersVisible = false;
            this.dgvAnimals.RowHeadersWidth = 51;
            this.dgvAnimals.RowTemplate.Height = 50;
            this.dgvAnimals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimals.Size = new System.Drawing.Size(1100, 439);
            this.dgvAnimals.TabIndex = 0;
            this.dgvAnimals.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAnimals_CellPainting);
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Animal Name";
            this.ColName.MinimumWidth = 6;
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColSpecies
            // 
            this.ColSpecies.HeaderText = "Species/Breed";
            this.ColSpecies.MinimumWidth = 6;
            this.ColSpecies.Name = "ColSpecies";
            this.ColSpecies.ReadOnly = true;
            // 
            // ColAge
            // 
            this.ColAge.HeaderText = "Age";
            this.ColAge.MinimumWidth = 6;
            this.ColAge.Name = "ColAge";
            this.ColAge.ReadOnly = true;
            // 
            // ColGender
            // 
            this.ColGender.HeaderText = "Gender";
            this.ColGender.MinimumWidth = 6;
            this.ColGender.Name = "ColGender";
            this.ColGender.ReadOnly = true;
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
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.rbAll);
            this.flpFilters.Controls.Add(this.rbAvailable);
            this.flpFilters.Controls.Add(this.rbAdopted);
            this.flpFilters.Controls.Add(this.rbSick);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.Location = new System.Drawing.Point(30, 100);
            this.flpFilters.Name = "flpFilters";
            this.flpFilters.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flpFilters.Size = new System.Drawing.Size(1140, 60);
            this.flpFilters.TabIndex = 1;
            // 
            // rbAll
            // 
            this.rbAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAll.AutoSize = true;
            this.rbAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.rbAll.Checked = true;
            this.rbAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.rbAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.rbAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rbAll.ForeColor = System.Drawing.Color.White;
            this.rbAll.Location = new System.Drawing.Point(0, 10);
            this.rbAll.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.rbAll.Name = "rbAll";
            this.rbAll.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.rbAll.Size = new System.Drawing.Size(59, 35);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = false;
            this.rbAll.CheckedChanged += new System.EventHandler(this.FilterChip_CheckedChanged);
            // 
            // rbAvailable
            // 
            this.rbAvailable.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAvailable.AutoSize = true;
            this.rbAvailable.BackColor = System.Drawing.Color.Transparent;
            this.rbAvailable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAvailable.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.rbAvailable.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.rbAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAvailable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.rbAvailable.Location = new System.Drawing.Point(69, 10);
            this.rbAvailable.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.rbAvailable.Name = "rbAvailable";
            this.rbAvailable.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.rbAvailable.Size = new System.Drawing.Size(95, 35);
            this.rbAvailable.TabIndex = 1;
            this.rbAvailable.Text = "Available";
            this.rbAvailable.UseVisualStyleBackColor = false;
            this.rbAvailable.CheckedChanged += new System.EventHandler(this.FilterChip_CheckedChanged);
            // 
            // rbAdopted
            // 
            this.rbAdopted.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAdopted.AutoSize = true;
            this.rbAdopted.BackColor = System.Drawing.Color.Transparent;
            this.rbAdopted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbAdopted.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.rbAdopted.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.rbAdopted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbAdopted.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbAdopted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.rbAdopted.Location = new System.Drawing.Point(174, 10);
            this.rbAdopted.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.rbAdopted.Name = "rbAdopted";
            this.rbAdopted.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.rbAdopted.Size = new System.Drawing.Size(94, 35);
            this.rbAdopted.TabIndex = 2;
            this.rbAdopted.Text = "Adopted";
            this.rbAdopted.UseVisualStyleBackColor = false;
            this.rbAdopted.CheckedChanged += new System.EventHandler(this.FilterChip_CheckedChanged);
            // 
            // rbSick
            // 
            this.rbSick.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSick.AutoSize = true;
            this.rbSick.BackColor = System.Drawing.Color.Transparent;
            this.rbSick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSick.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.rbSick.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.rbSick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbSick.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbSick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(147)))), ((int)(((byte)(141)))));
            this.rbSick.Location = new System.Drawing.Point(278, 10);
            this.rbSick.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.rbSick.Name = "rbSick";
            this.rbSick.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.rbSick.Size = new System.Drawing.Size(121, 35);
            this.rbSick.TabIndex = 3;
            this.rbSick.Text = "Sick / In Care";
            this.rbSick.UseVisualStyleBackColor = false;
            this.rbSick.CheckedChanged += new System.EventHandler(this.FilterChip_CheckedChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnAddAnimal);
            this.pnlHeader.Controls.Add(this.pnlSearchBox);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(30, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1140, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnAddAnimal
            // 
            this.btnAddAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAnimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnAddAnimal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAnimal.FlatAppearance.BorderSize = 0;
            this.btnAddAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAnimal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddAnimal.ForeColor = System.Drawing.Color.White;
            this.btnAddAnimal.Location = new System.Drawing.Point(990, 30);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(150, 45);
            this.btnAddAnimal.TabIndex = 2;
            this.btnAddAnimal.Text = "+ Add Animal";
            this.btnAddAnimal.UseVisualStyleBackColor = false;
            this.btnAddAnimal.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_PaintRounded);
            // 
            // AnimalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1200, 749);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopBar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "AnimalsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Animals Management";
            this.Load += new System.EventHandler(this.AnimalsForm_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlDataContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Button btnAddAnimal;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbAvailable;
        private System.Windows.Forms.RadioButton rbAdopted;
        private System.Windows.Forms.RadioButton rbSick;
        private System.Windows.Forms.Panel pnlDataContainer;
        private System.Windows.Forms.DataGridView dgvAnimals;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSpecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColActions;
    }
}