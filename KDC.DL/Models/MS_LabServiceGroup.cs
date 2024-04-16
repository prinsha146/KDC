namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_LabServiceGroup")]
    public partial class MS_LabServiceGroup
    {
        [Key]
        public int ServiceGroupId { get; set; }

        [StringLength(100)]
        public string ServiceGroupName { get; set; }

        public bool? IsComplete { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
