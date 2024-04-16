namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ams_kdcdb1.BL_Patient")]
    public partial class BL_Patient
    {
        [Key]
        public int PatientId { get; set; }

        [StringLength(150)]
        public string PatientName { get; set; }

        public string Gender { get; set; }

        public int? Age { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneMobile { get; set; }

        [StringLength(10)]
        public string ManualNo { get; set; }

        [StringLength(15)]
        public string InvoiceNo { get; set; }

        public DateTime? InvoiceDateAD { get; set; }

        [StringLength(10)]
        public string InvoiceDateBS { get; set; }

        public int? ReferrerId { get; set; }

        public int? EnteredBy { get; set; }

        public DateTime? EnteredDate { get; set; }

        public int? LabCode { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? Discount { get; set; }

        public decimal? Net { get; set; }

        public decimal? Tender { get; set; }

        public decimal? Change { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
