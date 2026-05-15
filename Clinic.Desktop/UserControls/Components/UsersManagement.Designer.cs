namespace Clinic.Desktop.UserControls.Components
{
    partial class UsersManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // --- KHAI BÁO CONTROLS ---
            pnlTop = new Panel();
            lblTitle = new Label();

            dgvUsers = new DataGridView();

            pnlRight = new Panel();
            lblDetailTitle = new Label();

            lblFullName = new Label();
            txtFullName = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();

            pnlButtons = new Panel();
            btnNew = new Button();
            btnSave = new Button();
            btnClear = new Button();
            btnDelete = new Button();

            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlRight.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // =====================================================
            // PANEL TOP
            // =====================================================
            pnlTop.BackColor = Color.FromArgb(235, 245, 255);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Size = new Size(920, 65);
            pnlTop.Controls.Add(lblTitle);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblTitle.Text = "QUẢN LÝ TÀI KHOẢN NGƯỜI DÙNG";
            lblTitle.Location = new Point(15, 17);

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Font = new Font("Segoe UI", 9.5F);
            dgvUsers.GridColor = Color.FromArgb(220, 230, 245);
            dgvUsers.RowTemplate.Height = 32;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 80, 150);
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 255);

            // =====================================================
            // PANEL RIGHT
            // =====================================================
            pnlRight.BackColor = Color.FromArgb(248, 250, 253);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Size = new Size(310, 535);
            pnlRight.Controls.AddRange(new Control[]
            {
                lblDetailTitle,
                lblFullName,  txtFullName,
                lblUsername,  txtUsername,
                lblPassword,  txtPassword,
                lblRole,      cboRole,
                pnlButtons
            });

            // Tiêu đề
            lblDetailTitle.Text = "THÔNG TIN TÀI KHOẢN";
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(15, 15);
            lblDetailTitle.Size = new Size(280, 28);

            // --- Họ và tên ---
            lblFullName.Text = "Họ và tên";
            lblFullName.Font = new Font("Segoe UI", 9F);
            lblFullName.ForeColor = Color.FromArgb(80, 80, 80);
            lblFullName.Location = new Point(15, 57);
            lblFullName.Size = new Size(280, 18);

            txtFullName.Location = new Point(15, 78);
            txtFullName.Size = new Size(280, 26);
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.PlaceholderText = "Nhập họ và tên đầy đủ...";

            // --- Tên đăng nhập ---
            lblUsername.Text = "Tên đăng nhập";
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.ForeColor = Color.FromArgb(80, 80, 80);
            lblUsername.Location = new Point(15, 118);
            lblUsername.Size = new Size(280, 18);

            txtUsername.Location = new Point(15, 139);
            txtUsername.Size = new Size(280, 26);
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.PlaceholderText = "Nhập tên đăng nhập...";

            // --- Mật khẩu ---
            lblPassword.Text = "Mật khẩu";
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.ForeColor = Color.FromArgb(80, 80, 80);
            lblPassword.Location = new Point(15, 179);
            lblPassword.Size = new Size(280, 18);

            txtPassword.Location = new Point(15, 200);
            txtPassword.Size = new Size(280, 26);
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Nhập mật khẩu...";

            // --- Chức vụ / Quyền ---
            lblRole.Text = "Chức vụ / Quyền hạn";
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.ForeColor = Color.FromArgb(80, 80, 80);
            lblRole.Location = new Point(15, 240);
            lblRole.Size = new Size(280, 18);

            cboRole.Location = new Point(15, 261);
            cboRole.Size = new Size(280, 28);
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;

            // =====================================================
            // PANEL BUTTONS
            // =====================================================
            pnlButtons.Location = new Point(15, 308);
            pnlButtons.Size = new Size(280, 185);
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.AddRange(new Control[] { btnNew, btnSave, btnClear, btnDelete });

            // Nút THÊM MỚI (xanh lá)
            btnNew.Location = new Point(0, 0);
            btnNew.Size = new Size(280, 40);
            btnNew.Text = "＋  TẠO TÀI KHOẢN MỚI";
            btnNew.BackColor = Color.FromArgb(40, 167, 69);
            btnNew.ForeColor = Color.White;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.Cursor = Cursors.Hand;

            // Nút LƯU / CẬP NHẬT (xanh dương)
            btnSave.Location = new Point(0, 48);
            btnSave.Size = new Size(280, 40);
            btnSave.Text = "💾  LƯU TÀI KHOẢN";
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;

            // Nút LÀM MỚI (xám)
            btnClear.Location = new Point(0, 96);
            btnClear.Size = new Size(280, 36);
            btnClear.Text = "🔄  Làm mới Form";
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.Cursor = Cursors.Hand;

            // Nút XÓA (đỏ)
            btnDelete.Location = new Point(0, 140);
            btnDelete.Size = new Size(280, 36);
            btnDelete.Text = "🗑  Xóa Tài Khoản";
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 9.5F);
            btnDelete.Cursor = Cursors.Hand;

            // =====================================================
            // USERCONTROL
            // =====================================================
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);
            Name = "UsersManagement";
            Size = new Size(920, 600);

            Controls.Add(dgvUsers);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlRight.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        // =====================================================
        // KHAI BÁO BIẾN
        // =====================================================
        private Panel pnlTop;
        private Label lblTitle;

        private DataGridView dgvUsers;

        private Panel pnlRight;
        private Label lblDetailTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cboRole;

        private Panel pnlButtons;
        private Button btnNew;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
    }
}