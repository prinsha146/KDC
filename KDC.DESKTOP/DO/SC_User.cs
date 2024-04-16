using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDC.DESKTOP.DO
{
    public class SC_User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public bool? Status { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string RegKey { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        
    }
}
