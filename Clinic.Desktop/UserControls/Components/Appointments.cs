using Clinic.Shared.Model;
using Clinic.Desktop.API;
using SharedServices = Clinic.Shared.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Clinic.Desktop.Components
{
    public partial class Appointments : UserControl
    {
        private List<Appointment> _allAppointments = new List<Appointment>();
        private List<User> _patients = new List<User>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<SharedServices> _services = new List<SharedServices>();
        private Appointment _selectedApp = null;

        public Appointments()
        {
            InitializeComponent();

            // Gán sự kiện
            dgvAppointments.CellClick += DgvAppointments_CellClick;
            btnAddNew.Click += (s, e) => ResetForm();
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            dtpFilterDate.ValueChanged += (s, e) => FilterAppointments();

            LoadInitialData();
        }

        private async void LoadInitialData()
        {
            try
            {
                // Load danh sách bệnh nhân (Role 3)
                var users = await ApiClient.GetAsync<List<User>>("api/Users");
                _patients = users?.Where(u => u.RoleID == 3).ToList() ?? new List<User>();
                cboPatient.DataSource = _patients;
                cboPatient.DisplayMember = "FullName";
                cboPatient.ValueMember = "UserID";

                // Load danh sách bác sĩ
                _doctors = await ApiClient.GetAsync<List<Doctor>>("api/Doctors") ?? new List<Doctor>();
                cboDoctor.DataSource = _doctors.Select(d => new {
                    d.DoctorID,
                    Name = d.User?.FullName ?? "BS. Không tên"
                }).ToList();
                cboDoctor.DisplayMember = "Name";
                cboDoctor.ValueMember = "DoctorID";

                // THÊM MỚI: Load danh sách dịch vụ
                _services = await ApiClient.GetAsync<List<SharedServices>>("api/Services") ?? new List<SharedServices>();
                cboService.DataSource = _services;
                cboService.DisplayMember = "ServiceName";
                cboService.ValueMember = "ServiceID";

                await LoadAppointments();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu ban đầu: " + ex.Message);
            }
        }

        private async Task LoadAppointments()
        {
            _allAppointments = await ApiClient.GetAsync<List<Appointment>>("api/Appointments") ?? new List<Appointment>();
            FilterAppointments();
        }

        private void FilterAppointments()
        {
            DateTime filterDate = dtpFilterDate.Value.Date;
            var filtered = _allAppointments
                .OrderByDescending(a => a.AppointmentID)
                .ToList();

            dgvAppointments.Rows.Clear();
            foreach (var app in filtered)
            {
                int n = dgvAppointments.Rows.Add();
                dgvAppointments.Rows[n].Cells["AppointmentID"].Value = app.AppointmentID;
                dgvAppointments.Rows[n].Cells["PatientName"].Value = app.Patient?.FullName ?? "N/A";
                dgvAppointments.Rows[n].Cells["DoctorName"].Value = app.Doctor?.User?.FullName ?? "N/A";
                dgvAppointments.Rows[n].Cells["DichVu"].Value = app.Service?.ServiceName ?? "N/A";
                dgvAppointments.Rows[n].Cells["AppTime"].Value = app.AppointmentDate.ToString("dd/MM HH:mm");
                dgvAppointments.Rows[n].Cells["Status"].Value = app.Status;
                dgvAppointments.Rows[n].Tag = app;

                dgvAppointments.Rows[n].DefaultCellStyle.BackColor = app.Status switch
                {
                    "Pending" => Color.FromArgb(254, 249, 195),
                    "Confirmed" => Color.FromArgb(219, 234, 254),
                    "Examining" => Color.FromArgb(237, 233, 254),
                    "WaitingForPayment" => Color.FromArgb(254, 215, 170),
                    "Completed" => Color.FromArgb(220, 252, 231),
                    "Cancelled" => Color.FromArgb(254, 226, 226),
                    _ => Color.White
                };
            }
        }

        private void DgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedApp = dgvAppointments.Rows[e.RowIndex].Tag as Appointment;
            if (_selectedApp == null) return;

            cboPatient.SelectedValue = _selectedApp.PatientID;
            cboDoctor.SelectedValue = _selectedApp.DoctorID;
            cboService.SelectedValue = _selectedApp.ServiceID;  // THÊM MỚI
            dtpAppointmentDate.Value = _selectedApp.AppointmentDate;
            txtNotes.Text = _selectedApp.Notes;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            cboStatus.Enabled = true;
            cboStatus.Items.Clear();

            switch (_selectedApp.Status)
            {
                case "Pending":
                    cboStatus.Items.AddRange(new string[] { "Pending", "Confirmed", "Cancelled" });
                    cboStatus.SelectedItem = "Pending";
                    btnUpdate.Text = "XÁC NHẬN LỊCH";
                    break;
                case "Confirmed":
                    cboStatus.Items.AddRange(new string[] { "Confirmed", "Examining", "Cancelled" });
                    cboStatus.SelectedItem = "Confirmed";
                    btnUpdate.Text = "TIẾP NHẬN KHÁM";
                    break;
                case "Examining":
                    cboStatus.Items.Add("Examining");
                    cboStatus.SelectedItem = "Examining";
                    cboStatus.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnUpdate.Text = "CẬP NHẬT GHI CHÚ";
                    break;
                case "WaitingForPayment":
                    cboStatus.Items.AddRange(new string[] { "WaitingForPayment", "Completed" });
                    cboStatus.SelectedItem = "WaitingForPayment";
                    btnUpdate.Text = "XÁC NHẬN THANH TOÁN";
                    break;
                default:
                    cboStatus.Items.Add(_selectedApp.Status);
                    cboStatus.SelectedItem = _selectedApp.Status;
                    btnUpdate.Enabled = false;
                    btnUpdate.Text = "HOÀN TẤT/HUỶ";
                    break;
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cboPatient.SelectedValue == null || cboDoctor.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Bệnh nhân và Bác sĩ!");
                return;
            }

            // THÊM MỚI: kiểm tra dịch vụ
            if (cboService.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Dịch vụ!");
                return;
            }

            try
            {
                var app = new Appointment
                {
                    PatientID = Convert.ToInt32(cboPatient.SelectedValue),
                    DoctorID = Convert.ToInt32(cboDoctor.SelectedValue),
                    ServiceID = Convert.ToInt32(cboService.SelectedValue),  // SỬA: thay vì = 1
                    AppointmentDate = dtpAppointmentDate.Value,
                    Status = "Pending",
                    Notes = txtNotes.Text
                };

                var result = await ApiClient.PostAsync<Appointment>("api/Appointments", app);
                if (result != null)
                {
                    MessageBox.Show("Đã lưu lịch hẹn mới thành công!");
                    await LoadAppointments();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedApp == null)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn!");
                return;
            }

            if (cboPatient.SelectedValue == null || cboDoctor.SelectedValue == null)
            {
                MessageBox.Show("Dữ liệu Bệnh nhân/Bác sĩ không hợp lệ!");
                return;
            }

            string newStatus = cboStatus.SelectedItem?.ToString();

            if (btnUpdate.Text == "TIẾP NHẬN KHÁM") newStatus = "Examining";
            if (btnUpdate.Text == "XÁC NHẬN LỊCH") newStatus = "Confirmed";

            bool isCompletingPayment = (_selectedApp.Status == "WaitingForPayment" && newStatus == "Completed");

            try
            {
                var app = new Appointment
                {
                    AppointmentID = _selectedApp.AppointmentID,
                    PatientID = Convert.ToInt32(cboPatient.SelectedValue),
                    DoctorID = Convert.ToInt32(cboDoctor.SelectedValue),
                    ServiceID = Convert.ToInt32(cboService.SelectedValue),  // SỬA: thay vì _selectedApp.ServiceID
                    AppointmentDate = dtpAppointmentDate.Value,
                    Status = newStatus,
                    Notes = txtNotes.Text
                };

                await ApiClient.PutAsync<Appointment>($"api/Appointments/{_selectedApp.AppointmentID}", app);
                await ApiClient.PutAsync<object>($"api/Appointments/status/{_selectedApp.AppointmentID}", new { Status = newStatus });

                if (isCompletingPayment)
                {
                    var invoice = new Invoice
                    {
                        AppointmentID = _selectedApp.AppointmentID,
                        TotalAmount = (decimal)(_selectedApp.Service?.Price ?? 0),
                        Status = "Paid",
                        PaymentDate = DateTime.Now
                    };
                    await ApiClient.PostAsync<Invoice>("api/Invoices", invoice);
                    MessageBox.Show("Đã thanh toán và tạo hóa đơn!");
                }
                else
                {
                    MessageBox.Show($"Thành công: {btnUpdate.Text}");
                }

                await LoadAppointments();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedApp == null) return;

            if (new[] { "Examining", "WaitingForPayment", "Completed" }.Contains(_selectedApp.Status))
            {
                MessageBox.Show("Không thể xóa lịch hẹn đã hoặc đang thực hiện!");
                return;
            }

            if (MessageBox.Show("Xác nhận xóa lịch hẹn này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var ok = await ApiClient.DeleteAsync($"api/Appointments/{_selectedApp.AppointmentID}");
                if (ok)
                {
                    await LoadAppointments();
                    ResetForm();
                }
            }
        }

        private void ResetForm()
        {
            _selectedApp = null;
            dgvAppointments.ClearSelection();
            txtNotes.Text = string.Empty;
            dtpAppointmentDate.Value = DateTime.Now;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnUpdate.Text = "CẬP NHẬT";

            cboStatus.Enabled = true;
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Pending");
            cboStatus.SelectedIndex = 0;

            // THÊM MỚI: reset về dịch vụ đầu tiên
            if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
        }
    }
}