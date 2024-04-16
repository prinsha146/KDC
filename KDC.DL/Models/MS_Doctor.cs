namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ams_kdcdb1.MS_Doctor")]
    public partial class MS_Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [StringLength(50)]
        public string DoctorName { get; set; }

        [StringLength(50)]
        public string Degree { get; set; }

        [StringLength(50)]
        public string Specialization { get; set; }
    }
}
