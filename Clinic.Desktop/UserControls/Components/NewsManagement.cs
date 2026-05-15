using Clinic.Shared.Model;
using Clinic.Desktop.API;
using Clinic.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Clinic.Desktop.UserControls.Components
{
    public partial class NewsManagement : UserControl
    {
        private News _selectedNews = null;

        // Giới hạn nghiệp vụ
        private const int MaxTitleLength = 250;
        private const int MaxContentLength = 4000;


        private static readonly string WwwrootNewsPath = Path.GetFullPath(
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Clinic.PatientWeb\wwwroot\images\news")
).TrimEnd(Path.DirectorySeparatorChar);

        public NewsManagement()
        {
            InitializeComponent();

            this.Load += (s, e) => LoadData();
            dgvNews.CellClick += DgvNews_CellClick;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnBrowseImage.Click += BtnBrowseImage_Click;
            btnNew.Click += (s, e) => ClearFields();
            btnClear.Click += (s, e) => ClearFields();

            // Ràng buộc độ dài tiêu đề ngay khi nhập
            txtNewsTitle.MaxLength = MaxTitleLength;
        }

        // ── TẢI DỮ LIỆU ─────────────────────────────────────────────
        private async void LoadData()
        {
            try
            {
                var list = await ApiClient.GetAsync<List<News>>("api/News");
                dgvNews.Rows.Clear();

                if (list != null)
                {
                    foreach (var n in list)
                    {
                        int index = dgvNews.Rows.Add();
                        var row = dgvNews.Rows[index];
                        row.Cells["ID"].Value = n.NewsID;
                        row.Cells["NewsTitle"].Value = n.Title;
                        row.Cells["CategoryName"].Value = n.Summary ?? "Thông báo";
                        row.Cells["ImageUrl"].Value = n.ImageUrl ?? string.Empty;
                        row.Tag = n;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tin tức: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── CHỌN DÒNG ───────────────────────────────────────────────
        private void DgvNews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedNews = dgvNews.Rows[e.RowIndex].Tag as News;
            if (_selectedNews == null) return;

            txtNewsTitle.Text = _selectedNews.Title;
            cboCategory.Text = _selectedNews.Summary ?? "Thông báo";
            txtImageUrl.Text = _selectedNews.ImageUrl ?? string.Empty;
            txtContent.Text = _selectedNews.Content;

            btnSave.Text = "💾 CẬP NHẬT";
            btnSave.BackColor = Color.FromArgb(255, 140, 0); // Màu cam khi sửa
        }

        // ── VALIDATION ──────────────────────────────────────────────
        private List<string> ValidateForm()
        {
            var errors = new List<string>();

            ClinicValidator.ValidateName(txtNewsTitle.Text, errors, "Tiêu đề bài viết", MaxTitleLength);

            if (string.IsNullOrWhiteSpace(txtContent.Text))
                errors.Add("Nội dung bài viết không được để trống.");

            if (cboCategory.SelectedIndex < 0 && string.IsNullOrWhiteSpace(cboCategory.Text))
                errors.Add("Vui lòng chọn danh mục tin tức.");

            ClinicValidator.ValidateImageUrl(txtImageUrl.Text, errors);

            return errors;
        }

        // ── LƯU (THÊM/SỬA) ──────────────────────────────────────────
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var errors = ValidateForm();
            if (ClinicValidator.ShowErrors(errors)) return;

            string imgUrl = string.IsNullOrWhiteSpace(txtImageUrl.Text) ? null : txtImageUrl.Text.Trim();

            try
            {
                if (_selectedNews == null) // THÊM MỚI
                {
                    var newNews = new News
                    {
                        Title = txtNewsTitle.Text.Trim(),
                        Content = txtContent.Text.Trim(),
                        Summary = cboCategory.Text,
                        ImageUrl = imgUrl,
                        Author = "Admin",
                        PublishDate = DateTime.Now
                    };

                    var result = await ApiClient.PostAsync<News>("api/News", newNews);
                    if (result != null)
                    {
                        MessageBox.Show("✅ Đăng bài viết thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadData();
                    }
                }
                else // CẬP NHẬT
                {
                    _selectedNews.Title = txtNewsTitle.Text.Trim();
                    _selectedNews.Content = txtContent.Text.Trim();
                    _selectedNews.Summary = cboCategory.Text;
                    _selectedNews.ImageUrl = imgUrl;

                    await ApiClient.PutAsync<News>($"api/News/{_selectedNews.NewsID}", _selectedNews);

                    MessageBox.Show("✅ Đã cập nhật nội dung bài viết!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bài viết:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── XÓA ─────────────────────────────────────────────────────
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedNews == null)
            {
                MessageBox.Show("Vui lòng chọn bài viết cần xóa!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa bài viết:\n\"{_selectedNews.Title}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = await ApiClient.DeleteAsync($"api/News/{_selectedNews.NewsID}");
                if (ok)
                {
                    MessageBox.Show("🗑 Đã xóa bài viết thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa bài viết:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── CHỌN ẢNH (Ánh xạ vào folder news) ───────────────────────
        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Đảm bảo thư mục tồn tại
                if (!Directory.Exists(WwwrootNewsPath)) Directory.CreateDirectory(WwwrootNewsPath);

                using var dlg = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.webp",
                    InitialDirectory = WwwrootNewsPath // Mở đúng thư mục đích
                };

                if (dlg.ShowDialog() != DialogResult.OK) return;

                // 2. CHUẨN HÓA ĐƯỜNG DẪN ĐỂ SO SÁNH (Đây là phần hay bị lỗi nhất)
                string selectedFolder = Path.GetFullPath(Path.GetDirectoryName(dlg.FileName)).TrimEnd(Path.DirectorySeparatorChar);
                string targetFolder = Path.GetFullPath(WwwrootNewsPath).TrimEnd(Path.DirectorySeparatorChar);

                // 3. So sánh không phân biệt hoa thường
                if (!selectedFolder.Equals(targetFolder, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        $"⚠️ Sai thư mục!\nBạn phải copy ảnh vào thư mục này trước khi chọn:\n\n{targetFolder}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Gán đường dẫn tương đối để lưu vào Database
                txtImageUrl.Text = $"/images/news/{Path.GetFileName(dlg.FileName)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // ── RESET FORM ───────────────────────────────────────────────
        private void ClearFields()
        {
            _selectedNews = null;
            txtNewsTitle.Clear();
            txtContent.Clear();
            txtImageUrl.Clear();
            cboCategory.SelectedIndex = -1;

            btnSave.Text = "💾 LƯU BÀI VIẾT";
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            dgvNews.ClearSelection();
            txtNewsTitle.Focus();
        }
    }
}