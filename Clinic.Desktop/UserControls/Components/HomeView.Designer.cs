namespace Clinic.Desktop.Components
{
    partial class HomeView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblWelcome = new Label();
            lblDate = new Label();
            pnlCards = new Panel();
            cardPatients = new Panel();
            lblCardP_Icon = new Label();
            lblCardP_Value = new Label();
            lblCardP_Title = new Label();
            cardAppointments = new Panel();
            lblCardA_Icon = new Label();
            lblCardA_Value = new Label();
            lblCardA_Title = new Label();
            cardRevenue = new Panel();
            lblCardR_Icon = new Label();
            lblCardR_Value = new Label();
            lblCardR_Title = new Label();
            cardDoctors = new Panel();
            lblCardD_Icon = new Label();
            lblCardD_Value = new Label();
            lblCardD_Title = new Label();
            pnlBottom = new Panel();
            pnlActivity = new Panel();
            lstActivity = new ListBox();
            lblActivityTitle = new Label();
            pnlChart = new Panel();
            chartPanel = new Panel();
            lblChartTitle = new Label();
            pnlTop.SuspendLayout();
            pnlCards.SuspendLayout();
            cardPatients.SuspendLayout();
            cardAppointments.SuspendLayout();
            cardRevenue.SuspendLayout();
            cardDoctors.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlActivity.SuspendLayout();
            pnlChart.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(30, 80, 150);
            pnlTop.Controls.Add(lblWelcome);
            pnlTop.Controls.Add(lblDate);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(20, 0, 20, 0);
            pnlTop.Size = new Size(905, 70);
            pnlTop.TabIndex = 2;


            chartBar = new Panel { BackColor = Color.White, Dock = DockStyle.None };
            chartPie = new Panel { BackColor = Color.White, Dock = DockStyle.None };

            // Hàng dưới: đường doanh thu  
            chartLine = new Panel { BackColor = Color.White, Dock = DockStyle.None };
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(20, 18);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(460, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "\U0001f9b7  DELTA SYSTEM — TỔNG QUAN PHÒNG KHÁM";
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblDate.ForeColor = Color.FromArgb(180, 210, 255);
            lblDate.Location = new Point(1405, 26);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(126, 17);
            lblDate.TabIndex = 1;
            lblDate.Text = "Thứ Hai, 06/04/2026";
            // 
            // pnlCards
            // 
            pnlCards.BackColor = Color.FromArgb(245, 247, 252);
            pnlCards.Controls.Add(cardPatients);
            pnlCards.Controls.Add(cardAppointments);
            pnlCards.Controls.Add(cardRevenue);
            pnlCards.Controls.Add(cardDoctors);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 70);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(16, 12, 16, 12);
            pnlCards.Size = new Size(905, 130);
            pnlCards.TabIndex = 1;
            // 
            // cardPatients
            // 
            cardPatients.BackColor = Color.White;
            cardPatients.Controls.Add(lblCardP_Icon);
            cardPatients.Controls.Add(lblCardP_Value);
            cardPatients.Controls.Add(lblCardP_Title);
            cardPatients.Location = new Point(16, 12);
            cardPatients.Name = "cardPatients";
            cardPatients.Padding = new Padding(12);
            cardPatients.Size = new Size(195, 100);
            cardPatients.TabIndex = 0;
            // 
            // lblCardP_Icon
            // 
            lblCardP_Icon.AutoSize = true;
            lblCardP_Icon.Font = new Font("Segoe UI", 22F);
            lblCardP_Icon.ForeColor = Color.FromArgb(0, 150, 200);
            lblCardP_Icon.Location = new Point(12, 12);
            lblCardP_Icon.Name = "lblCardP_Icon";
            lblCardP_Icon.Size = new Size(59, 41);
            lblCardP_Icon.TabIndex = 0;
            lblCardP_Icon.Text = "👥";
            // 
            // lblCardP_Value
            // 
            lblCardP_Value.AutoSize = true;
            lblCardP_Value.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardP_Value.ForeColor = Color.FromArgb(30, 40, 60);
            lblCardP_Value.Location = new Point(108, 12);
            lblCardP_Value.Name = "lblCardP_Value";
            lblCardP_Value.Size = new Size(54, 41);
            lblCardP_Value.TabIndex = 1;
            lblCardP_Value.Text = "---";
            // 
            // lblCardP_Title
            // 
            lblCardP_Title.AutoSize = true;
            lblCardP_Title.Font = new Font("Segoe UI", 9F);
            lblCardP_Title.ForeColor = Color.FromArgb(120, 130, 150);
            lblCardP_Title.Location = new Point(98, 73);
            lblCardP_Title.Name = "lblCardP_Title";
            lblCardP_Title.Size = new Size(64, 15);
            lblCardP_Title.TabIndex = 2;
            lblCardP_Title.Text = "Bệnh nhân";
            // 
            // cardAppointments
            // 
            cardAppointments.BackColor = Color.White;
            cardAppointments.Controls.Add(lblCardA_Icon);
            cardAppointments.Controls.Add(lblCardA_Value);
            cardAppointments.Controls.Add(lblCardA_Title);
            cardAppointments.Location = new Point(227, 12);
            cardAppointments.Name = "cardAppointments";
            cardAppointments.Padding = new Padding(12);
            cardAppointments.Size = new Size(195, 100);
            cardAppointments.TabIndex = 1;
            // 
            // lblCardA_Icon
            // 
            lblCardA_Icon.AutoSize = true;
            lblCardA_Icon.Font = new Font("Segoe UI", 22F);
            lblCardA_Icon.ForeColor = Color.FromArgb(40, 167, 69);
            lblCardA_Icon.Location = new Point(12, 12);
            lblCardA_Icon.Name = "lblCardA_Icon";
            lblCardA_Icon.Size = new Size(59, 41);
            lblCardA_Icon.TabIndex = 0;
            lblCardA_Icon.Text = "📅";
            // 
            // lblCardA_Value
            // 
            lblCardA_Value.AutoSize = true;
            lblCardA_Value.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardA_Value.ForeColor = Color.FromArgb(30, 40, 60);
            lblCardA_Value.Location = new Point(97, 12);
            lblCardA_Value.Name = "lblCardA_Value";
            lblCardA_Value.Size = new Size(54, 41);
            lblCardA_Value.TabIndex = 1;
            lblCardA_Value.Text = "---";
            // 
            // lblCardA_Title
            // 
            lblCardA_Title.AutoSize = true;
            lblCardA_Title.Font = new Font("Segoe UI", 9F);
            lblCardA_Title.ForeColor = Color.FromArgb(120, 130, 150);
            lblCardA_Title.Location = new Point(61, 73);
            lblCardA_Title.Name = "lblCardA_Title";
            lblCardA_Title.Size = new Size(102, 15);
            lblCardA_Title.TabIndex = 2;
            lblCardA_Title.Text = "Lịch hẹn hôm nay";
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.White;
            cardRevenue.Controls.Add(lblCardR_Icon);
            cardRevenue.Controls.Add(lblCardR_Value);
            cardRevenue.Controls.Add(lblCardR_Title);
            cardRevenue.Location = new Point(438, 12);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Padding = new Padding(12);
            cardRevenue.Size = new Size(205, 100);
            cardRevenue.TabIndex = 2;
            // 
            // lblCardR_Icon
            // 
            lblCardR_Icon.AutoSize = true;
            lblCardR_Icon.Font = new Font("Segoe UI", 22F);
            lblCardR_Icon.ForeColor = Color.FromArgb(255, 140, 0);
            lblCardR_Icon.Location = new Point(12, 12);
            lblCardR_Icon.Name = "lblCardR_Icon";
            lblCardR_Icon.Size = new Size(59, 41);
            lblCardR_Icon.TabIndex = 0;
            lblCardR_Icon.Text = "💰";
            // 
            // lblCardR_Value
            // 
            lblCardR_Value.AutoSize = true;
            lblCardR_Value.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardR_Value.ForeColor = Color.FromArgb(30, 40, 60);
            lblCardR_Value.Location = new Point(93, 12);
            lblCardR_Value.Name = "lblCardR_Value";
            lblCardR_Value.Size = new Size(54, 41);
            lblCardR_Value.TabIndex = 1;
            lblCardR_Value.Text = "---";
            // 
            // lblCardR_Title
            // 
            lblCardR_Title.AutoSize = true;
            lblCardR_Title.Font = new Font("Segoe UI", 9F);
            lblCardR_Title.ForeColor = Color.FromArgb(120, 130, 150);
            lblCardR_Title.Location = new Point(71, 73);
            lblCardR_Title.Name = "lblCardR_Title";
            lblCardR_Title.Size = new Size(97, 15);
            lblCardR_Title.TabIndex = 2;
            lblCardR_Title.Text = "Doanh thu tháng";
            // 
            // cardDoctors
            // 
            cardDoctors.BackColor = Color.White;
            cardDoctors.Controls.Add(lblCardD_Icon);
            cardDoctors.Controls.Add(lblCardD_Value);
            cardDoctors.Controls.Add(lblCardD_Title);
            cardDoctors.Location = new Point(649, 12);
            cardDoctors.Name = "cardDoctors";
            cardDoctors.Padding = new Padding(12);
            cardDoctors.Size = new Size(237, 100);
            cardDoctors.TabIndex = 3;
            // 
            // lblCardD_Icon
            // 
            lblCardD_Icon.AutoSize = true;
            lblCardD_Icon.Font = new Font("Segoe UI", 22F);
            lblCardD_Icon.ForeColor = Color.FromArgb(150, 50, 200);
            lblCardD_Icon.Location = new Point(12, 12);
            lblCardD_Icon.Name = "lblCardD_Icon";
            lblCardD_Icon.Size = new Size(59, 41);
            lblCardD_Icon.TabIndex = 0;
            lblCardD_Icon.Text = "\U0001fa7a";
            // 
            // lblCardD_Value
            // 
            lblCardD_Value.AutoSize = true;
            lblCardD_Value.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCardD_Value.ForeColor = Color.FromArgb(30, 40, 60);
            lblCardD_Value.Location = new Point(107, 12);
            lblCardD_Value.Name = "lblCardD_Value";
            lblCardD_Value.Size = new Size(54, 41);
            lblCardD_Value.TabIndex = 1;
            lblCardD_Value.Text = "---";
            // 
            // lblCardD_Title
            // 
            lblCardD_Title.AutoSize = true;
            lblCardD_Title.Font = new Font("Segoe UI", 9F);
            lblCardD_Title.ForeColor = Color.FromArgb(120, 130, 150);
            lblCardD_Title.Location = new Point(81, 73);
            lblCardD_Title.Name = "lblCardD_Title";
            lblCardD_Title.Size = new Size(95, 15);
            lblCardD_Title.TabIndex = 2;
            lblCardD_Title.Text = "Bác sĩ hoạt động";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(245, 247, 252);
            pnlBottom.Controls.Add(pnlActivity);
            pnlBottom.Controls.Add(pnlChart);
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Location = new Point(0, 200);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(16, 8, 16, 16);
            pnlBottom.Size = new Size(905, 473);
            pnlBottom.TabIndex = 0;
            // 
            // pnlActivity
            // 
            pnlActivity.BackColor = Color.White;
            pnlActivity.Controls.Add(lstActivity);
            pnlActivity.Controls.Add(lblActivityTitle);
            pnlActivity.Dock = DockStyle.Right;
            pnlActivity.Location = new Point(609, 8);
            pnlActivity.Name = "pnlActivity";
            pnlActivity.Padding = new Padding(12);
            pnlActivity.Size = new Size(280, 449);
            pnlActivity.TabIndex = 0;
            // 
            // lstActivity
            // 
            lstActivity.BackColor = Color.White;
            lstActivity.BorderStyle = BorderStyle.None;
            lstActivity.Dock = DockStyle.Fill;
            lstActivity.Font = new Font("Segoe UI", 9.5F);
            lstActivity.ForeColor = Color.FromArgb(50, 60, 80);
            lstActivity.ItemHeight = 17;
            lstActivity.Location = new Point(12, 48);
            lstActivity.Name = "lstActivity";
            lstActivity.Size = new Size(256, 389);
            lstActivity.TabIndex = 0;
            // 
            // lblActivityTitle
            // 
            lblActivityTitle.Dock = DockStyle.Top;
            lblActivityTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblActivityTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblActivityTitle.Location = new Point(12, 12);
            lblActivityTitle.Name = "lblActivityTitle";
            lblActivityTitle.Padding = new Padding(0, 6, 0, 0);
            lblActivityTitle.Size = new Size(256, 36);
            lblActivityTitle.TabIndex = 1;
            lblActivityTitle.Text = "🕐  Lịch hẹn hôm nay";
            // 
            // pnlChart
            // 
            pnlChart.BackColor = Color.White;
            pnlChart.Controls.Add(chartPanel);
            pnlChart.Controls.Add(lblChartTitle);
            pnlChart.Dock = DockStyle.Fill;
            pnlChart.Location = new Point(16, 8);
            pnlChart.Name = "pnlChart";
            pnlChart.Padding = new Padding(16);
            pnlChart.Size = new Size(873, 449);
            pnlChart.TabIndex = 1;
            // 
            // chartPanel
            // 
            chartPanel.BackColor = Color.White;
            chartPanel.Dock = DockStyle.Fill;
            chartPanel.Location = new Point(16, 52);
            chartPanel.Name = "chartPanel";
            chartPanel.Size = new Size(841, 381);
            chartPanel.TabIndex = 0;
            // 
            // lblChartTitle
            // 
            lblChartTitle.Dock = DockStyle.Top;
            lblChartTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblChartTitle.Location = new Point(16, 16);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Padding = new Padding(0, 6, 0, 0);
            lblChartTitle.Size = new Size(841, 36);
            lblChartTitle.TabIndex = 1;
            lblChartTitle.Text = "📊  Lịch hẹn 7 ngày gần nhất";
            // 
            // HomeView
            // 
            BackColor = Color.FromArgb(245, 247, 252);
            Controls.Add(pnlBottom);
            Controls.Add(pnlCards);
            Controls.Add(pnlTop);
            Name = "HomeView";
            Size = new Size(905, 673);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlCards.ResumeLayout(false);
            cardPatients.ResumeLayout(false);
            cardPatients.PerformLayout();
            cardAppointments.ResumeLayout(false);
            cardAppointments.PerformLayout();
            cardRevenue.ResumeLayout(false);
            cardRevenue.PerformLayout();
            cardDoctors.ResumeLayout(false);
            cardDoctors.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlActivity.ResumeLayout(false);
            pnlChart.ResumeLayout(false);
            ResumeLayout(false);
            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                BackColor = Color.FromArgb(245, 247, 252),
                Padding = new Padding(0),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 55f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));

            tbl.Controls.Add(WrapChart(chartBar, "📊 Lịch hẹn 7 ngày gần nhất"), 0, 0);
            tbl.Controls.Add(WrapChart(chartPie, "🔵 Trạng thái lịch hẹn hôm nay"), 1, 0);
            tbl.Controls.Add(WrapChart(chartLine, "💰 Doanh thu 6 tháng gần nhất"), 0, 1);
            // Ô [1,1] để trống hoặc có thể đặt thêm biểu đồ khác sau

            pnlChart.Controls.Clear();
            pnlChart.Controls.Add(tbl);
        }
        private Panel WrapChart(Panel chart, string title)
        {
            var wrapper = new Panel
            {
                BackColor = Color.White,
                Margin = new Padding(6),
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
            };
            var lbl = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 32,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 80, 150),
            };
            chart.Dock = DockStyle.Fill;
            wrapper.Controls.Add(chart);
            wrapper.Controls.Add(lbl);
            return wrapper;
        }
        private Panel pnlTop;
        private Label lblWelcome, lblDate;

        private Panel pnlCards;
        private Panel cardPatients, cardAppointments, cardRevenue, cardDoctors;
        private Label lblCardP_Icon, lblCardP_Value, lblCardP_Title;
        private Label lblCardA_Icon, lblCardA_Value, lblCardA_Title;
        private Label lblCardR_Icon, lblCardR_Value, lblCardR_Title;
        private Label lblCardD_Icon, lblCardD_Value, lblCardD_Title;

        private Panel pnlBottom;
        private Panel pnlChart;
        private Label lblChartTitle;
        private Panel chartPanel;
        private Panel pnlActivity;
        private Label lblActivityTitle;
        private ListBox lstActivity;
        private Panel chartBar;   // Biểu đồ cột — lịch hẹn 7 ngày
        private Panel chartPie;   // Biểu đồ tròn — trạng thái hôm nay  
        private Panel chartLine;  // Biểu đồ đường — doanh thu 6 tháng
    }
}