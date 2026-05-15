namespace Clinic.Desktop.Components
{
    partial class Service
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblTitle = new Label();
            txtSearchService = new TextBox();
            btnSearch = new Button();
            dgvServices = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ServiceName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Duration = new DataGridViewTextBoxColumn();
            ImageUrl = new DataGridViewTextBoxColumn();
            pnlRight = new Panel();
            lblServiceDetail = new Label();
            lblName = new Label();
            txtServiceName = new TextBox();
            lblPrice = new Label();
            txtServicePrice = new TextBox();
            lblDuration = new Label();
            txtDuration = new TextBox();
            lblImage = new Label();
            pnlImageUrl = new Panel();
            txtImageUrl = new TextBox();
            btnBrowseImage = new Button();
            pnlButtons = new Panel();
            btnNew = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            txtDescription = new TextBox();
            lblDescCount = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            pnlRight.SuspendLayout();
            pnlImageUrl.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(235, 245, 255);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(txtSearchService);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(950, 65);
            pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblTitle.Location = new Point(15, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(202, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "DANH MỤC DỊCH VỤ";
            // 
            // txtSearchService
            // 
            txtSearchService.Font = new Font("Segoe UI", 10F);
            txtSearchService.Location = new Point(350, 20);
            txtSearchService.Name = "txtSearchService";
            txtSearchService.PlaceholderText = "Tìm tên dịch vụ...";
            txtSearchService.Size = new Size(250, 25);
            txtSearchService.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 122, 204);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(610, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 28);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 Tìm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServices.BackgroundColor = Color.White;
            dgvServices.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 80, 150);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvServices.Columns.AddRange(new DataGridViewColumn[] { ID, ServiceName, Price, Duration, ImageUrl });
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.EnableHeadersVisualStyles = false;
            dgvServices.Font = new Font("Segoe UI", 9.5F);
            dgvServices.GridColor = Color.FromArgb(220, 230, 245);
            dgvServices.Location = new Point(0, 65);
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersVisible = false;
            dgvServices.RowTemplate.Height = 32;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(660, 635);
            dgvServices.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // ServiceName
            // 
            ServiceName.HeaderText = "Tên Dịch Vụ";
            ServiceName.Name = "ServiceName";
            ServiceName.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Đơn Giá (VNĐ)";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Duration
            // 
            Duration.HeaderText = "Thời gian (Phút)";
            Duration.Name = "Duration";
            Duration.ReadOnly = true;
            // 
            // ImageUrl
            // 
            ImageUrl.HeaderText = "Ảnh (URL)";
            ImageUrl.Name = "ImageUrl";
            ImageUrl.ReadOnly = true;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(248, 250, 253);
            pnlRight.Controls.Add(lblServiceDetail);
            pnlRight.Controls.Add(lblName);
            pnlRight.Controls.Add(txtServiceName);
            pnlRight.Controls.Add(lblPrice);
            pnlRight.Controls.Add(txtServicePrice);
            pnlRight.Controls.Add(lblDuration);
            pnlRight.Controls.Add(txtDuration);
            pnlRight.Controls.Add(lblImage);
            pnlRight.Controls.Add(pnlImageUrl);
            pnlRight.Controls.Add(pnlButtons);
            pnlRight.Controls.Add(txtDescription);
            pnlRight.Controls.Add(lblDescCount);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(660, 65);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(290, 635);
            pnlRight.TabIndex = 1;
            // 
            // lblServiceDetail
            // 
            lblServiceDetail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblServiceDetail.ForeColor = Color.FromArgb(30, 80, 150);
            lblServiceDetail.Location = new Point(15, 15);
            lblServiceDetail.Name = "lblServiceDetail";
            lblServiceDetail.Size = new Size(260, 28);
            lblServiceDetail.TabIndex = 0;
            lblServiceDetail.Text = "THÔNG TIN DỊCH VỤ";
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI", 9F);
            lblName.ForeColor = Color.FromArgb(80, 80, 80);
            lblName.Location = new Point(15, 55);
            lblName.Name = "lblName";
            lblName.Size = new Size(260, 18);
            lblName.TabIndex = 1;
            lblName.Text = "Tên dịch vụ";
            // 
            // txtServiceName
            // 
            txtServiceName.BorderStyle = BorderStyle.FixedSingle;
            txtServiceName.Font = new Font("Segoe UI", 10F);
            txtServiceName.Location = new Point(15, 76);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.PlaceholderText = "Nhập tên dịch vụ...";
            txtServiceName.Size = new Size(260, 25);
            txtServiceName.TabIndex = 2;
            // 
            // lblPrice
            // 
            lblPrice.Font = new Font("Segoe UI", 9F);
            lblPrice.ForeColor = Color.FromArgb(80, 80, 80);
            lblPrice.Location = new Point(15, 115);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(260, 18);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Đơn giá (VNĐ)";
            // 
            // txtServicePrice
            // 
            txtServicePrice.BorderStyle = BorderStyle.FixedSingle;
            txtServicePrice.Font = new Font("Segoe UI", 10F);
            txtServicePrice.Location = new Point(15, 136);
            txtServicePrice.Name = "txtServicePrice";
            txtServicePrice.PlaceholderText = "Ví dụ: 150000";
            txtServicePrice.Size = new Size(260, 25);
            txtServicePrice.TabIndex = 4;
            // 
            // lblDuration
            // 
            lblDuration.Font = new Font("Segoe UI", 9F);
            lblDuration.ForeColor = Color.FromArgb(80, 80, 80);
            lblDuration.Location = new Point(15, 175);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(260, 18);
            lblDuration.TabIndex = 5;
            lblDuration.Text = "Thời gian (Phút)";
            // 
            // txtDuration
            // 
            txtDuration.BorderStyle = BorderStyle.FixedSingle;
            txtDuration.Font = new Font("Segoe UI", 10F);
            txtDuration.Location = new Point(15, 196);
            txtDuration.Name = "txtDuration";
            txtDuration.PlaceholderText = "Ví dụ: 30";
            txtDuration.Size = new Size(260, 25);
            txtDuration.TabIndex = 6;
            // 
            // lblImage
            // 
            lblImage.Font = new Font("Segoe UI", 9F);
            lblImage.ForeColor = Color.FromArgb(80, 80, 80);
            lblImage.Location = new Point(15, 235);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(260, 18);
            lblImage.TabIndex = 7;
            lblImage.Text = "Ảnh (URL hoặc đường dẫn)";
            // 
            // pnlImageUrl
            // 
            pnlImageUrl.Controls.Add(txtImageUrl);
            pnlImageUrl.Controls.Add(btnBrowseImage);
            pnlImageUrl.Location = new Point(15, 256);
            pnlImageUrl.Name = "pnlImageUrl";
            pnlImageUrl.Size = new Size(260, 28);
            pnlImageUrl.TabIndex = 8;
            // 
            // txtImageUrl
            // 
            txtImageUrl.BorderStyle = BorderStyle.FixedSingle;
            txtImageUrl.Dock = DockStyle.Fill;
            txtImageUrl.Font = new Font("Segoe UI", 9F);
            txtImageUrl.Location = new Point(0, 0);
            txtImageUrl.Name = "txtImageUrl";
            txtImageUrl.PlaceholderText = "URL ảnh...";
            txtImageUrl.Size = new Size(195, 23);
            txtImageUrl.TabIndex = 0;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BackColor = Color.FromArgb(108, 117, 125);
            btnBrowseImage.Cursor = Cursors.Hand;
            btnBrowseImage.Dock = DockStyle.Right;
            btnBrowseImage.FlatAppearance.BorderSize = 0;
            btnBrowseImage.FlatStyle = FlatStyle.Flat;
            btnBrowseImage.Font = new Font("Segoe UI", 8.5F);
            btnBrowseImage.ForeColor = Color.White;
            btnBrowseImage.Location = new Point(195, 0);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(65, 28);
            btnBrowseImage.TabIndex = 1;
            btnBrowseImage.Text = "Browse";
            btnBrowseImage.UseVisualStyleBackColor = false;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.Transparent;
            pnlButtons.Controls.Add(btnNew);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Location = new Point(15, 419);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(260, 150);
            pnlButtons.TabIndex = 9;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(40, 167, 69);
            btnNew.Cursor = Cursors.Hand;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(0, 4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(260, 40);
            btnNew.TabIndex = 0;
            btnNew.Text = "＋  THÊM MỚI";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 50);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(260, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾  LƯU DỊCH VỤ";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 100);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(260, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🚫  NGỪNG CUNG CẤP";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtDescription
            // 
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(15, 290);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Nhập mô tả dịch vụ...";
            txtDescription.Size = new Size(260, 123);
            txtDescription.TabIndex = 8;
            // 
            // lblDescCount
            // 
            lblDescCount.AutoSize = true;
            lblDescCount.Font = new Font("Segoe UI", 8F);
            lblDescCount.ForeColor = Color.Gray;
            lblDescCount.Location = new Point(220, 494);
            lblDescCount.Name = "lblDescCount";
            lblDescCount.Size = new Size(41, 13);
            lblDescCount.TabIndex = 10;
            lblDescCount.Text = "0/1000";
            // 
            // Service
            // 
            Controls.Add(dgvServices);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
            Name = "Service";
            Size = new Size(950, 700);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlImageUrl.ResumeLayout(false);
            pnlImageUrl.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        // =====================================================
        // KHAI BÁO BIẾN
        // =====================================================
        private Panel pnlTop;
        private Label lblTitle;
        private TextBox txtSearchService;
        private Button btnSearch;

        private DataGridView dgvServices;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ServiceName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Duration;
        private DataGridViewTextBoxColumn ImageUrl;

        private Panel pnlRight;
        private Label lblServiceDetail;
        private Label lblName;
        private TextBox txtServiceName;
        private Label lblPrice;
        private TextBox txtServicePrice;
        private Label lblDuration;
        private TextBox txtDuration;
        private Label lblImage;
        private Panel pnlImageUrl;
        private TextBox txtImageUrl;
        private Button btnBrowseImage;

        private Panel pnlButtons;
        private Button btnNew;
        private Button btnSave;
        private Button btnDelete;
        private TextBox txtDescription; // Thêm dòng này
        private Label lblDescCount;     // Thêm dòng này
    }
}