using Clinic.Shared.Model;
using Clinic.Desktop.API;
using Clinic.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Desktop.Components
{
    public partial class Patients : UserControl
    {
        private List<User> _allPatients = new List<User>();
        private User _selectedPatient = null;

        public Patients()
        {
            InitializeComponent();

            btnAdd.Click += async (s, e) => await HandleAdd();
            btnUpdate.Click += async (s, e) => await HandleUpdate();
            btnDelete.Click += async (s, e) => await HandleDelete();

            dgvPatients.CellClick += DgvPatients_CellClick;
            txtSearch.TextChanged += (s, e) => FilterGrid();

            // Chỉ nhận số ở ô SĐT
            txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            this.Load += async (s, e) => await LoadData();
        }

        // ── TẢI DỮ LIỆU ────────────────────────────────────────────
        private async Task LoadData()
        {
            try
            {
                var users = await ApiClient.GetAsync<List<User>>("api/Users");
                _allPatients = users?.Where(u => u.RoleID == 3).ToList()
                               ?? new List<User>();
                BindGrid(_allPatients);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<User> list)
        {
            dgvPatients.DataSource = null;
            dgvPatients.DataSource = list;
        }

        // ── TÌM KIẾM ───────────────────────────────────────────────
        private void FilterGrid()
        {
            string kw = txtSearch.Text.ToLower().Trim();
            var filtered = _allPatients.Where(p =>
                (p.FullName != null && p.FullName.ToLower().Contains(kw)) ||
                (p.PhoneNumber != null && p.PhoneNumber.Contains(kw))
            ).ToList();
            BindGrid(filtered);
        }

        // ── CHỌN DÒNG ──────────────────────────────────────────────
        private void DgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedPatient = dgvPatients.Rows[e.RowIndex].DataBoundItem as User;
            if (_selectedPatient == null) return;

            txtName.Text = _selectedPatient.FullName ?? "";
            txtPhone.Text = _selectedPatient.PhoneNumber ?? "";
            txtEmail.Text = _selectedPatient.Email ?? "";
        }

        // ── VALIDATION ─────────────────────────────────────────────
        private List<string> ValidateForm(bool isNew)
        {
            var errors = new List<string>();

            ClinicValidator.ValidateFullName(txtName.Text, errors, "Họ và tên");
            ClinicValidator.ValidatePhone(txtPhone.Text, errors);
            ClinicValidator.ValidateEmail(txtEmail.Text, errors, required: false);

            // SĐT trùng — chỉ kiểm tra khi thêm mới, hoặc khi update mà đổi SĐT
            string phone = txtPhone.Text.Trim();
            if (errors.Count == 0) // chỉ check trùng khi format đã hợp lệ
            {
                bool isDuplicate = isNew
                    ? _allPatients.Any(p => p.PhoneNumber == phone)
                    : _allPatients.Any(p => p.PhoneNumber == phone
                                         && p.UserID != _selectedPatient?.UserID);
                if (isDuplicate)
                    errors.Add("• Số điện thoại này đã được đăng ký cho bệnh nhân khác.");
            }

            return errors;
        }

        // ── THÊM MỚI ───────────────────────────────────────────────
        private async Task HandleAdd()
        {
            var errors = ValidateForm(isNew: true);
            if (ClinicValidator.ShowErrors(errors)) return;

            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            var newUser = new User
            {
                FullName = txtName.Text.Trim(),
                PhoneNumber = phone,
                Email = string.IsNullOrWhiteSpace(email)
                                    ? $"{phone}@clinic.local"
                                    : email,
                RoleID = 3,
                Username = phone,
                PasswordHash = phone,
                CreatedAt = DateTime.Now
            };

            try
            {
                var result = await ApiClient.PostAsync<User>("api/Users", newUser);
                if (result != null)
                {
                    MessageBox.Show(
                        $"✅ Thêm bệnh nhân thành công!\n" +
                        $"Username / Mật khẩu mặc định: {phone}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    await LoadData();
                }
                else
                {
                    MessageBox.Show("API không phản hồi. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm bệnh nhân:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── CẬP NHẬT ───────────────────────────────────────────────
        private async Task HandleUpdate()
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần cập nhật!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var errors = ValidateForm(isNew: false);
            if (ClinicValidator.ShowErrors(errors)) return;

            // Kiểm tra có thay đổi gì không
            string newName = txtName.Text.Trim();
            string newPhone = txtPhone.Text.Trim();
            string newEmail = txtEmail.Text.Trim();

            bool noChange = _selectedPatient.FullName == newName
                         && _selectedPatient.PhoneNumber == newPhone
                         && (_selectedPatient.Email ?? "") == newEmail;

            if (noChange)
            {
                MessageBox.Show("Không có thông tin nào thay đổi.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _selectedPatient.FullName = newName;
            _selectedPatient.PhoneNumber = newPhone;
            _selectedPatient.Email = string.IsNullOrWhiteSpace(newEmail)
                                               ? _selectedPatient.Email
                                               : newEmail;

            try
            {
                bool ok = await ApiClient.PutVoidAsync(
                    $"api/Users/{_selectedPatient.UserID}", _selectedPatient);

                if (ok)
                {
                    MessageBox.Show("✅ Cập nhật thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── XÓA ────────────────────────────────────────────────────
        private async Task HandleDelete()
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận xóa bệnh nhân:\n\"{_selectedPatient.FullName}\" — SĐT: {_selectedPatient.PhoneNumber}\n\n" +
                "Lưu ý: toàn bộ lịch hẹn liên quan có thể bị ảnh hưởng.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = await ApiClient.DeleteAsync($"api/Users/{_selectedPatient.UserID}");
                if (ok)
                {
                    MessageBox.Show("🗑 Đã xóa bệnh nhân!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    await LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công. API có thể từ chối do ràng buộc dữ liệu.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── RESET FORM ──────────────────────────────────────────────
        private void ClearFields()
        {
            _selectedPatient = null;
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            dgvPatients.ClearSelection();
            txtName.Focus();
        }
    }
}