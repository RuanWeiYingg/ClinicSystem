using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Clinic.Shared.Model;
using Clinic.Desktop.API;
using Clinic.Desktop.View;

namespace Clinic.Desktop.UserControls.DoctorSchedule
{
    public partial class Examination : UserControl
    {
        private readonly int _appointmentId;
        private int _patientId;
        private int? _existingRecordId = null;
        private Appointment _currentApp = null; // FIX: lưu app để dùng khi tạo hóa đơn

        public Examination(int appointmentId)
        {
            InitializeComponent();
            _appointmentId = appointmentId;

            btnFinishExam.Click += BtnFinishExam_Click;
            this.Load += async (s, e) => await LoadAppointmentDetails();
        }

        private async Task LoadAppointmentDetails()
        {
            try
            {
                var app = await ApiClient.GetAsync<Appointment>($"api/Appointments/{_appointmentId}");

                if (app != null)
                {
                    _currentApp = app; // FIX: lưu lại để BtnFinishExam_Click dùng
                    _patientId = app.PatientID;

                    lblPatientName.Text = app.Patient?.FullName ?? "N/A";
                    lblPatientPhone.Text = app.Patient?.PhoneNumber ?? "N/A";
                    lblService.Text = app.Service?.ServiceName ?? "Dịch vụ tổng quát";
                    lblAppointmentTime.Text = app.AppointmentDate.ToString("HH:mm - dd/MM/yyyy");
                    txtSymptoms.Text = app.Notes;

                    // Kiểm tra dữ liệu nháp cũ
                    var existingRecord = await ApiClient.GetAsync<MedicalRecord>(
                        $"api/MedicalRecords/by-appointment/{_appointmentId}",
                        false
                    );

                    if (existingRecord != null)
                    {
                        _existingRecordId = existingRecord.RecordID;
                        txtSymptoms.Text = existingRecord.Symptoms;
                        txtDiagnosis.Text = existingRecord.Diagnosis;
                        txtTreatment.Text = existingRecord.TreatmentPlan;
                        txtPrescription.Text = existingRecord.Prescription;
                        Console.WriteLine("Hệ thống: Đã khôi phục dữ liệu nháp cho ca khám này.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý giao diện: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnFinishExam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Bác sĩ bắt buộc phải nhập Chẩn đoán trước khi hoàn tất!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiagnosis.Focus();
                return;
            }

            // FIX: Hiển thị giá dịch vụ trong hộp xác nhận để bác sĩ biết
            decimal servicePrice = (decimal)(_currentApp?.Service?.Price ?? 0);
            string serviceName = _currentApp?.Service?.ServiceName ?? "Dịch vụ tổng quát";
            string confirmMsg = $"Xác nhận HOÀN TẤT ca khám?\n\n" +
                                $"Dịch vụ: {serviceName}\n" +
                                $"Số tiền hóa đơn: {servicePrice:N0} VNĐ\n\n" +
                                $"Hệ thống sẽ lưu bệnh án và tạo hóa đơn chờ thanh toán.";

            var confirm = MessageBox.Show(confirmMsg, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            btnFinishExam.Enabled = false;

            try
            {
                // 1. Lưu bệnh án
                var medicalRecord = new MedicalRecord
                {
                    RecordID = _existingRecordId ?? 0,
                    PatientID = _patientId,
                    AppointmentID = _appointmentId,
                    Diagnosis = txtDiagnosis.Text,
                    Symptoms = txtSymptoms.Text,
                    TreatmentPlan = txtTreatment.Text,
                    Prescription = txtPrescription.Text,
                    DateCreated = DateTime.Now
                };

                if (_existingRecordId == null)
                    await ApiClient.PostAsync<MedicalRecord>("api/MedicalRecords", medicalRecord);
                else
                    await ApiClient.PutAsync<MedicalRecord>(
                        $"api/MedicalRecords/{_existingRecordId}", medicalRecord);

                // 2. Cập nhật trạng thái lịch hẹn → WaitingForPayment
                await ApiClient.PutVoidAsync(
                    $"api/Appointments/status/{_appointmentId}",
                    new { Status = "WaitingForPayment" });

                // 3. FIX: Tạo hóa đơn với giá từ Service, không phải 0
                var invoice = new Invoice
                {
                    AppointmentID = _appointmentId,
                    TotalAmount = servicePrice, // FIX: lấy từ Service.Price
                    Status = "Unpaid",
                    PaymentDate = DateTime.Now
                };
                await ApiClient.PostAsync<Invoice>("api/Invoices", invoice);

                MessageBox.Show(
                    $"Lưu kết quả khám thành công!\nHóa đơn {servicePrice:N0} VNĐ đã được tạo.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Quay lại màn hình danh sách
                if (this.FindForm() is DoctorHome doctorHome)
                    doctorHome.LoadDoctorView(0, "Lịch khám hôm nay");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình hoàn tất: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnFinishExam.Enabled = true;
            }
        }
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            if (btnFinishExam != null)
                btnFinishExam.Left = pnlBottom.Width - btnFinishExam.Width - 16;
        }
    }
}