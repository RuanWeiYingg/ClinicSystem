using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.UserControls.Components
{
    public partial class MedicalRecords : UserControl
    {
        private List<User> _allPatients = new List<User>();
        private List<MedicalRecord> _currentRecords = new List<MedicalRecord>();

        public MedicalRecords()
        {
            InitializeComponent();
            SetupGridColumns();

            this.Load += async (s, e) => await LoadPatients();

            txtSearchPatient.TextChanged += TxtSearch_TextChanged;
            lstPatients.SelectedIndexChanged += async (s, e) => await OnPatientSelected();
            dgvHistory.SelectionChanged += DgvHistory_SelectionChanged;
            btnPrint.Click += (s, e) => HandlePrint();
        }

        // ── CỘT BẢNG ───────────────────────────────────────────────
        private void SetupGridColumns()
        {
            dgvHistory.Columns.Clear();

            // Cột ẩn index
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colIdx", Visible = false });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                Width = 55,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Ngày khám",
                Width = 120,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDiag",
                HeaderText = "Chẩn đoán",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 50
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTreat",
                HeaderText = "Phương pháp điều trị",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 50
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                Width = 130,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        // ── TẢI BỆNH NHÂN ──────────────────────────────────────────
        private async Task LoadPatients()
        {
            try
            {
                var patients = await ApiClient.GetAsync<List<User>>("api/Users/role/3");
                _allPatients = patients ?? new List<User>();
                RefreshList(_allPatients);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        private void RefreshList(List<User> list)
        {
            lstPatients.DataSource = null;
            lstPatients.DataSource = list;
            lstPatients.DisplayMember = "FullName";
            lstPatients.ValueMember = "UserID";
        }

        // ── TÌM KIẾM ───────────────────────────────────────────────
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearchPatient.Text.ToLower().Trim();
            var filtered = _allPatients.Where(p =>
                p.FullName.ToLower().Contains(kw) ||
                (p.PhoneNumber != null && p.PhoneNumber.Contains(kw))
            ).ToList();
            RefreshList(filtered);
        }

        // ── CHỌN BỆNH NHÂN ─────────────────────────────────────────
        private async Task OnPatientSelected()
        {
            if (lstPatients.SelectedItem is not User patient) return;

            // Cập nhật header
            lblPatientName.Text = $"👤  {patient.FullName.ToUpper()}";
            lblPatientPhone.Text = $"📞  {patient.PhoneNumber ?? "Chưa có SĐT"}";
            lblPatientRole.Text = $"🆔  Mã BN: {patient.UserID}";

            ClearDetail();
            await LoadHistory(patient.UserID);
        }

        // ── TẢI LỊCH SỬ KHÁM ───────────────────────────────────────
        private async Task LoadHistory(int patientId)
        {
            try
            {
                var records = await ApiClient.GetAsync<List<MedicalRecord>>(
                    $"api/MedicalRecords/patient/{patientId}");

                dgvHistory.Rows.Clear();
                _currentRecords.Clear();

                if (records == null || records.Count == 0)
                {
                    int r = dgvHistory.Rows.Add("", "", "", "Chưa có lịch sử khám", "", "");
                    dgvHistory.Rows[r].DefaultCellStyle.ForeColor = Color.Gray;
                    dgvHistory.Rows[r].DefaultCellStyle.Font =
                        new Font("Segoe UI", 9.5F, FontStyle.Italic);
                    return;
                }

                _currentRecords = records;

                for (int i = 0; i < records.Count; i++)
                {
                    var rec = records[i];
                    string date = rec.DateCreated.ToString("dd/MM/yyyy");
                    string diag = rec.Diagnosis ?? "---";
                    string treat = rec.TreatmentPlan ?? "---";

                    string status = rec.Appointment?.Status switch
                    {
                        "WaitingForPayment" => "Chờ thanh toán",
                        "Completed" => "Hoàn thành",
                        "Examining" => "Đang khám",
                        "Confirmed" => "Đã xác nhận",
                        "Pending" => "Chờ khám",
                        "Cancelled" => "Đã hủy",
                        _ => rec.Appointment?.Status ?? "---"
                    };

                    int rowIdx = dgvHistory.Rows.Add(
                        i.ToString(), (i + 1).ToString(),
                        date, diag, treat, status);

                    // Màu trạng thái
                    (Color fg, Color bg) = status switch
                    {
                        "Hoàn thành" => (Color.FromArgb(34, 139, 80), Color.FromArgb(220, 245, 230)),
                        "Chờ thanh toán" => (Color.FromArgb(180, 100, 0), Color.FromArgb(255, 243, 220)),
                        "Đang khám" => (Color.FromArgb(0, 100, 200), Color.FromArgb(220, 235, 255)),
                        "Đã hủy" => (Color.FromArgb(180, 50, 50), Color.FromArgb(255, 230, 230)),
                        _ => (Color.FromArgb(100, 120, 150), Color.FromArgb(240, 240, 245))
                    };

                    var cell = dgvHistory.Rows[rowIdx].Cells["colStatus"];
                    cell.Style.ForeColor = fg;
                    cell.Style.BackColor = bg;
                    cell.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message);
            }
        }

        // ── CHỌN DÒNG → HIỂN THỊ CHI TIẾT ─────────────────────────
        private void DgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count == 0) { ClearDetail(); return; }

            var row = dgvHistory.SelectedRows[0];
            if (!int.TryParse(row.Cells["colIdx"].Value?.ToString(), out int idx)) return;
            if (idx < 0 || idx >= _currentRecords.Count) return;

            var r = _currentRecords[idx];

            lblDetailTitle.Text = "CHI TIẾT LẦN KHÁM";
            lblDateValue.Text = r.DateCreated.ToString("dd/MM/yyyy HH:mm");
            rtbDiagnosis.Text = r.Diagnosis ?? "Chưa có";
            rtbTreatment.Text = $"{r.TreatmentPlan ?? "Chưa có"}" +
                                   $"\n\n[Đơn thuốc]\n{r.Prescription ?? "Chưa có"}";
        }

        private void ClearDetail()
        {
            lblDetailTitle.Text = "CHI TIẾT LẦN KHÁM";
            lblDateValue.Text = "---";
            rtbDiagnosis.Clear();
            rtbTreatment.Clear();
        }

        // ── IN BỆNH ÁN ─────────────────────────────────────────────
        private void HandlePrint()
        {
            if (dgvHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn lần khám cần in!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Đang kết nối máy in...", "In ấn");
        }
    }
}