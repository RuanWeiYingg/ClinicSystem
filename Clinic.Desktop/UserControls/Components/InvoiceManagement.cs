using Clinic.Shared.Model;
using Clinic.Desktop.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

// Thư viện iText7
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font;

// Thư viện EPPlus
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Clinic.Desktop.Components
{
    public partial class Invoice_Management : UserControl
    {
        private List<Invoice> _allInvoices = new List<Invoice>();
        private Invoice _selectedInvoice = null;

        public Invoice_Management()
        {
            InitializeComponent();
            SetupEvents();
            ExcelPackage.License.SetNonCommercialPersonal("Delta Clinic");
            cboStatusFilter.SelectedIndex = 0;
            ClearRightPanel();
            LoadInvoices();
        }

        private void SetupEvents()
        {
            txtSearchInvoice.TextChanged += (s, e) => FilterInvoices();
            cboStatusFilter.SelectedIndexChanged += (s, e) => FilterInvoices();
            dgvInvoices.CellClick += DgvInvoices_CellClick;
            btnConfirmPayment.Click += BtnConfirmPayment_Click;
            btnPrintInvoice.Click += BtnPrintInvoice_Click;
        }

        private async void LoadInvoices()
        {
            try
            {
                _allInvoices = await ApiClient.GetAsync<List<Invoice>>("api/Invoices") ?? new List<Invoice>();
                FilterInvoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindGrid(List<Invoice> list)
        {
            dgvInvoices.Rows.Clear();
            foreach (var inv in list)
            {
                int n = dgvInvoices.Rows.Add();
                var row = dgvInvoices.Rows[n];
                row.Cells[colInvoiceID.Name].Value = inv.InvoiceID;
                row.Cells[colPatientName.Name].Value = inv.Appointment?.Patient?.FullName ?? "N/A";
                row.Cells[colTotalAmount.Name].Value = inv.TotalAmount.ToString("N0") + " VNĐ";
                row.Cells[colPaymentDate.Name].Value = inv.PaymentDate?.ToString("dd/MM/yyyy HH:mm") ?? "---";
                row.Cells[colStatus.Name].Value = (inv.Status == "Paid") ? "Đã thanh toán" : "Chưa thanh toán";
                row.Tag = inv;
                row.DefaultCellStyle.BackColor = inv.Status == "Paid"
                    ? Color.FromArgb(220, 252, 231)
                    : Color.FromArgb(254, 249, 195);
            }
        }

        private void FilterInvoices()
        {
            string search = txtSearchInvoice.Text.ToLower().Trim();
            string statusFilter = cboStatusFilter.SelectedItem?.ToString() ?? "Tất cả";

            string englishStatus = statusFilter switch
            {
                "Chưa thanh toán" => "Unpaid",
                "Đã thanh toán" => "Paid",
                _ => "Tất cả"
            };

            var filtered = _allInvoices.Where(i =>
                (i.InvoiceID.ToString().Contains(search) ||
                 (i.Appointment?.Patient?.FullName?.ToLower().Contains(search) ?? false)) &&
                (englishStatus == "Tất cả" || (i.Status ?? "Unpaid") == englishStatus)
            ).OrderByDescending(i => i.InvoiceID).ToList();

            BindGrid(filtered);
            ClearRightPanel();
        }

        private void DgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedInvoice = dgvInvoices.Rows[e.RowIndex].Tag as Invoice;
            UpdateRightPanel();
        }

        private void UpdateRightPanel()
        {
            if (_selectedInvoice == null) return;

            lblPatientName.Text = $"Bệnh nhân: {_selectedInvoice.Appointment?.Patient?.FullName ?? "N/A"}";
            lblServiceName.Text = $"Dịch vụ: {_selectedInvoice.Appointment?.Service?.ServiceName ?? "N/A"}";

            if (_selectedInvoice.Status == "Paid")
            {
                lblTotalAmount.Text = $"Tổng tiền: {_selectedInvoice.TotalAmount:N0} VNĐ";
                nudAmount.Visible = false;
                lblAmountEdit.Visible = false;
                lblDate.Text = $"Ngày thanh toán: {_selectedInvoice.PaymentDate?.ToString("dd/MM/yyyy HH:mm")}";
                btnConfirmPayment.Enabled = false;
                btnConfirmPayment.Text = "✔ ĐÃ HOÀN TẤT";
                btnConfirmPayment.BackColor = Color.Gray;
            }
            else
            {
                lblTotalAmount.Text = "Tổng tiền (có thể điều chỉnh):";
                nudAmount.Visible = true;
                nudAmount.Maximum = 1000000000;
                nudAmount.Value = (decimal)_selectedInvoice.TotalAmount;
                lblAmountEdit.Visible = true;
                lblDate.Text = "Trạng thái: Chờ thanh toán";
                btnConfirmPayment.Enabled = true;
                btnConfirmPayment.Text = "XÁC NHẬN THANH TOÁN";
                btnConfirmPayment.BackColor = Color.OrangeRed;
            }
            btnPrintInvoice.Enabled = true;
        }

        private void ClearRightPanel()
        {
            _selectedInvoice = null;
            lblPatientName.Text = "Bệnh nhân: ---";
            lblServiceName.Text = "Dịch vụ: ---";
            lblTotalAmount.Text = "Tổng tiền: ---";
            lblDate.Text = "Ngày lập: ---";
            nudAmount.Visible = false;
            lblAmountEdit.Visible = false;
            btnConfirmPayment.Enabled = false;
            btnPrintInvoice.Enabled = false;
        }

        private async void BtnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (_selectedInvoice == null) return;

            decimal finalAmount = nudAmount.Visible ? nudAmount.Value : _selectedInvoice.TotalAmount;

            var confirm = MessageBox.Show(
                $"Xác nhận thanh toán #{_selectedInvoice.InvoiceID}?\n\n" +
                $"Số tiền: {finalAmount:N0} VNĐ\n" +
                $"Hệ thống sẽ tự động hoàn tất lịch hẹn này.",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            btnConfirmPayment.Enabled = false;
            _selectedInvoice.Status = "Paid";
            _selectedInvoice.TotalAmount = finalAmount;
            _selectedInvoice.PaymentDate = DateTime.Now;

            if (_selectedInvoice.Appointment != null)
                _selectedInvoice.Appointment.Status = "Completed";

            try
            {
                var updated = await ApiClient.PutAsync<Invoice>(
                    $"api/Invoices/{_selectedInvoice.InvoiceID}", _selectedInvoice);

                if (updated != null)
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvoices();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                btnConfirmPayment.Enabled = true;
            }
        }

        private void BtnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (_selectedInvoice == null) return;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = $"HD_{_selectedInvoice.InvoiceID}.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                string fontPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "tahoma.ttf");
                string fontBoldPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "tahomabd.ttf");

                // Fallback nếu không có tahomabd.ttf
                if (!File.Exists(fontBoldPath)) fontBoldPath = fontPath;

                using PdfWriter writer = new PdfWriter(sfd.FileName);
                using PdfDocument pdf = new PdfDocument(writer);
                Document doc = new Document(pdf);

                // FIX: dùng 2 font riêng (regular + bold) thay vì Property.BOLD
                PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                PdfFont fontBold = PdfFontFactory.CreateFont(fontBoldPath, PdfEncodings.IDENTITY_H);

                doc.Add(new Paragraph("PHÒNG KHÁM DELTA SYSTEM")
                    .SetFont(fontBold).SetFontSize(18)
                    .SetTextAlignment(TextAlignment.CENTER));

                doc.Add(new Paragraph("HÓA ĐƠN DỊCH VỤ")
                    .SetFont(fontBold).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER));

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Mã hóa đơn : #{_selectedInvoice.InvoiceID}").SetFont(font).SetFontSize(11));
                doc.Add(new Paragraph($"Bệnh nhân  : {_selectedInvoice.Appointment?.Patient?.FullName ?? "N/A"}").SetFont(font).SetFontSize(11));
                doc.Add(new Paragraph($"Dịch vụ    : {_selectedInvoice.Appointment?.Service?.ServiceName ?? "N/A"}").SetFont(font).SetFontSize(11));
                doc.Add(new Paragraph($"Ngày in    : {DateTime.Now:dd/MM/yyyy HH:mm}").SetFont(font).SetFontSize(11));
                doc.Add(new Paragraph("------------------------------------------------").SetFont(font).SetFontSize(11));

                doc.Add(new Paragraph($"TỔNG TIỀN: {_selectedInvoice.TotalAmount:N0} VNĐ")
                    .SetFont(fontBold).SetFontSize(14)
                    .SetTextAlignment(TextAlignment.RIGHT));

                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(
                    $"Trạng thái: {(_selectedInvoice.Status == "Paid" ? "ĐÃ THANH TOÁN" : "CHƯA THANH TOÁN")}")
                    .SetFont(fontBold).SetFontSize(11)
                    .SetFontColor(iText.Kernel.Colors.ColorConstants.GREEN));

                doc.Close();

                MessageBox.Show("Đã xuất hóa đơn PDF thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in PDF: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToExcel()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = "BaoCao_DoanhThu.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var package = new ExcelPackage();
                var ws = package.Workbook.Worksheets.Add("Invoices");

                string[] headers = { "ID", "Bệnh nhân", "Dịch vụ", "Số tiền", "Ngày thanh toán", "Trạng thái" };
                for (int i = 0; i < headers.Length; i++)
                {
                    ws.Cells[1, i + 1].Value = headers[i];
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                    ws.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(59, 130, 246));
                    ws.Cells[1, i + 1].Style.Font.Color.SetColor(Color.White);
                }

                int row = 2;
                foreach (var inv in _allInvoices)
                {
                    ws.Cells[row, 1].Value = inv.InvoiceID;
                    ws.Cells[row, 2].Value = inv.Appointment?.Patient?.FullName ?? "N/A";
                    ws.Cells[row, 3].Value = inv.Appointment?.Service?.ServiceName ?? "N/A";
                    ws.Cells[row, 4].Value = inv.TotalAmount;
                    ws.Cells[row, 4].Style.Numberformat.Format = "#,##0";
                    ws.Cells[row, 5].Value = inv.PaymentDate?.ToString("dd/MM/yyyy HH:mm") ?? "---";
                    ws.Cells[row, 6].Value = inv.Status == "Paid" ? "Đã thanh toán" : "Chưa thanh toán";

                    var fillColor = inv.Status == "Paid"
                        ? Color.FromArgb(220, 252, 231)
                        : Color.FromArgb(254, 249, 195);
                    for (int c = 1; c <= 6; c++)
                    {
                        ws.Cells[row, c].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[row, c].Style.Fill.BackgroundColor.SetColor(fillColor);
                    }
                    row++;
                }

                ws.Cells.AutoFitColumns();
                File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());

                MessageBox.Show("Xuất Excel thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(
                    new System.Diagnostics.ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}