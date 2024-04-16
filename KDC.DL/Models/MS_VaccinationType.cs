namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_VaccinationType")]
    public partial class MS_VaccinationType
    {
        [Key]
        public int VaccinationTypeId { get; set; }

        [StringLength(50)]
        public string VaccinationTypeName { get; set; }
    }
}
