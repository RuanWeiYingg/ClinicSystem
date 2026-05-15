namespace Clinic.Desktop.UserControls.DoctorSchedule
{
    partial class DashBoard : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tlpMain = new System.Windows.Forms.TableLayoutPanel();
            tlpCards = new System.Windows.Forms.TableLayoutPanel();

            pnlCard1 = new System.Windows.Forms.Panel();
            lblCountApp = new System.Windows.Forms.Label();
            lblTitleApp = new System.Windows.Forms.Label();

            pnlCard2 = new System.Windows.Forms.Panel();
            lblCountWaiting = new System.Windows.Forms.Label();
            lblTitleWaiting = new System.Windows.Forms.Label();

            pnlCard3 = new System.Windows.Forms.Panel();
            lblCountRevenue = new System.Windows.Forms.Label();
            lblTitleRevenue = new System.Windows.Forms.Label();

            tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            pnlLeftTable = new System.Windows.Forms.Panel();
            dgvWaiting = new System.Windows.Forms.DataGridView();
            lblTableTitle = new System.Windows.Forms.Label();
            pnlRightNoti = new System.Windows.Forms.Panel();
            flpNotifications = new System.Windows.Forms.FlowLayoutPanel();
            lblNotiTitle = new System.Windows.Forms.Label();

            tlpMain.SuspendLayout();
            tlpCards.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            tlpBottom.SuspendLayout();
            pnlLeftTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWaiting).BeginInit();
            pnlRightNoti.SuspendLayout();
            SuspendLayout();

            // ── tlpMain ───────────────────────────────────────────
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 100F));
            tlpMain.Controls.Add(tlpCards, 0, 0);
            tlpMain.Controls.Add(tlpBottom, 0, 1);
            tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Absolute, 120F));
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 100F));

            // ── tlpCards ──────────────────────────────────────────
            tlpCards.ColumnCount = 3;
            tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 33.33F));
            tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 33.33F));
            tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 33.33F));
            tlpCards.Controls.Add(pnlCard1, 0, 0);
            tlpCards.Controls.Add(pnlCard2, 1, 0);
            tlpCards.Controls.Add(pnlCard3, 2, 0);
            tlpCards.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 100F));

            // ── Card 1: Lịch hẹn hôm nay ─────────────────────────
            pnlCard1.BackColor = System.Drawing.Color.FromArgb(30, 100, 200);
            pnlCard1.Controls.Add(lblCountApp);
            pnlCard1.Controls.Add(lblTitleApp);
            pnlCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard1.Margin = new System.Windows.Forms.Padding(8);
            pnlCard1.Padding = new System.Windows.Forms.Padding(12);

            lblTitleApp.Text = "📅  LỊCH HẸN HÔM NAY";
            lblTitleApp.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            lblTitleApp.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                System.Drawing.FontStyle.Bold);
            lblTitleApp.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitleApp.Height = 30;
            lblTitleApp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            lblCountApp.Text = "---";
            lblCountApp.ForeColor = System.Drawing.Color.White;
            lblCountApp.Font = new System.Drawing.Font("Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);
            lblCountApp.Location = new System.Drawing.Point(12, 38);
            lblCountApp.AutoSize = true;

            // ── Card 2: Bệnh nhân đang đợi ───────────────────────
            pnlCard2.BackColor = System.Drawing.Color.FromArgb(200, 100, 20);
            pnlCard2.Controls.Add(lblCountWaiting);
            pnlCard2.Controls.Add(lblTitleWaiting);
            pnlCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard2.Margin = new System.Windows.Forms.Padding(8);
            pnlCard2.Padding = new System.Windows.Forms.Padding(12);

            lblTitleWaiting.Text = "⏳  ĐANG CHỜ KHÁM";
            lblTitleWaiting.ForeColor = System.Drawing.Color.FromArgb(255, 220, 180);
            lblTitleWaiting.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                System.Drawing.FontStyle.Bold);
            lblTitleWaiting.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitleWaiting.Height = 30;
            lblTitleWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            lblCountWaiting.Text = "---";
            lblCountWaiting.ForeColor = System.Drawing.Color.White;
            lblCountWaiting.Font = new System.Drawing.Font("Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);
            lblCountWaiting.Location = new System.Drawing.Point(12, 38);
            lblCountWaiting.AutoSize = true;

            // ── Card 3: Đã hoàn thành ─────────────────────────────
            pnlCard3.BackColor = System.Drawing.Color.FromArgb(30, 150, 80);
            pnlCard3.Controls.Add(lblCountRevenue);
            pnlCard3.Controls.Add(lblTitleRevenue);
            pnlCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlCard3.Margin = new System.Windows.Forms.Padding(8);
            pnlCard3.Padding = new System.Windows.Forms.Padding(12);

            lblTitleRevenue.Text = "✅  ĐÃ HOÀN THÀNH";
            lblTitleRevenue.ForeColor = System.Drawing.Color.FromArgb(180, 240, 200);
            lblTitleRevenue.Font = new System.Drawing.Font("Segoe UI", 9.5F,
                System.Drawing.FontStyle.Bold);
            lblTitleRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitleRevenue.Height = 30;
            lblTitleRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            lblCountRevenue.Text = "---";
            lblCountRevenue.ForeColor = System.Drawing.Color.White;
            lblCountRevenue.Font = new System.Drawing.Font("Segoe UI", 30F,
                System.Drawing.FontStyle.Bold);
            lblCountRevenue.Location = new System.Drawing.Point(12, 38);
            lblCountRevenue.AutoSize = true;

            // ── tlpBottom ─────────────────────────────────────────
            tlpBottom.ColumnCount = 2;
            tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 65F));
            tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
                System.Windows.Forms.SizeType.Percent, 35F));
            tlpBottom.Controls.Add(pnlLeftTable, 0, 0);
            tlpBottom.Controls.Add(pnlRightNoti, 1, 0);
            tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(
                System.Windows.Forms.SizeType.Percent, 100F));

            // ── Panel trái — Danh sách chờ khám ──────────────────
            pnlLeftTable.BackColor = System.Drawing.Color.White;
            pnlLeftTable.Controls.Add(dgvWaiting);
            pnlLeftTable.Controls.Add(lblTableTitle);
            pnlLeftTable.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLeftTable.Margin = new System.Windows.Forms.Padding(8, 8, 4, 8);

            lblTableTitle.Text = "📋  DANH SÁCH BỆNH NHÂN CHỜ KHÁM";
            lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 11F,
                System.Drawing.FontStyle.Bold);
            lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(15, 40, 75);
            lblTableTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTableTitle.Height = 44;
            lblTableTitle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            lblTableTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            dgvWaiting.BackgroundColor = System.Drawing.Color.White;
            dgvWaiting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvWaiting.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvWaiting.ColumnHeadersHeight = 38;
            dgvWaiting.RowHeadersVisible = false;
            dgvWaiting.ReadOnly = true;
            dgvWaiting.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvWaiting.Font =
                new System.Drawing.Font("Segoe UI", 9.5F);
            dgvWaiting.RowTemplate.Height = 34;
            dgvWaiting.GridColor =
                System.Drawing.Color.FromArgb(220, 230, 245);
            dgvWaiting.EnableHeadersVisualStyles = false;
            dgvWaiting.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(15, 40, 75);
            dgvWaiting.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;
            dgvWaiting.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9.5F,
                System.Drawing.FontStyle.Bold);
            dgvWaiting.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(248, 251, 255);

            // ── Panel phải — Hoạt động gần đây ───────────────────
            pnlRightNoti.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            pnlRightNoti.Controls.Add(flpNotifications);
            pnlRightNoti.Controls.Add(lblNotiTitle);
            pnlRightNoti.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlRightNoti.Margin = new System.Windows.Forms.Padding(4, 8, 8, 8);

            lblNotiTitle.Text = "🕐  LỊCH HẸN HÔM NAY";
            lblNotiTitle.Font = new System.Drawing.Font("Segoe UI", 11F,
                System.Drawing.FontStyle.Bold);
            lblNotiTitle.ForeColor = System.Drawing.Color.FromArgb(15, 40, 75);
            lblNotiTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblNotiTitle.Height = 44;
            lblNotiTitle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            lblNotiTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            flpNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            flpNotifications.AutoScroll = true;
            flpNotifications.Padding = new System.Windows.Forms.Padding(6);
            flpNotifications.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);

            // ── UserControl ───────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 244, 252);
            Controls.Add(tlpMain);
            Name = "DashBoard";
            Size = new System.Drawing.Size(1000, 700);

            tlpMain.ResumeLayout(false);
            tlpCards.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            tlpBottom.ResumeLayout(false);
            pnlLeftTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWaiting).EndInit();
            pnlRightNoti.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCountApp;
        private System.Windows.Forms.Label lblTitleApp;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCountWaiting;
        private System.Windows.Forms.Label lblTitleWaiting;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCountRevenue;
        private System.Windows.Forms.Label lblTitleRevenue;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.Panel pnlLeftTable;
        private System.Windows.Forms.DataGridView dgvWaiting;
        private System.Windows.Forms.Label lblTableTitle;
        private System.Windows.Forms.Panel pnlRightNoti;
        private System.Windows.Forms.FlowLayoutPanel flpNotifications;
        private System.Windows.Forms.Label lblNotiTitle;
    }
}