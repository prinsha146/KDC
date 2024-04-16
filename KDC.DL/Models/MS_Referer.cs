namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_Referer")]
    public partial class MS_Referer
    {
        [Key]
        public int RefererId { get; set; }

        [StringLength(100)]
        public string RefererName { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
