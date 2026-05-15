using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.DoctorSchedule
{
    public partial class Profile : UserControl
    {
        private int _doctorId;
        private byte[]? _pendingAvatarBytes = null;

        public Profile(int doctorId)
        {
            InitializeComponent();
            _doctorId = doctorId;

            // ── Sự kiện ───────────────────────────────────────────────
            picAvatar.Paint += PicAvatar_Paint;
            picAvatar.Click += PicAvatar_Click;
            btnUploadAvatar.Click += BtnUploadAvatar_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => LoadDoctorProfile().ConfigureAwait(false);

            // Hover effect cho btnSave
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(24, 95, 165);
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(15, 76, 129);

            // Load dữ liệu
            this.Load += async (s, e) =>
            {
                if (_doctorId > 0)
                    await LoadDoctorProfile();
                else
                    MessageBox.Show($"ID bác sĩ không hợp lệ: {_doctorId}", "Lỗi hệ thống");
            };
        }

        // ══════════════════════════════════════════════════════════════
        // VẼ AVATAR TRÒN
        // ══════════════════════════════════════════════════════════════
        private void PicAvatar_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var path = new GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width - 1, picAvatar.Height - 1);
            e.Graphics.SetClip(path);

            if (picAvatar.Image != null)
            {
                e.Graphics.DrawImage(picAvatar.Image,
                    new Rectangle(0, 0, picAvatar.Width, picAvatar.Height));
            }
            else
            {
                // Vẽ initials khi chưa có ảnh
                using var bg = new SolidBrush(Color.FromArgb(180, 210, 240));
                e.Graphics.FillEllipse(bg, 0, 0, picAvatar.Width - 1, picAvatar.Height - 1);

                string initials = GetInitials(lblFullName.Text);
                using var font = new Font("Segoe UI", 28f, FontStyle.Bold);
                using var brush = new SolidBrush(Color.FromArgb(15, 76, 129));
                var sz = e.Graphics.MeasureString(initials, font);
                e.Graphics.DrawString(initials, font, brush,
                    (picAvatar.Width - sz.Width) / 2,
                    (picAvatar.Height - sz.Height) / 2);
            }

            // Viền trắng
            e.Graphics.ResetClip();
            using var borderPen = new Pen(Color.FromArgb(80, 255, 255, 255), 3f);
            e.Graphics.DrawEllipse(borderPen, 1, 1, picAvatar.Width - 3, picAvatar.Height - 3);
        }

        private static string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "?";
            var parts = fullName.Trim().Split(' ');
            if (parts.Length == 1) return parts[0][..1].ToUpper();
            return $"{parts[0][0]}{parts[^1][0]}".ToUpper();
        }

        // ══════════════════════════════════════════════════════════════
        // CHỌN ẢNH TỪ MÁY TÍNH
        // ══════════════════════════════════════════════════════════════
        private void PicAvatar_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Chọn ảnh đại diện",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var img = Image.FromFile(dialog.FileName);
                picAvatar.Image = img;
                _pendingAvatarBytes = File.ReadAllBytes(dialog.FileName);
                lblUploadStatus.Text = $"Đã chọn: {Path.GetFileName(dialog.FileName)}";
                picAvatar.Invalidate(); // Vẽ lại tròn
            }
            catch
            {
                MessageBox.Show("Không thể tải ảnh này!", "Lỗi");
            }
        }

        // ══════════════════════════════════════════════════════════════
        // UPLOAD ẢNH LÊN SERVER
        // ══════════════════════════════════════════════════════════════
        private async void BtnUploadAvatar_Click(object? sender, EventArgs e)
        {
            if (_pendingAvatarBytes == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh trước (nhấn vào avatar)!", "Thông báo");
                return;
            }

            try
            {
                btnUploadAvatar.Text = "Đang tải lên...";
                btnUploadAvatar.Enabled = false;
                lblUploadStatus.Text = "";

                using var client = new HttpClient();
                using var content = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(_pendingAvatarBytes);
                fileContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                content.Add(fileContent, "avatar", "avatar.jpg");

                var response = await client.PostAsync(
                    $"https://localhost:7137/api/Doctors/{_doctorId}/avatar", content);

                if (response.IsSuccessStatusCode)
                {
                    lblUploadStatus.Text = "✓ Upload thành công!";
                    lblUploadStatus.ForeColor = Color.FromArgb(80, 200, 120);
                    _pendingAvatarBytes = null;
                }
                else
                {
                    lblUploadStatus.Text = "✗ Upload thất bại";
                    lblUploadStatus.ForeColor = Color.FromArgb(240, 100, 100);
                }
            }
            catch (Exception ex)
            {
                lblUploadStatus.Text = "Lỗi kết nối";
                MessageBox.Show("Lỗi upload: " + ex.Message, "Lỗi");
            }
            finally
            {
                btnUploadAvatar.Text = "Tải ảnh lên server";
                btnUploadAvatar.Enabled = true;
            }
        }

        // ══════════════════════════════════════════════════════════════
        // TẢI DỮ LIỆU BÁC SĨ
        // ══════════════════════════════════════════════════════════════
        private async Task LoadDoctorProfile()
        {
            try
            {
                var doctor = await ApiClient.GetAsync<Doctor>($"api/Doctors/{_doctorId}");
                if (doctor == null) return;

                // Form fields
                txtName.Text = doctor.User?.FullName ?? "N/A";
                txtID.Text = $"DOC{doctor.DoctorID:D3}";
                txtPhone.Text = doctor.User?.PhoneNumber ?? "";
                txtSpecialty.Text = doctor.Specialty?.SpecialtyName ?? "Chưa xác định";
                txtExperience.Text = doctor.ExperienceYears?.ToString() ?? "0";
                txtEmail.Text = doctor.User?.Email ?? "";
                rtbBio.Text = doctor.Bio ?? "Chưa có tiểu sử.";

                // Sidebar
                lblFullName.Text = doctor.User?.FullName ?? "N/A";
                lblDoctorID.Text = $"ID nhân viên: DOC{doctor.DoctorID:D3}";
                lblSidePhone.Text = $"📞  {doctor.User?.PhoneNumber ?? "---"}";
                lblSideSpec.Text = $"🏥  {doctor.Specialty?.SpecialtyName ?? "---"}";
                lblSideExp.Text = $"⏱  {doctor.ExperienceYears ?? 0} năm kinh nghiệm";

                picAvatar.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hồ sơ: " + ex.Message, "Phòng khám Delta");
            }
        }

        // ══════════════════════════════════════════════════════════════
        // LƯU THAY ĐỔI
        // ══════════════════════════════════════════════════════════════
        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                btnSave.Text = "Đang lưu...";
                btnSave.Enabled = false;

                var currentDoc = await ApiClient.GetAsync<Doctor>($"api/Doctors/{_doctorId}");
                if (currentDoc == null) return;

                if (int.TryParse(txtExperience.Text, out int years))
                    currentDoc.ExperienceYears = years;

                currentDoc.Bio = rtbBio.Text.Trim();

                if (currentDoc.User != null)
                {
                    currentDoc.User.PhoneNumber = txtPhone.Text.Trim();
                    currentDoc.User.Email = txtEmail.Text.Trim();
                }

                var result = await ApiClient.PutAsync<Doctor>(
                    $"api/Doctors/{_doctorId}", currentDoc);

                if (result != null)
                {
                    lblLastUpdate.Text = $"Cập nhật lần cuối: {DateTime.Now:dd/MM/yyyy HH:mm}";
                    MessageBox.Show("Cập nhật hồ sơ thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDoctorProfile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi");
            }
            finally
            {
                btnSave.Text = "Lưu thay đổi";
                btnSave.Enabled = true;
            }
        }
    }
}