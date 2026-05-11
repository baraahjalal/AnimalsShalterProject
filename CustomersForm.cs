using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnimalsShalterProject
{
    public partial class CustomersForm : Form
    {
        private static readonly Color ColorGreen = Color.FromArgb(69, 115, 87);
        private static readonly Color ColorCard = Color.White;
        private static readonly Color ColorAccent = Color.FromArgb(235, 230, 225);

        public CustomersForm()
        {
            InitializeComponent();
            SetupUI();
            LoadSampleCustomers();
        }

        private void SetupUI()
        {
            // تطبيق الحواف الدائرية للعناصر الأساسية
            this.Load += (s, e) => {
                ApplyRoundedCorners(pnlSearch, 15);
                ApplyRoundedCorners(btnAddCustomer, 10);
            };
        }

        private void LoadSampleCustomers()
        {
            flpCustomerList.Controls.Clear();
            
            // إضافة عينة من العملاء بناءً على الصورة المرفقة
            AddCustomerCard("Eleanor Vance", "CUST-8829", "(555) 234-9012", "Mar 2022", 2);
            AddCustomerCard("Marcus Thorne", "CUST-7741", "(555) 876-5432", "Jan 2023", 1);
            AddCustomerCard("Sylvia Rossi", "CUST-6510", "(555) 998-1122", "Nov 2021", 0);
        }

        private void AddCustomerCard(string name, string id, string phone, string joinDate, int adoptions)
        {
            // لوحة الكارت الرئيسية
            Panel card = new Panel {
                Size = new Size(flpCustomerList.Width - 50, 100),
                BackColor = ColorCard,
                Margin = new Padding(0, 0, 0, 15),
                Padding = new Padding(15)
            };
            card.Paint += (s, e) => ApplyRoundedCorners(card, 15);

            // صورة العميل (دائرية)
            PictureBox pb = new PictureBox {
                Size = new Size(60, 60),
                Location = new Point(15, 20),
                BackColor = ColorAccent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pb.Paint += (s, e) => {
                using (GraphicsPath path = new GraphicsPath()) {
                    path.AddEllipse(0, 0, pb.Width - 1, pb.Height - 1);
                    pb.Region = new Region(path);
                }
            };

            // المعلومات النصية
            Label lblName = new Label {
                Text = name,
                Font = new Font("Segoe UI Bold", 12F),
                Location = new Point(85, 20),
                AutoSize = true
            };
            Label lblDetails = new Label {
                Text = $"ID: {id}  •  Joined {joinDate}",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.Gray,
                Location = new Point(85, 45),
                AutoSize = true
            };

            // رقم الهاتف
            Label lblPhoneTitle = new Label {
                Text = "PHONE",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.DarkGray,
                Location = new Point(400, 20),
                AutoSize = true
            };
            Label lblPhoneValue = new Label {
                Text = phone,
                Font = new Font("Segoe UI Semibold", 10F),
                Location = new Point(400, 40),
                AutoSize = true
            };

            // عدد التبني
            Label lblAdoptTitle = new Label {
                Text = "ADOPTIONS",
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.DarkGray,
                Location = new Point(550, 20),
                AutoSize = true
            };
            Label lblAdoptVal = new Label {
                Text = adoptions.ToString(),
                Font = new Font("Segoe UI Bold", 10F),
                Location = new Point(550, 40),
                AutoSize = true
            };

            // أزرار التحكم (Edit / Expand)
            Button btnEdit = new Button {
                Text = "✎",
                Size = new Size(35, 35),
                Location = new Point(card.Width - 100, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = ColorAccent
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Paint += (s, e) => ApplyRoundedCorners(btnEdit, 10);

            card.Controls.AddRange(new Control[] { pb, lblName, lblDetails, lblPhoneTitle, lblPhoneValue, lblAdoptTitle, lblAdoptVal, btnEdit });
            flpCustomerList.Controls.Add(card);
        }

        // --- المساعد البرمجي للحواف الدائرية ---
        private void ApplyRoundedCorners(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(ctrl.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(ctrl.Width - radius, ctrl.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, ctrl.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                ctrl.Region = new Region(path);
            }
        }
    }
}
