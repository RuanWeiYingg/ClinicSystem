using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Desktop.View;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.DoctorSchedule
{
    public partial class MySchedule : UserControl
    {
        private int _doctorId;
        private int _selectedAppId = 0;
        private int _selectedPatientId = 0;

        public MySchedule(int doctorId = 0)
        {
            InitializeComponent();
            _doctorId = doctorId;

            // Đăng ký sự kiện cho các điều khiển lọc
            btnRefresh.Click += async (s, e) => await LoadSchedule();
            dtpScheduleDate.ValueChanged += async (s, e) => await LoadSchedule();
            cboStatusFilter.SelectedIndexChanged += async (s, e) => await LoadSchedule();

            // Sự kiện các nút chức năng
            btnStartExam.Click += BtnStartExam_Click;
            btnFinishExam.Click += BtnFinishExam_Click;

            SetupFilterComboBox();
            SetupGrid();

            this.Load += async (s, e) => {
                if (_doctorId > 0) await LoadSchedule();
            };

            // Theo dõi dòng được chọn để lấy ID và cập nhật trạng thái nút
            dgvSchedule.SelectionChanged += DgvSchedule_SelectionChanged;
        }

        private void SetupFilterComboBox()
        {
            cboStatusFilter.Items.Clear();
            cboStatusFilter.Items.AddRange(new object[]
            {
                "Tất cả",
                "Sẵn sàng khám", 
                "Đang khám",     
                "Chờ thanh toán" 
            });
            cboStatusFilter.SelectedIndex = 0;
        }

        private void SetupGrid()
        {
            dgvSchedule.AutoGenerateColumns = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.BorderStyle = BorderStyle.None;

            dgvSchedule.Columns.Clear();
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "AppID", DataPropertyName = "AppID", HeaderText = "Mã số", Width = 60 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ThoiGian", DataPropertyName = "ThoiGian", HeaderText = "Giờ khám", Width = 90 });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "BenhNhan", DataPropertyName = "BenhNhan", HeaderText = "Bệnh nhân" });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "LyDo", DataPropertyName = "LyDo", HeaderText = "Lý do khám" });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "TrangThai", DataPropertyName = "TrangThai", HeaderText = "Trạng thái", Width = 130 });

            // Cột ẩn dùng để xử lý logic
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientID", DataPropertyName = "PatientID", Visible = false });
            dgvSchedule.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "RawStatus", DataPropertyName = "RawStatus", Visible = false });
        }

        private async Task LoadSchedule()
        {
            try
            {
                if (_doctorId <= 0) return;

                string selectedDate = dtpScheduleDate.Value.ToString("yyyy-MM-dd");
                string statusFilter = cboStatusFilter.SelectedItem?.ToString() switch
                {
                    "Sẵn sàng khám" => "Confirmed",
                    "Đang khám" => "Examining",
                    "Chờ thanh toán" => "WaitingForPayment",
                    _ => "All"
                };

                string endpoint = $"api/Appointments/doctor/{_doctorId}?date={selectedDate}";
                var appointments = await ApiClient.GetAsync<List<Appointment>>(endpoint);

                if (appointments == null)
                {
                    dgvSchedule.DataSource = null;
                    UpdateButtonStates(null);
                    return;
                }

                var filteredData = appointments
                    .Where(a => a.Status != "Pending" && a.Status != "Cancelled")
                    .Where(a => statusFilter == "All" || a.Status == statusFilter)
                    .OrderBy(a => a.AppointmentDate)
                    .Select(a => new
                    {
                        AppID = a.AppointmentID,
                        ThoiGian = a.AppointmentDate.ToString("HH:mm"),
                        BenhNhan = a.Patient?.FullName ?? "N/A",
                        PatientID = a.PatientID,
                        LyDo = a.Notes ?? "Không có ghi chú",
                        TrangThai = TranslateStatus(a.Status),
                        RawStatus = a.Status
                    }).ToList();

                dgvSchedule.DataSource = filteredData;

                // Cập nhật màu sắc dòng dựa trên trạng thái
                foreach (DataGridViewRow row in dgvSchedule.Rows)
                {
                    string raw = row.Cells["RawStatus"].Value?.ToString();
                    row.DefaultCellStyle.BackColor = raw switch
                    {
                        "Confirmed" => Color.FromArgb(219, 234, 254), 
                        "Examining" => Color.FromArgb(237, 233, 254), 
                        "WaitingForPayment" => Color.FromArgb(254, 215, 170), 
                        "Completed" => Color.FromArgb(220, 252, 231), 
                        _ => Color.White
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch khám: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvSchedule_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count == 0)
            {
                _selectedAppId = 0;
                _selectedPatientId = 0;
                UpdateButtonStates(null);
                return;
            }

            var row = dgvSchedule.SelectedRows[0];
            _selectedAppId = Convert.ToInt32(row.Cells["AppID"].Value);
            _selectedPatientId = Convert.ToInt32(row.Cells["PatientID"].Value);
            string rawStatus = row.Cells["RawStatus"].Value?.ToString();

            UpdateButtonStates(rawStatus);
        }

        // --- ĐÂY LÀ PHẦN FIX CHÍNH ---
        private void UpdateButtonStates(string rawStatus)
        {
            // Trạng thái 'Confirmed' (Sẵn sàng): Hiện "Bắt đầu khám"
            if (rawStatus == "Confirmed")
            {
                btnStartExam.Text = "Bắt đầu khám";
                btnStartExam.Enabled = true;
                btnStartExam.BackColor = Color.ForestGreen;
                btnStartExam.ForeColor = Color.White;
            }
            // Trạng thái 'Examining' (Đang khám): Hiện "Tiếp tục khám" (Xử lý mất điện/tắt app)
            else if (rawStatus == "Examining")
            {
                btnStartExam.Text = "Tiếp tục khám";
                btnStartExam.Enabled = true; // KHÔNG bị disable nữa
                btnStartExam.BackColor = Color.DarkOrange; 
                btnStartExam.ForeColor = Color.White;
            }
            // Các trạng thái khác: Khóa nút
            else
            {
                btnStartExam.Text = "Bắt đầu khám";
                btnStartExam.Enabled = false;
                btnStartExam.BackColor = Color.LightGray;
                btnStartExam.ForeColor = Color.DimGray;
            }

            // Nút Hoàn tất chỉ sáng khi trạng thái là Đang khám
            btnFinishExam.Enabled = (rawStatus == "Examining");
        }

        private string TranslateStatus(string status) => status switch
        {
            "Confirmed" => "Sẵn sàng khám",
            "Examining" => "Đang khám",
            "WaitingForPayment" => "Chờ thanh toán",
            "Completed" => "Hoàn tất",
            "Cancelled" => "Đã hủy",
            _ => "Không xác định"
        };

        // --- ĐÂY LÀ PHẦN FIX CHÍNH ---
        private async void BtnStartExam_Click(object sender, EventArgs e)
        {
            if (_selectedAppId <= 0) return;

            var row = dgvSchedule.SelectedRows[0];
            string rawStatus = row.Cells["RawStatus"].Value?.ToString();
            string patientName = row.Cells["BenhNhan"].Value?.ToString();

            try
            {
                // 1. Nếu là ca mới tinh thì mới cần xác nhận và cập nhật DB
                if (rawStatus == "Confirmed")
                {
                    var confirm = MessageBox.Show($"Bắt đầu khám cho bệnh nhân: {patientName}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm != DialogResult.Yes) return;

                    // Cập nhật trạng thái sang Đang khám trên Server
                    await ApiClient.PutAsync<object>($"api/Appointments/status/{_selectedAppId}", new { Status = "Examining" });
                }

                // 2. Chuyển sang trang khám bệnh (Dù là Bắt đầu mới hay Tiếp tục ca cũ)
                Form parentForm = this.FindForm();
                if (parentForm is DoctorHome doctorHome)
                {
                    // Truyền ID sang trang Examination để bác sĩ làm việc tiếp
                    doctorHome.LoadDoctorView(6, "Tiến hành khám bệnh", _selectedAppId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void BtnFinishExam_Click(object sender, EventArgs e)
        {
            if (_selectedAppId <= 0) return;

            var confirm = MessageBox.Show("Hoàn tất ca khám này và chuyển hồ sơ sang bộ phận thanh toán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await ApiClient.PutAsync<object>($"api/Appointments/status/{_selectedAppId}", new { Status = "WaitingForPayment" });

                var invoice = new Invoice
                {
                    AppointmentID = _selectedAppId,
                    TotalAmount = 0,
                    Status = "Unpaid"
                };
                await ApiClient.PostAsync<Invoice>("api/Invoices", invoice);

                MessageBox.Show("Đã chuyển hồ sơ sang bộ phận thu ngân.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadSchedule();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}