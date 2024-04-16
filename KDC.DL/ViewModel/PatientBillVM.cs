using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
    public class PatientBillVM
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string InvoiceNo { get; set; }
        public string ManualNo { get; set; }
        public DateTime InvoiceDateAD { get; set; }
        public string InvoiceDateBS { get; set; }
        public string Address { get; set; }
        public string Referrer { get; set; }
        public int LabCode { get; set; }
        public string PhoneMobile { get; set; }

        public string Service { get; set; }
        public int Unit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Net { get; set; }
        public decimal Tender { get; set; }
        public decimal Change { get; set; }

		public string Remarks { get; set; }

        public string EnteredBy { get; set; }
    }
}
