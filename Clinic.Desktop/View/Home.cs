using Clinic.Desktop.Components;
using Clinic.Desktop.UserControls.Components;
using Clinic.Desktop.View;
using System;
using System.Windows.Forms;

namespace Clinic.Desktop.View
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            // --- Đăng ký sự kiện trực tiếp trong Constructor ---
            btnDashBoard.Click += (s, e) => LoadGiaoDien(1, "Bảng điều khiển");
            btnLichHen.Click += (s, e) => LoadGiaoDien(2, "Quản lý Lịch hẹn");
            btnBenhNhan.Click += (s, e) => LoadGiaoDien(3, "Quản lý Bệnh nhân");
            btnHoSo.Click += (s, e) => LoadGiaoDien(4, "Hồ sơ bệnh án");
            btnHoaDon.Click += (s, e) => LoadGiaoDien(5, "Quản lý Hóa đơn");
            btnDichVu.Click += (s, e) => LoadGiaoDien(6, "Danh mục Dịch vụ");
            btnBacSi.Click += (s, e) => LoadGiaoDien(7, "Danh sách Bác sĩ");
            btnChuyenKhoa.Click += (s, e) => LoadGiaoDien(8, "Chuyên khoa");
            btnTaiKhoan.Click += (s, e) => LoadGiaoDien(9, "Quản lý tài khoản");

            // Hai nút mới
            btnFacility.Click += (s, e) => LoadGiaoDien(10, "Quản lý Cơ sở vật chất");
            btnNews.Click += (s, e) => LoadGiaoDien(11, "Quản lý Tin tức");

            btnLogOut.Click += btnLogOut_Click;

            // Thiết lập ban đầu
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadGiaoDien(1, "Bảng điều khiển");
        }

        private void LoadGiaoDien(int index, string title)
        {
            // pnContent là vùng chứa nội dung bên phải
            pnContent.Controls.Clear();
            UserControl selectedControl = null;

            switch (index)
            {
                case 1:
                    selectedControl = new HomeView();
                    break;
                case 2:
                    selectedControl = new Appointments();
                    break;
                case 3:
                    selectedControl = new Patients();
                    break;
                case 4:
                    selectedControl = new MedicalRecords();
                    break;
                case 5:
                    selectedControl = new Invoice_Management();
                    break;
                case 6:
                    selectedControl = new Service();
                    break;
                case 7:
                    selectedControl = new Doctors();
                    break;
                case 8:
                    selectedControl = new Specialty();
                    break;
                case 9:
                    selectedControl = new UsersManagement();
                    break;
                case 10:
                    selectedControl = new FacilityManagement(); // Nút Cơ sở vật chất
                    break;
                case 11:
                    selectedControl = new NewsManagement(); // Nút Tin tức
                    break;
                default:
                    return;
            }

            if (selectedControl != null)
            {
                selectedControl.Dock = DockStyle.Fill;
                pnContent.Controls.Add(selectedControl);

                // Cập nhật tiêu đề nếu bạn có lblHeaderTitle trên form Home
                // lblHeaderTitle.Text = title.ToUpper(); 
            }
        }

        // --- Các hàm Click cũ (Giữ lại để đảm bảo tính tương thích nếu bạn gọi từ Designer) ---

        private void btnDashBoard_Click(object sender, EventArgs e) => LoadGiaoDien(1, "Bảng điều khiển");
        private void btnLichHen_Click(object sender, EventArgs e) => LoadGiaoDien(2, "Quản lý Lịch hẹn");
        private void btnBenhNhan_Click(object sender, EventArgs e) => LoadGiaoDien(3, "Quản lý Bệnh nhân");
        private void btnHoSo_Click(object sender, EventArgs e) => LoadGiaoDien(4, "Hồ sơ bệnh án");
        private void btnHoaDon_Click(object sender, EventArgs e) => LoadGiaoDien(5, "Quản lý Hóa đơn");
        private void btnDichVu_Click(object sender, EventArgs e) => LoadGiaoDien(6, "Danh mục Dịch vụ");
        private void btnBacSi_Click(object sender, EventArgs e) => LoadGiaoDien(7, "Danh sách Bác sĩ");
        private void btnChuyenKhoa_Click(object sender, EventArgs e) => LoadGiaoDien(8, "Chuyên khoa");
        private void btnTaiKhoan_Click(object sender, EventArgs e) => LoadGiaoDien(9, "Quản lý tài khoản");

        // Hai hàm Click mới
        private void btnFacility_Click(object sender, EventArgs e) => LoadGiaoDien(10, "Quản lý Cơ sở vật chất");
        private void btnNews_Click(object sender, EventArgs e) => LoadGiaoDien(11, "Quản lý Tin tức");

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}