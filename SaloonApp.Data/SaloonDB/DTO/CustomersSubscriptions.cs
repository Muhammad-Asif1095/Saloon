using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class CustomersSubscriptions
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public DateTime SignedOn { get; set; }
        public DateTime ValidThrough { get; set; }
        public Guid? CustomerId { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;
        public virtual Customers? Customer { get; set; }
        public virtual AspNetUsers? DeletedByNavigation { get; set; }
        public virtual AspNetUsers? LastModifiedByNavigation { get; set; }
    }
}
