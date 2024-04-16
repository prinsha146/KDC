namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_MedicalReportType")]
    public partial class MS_MedicalReportType
    {
        [Key]
        public int ReportTypeId { get; set; }

        [StringLength(50)]
        public string ReportTypeName { get; set; }
    }
}
