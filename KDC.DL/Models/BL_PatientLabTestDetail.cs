namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ams_kdcdb1.BL_PatientLabTestDetail")]
    public partial class BL_PatientLabTestDetail
    {
        [Key]
        public int PatientLabTestDetailId { get; set; }

        public int? PatientId { get; set; }

        public string GroupId { get; set; }

        public string ServiceId { get; set; }

        public string ServiceLabDetailId { get; set; }

        public string Result { get; set; }

        public bool? IsNormal { get; set; }

        public int? EnteredBy { get; set; }

        public DateTime? EnteredDate { get; set; }

        public bool? IsDeleted { get; set; }

        public string IsResultAdded { get; set; }
    }
}
