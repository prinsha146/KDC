using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
    public class CandidateThumbVM
    {
        public string CandidateName { get; set; }
        public string PassportNo { get; set; }
        public string Gender { get; set; }
        public string FingerPrint { get; set; }
        public string FingerPrintRemarks { get; set; }
        public string PhotoCamera { get; set; }
        public int CandidateDetailsEnteredBy { get; set; }

        public DateTime CandidateDetailsEnteredDate { get; set; }
    }
}
