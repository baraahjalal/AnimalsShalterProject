using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class LoginForm : Form
    {
        // --- STYLING CONSTANTS ---
        private readonly Color ColorInputBorder = ColorTranslator.FromHtml("#D3D8D5");

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;

            // Wire up events for login
            this.btnLogin.Click += BtnLogin_Click;
            this.txtUsername.KeyDown += TxtUsername_KeyDown;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Apply rounded corners to the form itself (since it's FormBorderStyle.None)
            ApplyRoundedRegion(this, 16);

            // Optionally pre-fill username textbox with first user for convenience
            if (UsersStore.Users.Count > 0)
                txtUsername.Text = UsersStore.Users[0];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // or this.Close() depending on application flow
        }

        // Handle Enter key in username textbox
        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                AttemptLogin();
            }
        }

        // Handle login button click
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        // Try to login with the typed username
        private void AttemptLogin()
        {
            string username = (txtUsername.Text ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Case-insensitive check against UsersStore
            var matched = UsersStore.Users.FirstOrDefault(u => string.Equals(u, username, StringComparison.OrdinalIgnoreCase));
            if (matched == null)
            {
                MessageBox.Show("Invalid username.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set session current user so other screens can read it
            Session.CurrentUser = matched;

            // Open main form and close login when main form closes
            var main = new MainForm();
            main.FormClosed += (s, e) => this.Close();
            main.Show();
            this.Hide();
        }

        // --- ROUNDED CORNERS (REGION MASKING) HELPER ---
        private void ApplyRoundedRegion(Control ctrl, int radius)
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

        // --- CUSTOM BORDER DRAWING FOR INPUT PANELS ---
        private void InputPanel_PaintRounded(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            int radius = 10;

            // Clip the panel so its background doesn't bleed out of the rounded corners
            ApplyRoundedRegion(pnl, radius);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the smooth border around the panel
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc(rect.Right - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc(rect.Right - (radius * 2), rect.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                using (Pen pen = new Pen(ColorInputBorder, 1.5f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        // --- CUSTOM BORDER DRAWING FOR BUTTON ---
        private void Button_PaintRounded(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            int radius = 10;
            ApplyRoundedRegion(btn, radius);
        }
    }
}
