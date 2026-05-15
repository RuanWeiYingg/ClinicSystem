namespace Clinic.Desktop.View
{
    partial class DoctorHome
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
            pnSideBar = new Panel();
            btnDashBoard = new Button();
            btnLogOut = new Button();
            btnProfile = new Button();
            btnMedicalHistory = new Button();
            btnPatients = new Button();
            btnMySchedule = new Button();
            pnLogo = new Panel();
            lblLogo = new Label();
            pnHeader = new Panel();
            lblTitle = new Label();
            pnContent = new Panel();
            pnSideBar.SuspendLayout();
            pnLogo.SuspendLayout();
            pnHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnSideBar
            // 
            pnSideBar.BackColor = Color.FromArgb(41, 57, 85);
            pnSideBar.Controls.Add(btnDashBoard);
            pnSideBar.Controls.Add(btnLogOut);
            pnSideBar.Controls.Add(btnProfile);
            pnSideBar.Controls.Add(btnMedicalHistory);
            pnSideBar.Controls.Add(btnPatients);
            pnSideBar.Controls.Add(btnMySchedule);
            pnSideBar.Controls.Add(pnLogo);
            pnSideBar.Dock = DockStyle.Left;
            pnSideBar.Location = new Point(0, 0);
            pnSideBar.Name = "pnSideBar";
            pnSideBar.Size = new Size(220, 720);
            pnSideBar.TabIndex = 2;
            // 
            // btnDashBoard
            // 
            btnDashBoard.Location = new Point(55, 203);
            btnDashBoard.Name = "btnDashBoard";
            btnDashBoard.Size = new Size(102, 23);
            btnDashBoard.TabIndex = 6;
            btnDashBoard.Text = "DashBoard";
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.FromArgb(239, 68, 68);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.ForeColor = Color.White;
            btnLogOut.Location = new Point(10, 650);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(200, 40);
            btnLogOut.TabIndex = 0;
            btnLogOut.Text = "Đăng xuất";
            btnLogOut.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            btnProfile.Location = new Point(55, 416);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(102, 23);
            btnProfile.TabIndex = 1;
            btnProfile.Text = "ProFile";
            // 
            // btnMedicalHistory
            // 
            btnMedicalHistory.Location = new Point(55, 302);
            btnMedicalHistory.Name = "btnMedicalHistory";
            btnMedicalHistory.Size = new Size(102, 23);
            btnMedicalHistory.TabIndex = 2;
            btnMedicalHistory.Text = "Lịch Sử Thuốc";
            // 
            // btnPatients
            // 
            btnPatients.Location = new Point(55, 361);
            btnPatients.Name = "btnPatients";
            btnPatients.Size = new Size(102, 23);
            btnPatients.TabIndex = 3;
            btnPatients.Text = "Bệnh Nhân ";
            // 
            // btnMySchedule
            // 
            btnMySchedule.Location = new Point(55, 254);
            btnMySchedule.Name = "btnMySchedule";
            btnMySchedule.Size = new Size(102, 23);
            btnMySchedule.TabIndex = 4;
            btnMySchedule.Text = "Lịch Khám";
            // 
            // pnLogo
            // 
            pnLogo.BackColor = Color.FromArgb(30, 41, 59);
            pnLogo.Controls.Add(lblLogo);
            pnLogo.Dock = DockStyle.Top;
            pnLogo.Location = new Point(0, 0);
            pnLogo.Name = "pnLogo";
            pnLogo.Size = new Size(220, 80);
            pnLogo.TabIndex = 5;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(220, 80);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "DOCTOR PORTAL";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnHeader
            // 
            pnHeader.BackColor = Color.White;
            pnHeader.Controls.Add(lblTitle);
            pnHeader.Dock = DockStyle.Top;
            pnHeader.Location = new Point(220, 0);
            pnHeader.Name = "pnHeader";
            pnHeader.Size = new Size(980, 80);
            pnHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F);
            lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitle.Location = new Point(25, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lịch khám hôm nay";
            // 
            // pnContent
            // 
            pnContent.BackColor = Color.FromArgb(244, 247, 252);
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(220, 80);
            pnContent.Name = "pnContent";
            pnContent.Padding = new Padding(20);
            pnContent.Size = new Size(980, 640);
            pnContent.TabIndex = 0;
            // 
            // DoctorHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 720);
            Controls.Add(pnContent);
            Controls.Add(pnHeader);
            Controls.Add(pnSideBar);
            Name = "DoctorHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cổng thông tin Bác sĩ";
            pnSideBar.ResumeLayout(false);
            pnLogo.ResumeLayout(false);
            pnHeader.ResumeLayout(false);
            pnHeader.PerformLayout();
            ResumeLayout(false);
        }

        private void StyleDoctorMenu(System.Windows.Forms.Button btn, string text, int top)
        {
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("Segoe UI", 11F);
            btn.ForeColor = System.Drawing.Color.White;
            btn.Location = new System.Drawing.Point(0, top);
            btn.Size = new System.Drawing.Size(220, 50);
            btn.Text = "   " + text;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.UseVisualStyleBackColor = false;
        }

        #endregion

        private System.Windows.Forms.Panel pnSideBar;
        private System.Windows.Forms.Panel pnLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnMySchedule;
        private System.Windows.Forms.Button btnPatients;
        private System.Windows.Forms.Button btnMedicalHistory;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnContent;
        private Button btnDashBoard;
    }
}