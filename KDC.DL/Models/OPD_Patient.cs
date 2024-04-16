namespace KDC.DL.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;


	[Table("ams_kdcdb1.OPD_Patient")]
	public partial class OPD_Patient
	{
		[Key]
		public int PatientId { get; set; }

		[StringLength(100)]
		public string PatientName { get; set; }

		[StringLength(50)]
		public string PatientCode { get; set; }

		public int Age { get; set; }

		[StringLength(10)]
		public string Gender { get; set; }

		[StringLength(100)]
		public string Address { get; set; }

		[StringLength(50)]
		public string Phone { get; set; }

		public DateTime EnteredDate { get; set; }

		public int EnteredBy { get; set; }

		public bool IsDeleted { get; set; }

	}
}
