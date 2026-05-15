using System.Windows.Forms;

namespace Clinic.Desktop.UserControls.Components
{
    partial class MedicalRecords
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

            pnlLeft = new Panel();
            lblPatientList = new Label();
            txtSearchPatient = new TextBox();
            lstPatients = new ListBox();

            pnlMain = new Panel();
            pnlHeader = new Panel();
            lblPatientName = new Label();
            lblPatientPhone = new Label();
            lblPatientRole = new Label();

            pnlContent = new Panel();
            dgvHistory = new DataGridView();

            pnlDetail = new Panel();
            lblDetailTitle = new Label();
            lblDateLabel = new Label();
            lblDateValue = new Label();
            lblDiagLabel = new Label();
            rtbDiagnosis = new RichTextBox();
            lblTreatLabel = new Label();
            rtbTreatment = new RichTextBox();
            btnPrint = new Button();

            pnlTop.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();

            // ── PANEL TOP ───────────────────────────────────────────
            pnlTop.BackColor = Color.FromArgb(30, 80, 150);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 55;
            pnlTop.Controls.Add(lblTitle);

            lblTitle.Text = "🗂  HỒ SƠ BỆNH ÁN";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 14);

            // ── PANEL LEFT — Danh sách bệnh nhân ───────────────────
            pnlLeft.BackColor = Color.FromArgb(240, 244, 252);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Width = 250;
            pnlLeft.Padding = new Padding(10, 10, 10, 10);
            pnlLeft.Controls.AddRange(new Control[] { lstPatients, txtSearchPatient, lblPatientList });

            lblPatientList.Text = "Danh sách bệnh nhân";
            lblPatientList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPatientList.ForeColor = Color.FromArgb(30, 80, 150);
            lblPatientList.Dock = DockStyle.Top;
            lblPatientList.Height = 32;

            txtSearchPatient.Dock = DockStyle.Top;
            txtSearchPatient.Height = 28;
            txtSearchPatient.Font = new Font("Segoe UI", 10F);
            txtSearchPatient.BorderStyle = BorderStyle.FixedSingle;
            txtSearchPatient.PlaceholderText = "🔍  Tìm tên hoặc SĐT...";

            lstPatients.Dock = DockStyle.Fill;
            lstPatients.Font = new Font("Segoe UI", 10F);
            lstPatients.BorderStyle = BorderStyle.None;
            lstPatients.BackColor = Color.FromArgb(240, 244, 252);
            lstPatients.ItemHeight = 24;
            lstPatients.FormattingEnabled = true;

            // ── PANEL MAIN ──────────────────────────────────────────
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Controls.AddRange(new Control[] { pnlContent, pnlHeader });

            // ── PANEL HEADER — Thông tin bệnh nhân được chọn ───────
            pnlHeader.BackColor = Color.FromArgb(30, 80, 150);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.Padding = new Padding(16, 0, 16, 0);
            pnlHeader.Controls.AddRange(new Control[] { lblPatientRole, lblPatientPhone, lblPatientName });

            lblPatientName.Text = "Chưa chọn bệnh nhân";
            lblPatientName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.White;
            lblPatientName.AutoSize = true;
            lblPatientName.Location = new Point(16, 10);

            lblPatientPhone.Text = "";
            lblPatientPhone.Font = new Font("Segoe UI", 9F);
            lblPatientPhone.ForeColor = Color.FromArgb(180, 210, 255);
            lblPatientPhone.AutoSize = true;
            lblPatientPhone.Location = new Point(16, 36);

            lblPatientRole.Text = "";
            lblPatientRole.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblPatientRole.ForeColor = Color.FromArgb(180, 210, 255);
            lblPatientRole.AutoSize = true;
            lblPatientRole.Location = new Point(200, 36);

            // ── PANEL CONTENT — Bảng + Chi tiết ────────────────────
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Controls.AddRange(new Control[] { pnlDetail, dgvHistory });

            // ── DATAGRIDVIEW — Danh sách lần khám ──────────────────
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.MultiSelect = false;
            dgvHistory.Font = new Font("Segoe UI", 9.5F);
            dgvHistory.RowTemplate.Height = 36;
            dgvHistory.GridColor = Color.FromArgb(220, 230, 245);
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 255);
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 80, 150);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            dgvHistory.ColumnHeadersHeight = 40;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 40, 80);
            dgvHistory.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);

            // ── PANEL DETAIL — Chi tiết lần khám được chọn ─────────
            pnlDetail.Dock = DockStyle.Right;
            pnlDetail.Width = 350;
            pnlDetail.BackColor = Color.FromArgb(248, 250, 255);
            pnlDetail.BorderStyle = BorderStyle.None;
            pnlDetail.Padding = new Padding(16, 12, 16, 12);
            pnlDetail.Controls.AddRange(new Control[]
            {
                btnPrint,
                rtbTreatment, lblTreatLabel,
                rtbDiagnosis, lblDiagLabel,
                lblDateValue, lblDateLabel,
                lblDetailTitle
            });

            lblDetailTitle.Text = "CHI TIẾT LẦN KHÁM";
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(16, 12);
            lblDetailTitle.Size = new Size(310, 26);

            lblDateLabel.Text = "Ngày khám:";
            lblDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateLabel.ForeColor = Color.FromArgb(100, 100, 120);
            lblDateLabel.Location = new Point(16, 48);
            lblDateLabel.AutoSize = true;

            lblDateValue.Text = "---";
            lblDateValue.Font = new Font("Segoe UI", 9.5F);
            lblDateValue.ForeColor = Color.FromArgb(30, 80, 150);
            lblDateValue.Location = new Point(100, 48);
            lblDateValue.AutoSize = true;

            lblDiagLabel.Text = "Chẩn đoán:";
            lblDiagLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiagLabel.ForeColor = Color.FromArgb(100, 100, 120);
            lblDiagLabel.Location = new Point(16, 80);
            lblDiagLabel.AutoSize = true;

            rtbDiagnosis.Location = new Point(16, 100);
            rtbDiagnosis.Size = new Size(314, 90);
            rtbDiagnosis.Font = new Font("Segoe UI", 9.5F);
            rtbDiagnosis.ReadOnly = true;
            rtbDiagnosis.BorderStyle = BorderStyle.FixedSingle;
            rtbDiagnosis.BackColor = Color.White;
            rtbDiagnosis.ScrollBars = RichTextBoxScrollBars.Vertical;

            lblTreatLabel.Text = "Điều trị & Đơn thuốc:";
            lblTreatLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTreatLabel.ForeColor = Color.FromArgb(100, 100, 120);
            lblTreatLabel.Location = new Point(16, 202);
            lblTreatLabel.AutoSize = true;

            rtbTreatment.Location = new Point(16, 222);
            rtbTreatment.Size = new Size(314, 140);
            rtbTreatment.Font = new Font("Segoe UI", 9.5F);
            rtbTreatment.ReadOnly = true;
            rtbTreatment.BorderStyle = BorderStyle.FixedSingle;
            rtbTreatment.BackColor = Color.White;
            rtbTreatment.ScrollBars = RichTextBoxScrollBars.Vertical;

            btnPrint.Text = "🖨  In bệnh án";
            btnPrint.Font = new Font("Segoe UI", 9.5F);
            btnPrint.Location = new Point(16, 378);
            btnPrint.Size = new Size(314, 36);
            btnPrint.BackColor = Color.FromArgb(108, 117, 125);
            btnPrint.ForeColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Cursor = Cursors.Hand;

            // ── USERCONTROL ─────────────────────────────────────────
            Size = new Size(1000, 600);
            BackColor = Color.White;
            Controls.AddRange(new Control[] { pnlMain, pnlLeft, pnlTop });

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlDetail.ResumeLayout(false);
            pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlLeft;
        private Label lblPatientList;
        private TextBox txtSearchPatient;
        private ListBox lstPatients;
        private Panel pnlMain;
        private Panel pnlHeader;
        private Label lblPatientName;
        private Label lblPatientPhone;
        private Label lblPatientRole;
        private Panel pnlContent;
        private DataGridView dgvHistory;
        private Panel pnlDetail;
        private Label lblDetailTitle;
        private Label lblDateLabel;
        private Label lblDateValue;
        private Label lblDiagLabel;
        private RichTextBox rtbDiagnosis;
        private Label lblTreatLabel;
        private RichTextBox rtbTreatment;
        private Button btnPrint;
    }
}