using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
	public class MedicalStatusVM
	{
		public int CandidateId { get; set; }
		public string CandidateName { get; set; }
		public string PassportNo { get; set; }
		public string MofaNo { get; set; }
		public DateTime IssueDate { get; set; }
		public string MedicalStatus { get; set; }	
		public string MedicalCenterName { get; set; }
	}
}
