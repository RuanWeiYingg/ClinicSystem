using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.UserControls.DoctorSchedule
{
    public partial class Patients : UserControl
    {
        private int _doctorId;

        public Patients(int doctorId = 0)
        {
            
            InitializeComponent();

            this._doctorId = doctorId;

            // Đăng ký các sự kiện xử lý
            this.btnSearch.Click += async (s, e) => await LoadPatientList(txtSearch.Text.Trim());
            this.dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;

            // Thiết lập ban đầu cho Grid
            SetupGrid();

            // Tự động tải dữ liệu khi mở tab
            this.Load += async (s, e) => await LoadPatientList();
        }

        private void SetupGrid()
        {
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.ReadOnly = true;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Xóa cột cũ nếu có và thêm cột mới để khớp với dữ liệu User
            dgvPatients.Columns.Clear();
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "UserID", Name = "UserID", Width = 50 });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ Tên", DataPropertyName = "FullName", Name = "FullName" });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SĐT", DataPropertyName = "PhoneNumber", Name = "PhoneNumber" });
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", Name = "Email" });
        }

        private async Task LoadPatientList(string keyword = "")
        {
            try
            {
                // Gọi API lấy danh sách bệnh nhân của bác sĩ
                string endpoint = $"api/Users/doctor/{_doctorId}";
                if (!string.IsNullOrEmpty(keyword))
                    endpoint += $"?search={Uri.EscapeDataString(keyword)}";

                var users = await ApiClient.GetAsync<List<User>>(endpoint);
                if (users != null)
                {
                    dgvPatients.DataSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách bệnh nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            // Khi chọn một bệnh nhân trên Grid, hiển thị thông tin tóm tắt bên phải
            if (dgvPatients.CurrentRow != null && dgvPatients.CurrentRow.DataBoundItem is User user)
            {
                txtBloodGroup.Text = "O+"; // Ví dụ, sau này bác lấy từ API MedicalRecord
                txtAllergy.Text = "Không có";
                rtbNotes.Text = $"Thông tin chi tiết:\n- Họ tên: {user.FullName}\n- Email: {user.Email}\n- Số điện thoại: {user.PhoneNumber}\n\nLịch sử khám gần nhất: 20/03/2026";
            }
        }
    }
}