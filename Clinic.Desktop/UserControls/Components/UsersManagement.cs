using Clinic.Shared.Model;
using Clinic.Desktop.API;
using Clinic.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Desktop.UserControls.Components
{
    public partial class UsersManagement : UserControl
    {
        private List<User> _usersList = new List<User>();
        private User _selectedUser = null;

        private readonly Dictionary<string, int> _roleMap = new()
        {
            { "Quản trị viên", 1 },
            { "Bác sĩ",        2 },
            { "Bệnh nhân",     3 }
        };

        private readonly Dictionary<int, string> _roleNameMap = new()
        {
            { 1, "Quản trị viên" },
            { 2, "Bác sĩ" },
            { 3, "Bệnh nhân" }
        };

        public UsersManagement()
        {
            InitializeComponent();
            SetupDataGridView();
            RegisterEvents();
        }

        // ── CẤU HÌNH GRID ───────────────────────────────────────────
        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "UserID", DataPropertyName = "UserID", HeaderText = "ID", Width = 50 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "FullName", DataPropertyName = "FullName", HeaderText = "Họ và Tên", FillWeight = 150 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Username", DataPropertyName = "Username", HeaderText = "Tên đăng nhập", Width = 140 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Role", DataPropertyName = "RoleID", HeaderText = "Quyền (ID)", Width = 100 });

            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
        }

        // ── ĐĂNG KÝ SỰ KIỆN ─────────────────────────────────────────
        private void RegisterEvents()
        {
            this.Load += async (s, e) => await LoadData();
            dgvUsers.CellClick += DgvUsers_CellClick;
            btnNew.Click += (s, e) => ResetForm();
            btnSave.Click += async (s, e) => await HandleSave();
            btnClear.Click += (s, e) => ResetForm();
            btnDelete.Click += async (s, e) => await HandleDelete();

            cboRole.Items.Clear();
            foreach (var key in _roleMap.Keys)
                cboRole.Items.Add(key);
            cboRole.SelectedIndex = 0;
        }

        // ── TẢI DỮ LIỆU ─────────────────────────────────────────────
        private async Task LoadData()
        {
            try
            {
                var response = await ApiClient.GetAsync<List<User>>("api/Users");
                _usersList = response ?? new List<User>();
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = _usersList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── CHỌN DÒNG ───────────────────────────────────────────────
        private void DgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedUser = dgvUsers.Rows[e.RowIndex].DataBoundItem as User;
            if (_selectedUser == null) return;

            txtFullName.Text = _selectedUser.FullName ?? "";
            txtUsername.Text = _selectedUser.Username ?? "";
            txtUsername.ReadOnly = true; // Username không được đổi sau khi tạo
            txtPassword.Clear();
            txtPassword.PlaceholderText = "(Để trống nếu không đổi mật khẩu)";

            if (_roleNameMap.TryGetValue(_selectedUser.RoleID, out string roleName))
                cboRole.SelectedItem = roleName;

            btnSave.Text = "💾  CẬP NHẬT TÀI KHOẢN";
            btnSave.BackColor = Color.FromArgb(255, 140, 0);
        }

        // ── VALIDATION ──────────────────────────────────────────────
        private List<string> ValidateForm(bool isNew)
        {
            var errors = new List<string>();

            // 1. Họ tên
            ClinicValidator.ValidateFullName(txtFullName.Text, errors);

            // 2. Tên đăng nhập
            ClinicValidator.ValidateUsername(txtUsername.Text, errors);

            // 3. Mật khẩu — bắt buộc khi tạo mới, tuỳ chọn khi cập nhật
            ClinicValidator.ValidatePassword(txtPassword.Text, errors,
                required: isNew);

            // 4. Username trùng — chỉ kiểm tra khi thêm mới
            if (isNew && errors.Count == 0)
            {
                string uname = txtUsername.Text.Trim().ToLower();
                bool duplicate = _usersList.Any(u =>
                    u.Username.ToLower() == uname);
                if (duplicate)
                    errors.Add("• Tên đăng nhập này đã tồn tại trong hệ thống.");
            }

            // 5. Không cho phép tự đổi vai trò của chính mình (bảo vệ admin)
            // (tuỳ chọn — bỏ comment nếu muốn bật)
            // if (!isNew && _selectedUser?.RoleID == 1)
            // {
            //     string selectedRole = cboRole.SelectedItem?.ToString() ?? "";
            //     if (_roleMap.TryGetValue(selectedRole, out int rid) && rid != 1)
            //         errors.Add("• Không thể thay đổi vai trò của tài khoản Quản trị viên.");
            // }

            return errors;
        }

        // ── LƯU / CẬP NHẬT ──────────────────────────────────────────
        private async Task HandleSave()
        {
            bool isNew = (_selectedUser == null);
            var errors = ValidateForm(isNew);
            if (ClinicValidator.ShowErrors(errors)) return;

            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string roleName = cboRole.SelectedItem?.ToString() ?? "Bệnh nhân";
            int roleId = _roleMap.TryGetValue(roleName, out int rid) ? rid : 3;

            // Kiểm tra không thay đổi gì (chế độ Update)
            if (!isNew)
            {
                bool noChange = _selectedUser.FullName == fullName
                             && _selectedUser.RoleID == roleId
                             && string.IsNullOrWhiteSpace(password);
                if (noChange)
                {
                    MessageBox.Show("Không có thông tin nào thay đổi.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            var userDto = new User
            {
                FullName = fullName,
                Username = username,
                RoleID = roleId,
                Email = $"{username}@clinic.local",
                PasswordHash = !string.IsNullOrWhiteSpace(password) ? password : null
            };

            try
            {
                bool isSuccess = false;

                if (isNew)
                {
                    var result = await ApiClient.PostAsync<User>("api/Users", userDto);
                    isSuccess = result != null;
                }
                else
                {
                    userDto.UserID = _selectedUser.UserID;
                    var result = await ApiClient.PutAsync<User>(
                        $"api/Users/{_selectedUser.UserID}", userDto);
                    isSuccess = result != null;
                }

                if (isSuccess)
                {
                    MessageBox.Show(isNew ? "✅ Tạo tài khoản thành công!"
                                          : "✅ Cập nhật thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadData();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("API không phản hồi. Vui lòng thử lại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── XÓA ─────────────────────────────────────────────────────
        private async Task HandleDelete()
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho xóa Admin
            if (_selectedUser.RoleID == 1)
            {
                MessageBox.Show("Không thể xóa tài khoản Quản trị viên!", "Hạn chế",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cảnh báo bổ sung nếu là Bác sĩ
            if (_selectedUser.RoleID == 2)
            {
                var warn = MessageBox.Show(
                    $"Tài khoản \"{_selectedUser.Username}\" là Bác sĩ.\n" +
                    "Xóa có thể ảnh hưởng đến hồ sơ bác sĩ và lịch hẹn liên quan.\n\n" +
                    "Bạn có muốn tiếp tục?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warn == DialogResult.No) return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận xóa tài khoản:\n\"{_selectedUser.Username}\" — {_selectedUser.FullName}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = await ApiClient.DeleteAsync($"api/Users/{_selectedUser.UserID}");
                if (ok)
                {
                    MessageBox.Show("🗑 Đã xóa tài khoản!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadData();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công. Tài khoản có thể đang được sử dụng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── RESET FORM ───────────────────────────────────────────────
        private void ResetForm()
        {
            _selectedUser = null;
            txtFullName.Clear();
            txtUsername.Clear();
            txtUsername.ReadOnly = false;
            txtPassword.Clear();
            txtPassword.PlaceholderText = "Nhập mật khẩu...";
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;
            dgvUsers.ClearSelection();

            btnSave.Text = "💾  LƯU TÀI KHOẢN";
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            txtFullName.Focus();
        }
    }
}