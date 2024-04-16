using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDC.DL.ViewModel
{
	public class OPDPatientVM
	{
		public int PatientId { get; set; }

		public string PatientName { get; set; }

		public string PatientCode { get; set; }

		public int Age { get; set; }

		public string Gender { get; set; }

		public string Address { get; set; }

		public string Phone { get; set; }

		public DateTime EnteredDate { get; set; }

		public int EnteredBy { get; set; }

		public bool IsDeleted { get; set; }
	}
}
