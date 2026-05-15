namespace Clinic.Desktop.DoctorSchedule
{
    partial class Profile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            picAvatar = new PictureBox();
            lblFullName = new Label();
            lblDoctorID = new Label();
            lblSideSpec = new Label();
            lblSidePhone = new Label();
            lblSideExp = new Label();
            btnUploadAvatar = new Button();
            lblUploadStatus = new Label();

            pnlMain = new Panel();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblLastUpdate = new Label();
            pnlForm = new Panel();
            pnlFooter = new Panel();

            lblFldName = new Label(); txtName = new TextBox();
            lblFldID = new Label(); txtID = new TextBox();
            lblFldPhone = new Label(); txtPhone = new TextBox();
            lblFldEmail = new Label(); txtEmail = new TextBox();
            lblFldSpec = new Label(); txtSpecialty = new TextBox();
            lblFldExp = new Label(); txtExperience = new TextBox();
            lblFldBio = new Label(); rtbBio = new RichTextBox();

            btnSave = new Button();
            btnCancel = new Button();

            // unused but declared
            pnlBadge = new Panel();
            lblBadgeDot = new Label();
            lblBadgeText = new Label();
            pnlSideInfo = new Panel();
            pnlTabBar = new Panel();
            btnTabInfo = new Button();
            lblAvatarHint = new Label();

            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            pnlMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlForm.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();

            // ══════════════════════════════════════════════════════
            // SIDEBAR
            // ══════════════════════════════════════════════════════
            pnlSidebar.BackColor = Color.FromArgb(15, 76, 129);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 240;
            pnlSidebar.Controls.AddRange(new Control[]
            {
                lblUploadStatus, btnUploadAvatar,
                lblSideExp, lblSidePhone, lblSideSpec,
                lblDoctorID, lblFullName, picAvatar
            });

            picAvatar.Location = new Point(65, 30);
            picAvatar.Size = new Size(110, 110);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.BackColor = Color.FromArgb(180, 210, 240);
            picAvatar.Cursor = Cursors.Hand;

            lblFullName.Text = "Bác sĩ";
            lblFullName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblFullName.ForeColor = Color.White;
            lblFullName.Location = new Point(10, 152);
            lblFullName.Size = new Size(220, 28);
            lblFullName.TextAlign = ContentAlignment.MiddleCenter;

            lblDoctorID.Text = "---";
            lblDoctorID.Font = new Font("Segoe UI", 9F);
            lblDoctorID.ForeColor = Color.FromArgb(160, 200, 240);
            lblDoctorID.Location = new Point(10, 182);
            lblDoctorID.Size = new Size(220, 20);
            lblDoctorID.TextAlign = ContentAlignment.MiddleCenter;

            lblSideSpec.Text = "🏥  ---";
            lblSideSpec.Font = new Font("Segoe UI", 9.5F);
            lblSideSpec.ForeColor = Color.FromArgb(200, 225, 255);
            lblSideSpec.Location = new Point(18, 220);
            lblSideSpec.Size = new Size(204, 22);

            lblSidePhone.Text = "📞  ---";
            lblSidePhone.Font = new Font("Segoe UI", 9.5F);
            lblSidePhone.ForeColor = Color.FromArgb(200, 225, 255);
            lblSidePhone.Location = new Point(18, 248);
            lblSidePhone.Size = new Size(204, 22);

            lblSideExp.Text = "⏱  ---";
            lblSideExp.Font = new Font("Segoe UI", 9.5F);
            lblSideExp.ForeColor = Color.FromArgb(200, 225, 255);
            lblSideExp.Location = new Point(18, 276);
            lblSideExp.Size = new Size(204, 22);

            btnUploadAvatar.Text = "🖼  Đổi ảnh đại diện";
            btnUploadAvatar.Font = new Font("Segoe UI", 9F);
            btnUploadAvatar.Location = new Point(18, 420);
            btnUploadAvatar.Size = new Size(204, 34);
            btnUploadAvatar.BackColor = Color.FromArgb(24, 95, 165);
            btnUploadAvatar.ForeColor = Color.White;
            btnUploadAvatar.FlatStyle = FlatStyle.Flat;
            btnUploadAvatar.FlatAppearance.BorderSize = 0;
            btnUploadAvatar.Cursor = Cursors.Hand;

            lblUploadStatus.Text = "";
            lblUploadStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblUploadStatus.ForeColor = Color.FromArgb(150, 220, 150);
            lblUploadStatus.Location = new Point(18, 458);
            lblUploadStatus.Size = new Size(204, 20);
            lblUploadStatus.TextAlign = ContentAlignment.MiddleCenter;

            // ══════════════════════════════════════════════════════
            // PANEL MAIN
            // ══════════════════════════════════════════════════════
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Controls.AddRange(new Control[] { pnlForm, pnlFooter, pnlHeader });

            // ── Header ────────────────────────────────────────────
            pnlHeader.BackColor = Color.FromArgb(240, 245, 255);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.Controls.AddRange(new Control[] { lblLastUpdate, lblTitle });

            lblTitle.Text = "THÔNG TIN HỒ SƠ CÁ NHÂN";
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 76, 129);
            lblTitle.Location = new Point(20, 16);
            lblTitle.AutoSize = true;

            lblLastUpdate.Text = "";
            lblLastUpdate.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblLastUpdate.ForeColor = Color.FromArgb(140, 140, 160);
            lblLastUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLastUpdate.Location = new Point(360, 22);
            lblLastUpdate.Size = new Size(240, 18);
            lblLastUpdate.TextAlign = ContentAlignment.MiddleRight;

            // ── Form ──────────────────────────────────────────────
            pnlForm.Dock = DockStyle.Fill;
            pnlForm.AutoScroll = true;
            pnlForm.Padding = new Padding(20, 12, 20, 0);
            pnlForm.Controls.AddRange(new Control[]
            {
                lblFldName,   txtName,
                lblFldID,     txtID,
                lblFldPhone,  txtPhone,
                lblFldEmail,  txtEmail,
                lblFldSpec,   txtSpecialty,
                lblFldExp,    txtExperience,
                lblFldBio,    rtbBio
            });

            // Hàng 1 — Họ tên (trái)
            lblFldName.Text = "Họ và tên";
            lblFldName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFldName.ForeColor = Color.FromArgb(80, 100, 130);
            lblFldName.Location = new Point(20, 8);
            lblFldName.AutoSize = true;

            txtName.Location = new Point(20, 26);
            txtName.Size = new Size(270, 28);
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.ReadOnly = true;
            txtName.BackColor = Color.FromArgb(240, 242, 246);

            // Hàng 1 — Mã bác sĩ (phải)
            lblFldID.Text = "Mã bác sĩ";
            lblFldID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFldID.ForeColor = Color.FromArgb(80, 100, 130);
            lblFldID.Location = new Point(310, 8);
            lblFldID.AutoSize = true;

            txtID.Location = new Point(310, 26);
            txtID.Size = new Size(270, 28);
            txtID.Font = new Font("Segoe UI", 10F);
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.ReadOnly = true;
            txtID.BackColor = Color.FromArgb(240, 242, 246);

            // Hàng 2 — Số điện thoại (trái)
            lblFldPhone.Text = "Số điện thoại";
            lblFldPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFldPhone.ForeColor = Color.FromArgb(80, 100, 130);
            lblFldPhone.Location = new Point(20, 68);
            lblFldPhone.AutoSize = true;

            txtPhone.Location = new Point(20, 86);
            txtPhone.Size = new Size(270, 28);
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.BorderStyle = BorderStyle.FixedSingle;

            // Hàng 2 — Email (phải)
            lblFldEmail.Text = "Email";
            lblFldEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFldEmail.ForeColor = Color.FromArgb(80, 100, 130);
            lblFldEmail.Location = new Point(310, 68);
            lblFldEmail.AutoSize = true;

            txtEmail.Location = new Point(310, 86);
            txtEmail.Size = new Size(270, 28);
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;

            // Hàng 3 — Chuyên khoa (trái)
            lblFldSpec.Text = "Chuyên khoa";
            lblFldSpec.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFldSpec.ForeColor = Color.FromArgb(80, 100, 130);
            lblFldSpec.Location = new Point(20, 128);
            lblFldSpec.AutoSize = true;

            txtSpecialty.Location = new Point(20, 146);
            txtSpecialty.Size = new Size(270, 28);
            txtSpecialty.Font = new Font("Segoe UI", 10F);
            txtSpecialty.BorderStyle = BorderStyle.FixedSingle;
            txtSpecialty.ReadOnly = true;
            txtSpecialty.BackColor = Color.FromArgb(240, 242, 246);

            // Hàng 3 — Kinh nghiệm (phải)
            lblFldExp.Text = "Số năm kinh nghiệm";
            lblFldExp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFldExp.ForeColor = Color.FromArgb(80, 100, 130);
            lblFldExp.Location = new Point(310, 128);
            lblFldExp.AutoSize = true;

            txtExperience.Location = new Point(310, 146);
            txtExperience.Size = new Size(270, 28);
            txtExperience.Font = new Font("Segoe UI", 10F);
            txtExperience.BorderStyle = BorderStyle.FixedSingle;

            // Hàng 4 — Tiểu sử (full width)
            lblFldBio.Text = "Tiểu sử / Giới thiệu";
            lblFldBio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFldBio.ForeColor = Color.FromArgb(80, 100, 130);
            lblFldBio.Location = new Point(20, 188);
            lblFldBio.AutoSize = true;

            rtbBio.Location = new Point(20, 208);
            rtbBio.Size = new Size(560, 130);
            rtbBio.Font = new Font("Segoe UI", 10F);
            rtbBio.BorderStyle = BorderStyle.FixedSingle;
            rtbBio.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbBio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // ── Footer ────────────────────────────────────────────
            pnlFooter.BackColor = Color.FromArgb(245, 247, 252);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 56;
            pnlFooter.Controls.AddRange(new Control[] { btnSave, btnCancel });

            btnSave.Text = "💾  Lưu thay đổi";
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Location = new Point(460, 12);
            btnSave.Size = new Size(150, 34);
            btnSave.BackColor = Color.FromArgb(15, 76, 129);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            btnCancel.Text = "↩  Hủy";
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Location = new Point(370, 12);
            btnCancel.Size = new Size(82, 34);
            btnCancel.BackColor = Color.FromArgb(220, 225, 235);
            btnCancel.ForeColor = Color.FromArgb(60, 80, 110);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // ══════════════════════════════════════════════════════
            // USERCONTROL
            // ══════════════════════════════════════════════════════
            BackColor = Color.White;
            Size = new Size(860, 500);
            Name = "Profile";
            Controls.AddRange(new Control[] { pnlMain, pnlSidebar });

            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            pnlMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlSidebar;
        private PictureBox picAvatar;
        private Label lblAvatarHint;
        private Label lblFullName;
        private Label lblDoctorID;
        private Panel pnlBadge;
        private Label lblBadgeDot;
        private Label lblBadgeText;
        private Panel pnlSideInfo;
        private Label lblSidePhone;
        private Label lblSideSpec;
        private Label lblSideExp;
        private Button btnUploadAvatar;
        private Label lblUploadStatus;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblLastUpdate;
        private Panel pnlTabBar;
        private Button btnTabInfo;
        private Panel pnlForm;
        private Label lblFldName; private TextBox txtName;
        private Label lblFldID; private TextBox txtID;
        private Label lblFldPhone; private TextBox txtPhone;
        private Label lblFldSpec; private TextBox txtSpecialty;
        private Label lblFldExp; private TextBox txtExperience;
        private Label lblFldEmail; private TextBox txtEmail;
        private Label lblFldBio; private RichTextBox rtbBio;
        private Panel pnlFooter;
        private Button btnCancel;
        private Button btnSave;
    }
}