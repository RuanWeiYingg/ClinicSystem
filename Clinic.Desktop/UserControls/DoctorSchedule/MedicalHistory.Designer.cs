namespace Clinic.Desktop.DoctorSchedule
{
    partial class MedicalHistory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlSearch = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvHistoryList = new DataGridView();
            pnlDetail = new Panel();
            lblDetailTitle = new Label();
            lblSymptoms = new Label();
            rtbSymptoms = new RichTextBox();
            lblDiagnosis = new Label();
            rtbDiagnosis = new RichTextBox();
            lblPrescription = new Label();
            rtbPrescription = new RichTextBox();
            btnPrint = new Button();
            STT = new DataGridViewTextBoxColumn();
            NgayKham = new DataGridViewTextBoxColumn();
            BenhNhan = new DataGridViewTextBoxColumn();
            ChanDoan = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            pnlTop.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoryList).BeginInit();
            pnlDetail.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(30, 80, 150);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(960, 55);
            pnlTop.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🗂  LỊCH SỬ KHÁM BỆNH";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.FromArgb(240, 245, 255);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 55);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(960, 50);
            pnlSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F);
            lblSearch.Location = new Point(20, 16);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(97, 17);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm bệnh nhân:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(135, 13);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên bệnh nhân...";
            txtSearch.Size = new Size(240, 25);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(30, 80, 150);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(385, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 28);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍  Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvHistoryList
            // 
            dgvHistoryList.AllowUserToAddRows = false;
            dgvHistoryList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistoryList.BackgroundColor = Color.White;
            dgvHistoryList.BorderStyle = BorderStyle.None;
            dgvHistoryList.Columns.AddRange(new DataGridViewColumn[] { STT, NgayKham, BenhNhan, ChanDoan, TrangThai });
            dgvHistoryList.Location = new Point(0, 105);
            dgvHistoryList.Name = "dgvHistoryList";
            dgvHistoryList.ReadOnly = true;
            dgvHistoryList.RowHeadersVisible = false;
            dgvHistoryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryList.Size = new Size(530, 418);
            dgvHistoryList.TabIndex = 0;
            // 
            // pnlDetail
            // 
            pnlDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlDetail.BackColor = Color.White;
            pnlDetail.BorderStyle = BorderStyle.FixedSingle;
            pnlDetail.Controls.Add(lblDetailTitle);
            pnlDetail.Controls.Add(lblSymptoms);
            pnlDetail.Controls.Add(rtbSymptoms);
            pnlDetail.Controls.Add(lblDiagnosis);
            pnlDetail.Controls.Add(rtbDiagnosis);
            pnlDetail.Controls.Add(lblPrescription);
            pnlDetail.Controls.Add(rtbPrescription);
            pnlDetail.Controls.Add(btnPrint);
            pnlDetail.Location = new Point(538, 105);
            pnlDetail.Name = "pnlDetail";
            pnlDetail.Size = new Size(420, 418);
            pnlDetail.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(10, 12);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(395, 26);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "CHI TIẾT LẦN KHÁM";
            // 
            // lblSymptoms
            // 
            lblSymptoms.AutoSize = true;
            lblSymptoms.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSymptoms.ForeColor = Color.FromArgb(80, 80, 80);
            lblSymptoms.Location = new Point(10, 48);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(73, 15);
            lblSymptoms.TabIndex = 1;
            lblSymptoms.Text = "Triệu chứng";
            // 
            // rtbSymptoms
            // 
            rtbSymptoms.BackColor = Color.FromArgb(250, 251, 255);
            rtbSymptoms.BorderStyle = BorderStyle.FixedSingle;
            rtbSymptoms.Font = new Font("Segoe UI", 9.5F);
            rtbSymptoms.Location = new Point(10, 68);
            rtbSymptoms.Name = "rtbSymptoms";
            rtbSymptoms.ReadOnly = true;
            rtbSymptoms.Size = new Size(395, 65);
            rtbSymptoms.TabIndex = 2;
            rtbSymptoms.Text = "";
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.AutoSize = true;
            lblDiagnosis.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiagnosis.ForeColor = Color.FromArgb(80, 80, 80);
            lblDiagnosis.Location = new Point(10, 145);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(65, 15);
            lblDiagnosis.TabIndex = 3;
            lblDiagnosis.Text = "Chẩn đoán";
            // 
            // rtbDiagnosis
            // 
            rtbDiagnosis.BackColor = Color.FromArgb(250, 251, 255);
            rtbDiagnosis.BorderStyle = BorderStyle.FixedSingle;
            rtbDiagnosis.Font = new Font("Segoe UI", 9.5F);
            rtbDiagnosis.Location = new Point(10, 165);
            rtbDiagnosis.Name = "rtbDiagnosis";
            rtbDiagnosis.ReadOnly = true;
            rtbDiagnosis.Size = new Size(395, 65);
            rtbDiagnosis.TabIndex = 4;
            rtbDiagnosis.Text = "";
            // 
            // lblPrescription
            // 
            lblPrescription.AutoSize = true;
            lblPrescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrescription.ForeColor = Color.FromArgb(80, 80, 80);
            lblPrescription.Location = new Point(10, 242);
            lblPrescription.Name = "lblPrescription";
            lblPrescription.Size = new Size(122, 15);
            lblPrescription.TabIndex = 5;
            lblPrescription.Text = "Đơn thuốc / Chỉ định";
            // 
            // rtbPrescription
            // 
            rtbPrescription.BackColor = Color.FromArgb(250, 251, 255);
            rtbPrescription.BorderStyle = BorderStyle.FixedSingle;
            rtbPrescription.Font = new Font("Segoe UI", 9.5F);
            rtbPrescription.Location = new Point(10, 262);
            rtbPrescription.Name = "rtbPrescription";
            rtbPrescription.ReadOnly = true;
            rtbPrescription.Size = new Size(395, 110);
            rtbPrescription.TabIndex = 6;
            rtbPrescription.Text = "";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(108, 117, 125);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 9.5F);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(140, 382);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(135, 30);
            btnPrint.TabIndex = 7;
            btnPrint.Text = "🖨  In bệnh án";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.Name = "STT";
            STT.ReadOnly = true;
            // 
            // NgayKham
            // 
            NgayKham.HeaderText = "Ngày Khám";
            NgayKham.Name = "NgayKham";
            NgayKham.ReadOnly = true;
            // 
            // BenhNhan
            // 
            BenhNhan.HeaderText = "Bệnh Nhân";
            BenhNhan.Name = "BenhNhan";
            BenhNhan.ReadOnly = true;
            // 
            // ChanDoan
            // 
            ChanDoan.HeaderText = "Chẩn Đoán";
            ChanDoan.Name = "ChanDoan";
            ChanDoan.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            // 
            // MedicalHistory
            // 
            BackColor = Color.White;
            Controls.Add(dgvHistoryList);
            Controls.Add(pnlDetail);
            Controls.Add(pnlSearch);
            Controls.Add(pnlTop);
            Name = "MedicalHistory";
            Size = new Size(960, 523);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoryList).EndInit();
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvHistoryList;
        private Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblSymptoms;
        private RichTextBox rtbSymptoms;
        private Label lblDiagnosis;
        private RichTextBox rtbDiagnosis;
        private Label lblPrescription;
        private RichTextBox rtbPrescription;
        private Button btnPrint;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn NgayKham;
        private DataGridViewTextBoxColumn BenhNhan;
        private DataGridViewTextBoxColumn ChanDoan;
        private DataGridViewTextBoxColumn TrangThai;
    }
}