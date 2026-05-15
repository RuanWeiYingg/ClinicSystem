namespace Clinic.Desktop.DoctorSchedule
{
    partial class MySchedule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblStatus = new Label();
            cboStatusFilter = new ComboBox();
            btnRefresh = new Button();
            dtpScheduleDate = new DateTimePicker();
            lblDate = new Label();
            dgvSchedule = new DataGridView();
            pnlBottom = new Panel();
            btnCancel = new Button();
            btnFinishExam = new Button(); // ✅ Thêm mới
            btnStartExam = new Button();
            AppID = new DataGridViewTextBoxColumn();
            ThoiGian = new DataGridViewTextBoxColumn();
            BenhNhan = new DataGridViewTextBoxColumn();
            LyDo = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();

            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();

            // ── pnlTop ────────────────────────────────────
            pnlTop.Controls.Add(lblStatus);
            pnlTop.Controls.Add(cboStatusFilter);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(dtpScheduleDate);
            pnlTop.Controls.Add(lblDate);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 2, 3, 2);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(831, 52);
            pnlTop.TabIndex = 2;

            // lblStatus
            lblStatus.Location = new Point(265, 16);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(88, 17);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Trạng thái:";

            // cboStatusFilter
            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Location = new Point(359, 14);
            cboStatusFilter.Margin = new Padding(3, 2, 3, 2);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(170, 23);
            cboStatusFilter.TabIndex = 1;

            // btnRefresh
            btnRefresh.BackColor = Color.FromArgb(41, 57, 85);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(551, 12);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 24);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;

            // dtpScheduleDate
            dtpScheduleDate.Format = DateTimePickerFormat.Short;
            dtpScheduleDate.Location = new Point(97, 13);
            dtpScheduleDate.Margin = new Padding(3, 2, 3, 2);
            dtpScheduleDate.Name = "dtpScheduleDate";
            dtpScheduleDate.Size = new Size(132, 23);
            dtpScheduleDate.TabIndex = 3;

            // lblDate
            lblDate.Location = new Point(3, 16);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(88, 17);
            lblDate.TabIndex = 4;
            lblDate.Text = "Chọn ngày:";

            // ── dgvSchedule ───────────────────────────────
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.BorderStyle = BorderStyle.None;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Columns.AddRange(new DataGridViewColumn[]
                { AppID, ThoiGian, BenhNhan, LyDo, TrangThai });
            dgvSchedule.Dock = DockStyle.Fill;
            dgvSchedule.Location = new Point(0, 52);
            dgvSchedule.Margin = new Padding(3, 2, 3, 2);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.Size = new Size(831, 354);
            dgvSchedule.TabIndex = 0;

            // ── pnlBottom ─────────────────────────────────
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(btnCancel);
            pnlBottom.Controls.Add(btnFinishExam); // ✅
            pnlBottom.Controls.Add(btnStartExam);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 406);
            pnlBottom.Margin = new Padding(3, 2, 3, 2);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(831, 52);
            pnlBottom.TabIndex = 1;

            // btnCancel
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.FromArgb(239, 68, 68);
            btnCancel.Location = new Point(390, 11);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Hủy lịch";
            btnCancel.UseVisualStyleBackColor = false;

            // ✅ btnFinishExam — HOÀN TẤT KHÁM (cam)
            btnFinishExam.BackColor = Color.FromArgb(249, 115, 22);
            btnFinishExam.FlatStyle = FlatStyle.Flat;
            btnFinishExam.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFinishExam.ForeColor = Color.White;
            btnFinishExam.Location = new Point(494, 11);
            btnFinishExam.Margin = new Padding(3, 2, 3, 2);
            btnFinishExam.Name = "btnFinishExam";
            btnFinishExam.Size = new Size(158, 30);
            btnFinishExam.TabIndex = 2;
            btnFinishExam.Text = "HOÀN TẤT KHÁM";
            btnFinishExam.UseVisualStyleBackColor = false;

            // btnStartExam — BẮT ĐẦU KHÁM (xanh lá)
            btnStartExam.BackColor = Color.FromArgb(34, 197, 94);
            btnStartExam.FlatStyle = FlatStyle.Flat;
            btnStartExam.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStartExam.ForeColor = Color.White;
            btnStartExam.Location = new Point(660, 11);
            btnStartExam.Margin = new Padding(3, 2, 3, 2);
            btnStartExam.Name = "btnStartExam";
            btnStartExam.Size = new Size(158, 30);
            btnStartExam.TabIndex = 1;
            btnStartExam.Text = "BẮT ĐẦU KHÁM";
            btnStartExam.UseVisualStyleBackColor = false;

            // ── Columns ───────────────────────────────────
            AppID.DataPropertyName = "AppID";
            AppID.HeaderText = "ID";
            AppID.Name = "AppID";
            AppID.Width = 50;

            ThoiGian.DataPropertyName = "ThoiGian";
            ThoiGian.HeaderText = "Thời Gian";
            ThoiGian.Name = "ThoiGian";
            ThoiGian.Width = 90;

            BenhNhan.DataPropertyName = "BenhNhan";
            BenhNhan.HeaderText = "Bệnh Nhân";
            BenhNhan.Name = "BenhNhan";

            LyDo.DataPropertyName = "LyDo";
            LyDo.HeaderText = "Lý Do";
            LyDo.Name = "LyDo";

            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.Name = "TrangThai";
            TrangThai.Width = 140;

            // ── MySchedule ────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvSchedule);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MySchedule";
            Size = new Size(831, 458);

            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblDate;
        private DateTimePicker dtpScheduleDate;
        private Button btnRefresh;
        private ComboBox cboStatusFilter;
        private Label lblStatus;
        private DataGridView dgvSchedule;
        private Panel pnlBottom;
        private Button btnStartExam;
        private Button btnFinishExam; // ✅ Thêm mới
        private Button btnCancel;
        private DataGridViewTextBoxColumn AppID;
        private DataGridViewTextBoxColumn ThoiGian;
        private DataGridViewTextBoxColumn BenhNhan;
        private DataGridViewTextBoxColumn LyDo;
        private DataGridViewTextBoxColumn TrangThai;
    }
}