using Clinic.Shared.Model;
using Clinic.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Clinic.Desktop.UserControls.Components
{
    public partial class FacilityManagement : UserControl
    {
        private List<Facility> _facilityList = new List<Facility>();
        private Facility _selectedFacility = null;

        private const int MaxNameLength = 200;
        private const int MaxDescLength = 1000;

        public FacilityManagement()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();

            dgvFacilities.CellClick += DgvFacilities_CellClick;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;
            btnClear.Click += BtnClear_Click;
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

        // ── CẤU HÌNH GRID ───────────────────────────────────────────
        private void SetupDataGridView()
        {
            dgvFacilities.AutoGenerateColumns = false;
            dgvFacilities.Columns.Clear();

            dgvFacilities.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "FacilityID", HeaderText = "ID", Width = 50 });
            dgvFacilities.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "FacilityName", HeaderText = "Tên Cơ Sở Vật Chất", FillWeight = 150 });
            dgvFacilities.Columns.Add(new DataGridViewCheckBoxColumn
            { DataPropertyName = "IsOperating", HeaderText = "Đang vận hành", Width = 110 });
        }

        // ── TẢI DỮ LIỆU (mock — thay bằng ApiClient khi có API) ────
        private void LoadData()
        {
            _facilityList = new List<Facility>
            {
                new Facility { FacilityID = 1, FacilityName = "Máy Chụp Cộng Hưởng Từ MRI 1.5T",
                               Description = "Hệ thống MRI hiện đại...",   IsOperating = true  },
                new Facility { FacilityID = 2, FacilityName = "Máy Siêu Âm 4D Voluson E10",
                               Description = "Thiết bị sản phụ khoa...",   IsOperating = true  },
                new Facility { FacilityID = 3, FacilityName = "Hệ Thống Xét Nghiệm Tự Động",
                               Description = "Xét nghiệm máu, sinh hóa...", IsOperating = false }
            };
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvFacilities.DataSource = null;
            dgvFacilities.DataSource = _facilityList;
        }

        // ── CHỌN DÒNG ───────────────────────────────────────────────
        private void DgvFacilities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedFacility = dgvFacilities.Rows[e.RowIndex].DataBoundItem as Facility;
            if (_selectedFacility == null) return;

            txtFacilityName.Text = _selectedFacility.FacilityName;
            txtDescription.Text = _selectedFacility.Description;
            cboStatus.SelectedIndex = _selectedFacility.IsOperating ? 0 : 1;

            btnSave.Text = "💾  CẬP NHẬT";
            btnSave.BackColor = Color.FromArgb(255, 140, 0);
        }

        // ── NÚT THÊM MỚI ────────────────────────────────────────────
        private void BtnNew_Click(object sender, EventArgs e) => ClearFields();

        // ── VALIDATION ──────────────────────────────────────────────
        private List<string> ValidateForm(bool isNew)
        {
            var errors = new List<string>();

            // 1. Tên cơ sở
            ClinicValidator.ValidateName(txtFacilityName.Text, errors,
                "Tên cơ sở vật chất", MaxNameLength);

            // 2. Mô tả
            ClinicValidator.ValidateDescription(txtDescription.Text, errors,
                "Mô tả", MaxDescLength);

            // 3. Tên trùng
            if (errors.Count == 0)
            {
                string name = txtFacilityName.Text.Trim().ToLower();
                bool isDuplicate = isNew
                    ? _facilityList.Any(f => f.FacilityName.ToLower() == name)
                    : _facilityList.Any(f => f.FacilityName.ToLower() == name
                                          && f.FacilityID != _selectedFacility?.FacilityID);
                if (isDuplicate)
                    errors.Add("• Tên cơ sở vật chất này đã tồn tại.");
            }

            return errors;
        }

        // ── LƯU ─────────────────────────────────────────────────────
        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool isNew = (_selectedFacility == null);
            var errors = ValidateForm(isNew);
            if (ClinicValidator.ShowErrors(errors)) return;

            bool isOperating = (cboStatus.SelectedIndex == 0);

            if (isNew)
            {
                var newFacility = new Facility
                {
                    FacilityID = _facilityList.Count > 0
                                       ? _facilityList.Max(f => f.FacilityID) + 1 : 1,
                    FacilityName = txtFacilityName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    IsOperating = isOperating,
                    CreatedAt = DateTime.Now
                };
                _facilityList.Add(newFacility);
                MessageBox.Show("✅ Thêm cơ sở vật chất thành công!", "Delta Clinic",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Kiểm tra có thay đổi không
                bool noChange = _selectedFacility.FacilityName == txtFacilityName.Text.Trim()
                             && (_selectedFacility.Description ?? "") == txtDescription.Text.Trim()
                             && _selectedFacility.IsOperating == isOperating;

                if (noChange)
                {
                    MessageBox.Show("Không có thông tin nào thay đổi.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _selectedFacility.FacilityName = txtFacilityName.Text.Trim();
                _selectedFacility.Description = txtDescription.Text.Trim();
                _selectedFacility.IsOperating = isOperating;
                MessageBox.Show("✅ Cập nhật thành công!", "Delta Clinic",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefreshGrid();
            ClearFields();
        }

        // ── XÓA ─────────────────────────────────────────────────────
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedFacility == null)
            {
                MessageBox.Show("Vui lòng chọn cơ sở vật chất cần xóa!", "Chưa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cảnh báo nếu đang vận hành
            if (_selectedFacility.IsOperating)
            {
                var warn = MessageBox.Show(
                    $"\"{_selectedFacility.FacilityName}\" hiện đang VẬN HÀNH.\n" +
                    "Bạn có chắc chắn muốn xóa?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (warn == DialogResult.No) return;
            }

            var confirm = MessageBox.Show(
                $"Xác nhận xóa:\n\"{_selectedFacility.FacilityName}\"?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            _facilityList.Remove(_selectedFacility);
            RefreshGrid();
            ClearFields();
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearFields();

        // ── RESET FORM ───────────────────────────────────────────────
        private void ClearFields()
        {
            _selectedFacility = null;
            txtFacilityName.Clear();
            txtDescription.Clear();
            if (lblDescCount != null)
            {
                lblDescCount.Text = $"0/{MaxDescLength}";
                lblDescCount.ForeColor = Color.FromArgb(120, 130, 150);
            }
            cboStatus.SelectedIndex = 0;
            dgvFacilities.ClearSelection();

            btnSave.Text = "💾  LƯU THÔNG TIN";
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
        }
    }
}