using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Drawing.Printing;

namespace Clinic.Desktop.Components
{
    partial class Appointments
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
            dtpFilterDate = new DateTimePicker();
            lblFilterDate = new Label();
            lblTitle = new Label();
            dgvAppointments = new DataGridView();
            AppointmentID = new DataGridViewTextBoxColumn();
            PatientName = new DataGridViewTextBoxColumn();
            DoctorName = new DataGridViewTextBoxColumn();
            DichVu = new DataGridViewTextBoxColumn();
            AppTime = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            pnlRight = new Panel();
            lblDetailTitle = new Label();
            cboPatient = new ComboBox();
            cboDoctor = new ComboBox();
            cboService = new ComboBox();  // THÊM MỚI
            dtpAppointmentDate = new DateTimePicker();
            cboStatus = new ComboBox();
            txtNotes = new TextBox();
            btnAddNew = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(245, 245, 245);
            pnlTop.Controls.Add(dtpFilterDate);
            pnlTop.Controls.Add(lblFilterDate);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1000, 70);
            pnlTop.TabIndex = 2;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.Format = DateTimePickerFormat.Short;
            dtpFilterDate.Location = new Point(445, 19);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(120, 23);
            dtpFilterDate.TabIndex = 0;
            // 
            // lblFilterDate
            // 
            lblFilterDate.Location = new Point(329, 19);
            lblFilterDate.Name = "lblFilterDate";
            lblFilterDate.Size = new Size(100, 23);
            lblFilterDate.TabIndex = 1;
            lblFilterDate.Text = "Xem theo:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(214, 30);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "QUẢN LÝ LỊCH HẸN";
            // 
            // dgvAppointments
            // 
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { AppointmentID, PatientName, DoctorName, DichVu, AppTime, Status });
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.Location = new Point(0, 70);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(700, 530);
            dgvAppointments.TabIndex = 0;
            // 
            // AppointmentID
            // 
            AppointmentID.HeaderText = "Mã Lịch";
            AppointmentID.Name = "AppointmentID";
            // 
            // PatientName
            // 
            PatientName.HeaderText = "Bệnh Nhân";
            PatientName.Name = "PatientName";
            // 
            // DoctorName
            // 
            DoctorName.HeaderText = "Bác Sĩ";
            DoctorName.Name = "DoctorName";
            // 
            // DichVu
            // 
            DichVu.HeaderText = "Dịch Vụ";
            DichVu.Name = "DichVu";
            // 
            // AppTime
            // 
            AppTime.HeaderText = "Thời Gian";
            AppTime.Name = "AppTime";
            // 
            // Status
            // 
            Status.HeaderText = "Trạng Thái";
            Status.Name = "Status";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Controls.Add(lblDetailTitle);
            pnlRight.Controls.Add(cboPatient);
            pnlRight.Controls.Add(cboDoctor);
            pnlRight.Controls.Add(cboService);         // THÊM MỚI
            pnlRight.Controls.Add(dtpAppointmentDate);
            pnlRight.Controls.Add(cboStatus);
            pnlRight.Controls.Add(txtNotes);
            pnlRight.Controls.Add(btnAddNew);
            pnlRight.Controls.Add(btnAdd);
            pnlRight.Controls.Add(btnUpdate);
            pnlRight.Controls.Add(btnDelete);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(700, 70);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(300, 530);
            pnlRight.TabIndex = 1;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailTitle.Location = new Point(15, 15);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Size = new Size(270, 25);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "THÔNG TIN CHI TIẾT";
            // 
            // cboPatient
            // 
            cboPatient.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboPatient.Location = new Point(15, 50);
            cboPatient.Name = "cboPatient";
            cboPatient.Size = new Size(270, 23);
            cboPatient.TabIndex = 1;
            // 
            // cboDoctor
            // 
            cboDoctor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboDoctor.Location = new Point(15, 85);
            cboDoctor.Name = "cboDoctor";
            cboDoctor.Size = new Size(270, 23);
            cboDoctor.TabIndex = 2;
            // 
            // cboService  ← THÊM MỚI
            // 
            cboService.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboService.Location = new Point(15, 120);
            cboService.Name = "cboService";
            cboService.Size = new Size(270, 23);
            cboService.TabIndex = 3;
            // 
            // dtpAppointmentDate  ← dịch xuống 35px
            // 
            dtpAppointmentDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpAppointmentDate.Format = DateTimePickerFormat.Custom;
            dtpAppointmentDate.Location = new Point(15, 155);
            dtpAppointmentDate.Name = "dtpAppointmentDate";
            dtpAppointmentDate.Size = new Size(270, 23);
            dtpAppointmentDate.TabIndex = 4;
            // 
            // cboStatus  ← dịch xuống 35px
            // 
            cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboStatus.Location = new Point(15, 190);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(270, 23);
            cboStatus.TabIndex = 5;
            // 
            // txtNotes  ← dịch xuống 35px
            // 
            txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNotes.Location = new Point(15, 225);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(270, 80);
            txtNotes.TabIndex = 6;
            // 
            // btnAddNew  ← dịch xuống 35px
            // 
            btnAddNew.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAddNew.BackColor = Color.MediumSeaGreen;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(15, 320);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(270, 35);
            btnAddNew.TabIndex = 7;
            btnAddNew.Text = "+ TẠO MỚI (RESET FORM)";
            btnAddNew.UseVisualStyleBackColor = false;
            // 
            // btnAdd  ← dịch xuống 35px
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(15, 360);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(270, 40);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "LƯU LỊCH HẸN MỚI";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate  ← dịch xuống 35px
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUpdate.BackColor = Color.Orange;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(15, 405);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(270, 40);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "CẬP NHẬT THAY ĐỔI";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete  ← dịch xuống 35px
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.BackColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(15, 450);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(270, 35);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "HỦY LỊCH HẸN";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // Appointments
            // 
            Controls.Add(dgvAppointments);
            Controls.Add(pnlRight);
            Controls.Add(pnlTop);
            Name = "Appointments";
            Size = new Size(1000, 600);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblFilterDate;
        private DateTimePicker dtpFilterDate;
        private DataGridView dgvAppointments;
        private Panel pnlRight;
        private Label lblDetailTitle;
        private ComboBox cboPatient;
        private ComboBox cboDoctor;
        private ComboBox cboService;   // THÊM MỚI
        private ComboBox cboStatus;
        private DateTimePicker dtpAppointmentDate;
        private TextBox txtNotes;
        private Button btnAdd;
        private Button btnDelete;
        private DataGridViewTextBoxColumn AppointmentID;
        private DataGridViewTextBoxColumn PatientName;
        private DataGridViewTextBoxColumn DoctorName;
        private DataGridViewTextBoxColumn DichVu;
        private DataGridViewTextBoxColumn AppTime;
        private DataGridViewTextBoxColumn Status;
        private Button btnUpdate;
        private Button btnAddNew;
    }
}