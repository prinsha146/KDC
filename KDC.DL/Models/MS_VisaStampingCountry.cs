namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_VisaStampingCountry")]
    public partial class MS_VisaStampingCountry
    {
        [Key]
        public int CountryId { get; set; }

        [StringLength(100)]
        public string CountryName { get; set; }

        public int? CountryCode { get; set; }
    }
}
