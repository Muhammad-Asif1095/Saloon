using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class ClientBank
    {
        public Guid Id { get; set; }
        public string BankName { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public int BranchCode { get; set; }
        public Guid CityId { get; set; }
        public Guid AspNetUserId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; } = null!;
        public virtual Country City { get; set; } = null!;
        public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;
        public virtual AspNetUsers? DeletedByNavigation { get; set; }
        public virtual AspNetUsers? ModifiedByNavigation { get; set; }
    }
}
