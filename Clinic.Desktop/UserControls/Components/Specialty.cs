using Clinic.Shared.Model;
using Clinic.Desktop.API;
using Clinic.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Clinic.Desktop.Components
{
    public partial class Specialty : UserControl
    {
        private List<Clinic.Shared.Model.Specialty> _specialties = new();
        private Clinic.Shared.Model.Specialty _selectedSpecialty = null;

        private const int MaxNameLength = 150;
        private const int MaxDescLength = 1000;

        public Specialty()
        {
            InitializeComponent();
            LoadData();

            dgvSpecialties.CellClick += DgvSpecialties_CellClick;
            btnNew.Click += BtnNew_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnClear.Click += (s, e) => ClearFields();
            btnDelete.Click += BtnDelete_Click;

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
                var data = await ApiClient.GetAsync<List<Clinic.Shared.Model.Specialty>>("api/Specialties");
                if (data != null)
                {
                    _specialties = data;
                    BindGrid(_specialties);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chuyên khoa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<Clinic.Shared.Model.Specialty> list)
        {
            dgvSpecialties.Rows.Clear();
            foreach (var item in list)
            {
                int n = dgvSpecialties.Rows.Add();
                dgvSpecialties.Rows[n].Cells["SpecName"].Value = item.SpecialtyName;
                dgvSpecialties.Rows[n].Cells["Description"].Value = item.Description;
                dgvSpecialties.Rows[n].Tag = item;
            }
        }

        // ── CHỌN DÒNG ───────────────────────────────────────────────
        private void DgvSpecialties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedSpecialty = dgvSpecialties.Rows[e.RowIndex].Tag
                                     as Clinic.Shared.Model.Specialty;
            if (_selectedSpecialty == null) return;

            txtName.Text = _selectedSpecialty.SpecialtyName;
            txtDescription.Text = _selectedSpecialty.Description;

            btnUpdate.Text = "💾  CẬP NHẬT";
            btnUpdate.BackColor = Color.FromArgb(255, 140, 0);
        }

        // ── VALIDATION ──────────────────────────────────────────────
        private List<string> ValidateForm(bool isNew)
        {
            var errors = new List<string>();

            // 1. Tên chuyên khoa
            ClinicValidator.ValidateName(txtName.Text, errors,
                "Tên chuyên khoa", MaxNameLength);

            // 2. Mô tả
            ClinicValidator.ValidateDescription(txtDescription.Text, errors,
                "Mô tả", MaxDescLength);

            // 3. Tên trùng
            if (errors.Count == 0)
            {
                string name = txtName.Text.Trim().ToLower();
                bool isDuplicate = isNew
                    ? _specialties.Any(s => s.SpecialtyName.ToLower() == name)
                    : _specialties.Any(s => s.SpecialtyName.ToLower() == name
                                         && s.SpecialtyID != _selectedSpecialty?.SpecialtyID);
                if (isDuplicate)
                    errors.Add("• Tên chuyên khoa này đã tồn tại trong hệ thống.");
            }

            return errors;
        }

        // ── NÚT THÊM MỚI ────────────────────────────────────────────
        private void BtnNew_Click(object sender, EventArgs e) => ClearFields();

        // ── LƯU / CẬP NHẬT ──────────────────────────────────────────
        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            bool isNew = (_selectedSpecialty == null);
            var errors = ValidateForm(isNew);
            if (ClinicValidator.ShowErrors(errors)) return;

            if (isNew)
            {
                var newItem = new Clinic.Shared.Model.Specialty
                {
                    SpecialtyName = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                try
                {
                    var result = await ApiClient.PostAsync<Clinic.Shared.Model.Specialty>(
                        "api/Specialties", newItem);

                    if (result != null)
                    {
                        MessageBox.Show("✅ Thêm chuyên khoa thành công!", "Thành công",
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
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm:\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Kiểm tra có thay đổi không
                bool noChange = _selectedSpecialty.SpecialtyName == txtName.Text.Trim()
                             && (_selectedSpecialty.Description ?? "") == txtDescription.Text.Trim();

                if (noChange)
                {
                    MessageBox.Show("Không có thông tin nào thay đổi.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _selectedSpecialty.SpecialtyName = txtName.Text.Trim();
                _selectedSpecialty.Description = txtDescription.Text.Trim();

                try
                {
                    var result = await ApiClient.PutAsync<Clinic.Shared.Model.Specialty>(
                        $"api/Specialties/{_selectedSpecialty.SpecialtyID}", _selectedSpecialty);

                    if (result != null)
                    {
                        MessageBox.Show("✅ Cập nhật thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật không thành công. Vui lòng thử lại.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật:\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── XÓA ─────────────────────────────────────────────────────
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSpecialty == null)
            {
                MessageBox.Show("Vui lòng chọn chuyên khoa cần xóa!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận xóa chuyên khoa:\n\"{_selectedSpecialty.SpecialtyName}\"?\n\n" +
                "Các bác sĩ thuộc chuyên khoa này có thể bị ảnh hưởng.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = await ApiClient.DeleteAsync(
                    $"api/Specialties/{_selectedSpecialty.SpecialtyID}");

                if (ok)
                {
                    MessageBox.Show("🗑 Đã xóa chuyên khoa!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công. Chuyên khoa có thể đang được bác sĩ sử dụng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── RESET FORM ───────────────────────────────────────────────
        private void ClearFields()
        {
            _selectedSpecialty = null;
            txtName.Clear();
            txtDescription.Clear();
            if (lblDescCount != null)
            {
                lblDescCount.Text = $"0/{MaxDescLength}";
                lblDescCount.ForeColor = Color.FromArgb(120, 130, 150);
            }
            dgvSpecialties.ClearSelection();
            txtName.Focus();

            btnUpdate.Text = "💾  LƯU CHUYÊN KHOA";
            btnUpdate.BackColor = Color.FromArgb(0, 122, 204);
        }
    }
}