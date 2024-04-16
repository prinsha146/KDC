namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_BloodGroupRH")]
    public partial class MS_BloodGroupRH
    {
        [Key]
        public int BloodGroupId { get; set; }

        [StringLength(100)]
        public string BloodGroupName { get; set; }
    }
}
