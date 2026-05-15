using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Shared.Model;
using Clinic.Desktop.API;

namespace Clinic.Desktop.Components
{
    public partial class HomeView : UserControl
    {
        // Dữ liệu lưu lại để vẽ biểu đồ
        private int[] _appt7Days = new int[7];
        private DateTime[] _appt7Labels = new DateTime[7];
        private Dictionary<string, int> _statusCounts = new();
        private decimal[] _revenue6Months = new decimal[6];
        private string[] _revenue6Labels = new string[6];

        public HomeView()
        {
            InitializeComponent();
            RegisterCardPaint();

            // Hook vẽ biểu đồ vào các panel
            chartBar.Paint += DrawBarChart;
            chartPie.Paint += DrawPieChart;
            chartLine.Paint += DrawLineChart;

            this.Load += async (s, e) => await LoadDashboard();
        }

        // ── ACCENT BAR CHO TỪNG CARD ────────────────────────────────
        private void RegisterCardPaint()
        {
            SetCardAccent(cardPatients, Color.FromArgb(0, 150, 200));
            SetCardAccent(cardAppointments, Color.FromArgb(40, 167, 69));
            SetCardAccent(cardRevenue, Color.FromArgb(255, 140, 0));
            SetCardAccent(cardDoctors, Color.FromArgb(150, 50, 200));
        }

        private void SetCardAccent(Panel card, Color color)
        {
            card.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 230, 245), 1);
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, card.Width - 1, card.Height - 1));
                using var bar = new SolidBrush(color);
                e.Graphics.FillRectangle(bar, 0, 0, 5, card.Height);
            };
        }

        // ── TẢI DỮ LIỆU DASHBOARD ──────────────────────────────────
        private async Task LoadDashboard()
        {
            try
            {
                var taskUsers = ApiClient.GetAsync<List<User>>("api/Users");
                var taskDoctors = ApiClient.GetAsync<List<Doctor>>("api/Doctors");
                var taskAppointments = ApiClient.GetAsync<List<Appointment>>("api/Appointments");
                var taskInvoices = ApiClient.GetAsync<List<Invoice>>("api/Invoices");

                await Task.WhenAll(taskUsers, taskDoctors, taskAppointments, taskInvoices);

                var users = taskUsers.Result ?? new List<User>();
                var doctors = taskDoctors.Result ?? new List<Doctor>();
                var appointments = taskAppointments.Result ?? new List<Appointment>();
                var invoices = taskInvoices.Result ?? new List<Invoice>();

                // ── 4 Metric cards ────────────────────────────────
                lblCardP_Value.Text = users.Count(u => u.RoleID == 3).ToString();

                int todayAppt = appointments.Count(a => a.AppointmentDate.Date == DateTime.Today);
                lblCardA_Value.Text = todayAppt.ToString();

                decimal revenue = invoices
                    .Where(i => i.PaymentDate?.Month == DateTime.Today.Month
                             && i.PaymentDate?.Year == DateTime.Today.Year
                             && i.Status == "Paid")
                    .Sum(i => i.TotalAmount);
                lblCardR_Value.Text = revenue > 0 ? $"{revenue / 1_000_000:F1}M" : "0";

                lblCardD_Value.Text = doctors.Count(d => d.IsActive == true).ToString();

                // ── Dữ liệu biểu đồ cột: lịch hẹn 7 ngày ────────
                for (int i = 0; i < 7; i++)
                {
                    _appt7Labels[i] = DateTime.Today.AddDays(i - 6);
                    _appt7Days[i] = appointments.Count(a =>
                        a.AppointmentDate.Date == _appt7Labels[i]);
                }

                // ── Dữ liệu biểu đồ tròn: trạng thái hôm nay ────
                _statusCounts = appointments
                    .Where(a => a.AppointmentDate.Date == DateTime.Today)
                    .GroupBy(a => a.Status)
                    .ToDictionary(g => g.Key, g => g.Count());

                // ── Dữ liệu biểu đồ đường: doanh thu 6 tháng ────
                for (int i = 0; i < 6; i++)
                {
                    var month = DateTime.Today.AddMonths(i - 5);
                    _revenue6Labels[i] = $"T{month.Month}";
                    _revenue6Months[i] = invoices
                        .Where(inv => inv.PaymentDate?.Month == month.Month
                                   && inv.PaymentDate?.Year == month.Year
                                   && inv.Status == "Paid")
                        .Sum(inv => inv.TotalAmount) / 1_000_000m;
                }

                // ── Danh sách lịch hẹn hôm nay ───────────────────
                lstActivity.Items.Clear();
                var todayList = appointments
                    .Where(a => a.AppointmentDate.Date == DateTime.Today)
                    .OrderBy(a => a.AppointmentDate)
                    .ToList();

                if (todayList.Count == 0)
                {
                    lstActivity.Items.Add("Không có lịch hẹn hôm nay");
                }
                else
                {
                    foreach (var a in todayList)
                    {
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
                        string patient = a.Patient?.FullName ?? $"BN#{a.PatientID}";
                        lstActivity.Items.Add(
                            $"{icon}  {a.AppointmentDate:HH:mm}  {patient}");
                    }
                }

                // Vẽ lại 3 biểu đồ
                chartBar.Invalidate();
                chartPie.Invalidate();
                chartLine.Invalidate();
            }
            catch (Exception ex)
            {
                foreach (var lbl in new[] { lblCardP_Value, lblCardA_Value,
                                            lblCardR_Value, lblCardD_Value })
                    lbl.Text = "!";
                lstActivity.Items.Add("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // ── BIỂU ĐỒ CỘT — lịch hẹn 7 ngày ─────────────────────────
        private void DrawBarChart(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var pnl = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int pad = 36;
            int right = 10;
            int top = 10;
            int bottom = 28;
            int w = pnl.Width - pad - right;
            int h = pnl.Height - top - bottom;
            int maxVal = _appt7Days.Length > 0 ? Math.Max(_appt7Days.Max(), 1) : 1;
            float barW = w / (float)_appt7Days.Length;

            // Đường kẻ ngang mờ
            using var gridPen = new Pen(Color.FromArgb(30, 0, 0, 0), 1);
            for (int step = 0; step <= 4; step++)
            {
                int y = top + (int)(h * step / 4f);
                g.DrawLine(gridPen, pad, y, pad + w, y);
                int val = maxVal - (int)(maxVal * step / 4f);
                using var fnt = new Font("Segoe UI", 7.5f);
                g.DrawString(val.ToString(), fnt,
                    Brushes.Gray, 0, y - 7);
            }

            // Cột
            using var barBrush = new SolidBrush(Color.FromArgb(55, 138, 221));
            using var barHover = new SolidBrush(Color.FromArgb(24, 95, 165));
            using var lblFont = new Font("Segoe UI", 7.5f);

            for (int i = 0; i < _appt7Days.Length; i++)
            {
                float barH = h * (_appt7Days[i] / (float)maxVal);
                float x = pad + i * barW + barW * 0.15f;
                float actualW = barW * 0.7f;
                float y = top + h - barH;

                // Bo góc trên
                using var path = new GraphicsPath();
                int radius = 4;
                path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
                path.AddArc(x + actualW - radius * 2, y, radius * 2, radius * 2, 270, 90);
                path.AddLine(x + actualW, y + barH, x, y + barH);
                path.CloseFigure();
                g.FillPath(barBrush, path);

                // Giá trị trên đỉnh cột
                if (_appt7Days[i] > 0)
                    g.DrawString(_appt7Days[i].ToString(), lblFont,
                        Brushes.DimGray, x + actualW / 2 - 5, y - 14);

                // Nhãn ngày dưới cột
                string label = _appt7Labels[i].ToString("dd/MM");
                g.DrawString(label, lblFont, Brushes.Gray,
                    x + actualW / 2 - 14, top + h + 6);
            }

            // Trục Y
            using var axisPen = new Pen(Color.FromArgb(60, 0, 0, 0), 1);
            g.DrawLine(axisPen, pad, top, pad, top + h);
        }

        // ── BIỂU ĐỒ TRÒN — trạng thái lịch hẹn ─────────────────────
        private void DrawPieChart(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var pnl = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Màu & nhãn cho từng trạng thái
            var statusConfig = new Dictionary<string, (Color color, string label)>
            {
                ["Completed"] = (Color.FromArgb(40, 167, 69), "Hoàn thành"),
                ["Confirmed"] = (Color.FromArgb(55, 138, 221), "Đã xác nhận"),
                ["Examining"] = (Color.FromArgb(150, 50, 200), "Đang khám"),
                ["WaitingForPayment"] = (Color.FromArgb(255, 140, 0), "Chờ thanh toán"),
                ["Pending"] = (Color.FromArgb(150, 160, 180), "Chờ xác nhận"),
                ["Cancelled"] = (Color.FromArgb(220, 53, 69), "Đã huỷ"),
            };

            // Gộp dữ liệu thực, bỏ trạng thái = 0
            var data = statusConfig
                .Where(kv => _statusCounts.ContainsKey(kv.Key) && _statusCounts[kv.Key] > 0)
                .Select(kv => (kv.Value.color, kv.Value.label, count: _statusCounts[kv.Key]))
                .ToList();

            if (data.Count == 0)
            {
                data.Add((Color.LightGray, "Không có dữ liệu", 1));
            }

            int total = data.Sum(d => d.count);
            int pieSize = Math.Min(pnl.Height - 20, 150);
            int pieCenterX = 10 + pieSize / 2;
            int pieCenterY = pnl.Height / 2;
            int holeR = pieSize / 4;             // doughnut
            var pieRect = new Rectangle(10, pieCenterY - pieSize / 2, pieSize, pieSize);

            float startAngle = -90f;
            foreach (var (color, label, count) in data)
            {
                float sweep = 360f * count / total;
                using var brush = new SolidBrush(color);
                g.FillPie(brush, pieRect, startAngle, sweep);
                using var pen = new Pen(Color.White, 2);
                g.DrawPie(pen, pieRect, startAngle, sweep);
                startAngle += sweep;
            }

            // Lỗ giữa (doughnut)
            using var holeBrush = new SolidBrush(pnl.BackColor);
            g.FillEllipse(holeBrush,
                pieCenterX - holeR, pieCenterY - holeR,
                holeR * 2, holeR * 2);

            // Tổng ở giữa
            using var totalFont = new Font("Segoe UI", 11f, FontStyle.Bold);
            using var subFont = new Font("Segoe UI", 7.5f);
            var totalStr = total.ToString();
            var sz = g.MeasureString(totalStr, totalFont);
            g.DrawString(totalStr, totalFont, Brushes.DimGray,
                pieCenterX - sz.Width / 2, pieCenterY - sz.Height / 2 - 2);
            var subSz = g.MeasureString("lịch hẹn", subFont);
            g.DrawString("lịch hẹn", subFont, Brushes.Gray,
                pieCenterX - subSz.Width / 2, pieCenterY + sz.Height / 2 - 4);

            // Legend bên phải
            int legendX = 10 + pieSize + 14;
            int legendY = 14;
            using var legendFont = new Font("Segoe UI", 8.5f);
            foreach (var (color, label, count) in data)
            {
                using var br = new SolidBrush(color);
                g.FillRectangle(br, legendX, legendY + 2, 10, 10);
                g.DrawString($"{label}  ({count})", legendFont,
                    Brushes.DimGray, legendX + 14, legendY);
                legendY += 22;
            }
        }

        // ── BIỂU ĐỒ ĐƯỜNG — doanh thu 6 tháng ──────────────────────
        private void DrawLineChart(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var pnl = (Panel)sender;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int pad = 42;
            int right = 12;
            int top = 10;
            int bottom = 24;
            int w = pnl.Width - pad - right;
            int h = pnl.Height - top - bottom;
            float maxVal = _revenue6Months.Length > 0
                ? (float)Math.Max(_revenue6Months.Max(), 1m)
                : 1f;
            float minVal = (float)Math.Max(_revenue6Months.Min() * 0.85m, 0m);
            float range = maxVal - minVal == 0 ? 1 : maxVal - minVal;

            // Grid ngang
            using var gridPen = new Pen(Color.FromArgb(25, 0, 0, 0), 1);
            using var fnt = new Font("Segoe UI", 7.5f);
            for (int step = 0; step <= 4; step++)
            {
                int y = top + (int)(h * step / 4f);
                g.DrawLine(gridPen, pad, y, pad + w, y);
                float val = maxVal - range * step / 4f;
                g.DrawString($"{val:F0}M", fnt, Brushes.Gray, 0, y - 7);
            }

            // Vùng fill dưới đường
            int n = _revenue6Months.Length;
            if (n > 1)
            {
                var fillPath = new GraphicsPath();
                float x0 = pad;
                float y0 = top + h - h * ((float)_revenue6Months[0] - minVal) / range;
                fillPath.StartFigure();
                fillPath.AddLine(x0, top + h, x0, y0);
                for (int i = 1; i < n; i++)
                {
                    float xi = pad + i * (w / (float)(n - 1));
                    float yi = top + h - h * ((float)_revenue6Months[i] - minVal) / range;
                    fillPath.AddLine(xi, yi, xi, yi);
                    if (i < n - 1)
                    {
                        float xNext = pad + (i + 1) * (w / (float)(n - 1));
                        float yNext = top + h - h * ((float)_revenue6Months[i + 1] - minVal) / range;
                        fillPath.AddLine(xi, yi, xNext, yNext);
                    }
                }
                fillPath.AddLine(pad + w, top + h, pad + w, top + h);
                fillPath.CloseFigure();
                using var fillBrush = new SolidBrush(Color.FromArgb(25, 255, 140, 0));
                g.FillPath(fillBrush, fillPath);
            }

            // Đường kẻ + điểm
            using var linePen = new Pen(Color.FromArgb(255, 140, 0), 2.5f);
            using var dotBrush = new SolidBrush(Color.FromArgb(255, 140, 0));
            using var valFont = new Font("Segoe UI", 7.5f);
            linePen.LineJoin = LineJoin.Round;

            PointF? prev = null;
            for (int i = 0; i < n; i++)
            {
                float xi = pad + i * (w / (float)(n - 1));
                float yi = top + h - h * ((float)_revenue6Months[i] - minVal) / range;

                if (prev.HasValue)
                    g.DrawLine(linePen, prev.Value, new PointF(xi, yi));

                g.FillEllipse(dotBrush, xi - 4, yi - 4, 8, 8);
                using var whiteDot = new SolidBrush(Color.White);
                g.FillEllipse(whiteDot, xi - 2, yi - 2, 4, 4);

                // Giá trị trên điểm
                string valStr = $"{_revenue6Months[i]:F1}M";
                var sz = g.MeasureString(valStr, valFont);
                g.DrawString(valStr, valFont, Brushes.DimGray, xi - sz.Width / 2, yi - 16);

                // Nhãn tháng
                var lsz = g.MeasureString(_revenue6Labels[i], valFont);
                g.DrawString(_revenue6Labels[i], valFont, Brushes.Gray,
                    xi - lsz.Width / 2, top + h + 6);

                prev = new PointF(xi, yi);
            }

            // Trục
            using var axisPen = new Pen(Color.FromArgb(60, 0, 0, 0), 1);
            g.DrawLine(axisPen, pad, top, pad, top + h);
        }
    }
}