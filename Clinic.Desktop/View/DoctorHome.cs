using Clinic.Desktop.DoctorSchedule;
using Clinic.Desktop.UserControls.DoctorSchedule;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clinic.Desktop.View
{
    public partial class DoctorHome : Form
    {
        private int _currentDoctorId;

        public DoctorHome(int doctorId)
        {
            InitializeComponent();
            _currentDoctorId = doctorId;

            // --- Đăng ký sự kiện Click cho các nút Menu ---
            btnDashBoard.Click += (s, e) => LoadDoctorView(5, "Trang chủ hệ thống");
            btnMySchedule.Click += (s, e) => LoadDoctorView(1, "Lịch khám hôm nay");
            btnPatients.Click += (s, e) => LoadDoctorView(2, "Danh sách bệnh nhân của tôi");

            // Fix: Truyền _currentDoctorId vào để trang Lịch sử có ID bác sĩ ngay lập tức
            btnMedicalHistory.Click += (s, e) => LoadDoctorView(3, "Tra cứu hồ sơ bệnh án", _currentDoctorId);

            btnProfile.Click += (s, e) => LoadDoctorView(4, "Hồ sơ cá nhân & Chuyên khoa");
            btnLogOut.Click += BtnLogOut_Click;

            this.StartPosition = FormStartPosition.CenterScreen;

            // Mặc định load DashBoard khi vừa đăng nhập xong
            LoadDoctorView(5, "Trang chủ hệ thống");
        }

        /// <summary>
        /// Hàm điều hướng chính giữa các chức năng của Bác sĩ
        /// </summary>
        /// <param name="index">Chỉ số trang (1-6)</param>
        /// <param name="title">Tiêu đề hiển thị trên Header</param>
        /// <param name="idValue">ID bổ trợ (AppointmentID khi khám, hoặc PatientID khi xem hồ sơ riêng)</param>
        public void LoadDoctorView(int index, string title, int idValue = 0)
        {
            lblTitle.Text = title.ToUpper();
            HighlightDoctorButton(index);

            // Dọn dẹp vùng nội dung cũ để giải phóng bộ nhớ
            pnContent.Controls.Clear();
            UserControl view = null;

            switch (index)
            {
                case 1:
                    // Lịch khám: Dùng ID bác sĩ đang đăng nhập
                    view = new MySchedule(_currentDoctorId);
                    break;
                case 2:
                    // Danh sách bệnh nhân: Dùng ID bác sĩ đang đăng nhập
                    view = new Patients(_currentDoctorId);
                    break;
                case 3:
                    // TRANG LỊCH SỬ BỆNH ÁN
                    // Ưu tiên dùng idValue nếu có (xem cụ thể 1 người), 
                    // nếu không thì dùng _currentDoctorId (xem tất cả ca của bác sĩ này)
                    int targetId = (idValue > 0) ? idValue : _currentDoctorId;
                    view = new MedicalHistory(targetId);
                    break;
                case 4:
                    // Hồ sơ cá nhân bác sĩ
                    view = new Profile(_currentDoctorId);
                    break;
                case 5:
                    // Dashboard tổng quan
                    view = new DashBoard(_currentDoctorId);
                    break;
                case 6:
                    // TIẾN HÀNH KHÁM: idValue lúc này bắt buộc là AppointmentID truyền từ MySchedule
                    view = new Examination(idValue);
                    break;
            }

            if (view != null)
            {
                view.Dock = DockStyle.Fill;
                pnContent.Controls.Add(view);
            }
        }

        /// <summary>
        /// Hiệu ứng đổi màu nút Menu khi đang ở trang tương ứng
        /// </summary>
        private void HighlightDoctorButton(int index)
        {
            foreach (Control ctrl in pnSideBar.Controls)
            {
                if (ctrl is Button btn && btn != btnLogOut)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.White;
                }
            }

            Button selected = index switch
            {
                1 => btnMySchedule,
                2 => btnPatients,
                3 => btnMedicalHistory,
                4 => btnProfile,
                5 => btnDashBoard,
                6 => btnMySchedule, // Đang khám vẫn sáng nút Lịch trình
                _ => null
            };

            if (selected != null)
            {
                selected.BackColor = Color.FromArgb(51, 65, 85);
                selected.ForeColor = Color.Cyan;
            }
        }

        /// <summary>
        /// Xử lý Đăng xuất: Ẩn form hiện tại và hiện Form Login
        /// </summary>
        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                // Đảm bảo khi đóng Login thì ứng dụng thoát hẳn, tránh chạy ngầm
                loginForm.FormClosed += (s, args) => Application.Exit();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}