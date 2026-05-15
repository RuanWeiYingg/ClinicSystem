namespace Clinic.Desktop.Components
{
    partial class Doctors
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblTitle = new Label();
            dgvDoctors = new DataGridView();
            DocName = new DataGridViewTextBoxColumn();
            SpecName = new DataGridViewTextBoxColumn();
            Exp = new DataGridViewTextBoxColumn();
            pnlRight = new Panel();
            lblDetailTitle = new Label();
            lblName = new Label();
            lblDoctorName = new Label();
            cboUserSelect = new ComboBox();
            lblSpecialty = new Label();
            cboSpecialty = new ComboBox();
            lblExp = new Label();
            txtExp = new TextBox();
            lblBio = new Label();
            txtBio = new TextBox();
            pnlButtons = new Panel();
            btnNew = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            lblBioCount = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).BeginInit();
            pnlRight.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(235, 245, 255);
            pnlTop.Controls.Add(lblBioCount);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(900, 65);
            pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblTitle.Location = new Point(15, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(158, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ BÁC SĨ";
            // 
            // dgvDoctors
            // 
            dgvDoctors.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 251, 255);
            dgvDoctors.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoctors.BackgroundColor = Color.White;
            dgvDoctors.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 80, 150);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDoctors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDoctors.Columns.AddRange(new DataGridViewColumn[] { DocName, SpecName, Exp });
            dgvDoctors.Dock = DockStyle.Fill;
            dgvDoctors.EnableHeadersVisualStyles = false;
            dgvDoctors.Font = new Font("Segoe UI", 9.5F);
            dgvDoctors.GridColor = Color.FromArgb(220, 230, 245);
            dgvDoctors.Location = new Point(0, 65);
            dgvDoctors.Name = "dgvDoctors";
            dgvDoctors.ReadOnly = true;
            dgvDoctors.RowHeadersVisible = false;
            dgvDoctors.RowTemplate.Height = 32;
            dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctors.Size = new Size(610, 535);
            dgvDoctors.TabIndex = 0;
            // 
            // DocName
            // 
            DocName.HeaderText = "Họ Tên";
            DocName.Name = "DocName";
            DocName.ReadOnly = true;
            // 
            // SpecName
            // 
            SpecName.HeaderText = "Chuyên Khoa";
            SpecName.Name = "SpecName";
            SpecName.ReadOnly = true;
            // 
            // Exp
            // 
            Exp.HeaderText = "Kinh Nghiệm (Năm)";
            Exp.Name = "Exp";
            Exp.ReadOnly = true;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(248, 250, 253);
            pnlRight.Controls.Add(lblDetailTitle);
            pnlRight.Controls.Add(lblName);
            pnlRight.Controls.Add(lblDoctorName);
            pnlRight.Controls.Add(cboUserSelect);
            pnlRight.Controls.Add(lblSpecialty);
            pnlRight.Controls.Add(cboSpecialty);
            pnlRight.Controls.Add(lblExp);
            pnlRight.Controls.Add(txtExp);
            pnlRight.Controls.Add(lblBio);
            pnlRight.Controls.Add(txtBio);
            pnlRight.Controls.Add(pnlButtons);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(610, 65);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(290, 535);
            pnlRight.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(15, 15);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(260, 28);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "THÔNG TIN BÁC SĨ";
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 9F);
            lblName.ForeColor = Color.FromArgb(80, 80, 80);
            lblName.Location = new Point(15, 57);
            lblName.Name = "lblName";
            lblName.Size = new Size(260, 18);
            lblName.TabIndex = 1;
            lblName.Text = "Họ và tên bác sĩ";
            // 
            // lblDoctorName
            // 
            lblDoctorName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoctorName.ForeColor = Color.FromArgb(30, 80, 150);
            lblDoctorName.Location = new Point(15, 78);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(260, 28);
            lblDoctorName.TabIndex = 2;
            lblDoctorName.Text = "---";
            // 
            // cboUserSelect
            // 
            cboUserSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUserSelect.FlatStyle = FlatStyle.Flat;
            cboUserSelect.Font = new Font("Segoe UI", 10F);
            cboUserSelect.Location = new Point(15, 78);
            cboUserSelect.Name = "cboUserSelect";
            cboUserSelect.Size = new Size(260, 25);
            cboUserSelect.TabIndex = 3;
            cboUserSelect.Visible = false;
            // 
            // lblSpecialty
            // 
            lblSpecialty.Font = new Font("Segoe UI", 9F);
            lblSpecialty.ForeColor = Color.FromArgb(80, 80, 80);
            lblSpecialty.Location = new Point(15, 118);
            lblSpecialty.Name = "lblSpecialty";
            lblSpecialty.Size = new Size(260, 18);
            lblSpecialty.TabIndex = 4;
            lblSpecialty.Text = "Chuyên khoa";
            // 
            // cboSpecialty
            // 
            cboSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSpecialty.FlatStyle = FlatStyle.Flat;
            cboSpecialty.Font = new Font("Segoe UI", 10F);
            cboSpecialty.Location = new Point(15, 139);
            cboSpecialty.Name = "cboSpecialty";
            cboSpecialty.Size = new Size(260, 25);
            cboSpecialty.TabIndex = 5;
            // 
            // lblExp
            // 
            lblExp.Font = new Font("Segoe UI", 9F);
            lblExp.ForeColor = Color.FromArgb(80, 80, 80);
            lblExp.Location = new Point(15, 181);
            lblExp.Name = "lblExp";
            lblExp.Size = new Size(260, 18);
            lblExp.TabIndex = 6;
            lblExp.Text = "Số năm kinh nghiệm";
            // 
            // txtExp
            // 
            txtExp.BorderStyle = BorderStyle.FixedSingle;
            txtExp.Font = new Font("Segoe UI", 10F);
            txtExp.Location = new Point(15, 202);
            txtExp.Name = "txtExp";
            txtExp.PlaceholderText = "Ví dụ: 5";
            txtExp.Size = new Size(260, 25);
            txtExp.TabIndex = 7;
            // 
            // lblBio
            // 
            lblBio.Font = new Font("Segoe UI", 9F);
            lblBio.ForeColor = Color.FromArgb(80, 80, 80);
            lblBio.Location = new Point(15, 242);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(260, 18);
            lblBio.TabIndex = 8;
            lblBio.Text = "Tiểu sử / Giới thiệu";
            // 
            // txtBio
            // 
            txtBio.BorderStyle = BorderStyle.FixedSingle;
            txtBio.Font = new Font("Segoe UI", 10F);
            txtBio.Location = new Point(15, 263);
            txtBio.Multiline = true;
            txtBio.Name = "txtBio";
            txtBio.PlaceholderText = "Tiểu sử tóm tắt...";
            txtBio.ScrollBars = ScrollBars.Vertical;
            txtBio.Size = new Size(260, 85);
            txtBio.TabIndex = 9;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.Add(btnNew);
            pnlButtons.Controls.Add(btnUpdate);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Location = new Point(15, 365);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(260, 185);
            pnlButtons.TabIndex = 10;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(40, 167, 69);
            btnNew.Cursor = Cursors.Hand;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(0, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(260, 40);
            btnNew.TabIndex = 0;
            btnNew.Text = "＋  THÊM BÁC SĨ";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 122, 204);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(0, 48);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(260, 40);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "💾  CẬP NHẬT";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.5F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(0, 96);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(260, 36);
            btnClear.TabIndex = 2;
            btnClear.Text = "🔄  Làm mới Form";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.5F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 140);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(260, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑  Xóa Bác Sĩ";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblBioCount
            // 
            lblBioCount.AutoSize = true;
            lblBioCount.Location = new Point(409, 22);
            lblBioCount.Name = "lblBioCount";
            lblBioCount.Size = new Size(43, 17);
            lblBioCount.TabIndex = 1;
            lblBioCount.Text = "label1";
            // 
            // Doctors
            // 
            BackColor = Color.White;
            Controls.Add(dgvDoctors);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.5F);
            Name = "Doctors";
            Size = new Size(900, 600);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        // =====================================================
        // KHAI BÁO BIẾN
        // =====================================================
        private Panel pnlTop;
        private Label lblTitle;

        private DataGridView dgvDoctors;
        private DataGridViewTextBoxColumn DocName;
        private DataGridViewTextBoxColumn SpecName;
        private DataGridViewTextBoxColumn Exp;

        private Panel pnlRight;
        private Label lblDetailTitle;
        private Label lblName;
        private Label lblDoctorName;     // ← Label tên (xem/sửa)
        private ComboBox cboUserSelect;  // ← ComboBox chọn user (thêm mới)
        private Label lblSpecialty;
        private ComboBox cboSpecialty;
        private Label lblExp;
        private TextBox txtExp;
        private Label lblBio;
        private TextBox txtBio;

        private Panel pnlButtons;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
        private Label lblBioCount;
    }
}