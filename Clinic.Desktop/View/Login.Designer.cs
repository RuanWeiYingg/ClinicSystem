namespace Clinic.Desktop.View
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlBackground = new Panel();
            pnlAccent = new Panel();
            lblSystemName = new Label();
            lblTagline = new Label();
            pnlCard = new Panel();
            lblLoginTitle = new Label();
            lblSubtitle = new Label();
            lblUsernameIcon = new Label();
            txtUsername = new TextBox();
            lblPasswordIcon = new Label();
            txtPassword = new TextBox();
            btnTogglePassword = new Button();
            pnlRemember = new Panel();
            chkRemember = new CheckBox();
            lblForgot = new Label();
            btnLogin = new Button();
            lblError = new Label();
            lblVersion = new Label();
            pnlBackground.SuspendLayout();
            pnlAccent.SuspendLayout();
            pnlCard.SuspendLayout();
            pnlRemember.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBackground
            // 
            pnlBackground.BackColor = Color.FromArgb(15, 23, 42);
            pnlBackground.Controls.Add(pnlAccent);
            pnlBackground.Controls.Add(pnlCard);
            pnlBackground.Controls.Add(lblVersion);
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.Location = new Point(0, 0);
            pnlBackground.Margin = new Padding(3, 2, 3, 2);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new Size(446, 418);
            pnlBackground.TabIndex = 0;
            // 
            // pnlAccent
            // 
            pnlAccent.BackColor = Color.FromArgb(29, 78, 216);
            pnlAccent.Controls.Add(lblSystemName);
            pnlAccent.Controls.Add(lblTagline);
            pnlAccent.Location = new Point(0, 0);
            pnlAccent.Margin = new Padding(3, 2, 3, 2);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(7, 375);
            pnlAccent.TabIndex = 0;
            // 
            // lblSystemName
            // 
            lblSystemName.Location = new Point(0, 0);
            lblSystemName.Name = "lblSystemName";
            lblSystemName.Size = new Size(88, 17);
            lblSystemName.TabIndex = 0;
            lblSystemName.Visible = false;
            // 
            // lblTagline
            // 
            lblTagline.Location = new Point(0, 0);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(88, 17);
            lblTagline.TabIndex = 1;
            lblTagline.Visible = false;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.FromArgb(30, 41, 59);
            pnlCard.Controls.Add(lblLoginTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblUsernameIcon);
            pnlCard.Controls.Add(txtUsername);
            pnlCard.Controls.Add(lblPasswordIcon);
            pnlCard.Controls.Add(txtPassword);
            pnlCard.Controls.Add(btnTogglePassword);
            pnlCard.Controls.Add(pnlRemember);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(lblError);
            pnlCard.Location = new Point(66, 45);
            pnlCard.Margin = new Padding(3, 2, 3, 2);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(315, 345);
            pnlCard.TabIndex = 1;
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLoginTitle.ForeColor = Color.FromArgb(248, 250, 252);
            lblLoginTitle.Location = new Point(27, 11);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(262, 47);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "DELTA SYSTEM";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(29, 68);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(262, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Phần mềm Quản lý Phòng khám";
            // 
            // lblUsernameIcon
            // 
            lblUsernameIcon.Font = new Font("Segoe UI", 10F);
            lblUsernameIcon.ForeColor = Color.FromArgb(100, 116, 139);
            lblUsernameIcon.Location = new Point(28, 93);
            lblUsernameIcon.Name = "lblUsernameIcon";
            lblUsernameIcon.Size = new Size(175, 20);
            lblUsernameIcon.TabIndex = 2;
            lblUsernameIcon.Text = "Tên đăng nhập";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(15, 23, 42);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.FromArgb(248, 250, 252);
            txtUsername.Location = new Point(28, 115);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";
            txtUsername.Size = new Size(263, 27);
            txtUsername.TabIndex = 0;
            // 
            // lblPasswordIcon
            // 
            lblPasswordIcon.Font = new Font("Segoe UI", 10F);
            lblPasswordIcon.ForeColor = Color.FromArgb(100, 116, 139);
            lblPasswordIcon.Location = new Point(28, 144);
            lblPasswordIcon.Name = "lblPasswordIcon";
            lblPasswordIcon.Size = new Size(175, 17);
            lblPasswordIcon.TabIndex = 3;
            lblPasswordIcon.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(15, 23, 42);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(248, 250, 252);
            txtPassword.Location = new Point(28, 170);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            txtPassword.Size = new Size(235, 27);
            txtPassword.TabIndex = 1;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.FromArgb(15, 23, 42);
            btnTogglePassword.Cursor = Cursors.Hand;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font("Segoe UI", 10F);
            btnTogglePassword.ForeColor = Color.FromArgb(100, 116, 139);
            btnTogglePassword.Location = new Point(263, 170);
            btnTogglePassword.Margin = new Padding(3, 2, 3, 2);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(28, 26);
            btnTogglePassword.TabIndex = 2;
            btnTogglePassword.Text = "👁";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += BtnTogglePassword_Click;
            // 
            // pnlRemember
            // 
            pnlRemember.BackColor = Color.Transparent;
            pnlRemember.Controls.Add(chkRemember);
            pnlRemember.Controls.Add(lblForgot);
            pnlRemember.Location = new Point(26, 206);
            pnlRemember.Margin = new Padding(3, 2, 3, 2);
            pnlRemember.Name = "pnlRemember";
            pnlRemember.Size = new Size(266, 20);
            pnlRemember.TabIndex = 4;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.BackColor = Color.Transparent;
            chkRemember.Cursor = Cursors.Hand;
            chkRemember.Font = new Font("Segoe UI", 9.5F);
            chkRemember.ForeColor = Color.FromArgb(148, 163, 184);
            chkRemember.Location = new Point(0, 2);
            chkRemember.Margin = new Padding(3, 2, 3, 2);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(109, 21);
            chkRemember.TabIndex = 3;
            chkRemember.Text = "Nhớ mật khẩu";
            chkRemember.UseVisualStyleBackColor = false;
            // 
            // lblForgot
            // 
            lblForgot.AutoSize = true;
            lblForgot.Cursor = Cursors.Hand;
            lblForgot.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblForgot.ForeColor = Color.FromArgb(59, 130, 246);
            lblForgot.Location = new Point(169, 5);
            lblForgot.Name = "lblForgot";
            lblForgot.Size = new Size(94, 15);
            lblForgot.TabIndex = 4;
            lblForgot.Text = "Quên mật khẩu?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(29, 78, 216);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(28, 242);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(262, 34);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;
            // 
            // lblError
            // 
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.FromArgb(248, 113, 113);
            lblError.Location = new Point(28, 286);
            lblError.Name = "lblError";
            lblError.Size = new Size(262, 30);
            lblError.TabIndex = 5;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 8F);
            lblVersion.ForeColor = Color.FromArgb(51, 65, 85);
            lblVersion.Location = new Point(149, 358);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(137, 13);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "v1.0.0 © 2026 Delta Clinic";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(446, 418);
            Controls.Add(pnlBackground);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Delta System - Đăng nhập";
            pnlBackground.ResumeLayout(false);
            pnlBackground.PerformLayout();
            pnlAccent.ResumeLayout(false);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlRemember.ResumeLayout(false);
            pnlRemember.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Panel pnlBackground;
        private Panel pnlAccent;
        private Label lblSystemName;
        private Label lblTagline;
        private Panel pnlCard;
        private Label lblLoginTitle;
        private Label lblSubtitle;
        private Label lblUsernameIcon;
        private TextBox txtUsername;
        private Label lblPasswordIcon;
        private TextBox txtPassword;
        private Button btnTogglePassword;
        private Panel pnlRemember;
        private CheckBox chkRemember;
        private Label lblForgot;
        private Button btnLogin;
        private Label lblError;
        private Label lblVersion;
    }
}