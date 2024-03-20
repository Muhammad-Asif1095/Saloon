using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class ClientServices
    {
        public ClientServices()
        {
            DiscountedServices = new HashSet<DiscountedServices>();
            StaffServices = new HashSet<StaffServices>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Cost { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;
        public virtual AspNetUsers? DeletedByNavigation { get; set; }
        public virtual AspNetUsers? ModifiedByNavigation { get; set; }
        public virtual ICollection<DiscountedServices> DiscountedServices { get; set; }
        public virtual ICollection<StaffServices> StaffServices { get; set; }
    }
}
