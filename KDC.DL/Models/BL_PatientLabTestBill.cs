namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ams_kdcdb1.BL_Patient")]
    public partial class BL_PatientLabTestBill
    {
        [Key]
        public int PatientLabTestId { get; set; }

        [StringLength(100)]
        public string GroupId { get; set; }

        [StringLength(100)]
        public string ServiceId { get; set; }

        public int? Unit { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? Amount { get; set; }

        public int? PatientId { get; set; }

        public int? EnteredBy { get; set; }

        public DateTime? EnteredDate { get; set; }

        public bool? IsDeleted { get; set; }

    }
}
