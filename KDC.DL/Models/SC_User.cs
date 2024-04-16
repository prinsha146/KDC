namespace KDC.DL.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ams_kdcdb1.SC_User")]
    public partial class SC_User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string UserType { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EnteredDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpireDate { get; set; }

        [StringLength(50)]
        public string RegKey { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
