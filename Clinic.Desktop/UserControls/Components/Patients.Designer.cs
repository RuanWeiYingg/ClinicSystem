namespace Clinic.Desktop.Components
{
    partial class Patients
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();

            pnlTop = new Panel();
            lblTitle = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();

            dgvPatients = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            CreatedAt = new DataGridViewTextBoxColumn();

            pnlRight = new Panel();
            lblDetailTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            pnlButtons = new Panel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            pnlRight.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // ── pnlTop ────────────────────────────────────────
            pnlTop.BackColor = Color.FromArgb(235, 245, 255);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 65;
            pnlTop.Name = "pnlTop";

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblTitle.Location = new Point(15, 17);
            lblTitle.Text = "QUẢN LÝ BỆNH NHÂN";
            lblTitle.Name = "lblTitle";

            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(350, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm tên hoặc SĐT...";
            txtSearch.Size = new Size(250, 25);
            txtSearch.TabIndex = 1;

            btnSearch.BackColor = Color.FromArgb(0, 122, 204);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(610, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 28);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            

            // ── dgvPatients ───────────────────────────────────
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(235, 245, 255);
            headerStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(30, 80, 150);
            headerStyle.WrapMode = DataGridViewTriState.True;

            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvPatients.Columns.AddRange(new DataGridViewColumn[] {
                colID, FullName, PhoneNumber, Email, CreatedAt });
            dgvPatients.Dock = DockStyle.Fill;
            dgvPatients.EnableHeadersVisualStyles = false;
            dgvPatients.Font = new Font("Segoe UI", 9.5F);
            dgvPatients.GridColor = Color.FromArgb(220, 230, 245);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.RowTemplate.Height = 32;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.MultiSelect = false;

            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.DataPropertyName = "UserID";
            colID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colID.Width = 50;
            colID.ReadOnly = true;

            FullName.HeaderText = "Họ Tên";
            FullName.Name = "FullName";
            FullName.DataPropertyName = "FullName";
            FullName.ReadOnly = true;

            PhoneNumber.HeaderText = "Số Điện Thoại";
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.ReadOnly = true;

            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.DataPropertyName = "Email";
            Email.ReadOnly = true;

            CreatedAt.HeaderText = "Ngày Đăng Ký";
            CreatedAt.Name = "CreatedAt";
            CreatedAt.DataPropertyName = "CreatedAt";
            CreatedAt.ReadOnly = true;

            // ── pnlRight ──────────────────────────────────────
            pnlRight.BackColor = Color.FromArgb(248, 250, 253);
            pnlRight.Controls.Add(lblDetailTitle);
            pnlRight.Controls.Add(lblName);
            pnlRight.Controls.Add(txtName);
            pnlRight.Controls.Add(lblPhone);
            pnlRight.Controls.Add(txtPhone);
            pnlRight.Controls.Add(lblEmail);
            pnlRight.Controls.Add(txtEmail);
            pnlRight.Controls.Add(pnlButtons);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Width = 290;
            pnlRight.Name = "pnlRight";

            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(15, 15);
            lblDetailTitle.Size = new Size(260, 28);
            lblDetailTitle.Text = "THÔNG TIN BỆNH NHÂN";
            lblDetailTitle.Name = "lblDetailTitle";

            lblName.Font = new Font("Segoe UI", 9F);
            lblName.ForeColor = Color.FromArgb(80, 80, 80);
            lblName.Location = new Point(15, 55);
            lblName.Size = new Size(260, 18);
            lblName.Text = "Họ và tên";
            lblName.Name = "lblName";

            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(15, 76);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nhập họ và tên...";
            txtName.Size = new Size(260, 25);
            txtName.TabIndex = 0;

            lblPhone.Font = new Font("Segoe UI", 9F);
            lblPhone.ForeColor = Color.FromArgb(80, 80, 80);
            lblPhone.Location = new Point(15, 115);
            lblPhone.Size = new Size(260, 18);
            lblPhone.Text = "Số điện thoại";
            lblPhone.Name = "lblPhone";

            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(15, 136);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Ví dụ: 0901234567";
            txtPhone.Size = new Size(260, 25);
            txtPhone.TabIndex = 1;

            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.ForeColor = Color.FromArgb(80, 80, 80);
            lblEmail.Location = new Point(15, 175);
            lblEmail.Size = new Size(260, 18);
            lblEmail.Text = "Email";
            lblEmail.Name = "lblEmail";

            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(15, 196);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Ví dụ: abc@gmail.com";
            txtEmail.Size = new Size(260, 25);
            txtEmail.TabIndex = 2;

            // ── pnlButtons ────────────────────────────────────
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Location = new Point(15, 240);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(260, 150);

            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(260, 40);
            btnAdd.Text = "＋  THÊM MỚI";
            btnAdd.UseVisualStyleBackColor = false;

            btnUpdate.BackColor = Color.FromArgb(0, 122, 204);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(0, 50);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(260, 40);
            btnUpdate.Text = "💾  CẬP NHẬT";
            btnUpdate.UseVisualStyleBackColor = false;

            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 100);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(260, 40);
            btnDelete.Text = "🚫  XÓA BỆNH NHÂN";
            btnDelete.UseVisualStyleBackColor = false;

            // ── UserControl ───────────────────────────────────
            Controls.Add(dgvPatients);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
            Name = "Patients";
            Size = new Size(950, 700);

            pnlButtons.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;

        private DataGridView dgvPatients;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn CreatedAt;

        private Panel pnlRight;
        private Label lblDetailTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Panel pnlButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}