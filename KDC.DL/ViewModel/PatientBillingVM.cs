using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
    public class PatientBillingVM
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string PhoneMobile { get; set; }
        public decimal TotalAmount { get; set; }
        public int LabCode { get; set; }
        //public string AddressName { get; set; }

        public int PatientLabTestId { get; set; }
        public string ServiceId { get; set; }
        public string Service { get; set; }
        public string GroupId { get; set; }
        public decimal Amount { get; set; }
        public int Unit { get; set; }

        public int PatientLabTestDetailId { get; set; }
        public string ServiceLabDetailId { get; set; }
        public string Result { get; set; }
        public bool IsNormal { get; set; }

        public int EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public bool IsDeleted { get; set; }
        public string IsResultAdded { get; set; }
       
    }
}
