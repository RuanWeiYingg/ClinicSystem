namespace Clinic.Desktop.Components
{
    partial class Invoice_Management
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            pnlTop = new Panel();
            cboStatusFilter = new ComboBox();
            txtSearchInvoice = new TextBox();
            lblTitle = new Label();
            pnlMain = new Panel();
            dgvInvoices = new DataGridView();
            colInvoiceID = new DataGridViewTextBoxColumn();
            colPatientName = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            colPaymentDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlRight = new Panel();
            lblInvoiceDetail = new Label();
            lblPatientName = new Label();
            lblServiceName = new Label();      // THÊM MỚI
            lblTotalAmount = new Label();
            lblAmountEdit = new Label();
            nudAmount = new NumericUpDown();
            lblDate = new Label();
            pnlButtons = new Panel();
            btnConfirmPayment = new Button();
            btnPrintInvoice = new Button();

            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // ── pnlTop ──────────────────────────────────────
            pnlTop.BackColor = Color.FromArgb(245, 245, 245);
            pnlTop.Controls.Add(cboStatusFilter);
            pnlTop.Controls.Add(txtSearchInvoice);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 70;
            pnlTop.Name = "pnlTop";

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 20);
            lblTitle.Text = "QUẢN LÝ HÓA ĐƠN";

            txtSearchInvoice.Location = new Point(350, 22);
            txtSearchInvoice.PlaceholderText = "Mã HĐ hoặc Tên BN...";
            txtSearchInvoice.Size = new Size(220, 23);
            txtSearchInvoice.Name = "txtSearchInvoice";

            cboStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Chưa thanh toán", "Đã thanh toán" });
            cboStatusFilter.Location = new Point(580, 22);
            cboStatusFilter.Size = new Size(160, 23);
            cboStatusFilter.Name = "cboStatusFilter";

            // ── pnlMain (chứa grid + panel phải, Dock Fill) ──
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(dgvInvoices);
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Name = "pnlMain";

            // ── pnlRight (Dock Right, tự co giãn) ────────────
            pnlRight.BackColor = Color.FromArgb(250, 250, 250);
            pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Dock = DockStyle.Right;  // FIX: Dock thay vì Location cứng
            pnlRight.Width = 310;
            pnlRight.Padding = new Padding(15);
            pnlRight.Name = "pnlRight";
            pnlRight.Controls.Add(pnlButtons);
            pnlRight.Controls.Add(nudAmount);
            pnlRight.Controls.Add(lblAmountEdit);
            pnlRight.Controls.Add(lblDate);
            pnlRight.Controls.Add(lblTotalAmount);
            pnlRight.Controls.Add(lblServiceName);
            pnlRight.Controls.Add(lblPatientName);
            pnlRight.Controls.Add(lblInvoiceDetail);

            // ── Labels trong pnlRight ─────────────────────────
            lblInvoiceDetail.Dock = DockStyle.Top;
            lblInvoiceDetail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInvoiceDetail.Height = 40;
            lblInvoiceDetail.Padding = new Padding(0, 10, 0, 0);
            lblInvoiceDetail.Text = "CHI TIẾT THANH TOÁN";
            lblInvoiceDetail.Name = "lblInvoiceDetail";

            lblPatientName.Dock = DockStyle.Top;
            lblPatientName.Height = 28;
            lblPatientName.Font = new Font("Segoe UI", 10F);
            lblPatientName.Text = "Bệnh nhân: ---";
            lblPatientName.Name = "lblPatientName";

            lblServiceName.Dock = DockStyle.Top;
            lblServiceName.Height = 28;
            lblServiceName.Font = new Font("Segoe UI", 10F);
            lblServiceName.Text = "Dịch vụ: ---";
            lblServiceName.Name = "lblServiceName";

            lblTotalAmount.Dock = DockStyle.Top;
            lblTotalAmount.Height = 30;
            lblTotalAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.DarkRed;
            lblTotalAmount.Text = "Tổng tiền: ---";
            lblTotalAmount.Name = "lblTotalAmount";

            lblAmountEdit.Dock = DockStyle.Top;
            lblAmountEdit.Height = 20;
            lblAmountEdit.Font = new Font("Segoe UI", 9F);
            lblAmountEdit.ForeColor = Color.FromArgb(107, 114, 128);
            lblAmountEdit.Text = "Điều chỉnh số tiền nếu cần:";
            lblAmountEdit.Name = "lblAmountEdit";
            lblAmountEdit.Visible = false;

            nudAmount.Dock = DockStyle.Top;
            nudAmount.Height = 30;
            nudAmount.DecimalPlaces = 0;
            nudAmount.Increment = 10000;
            nudAmount.Maximum = 100000000;
            nudAmount.Minimum = 0;
            nudAmount.ThousandsSeparator = true;
            nudAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            nudAmount.ForeColor = Color.DarkRed;
            nudAmount.Name = "nudAmount";
            nudAmount.Visible = false;

            lblDate.Dock = DockStyle.Top;
            lblDate.Height = 28;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.Text = "Ngày lập: ---";
            lblDate.Name = "lblDate";

            // ── pnlButtons (Dock Bottom trong pnlRight) ────────
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Height = 105;
            pnlButtons.Padding = new Padding(0, 5, 0, 5);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Controls.Add(btnConfirmPayment);
            pnlButtons.Controls.Add(btnPrintInvoice);

            btnPrintInvoice.Dock = DockStyle.Top;
            btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            btnPrintInvoice.Height = 40;
            btnPrintInvoice.Text = "IN HÓA ĐƠN (PDF)";
            btnPrintInvoice.Font = new Font("Segoe UI", 9F);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Enabled = false;

            btnConfirmPayment.Dock = DockStyle.Bottom;
            btnConfirmPayment.BackColor = Color.OrangeRed;
            btnConfirmPayment.FlatStyle = FlatStyle.Flat;
            btnConfirmPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmPayment.ForeColor = Color.White;
            btnConfirmPayment.Height = 50;
            btnConfirmPayment.Text = "XÁC NHẬN THANH TOÁN";
            btnConfirmPayment.Name = "btnConfirmPayment";
            btnConfirmPayment.UseVisualStyleBackColor = false;
            btnConfirmPayment.Enabled = false;

            // ── dgvInvoices (Dock Fill trong pnlMain) ─────────
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.BackgroundColor = Color.White;
            dgvInvoices.Columns.AddRange(new DataGridViewColumn[] {
                colInvoiceID, colPatientName, colTotalAmount, colPaymentDate, colStatus });
            dgvInvoices.Dock = DockStyle.Fill;  // FIX: Fill thay vì Size cứng
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowHeadersVisible = false;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            colInvoiceID.HeaderText = "Mã HĐ"; colInvoiceID.Name = "colInvoiceID"; colInvoiceID.ReadOnly = true;
            colPatientName.HeaderText = "Bệnh nhân"; colPatientName.Name = "colPatientName"; colPatientName.ReadOnly = true;
            colTotalAmount.HeaderText = "Tổng tiền"; colTotalAmount.Name = "colTotalAmount"; colTotalAmount.ReadOnly = true;
            colPaymentDate.HeaderText = "Ngày lập"; colPaymentDate.Name = "colPaymentDate"; colPaymentDate.ReadOnly = true;
            colStatus.HeaderText = "Trạng thái"; colStatus.Name = "colStatus"; colStatus.ReadOnly = true;

            // ── UserControl ──────────────────────────────────
            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            Name = "Invoice_Management";
            Size = new Size(1000, 600);

            pnlButtons.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            pnlMain.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private TextBox txtSearchInvoice;
        private ComboBox cboStatusFilter;
        private Panel pnlMain;
        private DataGridView dgvInvoices;
        private Panel pnlRight;
        private Label lblInvoiceDetail;
        private Label lblPatientName;
        private Label lblServiceName;      // THÊM MỚI
        private Label lblTotalAmount;
        private Label lblAmountEdit;
        private NumericUpDown nudAmount;
        private Label lblDate;
        private Panel pnlButtons;
        private Button btnConfirmPayment;
        private Button btnPrintInvoice;
        private DataGridViewTextBoxColumn colInvoiceID;
        private DataGridViewTextBoxColumn colPatientName;
        private DataGridViewTextBoxColumn colTotalAmount;
        private DataGridViewTextBoxColumn colPaymentDate;
        private DataGridViewTextBoxColumn colStatus;
    }
}