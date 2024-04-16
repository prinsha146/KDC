using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
    public class PatientLabTestDetailVM
    {
        public int PatientLabTestDetailId { get; set; }
        public int PatientId { get; set; }
        public int LabCode { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string EnteredDate { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDateAD { get; set; }
		public string InvoiceDate { get; set; }
        public string InvoiceDateBS { get; set; }
        public string Referrer { get; set; }
		public string LabDate { get; set; }
        public string ServiceLabDetailId { get; set; }
        public string Particular { get; set; }
		public string ParticulatUnit { get; set; }
		public int DataType { get; set; }
        public string Result { get; set; }
        public bool IsNormal { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }

    }
}
