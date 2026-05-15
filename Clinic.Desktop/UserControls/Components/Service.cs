using Clinic.Shared.Model;
using Clinic.Desktop.API;
using Clinic.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Clinic.Desktop.Components
{
    public partial class Service : UserControl
    {
        private Services _selectedService = null;

        // Giới hạn nghiệp vụ
        private const int MaxDurationMinutes = 480;
        private const int MaxNameLength = 200;
        private const int MaxDescLength = 1000;

        // Đường dẫn tới wwwroot của project web (chỉnh lại nếu cần)
        private static readonly string WwwrootServicesPath = Path.GetFullPath(
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\..\..\Clinic.PatientWeb\wwwroot\images\Services"
            )
        );

        public Service()
        {
            InitializeComponent();

            this.Load += (s, e) => LoadData();
            dgvServices.CellClick += DgvServices_CellClick;
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            btnBrowseImage.Click += BtnBrowseImage_Click;
            if (btnNew != null) btnNew.Click += BtnNew_Click;

            // Chỉ nhận số và dấu phẩy ở ô giá
            txtServicePrice.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            // Chỉ nhận số ở ô thời gian
            txtDuration.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            };

            // Đếm ký tự mô tả
            txtDescription.TextChanged += (s, e) =>
            {
                if (lblDescCount == null) return;
                lblDescCount.Text = $"{txtDescription.Text.Length}/{MaxDescLength}";
                lblDescCount.ForeColor = (MaxDescLength - txtDescription.Text.Length) < 100
                    ? Color.FromArgb(200, 50, 50)
                    : Color.FromArgb(120, 130, 150);
            };
        }

        // ── TẢI DỮ LIỆU ─────────────────────────────────────────────
        private async void LoadData()
        {
            try
            {
                var list = await ApiClient.GetAsync<List<Services>>("api/Services");
                dgvServices.Rows.Clear();

                if (list != null)
                {
                    foreach (var s in list)
                    {
                        int n = dgvServices.Rows.Add();
                        var row = dgvServices.Rows[n];
                        row.Cells["ServiceName"].Value = s.ServiceName;
                        row.Cells["Price"].Value = s.Price.ToString("N0");
                        row.Cells["Duration"].Value = s.DurationMinutes;
                        row.Cells["ImageUrl"].Value = s.ImageUrl ?? string.Empty;
                        row.Tag = s;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── CHỌN DÒNG ───────────────────────────────────────────────
        private void DgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedService = dgvServices.Rows[e.RowIndex].Tag as Services;
            if (_selectedService == null) return;

            txtServiceName.Text = _selectedService.ServiceName;
            txtServicePrice.Text = _selectedService.Price.ToString("G29");
            txtDuration.Text = _selectedService.DurationMinutes.ToString();
            txtImageUrl.Text = _selectedService.ImageUrl ?? string.Empty;

            btnSave.Text = "💾 CẬP NHẬT";
            btnSave.BackColor = Color.FromArgb(255, 140, 0);
        }

        // ── VALIDATION ──────────────────────────────────────────────
        private List<string> ValidateForm()
        {
            var errors = new List<string>();

            // 1. Tên dịch vụ
            ClinicValidator.ValidateName(txtServiceName.Text, errors,
                "Tên dịch vụ", MaxNameLength);

            // 2. Giá tiền
            ClinicValidator.ValidatePrice(txtServicePrice.Text, errors);

            // 3. Thời gian thực hiện
            ClinicValidator.ValidatePositiveInt(txtDuration.Text, errors,
                "Thời gian thực hiện", min: 1, max: MaxDurationMinutes);

            // 4. Mô tả (nếu có txtDescription)
            if (txtDescription != null)
                ClinicValidator.ValidateDescription(txtDescription.Text, errors,
                    "Mô tả dịch vụ", MaxDescLength);

            // 5. Đường dẫn ảnh
            ClinicValidator.ValidateImageUrl(txtImageUrl.Text, errors);

            return errors;
        }

        // ── LƯU ─────────────────────────────────────────────────────
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var errors = ValidateForm();
            if (ClinicValidator.ShowErrors(errors)) return;

            decimal price = decimal.Parse(txtServicePrice.Text.Trim().Replace(",", ""));
            int duration = int.Parse(txtDuration.Text.Trim());
            string imgUrl = string.IsNullOrWhiteSpace(txtImageUrl.Text)
                                   ? null : txtImageUrl.Text.Trim();

            try
            {
                if (_selectedService == null) // THÊM MỚI
                {
                    var newService = new Services
                    {
                        ServiceName = txtServiceName.Text.Trim(),
                        Price = price,
                        DurationMinutes = duration,
                        ImageUrl = imgUrl
                    };

                    var result = await ApiClient.PostAsync<Services>("api/Services", newService);
                    if (result != null)
                    {
                        MessageBox.Show("✅ Thêm dịch vụ mới thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("API không phản hồi. Vui lòng thử lại.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else // CẬP NHẬT
                {
                    // Kiểm tra có thay đổi không
                    bool noChange = _selectedService.ServiceName == txtServiceName.Text.Trim()
                                 && _selectedService.Price == price
                                 && _selectedService.DurationMinutes == duration
                                 && (_selectedService.ImageUrl ?? "") == (imgUrl ?? "");

                    if (noChange)
                    {
                        MessageBox.Show("Không có thông tin nào thay đổi.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    _selectedService.ServiceName = txtServiceName.Text.Trim();
                    _selectedService.Price = price;
                    _selectedService.DurationMinutes = duration;
                    _selectedService.ImageUrl = imgUrl;

                    await ApiClient.PutAsync<Services>(
                        $"api/Services/{_selectedService.ServiceID}", _selectedService);

                    MessageBox.Show($"✅ Đã cập nhật dịch vụ: {_selectedService.ServiceName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── XÓA ─────────────────────────────────────────────────────
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận ngừng cung cấp dịch vụ:\n\"{_selectedService.ServiceName}\"?\n\n" +
                "Các lịch hẹn đang dùng dịch vụ này có thể bị ảnh hưởng.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = await ApiClient.DeleteAsync(
                    $"api/Services/{_selectedService.ServiceID}");

                if (ok)
                {
                    MessageBox.Show("🚫 Đã gỡ bỏ dịch vụ khỏi danh mục!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công. Dịch vụ có thể đang được sử dụng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── TÌM KIẾM ────────────────────────────────────────────────
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearchService.Text.Trim().ToLower();
            dgvServices.CurrentCell = null;

            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                if (row.Cells["ServiceName"].Value != null)
                    row.Visible = row.Cells["ServiceName"].Value
                                      .ToString().ToLower().Contains(kw);
            }
        }

        // ── CHỌN ẢNH ────────────────────────────────────────────────
        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            // Tạo thư mục nếu chưa có để tránh lỗi InitialDirectory
            Directory.CreateDirectory(WwwrootServicesPath);

            using var dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.webp",
                Title = "Chọn ảnh từ thư mục wwwroot/images/Services",
                // Mở thẳng vào thư mục wwwroot/images/Services
                InitialDirectory = WwwrootServicesPath
            };

            if (dlg.ShowDialog() != DialogResult.OK) return;

            // Kiểm tra user có chọn đúng trong thư mục wwwroot không
            string selectedDir = Path.GetDirectoryName(dlg.FileName);
            if (!selectedDir.Equals(WwwrootServicesPath, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "⚠️ Vui lòng chỉ chọn ảnh từ thư mục:\n" + WwwrootServicesPath +
                    "\n\nHãy copy ảnh vào thư mục đó trước rồi chọn lại.",
                    "Sai thư mục", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu đường dẫn web tương đối
            string fileName = Path.GetFileName(dlg.FileName);
            txtImageUrl.Text = $"/images/Services/{fileName}";
        }

        private void BtnNew_Click(object sender, EventArgs e) => ClearFields();

        // ── RESET FORM ───────────────────────────────────────────────
        private void ClearFields()
        {
            _selectedService = null;
            txtServiceName.Clear();
            txtServicePrice.Clear();
            txtDuration.Clear();
            txtImageUrl.Clear();
            if (txtDescription != null) txtDescription.Clear();
            if (lblDescCount != null)
            {
                lblDescCount.Text = $"0/{MaxDescLength}";
                lblDescCount.ForeColor = Color.FromArgb(120, 130, 150);
            }

            btnSave.Text = "💾 LƯU DỊCH VỤ";
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            txtServiceName.Focus();
        }
    }
}