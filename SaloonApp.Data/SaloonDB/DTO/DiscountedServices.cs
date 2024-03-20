using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class DiscountedServices
    {
        public Guid Id { get; set; }
        public Guid ClientServicesId { get; set; }
        public decimal DiscountPercent { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual ClientServices ClientServices { get; set; } = null!;
        public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;
        public virtual AspNetUsers? DeletedByNavigation { get; set; }
        public virtual AspNetUsers? ModifiedByNavigation { get; set; }
    }
}
