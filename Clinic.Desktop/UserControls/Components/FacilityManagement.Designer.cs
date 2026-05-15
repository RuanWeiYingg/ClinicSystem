namespace Clinic.Desktop.UserControls.Components
{
    partial class FacilityManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblTitle = new Label();
            dgvFacilities = new DataGridView();
            pnlRight = new Panel();
            lblDetailTitle = new Label();
            lblFacilityName = new Label();
            txtFacilityName = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            pnlButtons = new Panel();
            btnNew = new Button();
            btnSave = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            lblDescCount = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacilities).BeginInit();
            pnlRight.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(235, 245, 255);
            pnlTop.Controls.Add(lblDescCount);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(920, 65);
            pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblTitle.Location = new Point(15, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(255, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ CƠ SỞ VẬT CHẤT";
            // 
            // dgvFacilities
            // 
            dgvFacilities.AllowUserToAddRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(248, 251, 255);
            dgvFacilities.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvFacilities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacilities.BackgroundColor = Color.White;
            dgvFacilities.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(30, 80, 150);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvFacilities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvFacilities.Dock = DockStyle.Fill;
            dgvFacilities.EnableHeadersVisualStyles = false;
            dgvFacilities.Font = new Font("Segoe UI", 9.5F);
            dgvFacilities.GridColor = Color.FromArgb(220, 230, 245);
            dgvFacilities.Location = new Point(0, 65);
            dgvFacilities.Name = "dgvFacilities";
            dgvFacilities.ReadOnly = true;
            dgvFacilities.RowHeadersVisible = false;
            dgvFacilities.RowTemplate.Height = 32;
            dgvFacilities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacilities.Size = new Size(620, 535);
            dgvFacilities.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(248, 250, 253);
            pnlRight.Controls.Add(lblDetailTitle);
            pnlRight.Controls.Add(lblFacilityName);
            pnlRight.Controls.Add(txtFacilityName);
            pnlRight.Controls.Add(lblStatus);
            pnlRight.Controls.Add(cboStatus);
            pnlRight.Controls.Add(lblDescription);
            pnlRight.Controls.Add(txtDescription);
            pnlRight.Controls.Add(pnlButtons);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(620, 65);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(300, 535);
            pnlRight.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(15, 15);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(270, 28);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "THÔNG TIN CƠ SỞ VẬT CHẤT";
            // 
            // lblFacilityName
            // 
            lblFacilityName.Font = new Font("Segoe UI", 9F);
            lblFacilityName.ForeColor = Color.FromArgb(80, 80, 80);
            lblFacilityName.Location = new Point(15, 57);
            lblFacilityName.Name = "lblFacilityName";
            lblFacilityName.Size = new Size(270, 18);
            lblFacilityName.TabIndex = 1;
            lblFacilityName.Text = "Tên cơ sở vật chất";
            // 
            // txtFacilityName
            // 
            txtFacilityName.BorderStyle = BorderStyle.FixedSingle;
            txtFacilityName.Font = new Font("Segoe UI", 10F);
            txtFacilityName.Location = new Point(15, 78);
            txtFacilityName.Name = "txtFacilityName";
            txtFacilityName.PlaceholderText = "Nhập tên cơ sở vật chất...";
            txtFacilityName.Size = new Size(270, 25);
            txtFacilityName.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(80, 80, 80);
            lblStatus.Location = new Point(15, 120);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(270, 18);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Trạng thái vận hành";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FlatStyle = FlatStyle.Flat;
            cboStatus.Font = new Font("Segoe UI", 10F);
            cboStatus.Items.AddRange(new object[] { "✅  Đang hoạt động", "🔧  Ngừng hoạt động / Bảo trì" });
            cboStatus.Location = new Point(15, 141);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(270, 25);
            cboStatus.TabIndex = 4;
            // 
            // lblDescription
            // 
            lblDescription.Font = new Font("Segoe UI", 9F);
            lblDescription.ForeColor = Color.FromArgb(80, 80, 80);
            lblDescription.Location = new Point(15, 185);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(270, 18);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Mô tả / Ghi chú";
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(15, 206);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Nhập mô tả, ghi chú về thiết bị/cơ sở...";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(270, 110);
            txtDescription.TabIndex = 6;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.Add(btnNew);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Location = new Point(15, 335);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(270, 185);
            pnlButtons.TabIndex = 7;
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
            btnNew.Size = new Size(270, 40);
            btnNew.TabIndex = 0;
            btnNew.Text = "＋  THÊM MỚI";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 48);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(270, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾  LƯU THÔNG TIN";
            btnSave.UseVisualStyleBackColor = false;
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
            btnClear.Size = new Size(270, 36);
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
            btnDelete.Size = new Size(270, 36);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑  Xóa khỏi danh sách";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblDescCount
            // 
            lblDescCount.AutoSize = true;
            lblDescCount.Location = new Point(388, 15);
            lblDescCount.Name = "lblDescCount";
            lblDescCount.Size = new Size(43, 17);
            lblDescCount.TabIndex = 1;
            lblDescCount.Text = "label1";
            // 
            // FacilityManagement
            // 
            BackColor = Color.White;
            Controls.Add(dgvFacilities);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.5F);
            Name = "FacilityManagement";
            Size = new Size(920, 600);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacilities).EndInit();
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

        private DataGridView dgvFacilities;

        private Panel pnlRight;
        private Label lblDetailTitle;
        private Label lblFacilityName;
        private TextBox txtFacilityName;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblDescription;
        private TextBox txtDescription;

        private Panel pnlButtons;
        private Button btnNew;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
        private Label lblDescCount;
    }
}