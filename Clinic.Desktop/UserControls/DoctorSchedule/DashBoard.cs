using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.UserControls.DoctorSchedule
{
    public partial class DashBoard : UserControl
    {
        private int _doctorId;

        public DashBoard() { InitializeComponent(); }

        public DashBoard(int doctorId)
        {
            InitializeComponent();
            _doctorId = doctorId;
            this.Load += async (s, e) => await LoadDashboard();
        }

        // ── LOAD TOÀN BỘ DASHBOARD ──────────────────────────────────
        private async Task LoadDashboard()
        {
            try
            {
                var appointments = await ApiClient.GetAsync<List<Appointment>>(
                    $"api/Appointments/doctor/{_doctorId}") ?? new List<Appointment>();

                var today = appointments
                    .Where(a => a.AppointmentDate.Date == DateTime.Today)
                    .ToList();

                // ── Cập nhật 3 card ────────────────────────────────
                lblCountApp.Text = today.Count.ToString();

                int waiting = today.Count(a =>
                    a.Status == "Pending" || a.Status == "Confirmed");
                lblCountWaiting.Text = waiting.ToString();

                int done = today.Count(a =>
                    a.Status == "Completed" || a.Status == "WaitingForPayment");
                lblCountRevenue.Text = done.ToString();

                // ── Bảng danh sách chờ khám ────────────────────────
                LoadWaitingGrid(today);

                // ── Danh sách lịch hẹn bên phải ───────────────────
                LoadActivityPanel(today);
            }
            catch (Exception ex)
            {
                lblCountApp.Text = "!";
                lblCountWaiting.Text = "!";
                lblCountRevenue.Text = "!";
                AddNotification($"Lỗi tải dữ liệu: {ex.Message}",
                                Color.FromArgb(200, 50, 50));
            }
        }

        // ── BẢNG DANH SÁCH CHỜ KHÁM ────────────────────────────────
        private void LoadWaitingGrid(List<Appointment> today)
        {
            dgvWaiting.AutoGenerateColumns = false;
            dgvWaiting.Columns.Clear();

            dgvWaiting.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                Width = 55,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvWaiting.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTime",
                HeaderText = "Giờ",
                Width = 70,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvWaiting.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Bệnh nhân",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvWaiting.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colService",
                HeaderText = "Dịch vụ",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvWaiting.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                Width = 120,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvWaiting.Rows.Clear();

            var waitingList = today
                .Where(a => a.Status == "Pending" || a.Status == "Confirmed"
                         || a.Status == "Examining")
                .OrderBy(a => a.AppointmentDate)
                .ToList();

            if (waitingList.Count == 0)
            {
                int r = dgvWaiting.Rows.Add("", "", "Không có bệnh nhân chờ khám", "", "");
                dgvWaiting.Rows[r].DefaultCellStyle.ForeColor = Color.Gray;
                dgvWaiting.Rows[r].DefaultCellStyle.Font =
                    new Font("Segoe UI", 9.5F, FontStyle.Italic);
                return;
            }

            for (int i = 0; i < waitingList.Count; i++)
            {
                var a = waitingList[i];

                string status = a.Status switch
                {
                    "Pending" => "Chờ xác nhận",
                    "Confirmed" => "Đã xác nhận",
                    "Examining" => "Đang khám",
                    _ => a.Status
                };

                int rowIdx = dgvWaiting.Rows.Add(
                    (i + 1).ToString(),
                    a.AppointmentDate.ToString("HH:mm"),
                    a.Patient?.FullName ?? "N/A",
                    a.Service?.ServiceName ?? "---",
                    status
                );

                // Màu trạng thái
                Color fg = a.Status switch
                {
                    "Examining" => Color.FromArgb(0, 100, 200),
                    "Confirmed" => Color.FromArgb(30, 140, 60),
                    _ => Color.FromArgb(180, 100, 0)
                };
                dgvWaiting.Rows[rowIdx].Cells["colStatus"].Style.ForeColor = fg;
                dgvWaiting.Rows[rowIdx].Cells["colStatus"].Style.Font =
                    new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        // ── PANEL LỊCH HẸN BÊN PHẢI ────────────────────────────────
        private void LoadActivityPanel(List<Appointment> today)
        {
            flpNotifications.Controls.Clear();

            if (today.Count == 0)
            {
                AddNotification("Không có lịch hẹn nào hôm nay.",
                                Color.FromArgb(120, 130, 150));
                return;
            }

            foreach (var a in today.OrderBy(x => x.AppointmentDate))
            {
                string time = a.AppointmentDate.ToString("HH:mm");
                string patient = a.Patient?.FullName ?? $"BN#{a.PatientID}";
                string icon = a.Status switch
                {
                    "Pending" => "⏳",
                    "Confirmed" => "✅",
                    "Examining" => "🔬",
                    "WaitingForPayment" => "💳",
                    "Completed" => "✔",
                    "Cancelled" => "❌",
                    _ => "•"
                };

                Color color = a.Status switch
                {
                    "Examining" => Color.FromArgb(0, 100, 200),
                    "Completed" => Color.FromArgb(30, 140, 60),
                    "WaitingForPayment" => Color.FromArgb(180, 100, 0),
                    "Cancelled" => Color.FromArgb(180, 50, 50),
                    _ => Color.FromArgb(60, 80, 110)
                };

                AddNotification($"{icon}  {time}  —  {patient}", color);
            }
        }

        // ── THÊM DÒNG VÀO PANEL PHẢI ───────────────────────────────
        private void AddNotification(string message, Color color)
        {
            var lbl = new Label
            {
                Text = message,
                AutoSize = false,
                Width = flpNotifications.Width - 20,
                Height = 42,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = color,
                Padding = new Padding(6, 0, 0, 0),
                Margin = new Padding(0, 0, 0, 4),
                TextAlign = ContentAlignment.MiddleLeft
            };

            lbl.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 228, 245), 1);
                e.Graphics.DrawLine(pen, 0, lbl.Height - 1, lbl.Width, lbl.Height - 1);
            };

            flpNotifications.Controls.Add(lbl);
        }

        // ── PUBLIC: Form cha gọi để refresh ─────────────────────────
        public async void UpdateDashboard()
        {
            await LoadDashboard();
        }
    }
}