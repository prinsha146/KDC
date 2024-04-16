namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_District")]
    public partial class MS_District
    {
        [Key]
        public int DistrictId { get; set; }

        [StringLength(50)]
        public string DistrictName { get; set; }
    }
}
