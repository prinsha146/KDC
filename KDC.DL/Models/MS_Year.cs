namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_Year")]
    public partial class MS_Year
    {
        [Key]
        public int YearId { get; set; }

        public int? YearNo { get; set; }

        public int? LabNumberStart { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
