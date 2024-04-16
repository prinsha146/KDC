namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_RecruitingAgency")]
    public partial class MS_RecruitingAgency
    {
        [Key]
        public int RecruitingAgencyId { get; set; }

        [StringLength(100)]
        public string RecruitingAgencyName { get; set; }

        [StringLength(50)]
        public string CODE { get; set; }

        [StringLength(50)]
        public string NAFEA { get; set; }

        [StringLength(100)]
        public string DirectorName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public string Fax { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
