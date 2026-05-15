namespace Clinic.Desktop.UserControls.Components
{
    partial class NewsManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblTitle = new Label();
            dgvNews = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NewsTitle = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            ImageUrl = new DataGridViewTextBoxColumn();
            pnlRight = new Panel();
            lblDetailTitle = new Label();
            lblNewsTitle = new Label();
            txtNewsTitle = new TextBox();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            lblImage = new Label();
            pnlImageUrl = new Panel();
            txtImageUrl = new TextBox();
            btnBrowseImage = new Button();
            lblContent = new Label();
            txtContent = new TextBox();
            pnlButtons = new Panel();
            btnNew = new Button();
            btnSave = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNews).BeginInit();
            pnlRight.SuspendLayout();
            pnlImageUrl.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(235, 245, 255);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(920, 65);
            pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblTitle.Location = new Point(15, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(297, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ TIN TỨC & THÔNG BÁO";
            // 
            // dgvNews
            // 
            dgvNews.AllowUserToAddRows = false;
            dgvNews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNews.BackgroundColor = Color.White;
            dgvNews.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 245, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 80, 150);
            dgvNews.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNews.Columns.AddRange(new DataGridViewColumn[] { ID, NewsTitle, CategoryName, ImageUrl });
            dgvNews.Dock = DockStyle.Fill;
            dgvNews.EnableHeadersVisualStyles = false;
            dgvNews.GridColor = Color.FromArgb(220, 230, 245);
            dgvNews.Location = new Point(0, 65);
            dgvNews.Name = "dgvNews";
            dgvNews.ReadOnly = true;
            dgvNews.RowHeadersVisible = false;
            dgvNews.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNews.Size = new Size(610, 535);
            dgvNews.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Visible = false;
            // 
            // NewsTitle
            // 
            NewsTitle.HeaderText = "Tiêu đề bài viết";
            NewsTitle.Name = "NewsTitle";
            NewsTitle.ReadOnly = true;
            // 
            // CategoryName
            // 
            CategoryName.HeaderText = "Danh mục";
            CategoryName.Name = "CategoryName";
            CategoryName.ReadOnly = true;
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
            pnlRight.Controls.Add(lblDetailTitle);
            pnlRight.Controls.Add(lblNewsTitle);
            pnlRight.Controls.Add(txtNewsTitle);
            pnlRight.Controls.Add(lblCategory);
            pnlRight.Controls.Add(cboCategory);
            pnlRight.Controls.Add(lblImage);
            pnlRight.Controls.Add(pnlImageUrl);
            pnlRight.Controls.Add(lblContent);
            pnlRight.Controls.Add(txtContent);
            pnlRight.Controls.Add(pnlButtons);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(610, 65);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(310, 535);
            pnlRight.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblDetailTitle.Location = new Point(15, 15);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(100, 23);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "NỘI DUNG CHI TIẾT";
            // 
            // lblNewsTitle
            // 
            lblNewsTitle.Location = new Point(15, 55);
            lblNewsTitle.Name = "lblNewsTitle";
            lblNewsTitle.Size = new Size(100, 23);
            lblNewsTitle.TabIndex = 1;
            lblNewsTitle.Text = "Tiêu đề bài viết";
            // 
            // txtNewsTitle
            // 
            txtNewsTitle.BorderStyle = BorderStyle.FixedSingle;
            txtNewsTitle.Location = new Point(15, 76);
            txtNewsTitle.Name = "txtNewsTitle";
            txtNewsTitle.Size = new Size(280, 23);
            txtNewsTitle.TabIndex = 2;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(15, 115);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Danh mục";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new object[] { "Y khoa", "Khuyến mãi", "Thông báo", "Sự kiện" });
            cboCategory.Location = new Point(15, 136);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(280, 23);
            cboCategory.TabIndex = 4;
            // 
            // lblImage
            // 
            lblImage.Location = new Point(15, 175);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(280, 18);
            lblImage.TabIndex = 5;
            lblImage.Text = "Ảnh (URL hoặc đường dẫn)";
            // 
            // pnlImageUrl
            // 
            pnlImageUrl.Controls.Add(txtImageUrl);
            pnlImageUrl.Controls.Add(btnBrowseImage);
            pnlImageUrl.Location = new Point(15, 196);
            pnlImageUrl.Name = "pnlImageUrl";
            pnlImageUrl.Size = new Size(280, 28);
            pnlImageUrl.TabIndex = 6;
            // 
            // txtImageUrl
            // 
            txtImageUrl.BorderStyle = BorderStyle.FixedSingle;
            txtImageUrl.Dock = DockStyle.Fill;
            txtImageUrl.Location = new Point(0, 0);
            txtImageUrl.Name = "txtImageUrl";
            txtImageUrl.PlaceholderText = "URL ảnh...";
            txtImageUrl.Size = new Size(215, 23);
            txtImageUrl.TabIndex = 0;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.BackColor = Color.FromArgb(108, 117, 125);
            btnBrowseImage.Dock = DockStyle.Right;
            btnBrowseImage.FlatStyle = FlatStyle.Flat;
            btnBrowseImage.ForeColor = Color.White;
            btnBrowseImage.Location = new Point(215, 0);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(65, 28);
            btnBrowseImage.TabIndex = 1;
            btnBrowseImage.Text = "Browse";
            btnBrowseImage.UseVisualStyleBackColor = false;
            // 
            // lblContent
            // 
            lblContent.Location = new Point(15, 235);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(100, 23);
            lblContent.TabIndex = 7;
            lblContent.Text = "Nội dung bài viết";
            // 
            // txtContent
            // 
            txtContent.BorderStyle = BorderStyle.FixedSingle;
            txtContent.Location = new Point(15, 256);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(280, 110);
            txtContent.TabIndex = 8;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnNew);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Location = new Point(15, 380);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(280, 150);
            pnlButtons.TabIndex = 9;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(40, 167, 69);
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(0, 0);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(280, 35);
            btnNew.TabIndex = 0;
            btnNew.Text = "＋  ĐĂNG BÀI MỚI";
            btnNew.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 122, 204);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 40);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(280, 35);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾  CẬP NHẬT";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(0, 80);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(280, 30);
            btnClear.TabIndex = 2;
            btnClear.Text = "🔄  Làm mới Form";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(0, 115);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(280, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑  Xóa bài";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // NewsManagement
            // 
            Controls.Add(dgvNews);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
            Name = "NewsManagement";
            Size = new Size(920, 600);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNews).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlImageUrl.ResumeLayout(false);
            pnlImageUrl.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Label lblTitle;
        private DataGridView dgvNews;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NewsTitle;
        private DataGridViewTextBoxColumn CategoryName;
        private DataGridViewTextBoxColumn ImageUrl;
        private Panel pnlRight;
        private Label lblDetailTitle;
        private Label lblNewsTitle;
        private TextBox txtNewsTitle;
        private Label lblCategory;
        private ComboBox cboCategory;
        private Label lblImage;
        private Panel pnlImageUrl;
        private TextBox txtImageUrl;
        private Button btnBrowseImage;
        private Label lblContent;
        private TextBox txtContent;
        private Panel pnlButtons;
        private Button btnNew;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
    }
}