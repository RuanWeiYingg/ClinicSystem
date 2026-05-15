using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.View
{
    public partial class Login : Form
    {
        // File lưu thông tin đăng nhập
        private readonly string _savedLoginPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ClinicDelta", "saved_login.json");

        public Login()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            btnLogin.Click += async (s, e) => await HandleLogin();
            chkRemember.CheckedChanged += (s, e) => { if (!chkRemember.Checked) ClearSavedLogin(); };

            LoadSavedLogin();
        }

        private void BtnTogglePassword_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = txtPassword.PasswordChar == '●' ? '\0' : '●';
            btnTogglePassword.ForeColor = txtPassword.PasswordChar == '\0'
                ? Color.FromArgb(29, 78, 216)
                : Color.FromArgb(100, 116, 139);
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
            => btnLogin.BackColor = Color.FromArgb(37, 99, 235);

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
            => btnLogin.BackColor = Color.FromArgb(29, 78, 216);

        // ── Nhớ mật khẩu ──────────────────────────────────────────────
        private void LoadSavedLogin()
        {
            try
            {
                if (!File.Exists(_savedLoginPath)) return;
                var json = File.ReadAllText(_savedLoginPath);
                var data = JsonSerializer.Deserialize<SavedLogin>(json);
                if (data == null) return;

                txtUsername.Text = data.Username ?? "";
                txtPassword.Text = data.Password ?? "";
                chkRemember.Checked = true;
            }
            catch { /* bỏ qua nếu file lỗi */ }
        }

        private void SaveLogin(string username, string password)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_savedLoginPath)!);
                var data = new SavedLogin { Username = username, Password = password };
                File.WriteAllText(_savedLoginPath, JsonSerializer.Serialize(data));
            }
            catch { }
        }

        private void ClearSavedLogin()
        {
            try { if (File.Exists(_savedLoginPath)) File.Delete(_savedLoginPath); }
            catch { }
        }

        // ── Xử lý đăng nhập ───────────────────────────────────────────
        private async Task HandleLogin()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Vui lòng nhập tài khoản và mật khẩu!");
                return;
            }

            try
            {
                SetLoading(true);
                HideError();

                var loginData = new User
                {
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = txtPassword.Text.Trim()
                };

                var user = await ApiClient.PostAsync<User>("api/Auth/login", loginData);

                if (user != null)
                {
                    // Lưu nếu chọn nhớ mật khẩu
                    if (chkRemember.Checked)
                        SaveLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    else
                        ClearSavedLogin();

                    Form nextForm = null;
                    switch (user.RoleID)
                    {
                        case 1:
                            nextForm = new Home();
                            break;
                        case 2:
                            var doctor = await ApiClient.GetAsync<Doctor>($"api/Doctors/user/{user.UserID}");
                            if (doctor != null)
                            {
                                nextForm = new DoctorHome(doctor.DoctorID);
                                MessageBox.Show($"Chào Bác sĩ: {user.FullName}", "Hệ thống Delta");
                            }
                            else
                            {
                                ShowError("Tài khoản bác sĩ chưa có dữ liệu chuyên môn!");
                                return;
                            }
                            break;
                        default:
                            ShowError("Tài khoản không có quyền truy cập hệ thống.");
                            return;
                    }

                    if (nextForm != null)
                    {
                        nextForm.FormClosed += (s, args) => Application.Exit();
                        nextForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    ShowError("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void SetLoading(bool loading)
        {
            btnLogin.Enabled = !loading;
            btnLogin.Text = loading ? "Đang xác thực..." : "ĐĂNG NHẬP";
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        private void HideError()
        {
            lblError.Visible = false;
        }

        // ── Model lưu login ───────────────────────────────────────────
        private class SavedLogin
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}