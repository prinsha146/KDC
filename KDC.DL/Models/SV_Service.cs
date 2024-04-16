namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ams_kdcdb1.SV_Service")]
    public partial class SV_Service
    {
        public string GroupId { get; set; }

        [Key]
        public string ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string Rate { get; set; }

        public string Discount { get; set; }

        public string UserId { get; set; }

        public string Status { get; set; }

        public string OrderBy { get; set; }
    }
    
}
