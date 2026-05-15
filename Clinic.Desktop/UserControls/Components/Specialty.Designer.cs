namespace Clinic.Desktop.Components
{
    partial class Specialty
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

            dgvSpecialties = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            SpecName = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();

            pnlRight = new Panel();
            lblDetailTitle = new Label();

            lblName = new Label();
            txtName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();

            pnlButtons = new Panel();
            btnNew = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();

            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpecialties).BeginInit();
            pnlRight.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // =====================================================
            // PANEL TOP
            // =====================================================
            pnlTop.BackColor = Color.FromArgb(235, 245, 255);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Size = new Size(908, 65);
            pnlTop.Controls.Add(lblTitle);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblTitle.Text = "QUẢN LÝ CHUYÊN KHOA";
            lblTitle.Location = new Point(15, 17);

            // =====================================================
            // CỘT DATAGRIDVIEW
            // =====================================================
            ID.Name = "ID";
            ID.HeaderText = "ID";
            ID.Visible = false;

            SpecName.Name = "SpecName";
            SpecName.HeaderText = "Tên Chuyên Khoa";

            Description.Name = "Description";
            Description.HeaderText = "Mô Tả";

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================
            dgvSpecialties.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSpecialties.BackgroundColor = Color.White;
            dgvSpecialties.BorderStyle = BorderStyle.None;
            dgvSpecialties.Dock = DockStyle.Fill;
            dgvSpecialties.RowHeadersVisible = false;
            dgvSpecialties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSpecialties.AllowUserToAddRows = false;
            dgvSpecialties.ReadOnly = true;
            dgvSpecialties.Font = new Font("Segoe UI", 9.5F);
            dgvSpecialties.GridColor = Color.FromArgb(220, 230, 245);
            dgvSpecialties.RowTemplate.Height = 32;
            dgvSpecialties.EnableHeadersVisualStyles = false;
            dgvSpecialties.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvSpecialties.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255);
            dgvSpecialties.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 80, 150);
            dgvSpecialties.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 255);
            dgvSpecialties.Columns.AddRange(new DataGridViewColumn[] { ID, SpecName, Description });

            // =====================================================
            // PANEL RIGHT
            // =====================================================
            pnlRight.BackColor = Color.FromArgb(248, 250, 253);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Size = new Size(300, 486);
            pnlRight.Controls.AddRange(new Control[]
            {
                lblDetailTitle,
                lblName,        txtName,
                lblDescription, txtDescription,
                pnlButtons
            });

            // Tiêu đề
            lblDetailTitle.Text = "THÔNG TIN CHUYÊN KHOA";
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(15, 15);
            lblDetailTitle.Size = new Size(270, 28);

            // --- Tên chuyên khoa ---
            lblName.Text = "Tên chuyên khoa";
            lblName.Font = new Font("Segoe UI", 9F);
            lblName.ForeColor = Color.FromArgb(80, 80, 80);
            lblName.Location = new Point(15, 57);
            lblName.Size = new Size(270, 18);

            txtName.Location = new Point(15, 78);
            txtName.Size = new Size(270, 26);
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.PlaceholderText = "Nhập tên chuyên khoa...";

            // --- Mô tả ---
            lblDescription.Text = "Mô tả / Ghi chú";
            lblDescription.Font = new Font("Segoe UI", 9F);
            lblDescription.ForeColor = Color.FromArgb(80, 80, 80);
            lblDescription.Location = new Point(15, 120);
            lblDescription.Size = new Size(270, 18);

            txtDescription.Location = new Point(15, 141);
            txtDescription.Size = new Size(270, 110);
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.PlaceholderText = "Mô tả ngắn gọn về chuyên khoa...";

            lblDescCount = new Label();
            lblDescCount.AutoSize = true;
            lblDescCount.Font = new Font("Segoe UI", 8F);
            lblDescCount.ForeColor = Color.FromArgb(120, 130, 150);
            lblDescCount.Location = new Point(230, 252); // Vị trí ngay góc dưới bên phải txtDescription
            lblDescCount.Name = "lblDescCount";
            lblDescCount.Size = new Size(40, 15);
            lblDescCount.Text = "0/1000";

            // =====================================================
            // PANEL BUTTONS
            // =====================================================
            pnlButtons.Location = new Point(15, 270);
            pnlButtons.Size = new Size(270, 185);
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.AddRange(new Control[] { btnNew, btnUpdate, btnClear, btnDelete });

            // Nút THÊM MỚI (xanh lá)
            btnNew.Location = new Point(0, 0);
            btnNew.Size = new Size(270, 40);
            btnNew.Text = "＋  THÊM CHUYÊN KHOA";
            btnNew.BackColor = Color.FromArgb(40, 167, 69);
            btnNew.ForeColor = Color.White;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.Cursor = Cursors.Hand;

            // Nút LƯU / CẬP NHẬT (xanh dương)
            btnUpdate.Location = new Point(0, 48);
            btnUpdate.Size = new Size(270, 40);
            btnUpdate.Text = "💾  LƯU CHUYÊN KHOA";
            btnUpdate.BackColor = Color.FromArgb(0, 122, 204);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.Cursor = Cursors.Hand;

            // Nút LÀM MỚI (xám)
            btnClear.Location = new Point(0, 96);
            btnClear.Size = new Size(270, 36);
            btnClear.Text = "🔄  Làm mới Form";
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.Cursor = Cursors.Hand;

            // Nút XÓA (đỏ)
            btnDelete.Location = new Point(0, 140);
            btnDelete.Size = new Size(270, 36);
            btnDelete.Text = "🗑  Xóa Chuyên Khoa";
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Segoe UI", 9.5F);
            btnDelete.Cursor = Cursors.Hand;

            // =====================================================
            // USERCONTROL
            // =====================================================
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9.5F);
            Name = "Specialty";
            Size = new Size(908, 551);

            Controls.Add(dgvSpecialties);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSpecialties).EndInit();
            pnlRight.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        // =====================================================
        // KHAI BÁO BIẾN
        // =====================================================
        private Panel pnlTop;
        private Label lblTitle;

        private DataGridView dgvSpecialties;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn SpecName;
        private DataGridViewTextBoxColumn Description;

        private Panel pnlRight;
        private Label lblDetailTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblDescription;
        private TextBox txtDescription;

        private Panel pnlButtons;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
        private Label lblDescCount;
    }
}