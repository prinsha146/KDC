namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_LabServiceItem")]
    public partial class MS_LabServiceItem
    {
        [Key]
        public int Serviceid { get; set; }

        public int? ServiceGroupId { get; set; }

        [StringLength(50)]
        public string Result { get; set; }

        [StringLength(100)]
        public string ItemDetail { get; set; }

        public int? Min { get; set; }

        public int? Max { get; set; }

        public int? Unit { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public int? MinYear { get; set; }

        public int? MInMonth { get; set; }

        public int? MaxYear { get; set; }

        public int? MaxMonth { get; set; }

        public decimal? Rate { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
