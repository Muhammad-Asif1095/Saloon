using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class Roles
    {
        public Roles()
        {
            AdminUserRoles = new HashSet<AdminUserRoles>();
            RoleRights = new HashSet<RoleRights>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsEnabled { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }

        public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;
        public virtual ICollection<AdminUserRoles> AdminUserRoles { get; set; }
        public virtual ICollection<RoleRights> RoleRights { get; set; }
    }
}
