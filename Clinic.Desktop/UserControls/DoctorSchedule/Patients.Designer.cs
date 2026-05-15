namespace Clinic.Desktop.UserControls.DoctorSchedule
{
    partial class Patients : UserControl
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
            pnlSearch = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvPatients = new DataGridView();
            pnlInfo = new Panel();
            rtbNotes = new RichTextBox();
            lblNotes = new Label();
            txtBloodGroup = new TextBox();
            lblBloodGroup = new Label();
            txtAllergy = new TextBox();
            lblAllergy = new Label();
            lblInfoTitle = new Label();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            pnlInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Margin = new Padding(3, 2, 3, 2);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(831, 45);
            pnlSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(18, 16);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(88, 17);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm bệnh nhân:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(114, 14);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(219, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(41, 57, 85);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(341, 12);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 24);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvPatients
            // 
            dgvPatients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(18, 56);
            dgvPatients.Margin = new Padding(3, 2, 3, 2);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(481, 382);
            dgvPatients.TabIndex = 1;
            // 
            // pnlInfo
            // 
            pnlInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlInfo.BackColor = Color.White;
            pnlInfo.Controls.Add(rtbNotes);
            pnlInfo.Controls.Add(lblNotes);
            pnlInfo.Controls.Add(txtBloodGroup);
            pnlInfo.Controls.Add(lblBloodGroup);
            pnlInfo.Controls.Add(txtAllergy);
            pnlInfo.Controls.Add(lblAllergy);
            pnlInfo.Controls.Add(lblInfoTitle);
            pnlInfo.Location = new Point(516, 56);
            pnlInfo.Margin = new Padding(3, 2, 3, 2);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(298, 382);
            pnlInfo.TabIndex = 0;
            // 
            // rtbNotes
            // 
            rtbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbNotes.Location = new Point(18, 154);
            rtbNotes.Margin = new Padding(3, 2, 3, 2);
            rtbNotes.Name = "rtbNotes";
            rtbNotes.ReadOnly = true;
            rtbNotes.Size = new Size(263, 211);
            rtbNotes.TabIndex = 0;
            rtbNotes.Text = "";
            // 
            // lblNotes
            // 
            lblNotes.Location = new Point(18, 139);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(150, 17);
            lblNotes.TabIndex = 1;
            lblNotes.Text = "Ghi chú bệnh lý dài hạn:";
            // 
            // txtBloodGroup
            // 
            txtBloodGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBloodGroup.Location = new Point(18, 60);
            txtBloodGroup.Margin = new Padding(3, 2, 3, 2);
            txtBloodGroup.Name = "txtBloodGroup";
            txtBloodGroup.ReadOnly = true;
            txtBloodGroup.Size = new Size(263, 23);
            txtBloodGroup.TabIndex = 2;
            // 
            // lblBloodGroup
            // 
            lblBloodGroup.Location = new Point(18, 45);
            lblBloodGroup.Name = "lblBloodGroup";
            lblBloodGroup.Size = new Size(88, 17);
            lblBloodGroup.TabIndex = 3;
            lblBloodGroup.Text = "Nhóm máu:";
            // 
            // txtAllergy
            // 
            txtAllergy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAllergy.ForeColor = Color.Red;
            txtAllergy.Location = new Point(18, 105);
            txtAllergy.Margin = new Padding(3, 2, 3, 2);
            txtAllergy.Name = "txtAllergy";
            txtAllergy.ReadOnly = true;
            txtAllergy.Size = new Size(263, 23);
            txtAllergy.TabIndex = 4;
            // 
            // lblAllergy
            // 
            lblAllergy.Location = new Point(18, 90);
            lblAllergy.Name = "lblAllergy";
            lblAllergy.Size = new Size(150, 17);
            lblAllergy.TabIndex = 5;
            lblAllergy.Text = "Dị ứng / Chống chỉ định:";
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInfoTitle.Location = new Point(18, 11);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(200, 25);
            lblInfoTitle.TabIndex = 6;
            lblInfoTitle.Text = "TÓM TẮT Y TẾ";
            // 
            // Patients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlInfo);
            Controls.Add(dgvPatients);
            Controls.Add(pnlSearch);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Patients";
            Size = new Size(831, 456);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblAllergy;
        private System.Windows.Forms.TextBox txtAllergy;
        private System.Windows.Forms.Label lblBloodGroup;
        private System.Windows.Forms.TextBox txtBloodGroup;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.RichTextBox rtbNotes;
    }
}