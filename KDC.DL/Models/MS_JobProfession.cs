namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_JobProfession")]
    public partial class MS_JobProfession
    {
        [Key]
        public int JobProfessionId { get; set; }

        [StringLength(50)]
        public string JobProfessionName { get; set; }

        public bool? Active { get; set; }
    }
}
