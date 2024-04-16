using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DESKTOP.DO
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string CandidateName { get; set; }
        public string PassportNo { get; set; }
        public string Barcode { get; set; }
		public string PhotoScanned { get; set; }
		public string FingerPrint { get; set; }

	}
    public class CandidateThumb
    {
        public int CandidateId { get; set; }
        public string FingerPrint { get; set; }
        public string FingerPrintRemarks { get; set; }
        public string PhotoCamera { get; set; }
    }
}
