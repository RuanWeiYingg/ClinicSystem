using Clinic.Shared.Model;
using Clinic.Desktop.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Clinic.Desktop.Components
{
    public partial class Doctors : UserControl
    {
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Clinic.Shared.Model.Specialty> _specialties = new List<Clinic.Shared.Model.Specialty>();
        private List<User> _allUsers = new List<User>();
        private Doctor _selectedDoctor = null;
        private bool _isAddingNew = false;

        // Giới hạn nghiệp vụ — chỉnh tại đây nếu cần
        private const int MaxExperienceYears = 60;
        private const int MaxBioLength = 1000;

        public Doctors()
        {
            InitializeComponent();

            dgvDoctors.CellClick += DgvDoctors_CellClick;
            btnNew.Click += BtnNew_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnClear.Click += (s, e) => ClearFields();
            btnDelete.Click += BtnDelete_Click;

            // Chỉ cho nhập số ở ô Kinh nghiệm
            txtExp.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            // Đếm ký tự Bio realtime
            txtBio.TextChanged += (s, e) =>
            {
                int remaining = MaxBioLength - txtBio.Text.Length;
                lblBioCount.Text = $"{txtBio.Text.Length}/{MaxBioLength}";
                lblBioCount.ForeColor = remaining < 100
                    ? Color.FromArgb(200, 50, 50)
                    : Color.FromArgb(120, 130, 150);
            };

            LoadInitData();
        }

        // ══════════════════════════════════════════════════════
        //  VALIDATION — hàm trung tâm, dùng lại cho cả Add & Update
        // ══════════════════════════════════════════════════════
        private List<string> ValidateForm(bool isNew)
        {
            var errors = new List<string>();

            // 1. Kiểm tra chọn User (chế độ thêm mới)
            if (isNew && cboUserSelect.SelectedItem == null)
                errors.Add("• Vui lòng chọn tài khoản bác sĩ.");

            // 2. Chuyên khoa
            if (cboSpecialty.SelectedValue == null || (int)cboSpecialty.SelectedValue <= 0)
                errors.Add("• Vui lòng chọn chuyên khoa.");

            // 3. Số năm kinh nghiệm
            string expText = txtExp.Text.Trim();
            if (string.IsNullOrEmpty(expText))
            {
                errors.Add("• Số năm kinh nghiệm không được để trống.");
            }
            else if (!int.TryParse(expText, out int exp))
            {
                errors.Add("• Số năm kinh nghiệm phải là số nguyên.");
            }
            else if (exp < 0)
            {
                errors.Add("• Số năm kinh nghiệm không được âm.");
            }
            else if (exp > MaxExperienceYears)
            {
                errors.Add($"• Số năm kinh nghiệm không được vượt quá {MaxExperienceYears}.");
            }

            // 4. Bio — không bắt buộc nhưng giới hạn độ dài
            if (txtBio.Text.Length > MaxBioLength)
                errors.Add($"• Giới thiệu không được vượt quá {MaxBioLength} ký tự " +
                           $"(hiện tại: {txtBio.Text.Length}).");

            return errors;
        }

        // Helper hiển thị lỗi
        private void ShowErrors(List<string> errors)
        {
            MessageBox.Show(
                "Vui lòng kiểm tra lại thông tin:\n\n" + string.Join("\n", errors),
                "Dữ liệu chưa hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        // ══════════════════════════════════════════════════════
        //  LOAD DỮ LIỆU
        // ══════════════════════════════════════════════════════
        private async void LoadInitData()
        {
            try
            {
                _specialties = await ApiClient.GetAsync<List<Clinic.Shared.Model.Specialty>>("api/Specialties");
                if (_specialties != null)
                {
                    cboSpecialty.DataSource = _specialties;
                    cboSpecialty.DisplayMember = "SpecialtyName";
                    cboSpecialty.ValueMember = "SpecialtyID";
                }

                _allUsers = await ApiClient.GetAsync<List<User>>("api/Users") ?? new List<User>();
                LoadDoctors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadDoctors()
        {
            try
            {
                var data = await ApiClient.GetAsync<List<Doctor>>("api/Doctors");
                if (data != null)
                {
                    _doctors = data;
                    dgvDoctors.Rows.Clear();
                    foreach (var d in _doctors)
                    {
                        int n = dgvDoctors.Rows.Add();
                        dgvDoctors.Rows[n].Cells["DocName"].Value = d.User?.FullName ?? "N/A";
                        dgvDoctors.Rows[n].Cells["SpecName"].Value = d.Specialty?.SpecialtyName ?? "N/A";
                        dgvDoctors.Rows[n].Cells["Exp"].Value = d.ExperienceYears;
                        dgvDoctors.Rows[n].Tag = d;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bác sĩ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════
        //  CHỌN DÒNG → HIỂN THỊ
        // ══════════════════════════════════════════════════════
        private void DgvDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _selectedDoctor = dgvDoctors.Rows[e.RowIndex].Tag as Doctor;
            if (_selectedDoctor == null) return;

            _isAddingNew = false;

            lblDoctorName.Text = _selectedDoctor.User?.FullName ?? "N/A";
            lblDoctorName.Visible = true;
            cboUserSelect.Visible = false;

            if (_selectedDoctor.SpecialtyID > 0)
                cboSpecialty.SelectedValue = _selectedDoctor.SpecialtyID;

            txtExp.Text = _selectedDoctor.ExperienceYears.ToString();
            txtBio.Text = _selectedDoctor.Bio ?? string.Empty;

            btnUpdate.Text = "💾  CẬP NHẬT";
            btnUpdate.BackColor = Color.FromArgb(255, 140, 0);
        }

        // ══════════════════════════════════════════════════════
        //  NÚT THÊM MỚI
        // ══════════════════════════════════════════════════════
        private async void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                _allUsers = await ApiClient.GetAsync<List<User>>("api/Users") ?? new List<User>();
                var latestDoctors = await ApiClient.GetAsync<List<Doctor>>("api/Doctors") ?? new List<Doctor>();

                var linkedUserIds = latestDoctors.Select(d => d.UserID).ToHashSet();
                var availableUsers = _allUsers
                    .Where(u => u.RoleID == 2 && !linkedUserIds.Contains(u.UserID))
                    .ToList();

                if (availableUsers.Count == 0)
                {
                    MessageBox.Show(
                        "Không còn tài khoản Bác sĩ nào chưa được liên kết!\n" +
                        "Vui lòng tạo tài khoản mới ở mục 'Tài Khoản' trước.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _isAddingNew = true;
                _selectedDoctor = null;

                lblDoctorName.Visible = false;
                cboUserSelect.DataSource = availableUsers;
                cboUserSelect.DisplayMember = "FullName";
                cboUserSelect.ValueMember = "UserID";
                cboUserSelect.Visible = true;

                if (cboSpecialty.Items.Count > 0) cboSpecialty.SelectedIndex = 0;
                txtExp.Clear();
                txtBio.Clear();

                btnUpdate.Text = "💾  LƯU BÁC SĨ";
                btnUpdate.BackColor = Color.FromArgb(40, 167, 69);
                cboUserSelect.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════
        //  NÚT LƯU / CẬP NHẬT
        // ══════════════════════════════════════════════════════
        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            // Validate chung cho cả 2 chế độ
            var errors = ValidateForm(_isAddingNew);
            if (errors.Count > 0)
            {
                ShowErrors(errors);
                return;
            }

            if (_isAddingNew)
            {
                var selectedUser = cboUserSelect.SelectedItem as User;

                var newDoctor = new Doctor
                {
                    UserID = selectedUser.UserID,
                    SpecialtyID = (int)cboSpecialty.SelectedValue,
                    ExperienceYears = int.Parse(txtExp.Text.Trim()),
                    Bio = txtBio.Text.Trim(),
                    IsActive = true
                };

                try
                {
                    var result = await ApiClient.PostAsync<Doctor>("api/Doctors", newDoctor);
                    if (result != null)
                    {
                        MessageBox.Show("✅ Thêm bác sĩ thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadDoctors();
                    }
                    else
                    {
                        MessageBox.Show("API không trả về dữ liệu. Vui lòng thử lại.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm bác sĩ:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (_selectedDoctor == null)
                {
                    MessageBox.Show("Vui lòng chọn bác sĩ từ danh sách!",
                        "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra có thực sự thay đổi gì không
                int newExp = int.Parse(txtExp.Text.Trim());
                int newSpecialty = (int)cboSpecialty.SelectedValue;
                string newBio = txtBio.Text.Trim();

                if (_selectedDoctor.ExperienceYears == newExp &&
                    _selectedDoctor.SpecialtyID == newSpecialty &&
                    (_selectedDoctor.Bio ?? "") == newBio)
                {
                    MessageBox.Show("Không có thông tin nào thay đổi.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    _selectedDoctor.ExperienceYears = newExp;
                    _selectedDoctor.Bio = newBio;
                    _selectedDoctor.SpecialtyID = newSpecialty;

                    var result = await ApiClient.PutAsync<Doctor>(
                        $"api/Doctors/{_selectedDoctor.DoctorID}", _selectedDoctor);

                    if (result != null)
                    {
                        MessageBox.Show("✅ Cập nhật thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadDoctors();
                    }
                    else
                    {
                        MessageBox.Show("API không trả về dữ liệu. Vui lòng thử lại.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ══════════════════════════════════════════════════════
        //  NÚT XÓA
        // ══════════════════════════════════════════════════════
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedDoctor == null)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!",
                    "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cảnh báo nếu bác sĩ đang hoạt động
            if (_selectedDoctor.IsActive == true)
            {
                var warn = MessageBox.Show(
                    $"Bác sĩ \"{_selectedDoctor.User?.FullName}\" hiện đang HOẠT ĐỘNG.\n" +
                    "Việc xóa có thể ảnh hưởng đến lịch hẹn đang chờ xử lý.\n\n" +
                    "Bạn có chắc chắn muốn tiếp tục?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (warn == DialogResult.No) return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận xóa vĩnh viễn bác sĩ:\n\"{_selectedDoctor.User?.FullName}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool success = await ApiClient.DeleteAsync(
                    $"api/Doctors/{_selectedDoctor.DoctorID}");

                if (success)
                {
                    MessageBox.Show("🗑 Đã xóa bác sĩ thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadDoctors();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công. API có thể đã từ chối do ràng buộc dữ liệu.",
                        "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════
        //  RESET FORM
        // ══════════════════════════════════════════════════════
        private void ClearFields()
        {
            _selectedDoctor = null;
            _isAddingNew = false;

            lblDoctorName.Text = "---";
            lblDoctorName.Visible = true;
            cboUserSelect.Visible = false;
            cboUserSelect.DataSource = null;

            txtExp.Clear();
            txtBio.Clear();
            lblBioCount.Text = $"0/{MaxBioLength}";
            lblBioCount.ForeColor = Color.FromArgb(120, 130, 150);

            if (cboSpecialty.Items.Count > 0) cboSpecialty.SelectedIndex = 0;
            dgvDoctors.ClearSelection();

            btnUpdate.Text = "💾  CẬP NHẬT";
            btnUpdate.BackColor = Color.FromArgb(0, 122, 204);
        }
    }
}