using System;
using System.Collections.Generic;

namespace Clinic.Shared.Model
{
    public class Invoice
    {
        // Đồng bộ với code WinForms
        public int InvoiceID { get; set; }

        // Đồng bộ ID cuộc hẹn
        public int AppointmentID { get; set; }

        public decimal TotalAmount { get; set; }

        
        public string? Status { get; set; } = "Unpaid";

        public DateTime? PaymentDate { get; set; }

        public virtual Appointment? Appointment { get; set; }
    }
}