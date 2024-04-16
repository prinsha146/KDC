namespace KDC.DL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ams_kdcdb1.MS_OrganizationSetup")]
    public partial class MS_OrganizationSetup
    {
        [Key]
        public int OrganizationId { get; set; }

        [StringLength(100)]
        public string OrganizationName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        public int? Fax { get; set; }

        [StringLength(50)]
        public string PAN { get; set; }

        [StringLength(50)]
        public string GccCodeNo { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
