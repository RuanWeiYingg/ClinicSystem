using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.DoctorSchedule
{
    public partial class MedicalHistory : UserControl
    {
        private int _doctorId;
        private List<MedicalRecord> _currentRecords = new();

        public MedicalHistory(int doctorId = 0)
        {
            InitializeComponent();
            _doctorId = doctorId;

            btnSearch.Click += async (s, e) => await LoadDataByDoctor(txtSearch.Text.Trim());
            dgvHistoryList.SelectionChanged += DgvHistoryList_SelectionChanged;

            SetupGridView();

            this.Load += async (s, e) => await LoadDataByDoctor();
        }

        private void SetupGridView()
        {
            dgvHistoryList.AutoGenerateColumns = false;
            dgvHistoryList.DataSource = null;
            dgvHistoryList.Columns.Clear();

            dgvHistoryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryList.MultiSelect = false;
            dgvHistoryList.ReadOnly = true;
            dgvHistoryList.RowHeadersVisible = false;
            dgvHistoryList.AllowUserToAddRows = false;
            dgvHistoryList.BackgroundColor = Color.White;
            dgvHistoryList.BorderStyle = BorderStyle.None;
            dgvHistoryList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistoryList.GridColor = Color.FromArgb(230, 235, 245);

            // Header style
            dgvHistoryList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 80, 150);  // ← Xanh đậm
            dgvHistoryList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;                   // ← Chữ trắng
            dgvHistoryList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvHistoryList.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            dgvHistoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistoryList.ColumnHeadersHeight = 40;                                                // ← Cao hơn
            dgvHistoryList.EnableHeadersVisualStyles = false;

            // Row style
            dgvHistoryList.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvHistoryList.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
            dgvHistoryList.RowTemplate.Height = 36;                                                 // ← Cao hơn
            dgvHistoryList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);

            dgvHistoryList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvHistoryList.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 40, 80);

            // Cột ẩn index
            dgvHistoryList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIndex",
                Visible = false
            });

            // STT
            dgvHistoryList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                Width = 50,
                MinimumWidth = 50,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Ngày khám — tăng width lên 120
            dgvHistoryList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgayKham",
                HeaderText = "Ngày khám",
                Width = 120,                                                                        // ← Tăng từ 100
                MinimumWidth = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Bệnh nhân
            dgvHistoryList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBenhNhan",
                HeaderText = "Bệnh nhân",
                MinimumWidth = 130,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 40
            });

            // Chẩn đoán
            dgvHistoryList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colChanDoan",
                HeaderText = "Chẩn đoán",
                MinimumWidth = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 60
            });

            // Trạng thái
            dgvHistoryList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTrangThai",
                HeaderText = "Trạng thái",
                Width = 130,                                                                        // ← Tăng từ 110
                MinimumWidth = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        public async Task LoadDataByDoctor(string searchKey = "")
        {
            try
            {
                string endpoint = $"api/MedicalRecords/doctor/{_doctorId}";
                if (!string.IsNullOrEmpty(searchKey))
                    endpoint += $"?patientSearch={Uri.EscapeDataString(searchKey)}";

                var records = await ApiClient.GetAsync<List<MedicalRecord>>(endpoint);

                dgvHistoryList.Rows.Clear();
                _currentRecords.Clear();
                ClearDetails();

                if (records == null || records.Count == 0)
                {
                    int emptyRow = dgvHistoryList.Rows.Add("", "", "", "Không có dữ liệu", "", "");
                    dgvHistoryList.Rows[emptyRow].DefaultCellStyle.ForeColor = Color.Gray;
                    dgvHistoryList.Rows[emptyRow].DefaultCellStyle.Font =
                        new Font("Segoe UI", 9.5f, FontStyle.Italic);
                    return;
                }

                _currentRecords = records;

                for (int i = 0; i < records.Count; i++)
                {
                    var r = records[i];

                    string ngayKham = r.Appointment?.AppointmentDate.ToString("dd/MM/yyyy")
                                   ?? r.DateCreated.ToString("dd/MM/yyyy");

                    string benhNhan = r.Appointment?.Patient?.FullName ?? "N/A";
                    string chanDoan = r.Diagnosis ?? "Chưa có chẩn đoán";

                    // ← Thêm đầy đủ các case trạng thái
                    string trangThai = r.Appointment?.Status switch
                    {
                        "WaitingForPayment" => "Chờ thanh toán",
                        "Completed" => "Hoàn thành",
                        "Examining" => "Đang khám",
                        "Confirmed" => "Đã xác nhận",
                        "Pending" => "Chờ khám",
                        "Cancelled" => "Đã hủy",
                        _ => r.Appointment?.Status ?? "---"
                    };

                    int rowIdx = dgvHistoryList.Rows.Add(
                        i.ToString(),
                        (i + 1).ToString(),
                        ngayKham,
                        benhNhan,
                        chanDoan,
                        trangThai
                    );

                    // Màu trạng thái
                    (Color fg, Color bg) = trangThai switch
                    {
                        "Hoàn thành" => (Color.FromArgb(34, 139, 80), Color.FromArgb(220, 245, 230)),
                        "Chờ thanh toán" => (Color.FromArgb(180, 100, 0), Color.FromArgb(255, 243, 220)),
                        "Đang khám" => (Color.FromArgb(0, 100, 200), Color.FromArgb(220, 235, 255)),
                        "Đã xác nhận" => (Color.FromArgb(0, 130, 180), Color.FromArgb(220, 240, 250)),
                        "Chờ khám" => (Color.FromArgb(140, 100, 0), Color.FromArgb(255, 250, 220)),
                        "Đã hủy" => (Color.FromArgb(180, 50, 50), Color.FromArgb(255, 230, 230)),
                        _ => (Color.FromArgb(100, 120, 150), Color.FromArgb(240, 240, 245))
                    };

                    var cell = dgvHistoryList.Rows[rowIdx].Cells["colTrangThai"];
                    cell.Style.ForeColor = fg;
                    cell.Style.BackColor = bg;
                    cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvHistoryList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistoryList.SelectedRows.Count == 0) { ClearDetails(); return; }

            var row = dgvHistoryList.SelectedRows[0];

            if (!int.TryParse(row.Cells["colIndex"].Value?.ToString(), out int idx)) return;
            if (idx < 0 || idx >= _currentRecords.Count) return;

            var r = _currentRecords[idx];

            lblDetailTitle.Text = $"🗂  KHÁM NGÀY: {row.Cells["colNgayKham"].Value}  —  {row.Cells["colBenhNhan"].Value}";
            rtbSymptoms.Text = r.Symptoms ?? r.Appointment?.Notes ?? "Không có ghi chú";
            rtbDiagnosis.Text = r.Diagnosis ?? "";
            rtbPrescription.Text =
                $"[KẾ HOẠCH ĐIỀU TRỊ]\n{r.TreatmentPlan ?? "Chưa có"}" +
                $"\n\n[ĐƠN THUỐC / CHỈ ĐỊNH]\n{r.Prescription ?? "Chưa có"}";
        }

        private void ClearDetails()
        {
            lblDetailTitle.Text = "CHI TIẾT LẦN KHÁM";
            rtbSymptoms.Clear();
            rtbDiagnosis.Clear();
            rtbPrescription.Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvHistoryList.SelectedRows.Count > 0)
                MessageBox.Show("Đang kết nối máy in hồ sơ...", "In ấn");
        }
    }
}