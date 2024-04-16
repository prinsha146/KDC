namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_VaccinationBatch")]
    public partial class MS_VaccinationBatch
    {
        [Key]
        public int VaccinationBatchId { get; set; }

        [StringLength(100)]
        public string Details { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        [StringLength(50)]
        public string BatchNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfManufacture { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfExpiry { get; set; }

        public int? VaccinationTypeId { get; set; }

        public bool? IsDeleted { get; set; }

        public string VaccinationTypeName { get; set; }
    }
}
