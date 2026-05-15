using System.Drawing;
using System.Windows.Forms;

namespace Clinic.Desktop.UserControls.DoctorSchedule
{
    partial class Examination
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            pnlPatientInfo = new Panel();
            pnlExamForm = new Panel();
            pnlBottom = new Panel();
            lblTitle = new Label();
            lblPatientLabel = new Label();
            lblPatientName = new Label();
            lblPhoneLabel = new Label();
            lblPatientPhone = new Label();
            lblServiceLabel = new Label();
            lblService = new Label();
            lblTimeLabel = new Label();
            lblAppointmentTime = new Label();
            lblSymptomsLabel = new Label();
            txtSymptoms = new TextBox();
            lblDiagnosisLabel = new Label();
            txtDiagnosis = new TextBox();
            lblTreatmentLabel = new Label();
            txtTreatment = new TextBox();
            lblPrescriptionLabel = new Label();
            txtPrescription = new TextBox();
            btnFinishExam = new Button();

            SuspendLayout();

            // ── lblTitle ──────────────────────────────────
            lblTitle.Text = "PHIẾU KHÁM BỆNH";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(500, 60);
            lblTitle.Location = new Point(20, 0);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            // ── pnlHeader ─────────────────────────────────
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
            pnlHeader.Controls.Add(lblTitle);

            // ── Patient Info Labels ────────────────────────
            lblPatientLabel.Text = "Bệnh nhân:";
            lblPatientLabel.Font = new Font("Segoe UI", 9F);
            lblPatientLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblPatientLabel.Location = new Point(20, 10);
            lblPatientLabel.AutoSize = true;

            lblPatientName.Text = "---";
            lblPatientName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(17, 24, 39);
            lblPatientName.Location = new Point(20, 28);
            lblPatientName.AutoSize = true;

            lblPhoneLabel.Text = "Số điện thoại:";
            lblPhoneLabel.Font = new Font("Segoe UI", 9F);
            lblPhoneLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblPhoneLabel.Location = new Point(220, 10);
            lblPhoneLabel.AutoSize = true;

            lblPatientPhone.Text = "---";
            lblPatientPhone.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPatientPhone.ForeColor = Color.FromArgb(37, 99, 235);
            lblPatientPhone.Location = new Point(220, 28);
            lblPatientPhone.AutoSize = true;

            lblServiceLabel.Text = "Dịch vụ:";
            lblServiceLabel.Font = new Font("Segoe UI", 9F);
            lblServiceLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblServiceLabel.Location = new Point(420, 10);
            lblServiceLabel.AutoSize = true;

            lblService.Text = "---";
            lblService.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblService.ForeColor = Color.FromArgb(17, 24, 39);
            lblService.Location = new Point(420, 28);
            lblService.AutoSize = true;

            lblTimeLabel.Text = "Thời gian:";
            lblTimeLabel.Font = new Font("Segoe UI", 9F);
            lblTimeLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblTimeLabel.Location = new Point(620, 10);
            lblTimeLabel.AutoSize = true;

            lblAppointmentTime.Text = "---";
            lblAppointmentTime.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAppointmentTime.ForeColor = Color.FromArgb(17, 24, 39);
            lblAppointmentTime.Location = new Point(620, 28);
            lblAppointmentTime.AutoSize = true;

            // ── pnlPatientInfo ────────────────────────────
            pnlPatientInfo.Dock = DockStyle.Top;
            pnlPatientInfo.Height = 80;
            pnlPatientInfo.BackColor = Color.White;
            pnlPatientInfo.Controls.Add(lblPatientLabel);
            pnlPatientInfo.Controls.Add(lblPatientName);
            pnlPatientInfo.Controls.Add(lblPhoneLabel);
            pnlPatientInfo.Controls.Add(lblPatientPhone);
            pnlPatientInfo.Controls.Add(lblServiceLabel);
            pnlPatientInfo.Controls.Add(lblService);
            pnlPatientInfo.Controls.Add(lblTimeLabel);
            pnlPatientInfo.Controls.Add(lblAppointmentTime);

            // ── Exam Form Fields ──────────────────────────
            lblSymptomsLabel.Text = "Triệu chứng / Lý do khám:";
            lblSymptomsLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSymptomsLabel.ForeColor = Color.FromArgb(55, 65, 81);
            lblSymptomsLabel.Location = new Point(20, 10);
            lblSymptomsLabel.AutoSize = true;

            txtSymptoms.Location = new Point(20, 30);
            txtSymptoms.Size = new Size(900, 60);
            txtSymptoms.Multiline = true;
            txtSymptoms.Font = new Font("Segoe UI", 10F);
            txtSymptoms.BorderStyle = BorderStyle.FixedSingle;
            txtSymptoms.BackColor = Color.FromArgb(249, 250, 251);
            txtSymptoms.PlaceholderText = "Nhập triệu chứng bệnh nhân mô tả...";
            txtSymptoms.ScrollBars = ScrollBars.Vertical;

            lblDiagnosisLabel.Text = "Chẩn đoán: *";
            lblDiagnosisLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiagnosisLabel.ForeColor = Color.FromArgb(185, 28, 28);
            lblDiagnosisLabel.Location = new Point(20, 105);
            lblDiagnosisLabel.AutoSize = true;

            txtDiagnosis.Location = new Point(20, 125);
            txtDiagnosis.Size = new Size(900, 70);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Font = new Font("Segoe UI", 10F);
            txtDiagnosis.BorderStyle = BorderStyle.FixedSingle;
            txtDiagnosis.BackColor = Color.FromArgb(249, 250, 251);
            txtDiagnosis.PlaceholderText = "Nhập chẩn đoán của bác sĩ...";
            txtDiagnosis.ScrollBars = ScrollBars.Vertical;

            lblTreatmentLabel.Text = "Phác đồ điều trị:";
            lblTreatmentLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTreatmentLabel.ForeColor = Color.FromArgb(55, 65, 81);
            lblTreatmentLabel.Location = new Point(20, 210);
            lblTreatmentLabel.AutoSize = true;

            txtTreatment.Location = new Point(20, 230);
            txtTreatment.Size = new Size(900, 70);
            txtTreatment.Multiline = true;
            txtTreatment.Font = new Font("Segoe UI", 10F);
            txtTreatment.BorderStyle = BorderStyle.FixedSingle;
            txtTreatment.BackColor = Color.FromArgb(249, 250, 251);
            txtTreatment.PlaceholderText = "Nhập phác đồ điều trị...";
            txtTreatment.ScrollBars = ScrollBars.Vertical;

            lblPrescriptionLabel.Text = "Đơn thuốc:";
            lblPrescriptionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrescriptionLabel.ForeColor = Color.FromArgb(55, 65, 81);
            lblPrescriptionLabel.Location = new Point(20, 315);
            lblPrescriptionLabel.AutoSize = true;

            txtPrescription.Location = new Point(20, 335);
            txtPrescription.Size = new Size(900, 80);
            txtPrescription.Multiline = true;
            txtPrescription.Font = new Font("Segoe UI", 10F);
            txtPrescription.BorderStyle = BorderStyle.FixedSingle;
            txtPrescription.BackColor = Color.FromArgb(249, 250, 251);
            txtPrescription.PlaceholderText = "Nhập tên thuốc, liều lượng, cách dùng...";
            txtPrescription.ScrollBars = ScrollBars.Vertical;

            // ── pnlExamForm ───────────────────────────────
            pnlExamForm.Dock = DockStyle.Fill;
            pnlExamForm.BackColor = Color.White;
            pnlExamForm.Padding = new Padding(20, 10, 20, 10);
            pnlExamForm.AutoScroll = true;
            pnlExamForm.Controls.Add(lblSymptomsLabel);
            pnlExamForm.Controls.Add(txtSymptoms);
            pnlExamForm.Controls.Add(lblDiagnosisLabel);
            pnlExamForm.Controls.Add(txtDiagnosis);
            pnlExamForm.Controls.Add(lblTreatmentLabel);
            pnlExamForm.Controls.Add(txtTreatment);
            pnlExamForm.Controls.Add(lblPrescriptionLabel);
            pnlExamForm.Controls.Add(txtPrescription);

            // ── btnFinishExam ─────────────────────────────
            btnFinishExam.Text = "HOÀN TẤT KHÁM & TẠO HÓA ĐƠN";
            btnFinishExam.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFinishExam.BackColor = Color.FromArgb(34, 197, 94);
            btnFinishExam.ForeColor = Color.White;
            btnFinishExam.FlatStyle = FlatStyle.Flat;
            btnFinishExam.Size = new Size(320, 40);
            btnFinishExam.Location = new Point(600, 10);

            // ── pnlBottom ─────────────────────────────────
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 60;
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(btnFinishExam);

            // ── Assemble UserControl ──────────────────────
            Controls.Add(pnlExamForm);
            Controls.Add(pnlPatientInfo);
            Controls.Add(pnlHeader);
            Controls.Add(pnlBottom);

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 244, 246);
            Name = "Examination";
            Size = new Size(960, 600);

            ResumeLayout(false);
        }

        private Panel pnlHeader, pnlPatientInfo, pnlExamForm, pnlBottom;
        private Label lblTitle;
        private Label lblPatientLabel, lblPatientName;
        private Label lblPhoneLabel, lblPatientPhone;
        private Label lblServiceLabel, lblService;
        private Label lblTimeLabel, lblAppointmentTime;
        private Label lblSymptomsLabel, lblDiagnosisLabel;
        private Label lblTreatmentLabel, lblPrescriptionLabel;
        private TextBox txtSymptoms, txtDiagnosis, txtTreatment, txtPrescription;
        private Button btnFinishExam;
    }
}