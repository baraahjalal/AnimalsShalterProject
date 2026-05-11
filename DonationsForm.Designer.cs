namespace AnimalsShalterProject
{
    partial class DonationsForm
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
            System.Windows.Forms.DataGridViewCellStyle dgvStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlStatsHeader = new System.Windows.Forms.Panel();
            this.pnlStat1 = new System.Windows.Forms.Panel();
            this.pnlStat2 = new System.Windows.Forms.Panel();
            this.pnlStat3 = new System.Windows.Forms.Panel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnAllTime = new System.Windows.Forms.Button();
            this.dgvDonations = new System.Windows.Forms.DataGridView();
            this.pnlGridContainer = new System.Windows.Forms.Panel();

            this.pnlStatsHeader.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonations)).BeginInit();
            this.pnlGridContainer.SuspendLayout();
            this.SuspendLayout();

            // 
            // DonationsForm Style
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(950, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // 
            // pnlStatsHeader (Contains 3 Panels)
            // 
            this.pnlStatsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatsHeader.Height = 140;
            this.pnlStatsHeader.Padding = new System.Windows.Forms.Padding(20);
            this.pnlStatsHeader.Controls.Add(this.pnlStat3);
            this.pnlStatsHeader.Controls.Add(this.pnlStat2);
            this.pnlStatsHeader.Controls.Add(this.pnlStat1);

            // pnlStat1 (Total Donations)
            this.pnlStat1.BackColor = System.Drawing.Color.White;
            this.pnlStat1.Size = new System.Drawing.Size(280, 100);
            this.pnlStat1.Location = new System.Drawing.Point(20, 20);

            // pnlStat2 (Monthly Target)
            this.pnlStat2.BackColor = System.Drawing.Color.White;
            this.pnlStat2.Size = new System.Drawing.Size(280, 100);
            this.pnlStat2.Location = new System.Drawing.Point(320, 20);

            // pnlStat3 (Donor Count)
            this.pnlStat3.BackColor = System.Drawing.Color.White;
            this.pnlStat3.Size = new System.Drawing.Size(280, 100);
            this.pnlStat3.Location = new System.Drawing.Point(620, 20);

            // 
            // pnlFilters (Filter Bar)
            // 
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Height = 60;
            this.pnlFilters.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlFilters.Controls.Add(this.btnAllTime);
            this.pnlFilters.Controls.Add(this.btnMonth);
            this.pnlFilters.Controls.Add(this.btnWeek);

            this.btnWeek.Text = "This Week";
            this.btnWeek.Size = new System.Drawing.Size(100, 35);
            this.btnWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            this.btnWeek.ForeColor = System.Drawing.Color.White;
            this.btnWeek.Location = new System.Drawing.Point(20, 10);

            this.btnMonth.Text = "This Month";
            this.btnMonth.Size = new System.Drawing.Size(100, 35);
            this.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonth.BackColor = System.Drawing.Color.White;
            this.btnMonth.Location = new System.Drawing.Point(130, 10);

            this.btnAllTime.Text = "All Time";
            this.btnAllTime.Size = new System.Drawing.Size(100, 35);
            this.btnAllTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllTime.BackColor = System.Drawing.Color.White;
            this.btnAllTime.Location = new System.Drawing.Point(240, 10);

            // 
            // dgvDonations (Custom Grid)
            // 
            this.dgvDonations.BackgroundColor = System.Drawing.Color.White;
            this.dgvDonations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDonations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDonations.RowTemplate.Height = 55;
            this.dgvDonations.EnableHeadersVisualStyles = false;
            dgvStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(115)))), ((int)(((byte)(87)))));
            dgvStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDonations.ColumnHeadersDefaultCellStyle = dgvStyle;
            this.dgvDonations.ColumnHeadersHeight = 45;

            // pnlGridContainer
            this.pnlGridContainer.Controls.Add(this.dgvDonations);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(20);

            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlStatsHeader);

            this.pnlStatsHeader.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonations)).EndInit();
            this.pnlGridContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlStatsHeader;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Panel pnlStat2;
        private System.Windows.Forms.Panel pnlStat3;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnAllTime;
        private System.Windows.Forms.DataGridView dgvDonations;
        private System.Windows.Forms.Panel pnlGridContainer;
    }
}