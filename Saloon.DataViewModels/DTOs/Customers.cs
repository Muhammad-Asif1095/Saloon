using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Customers
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? MediaStoreId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual ICollection<AspNetUsers> AspNetUsers { get; } = new List<AspNetUsers>();

    public virtual AspNetUsers CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<CustomersSubscriptions> CustomersSubscriptions { get; } = new List<CustomersSubscriptions>();

    public virtual AspNetUsers? DeletedByNavigation { get; set; }

    public virtual AspNetUsers? LastModifiedByNavigation { get; set; }

    public virtual MediaStore? MediaStore { get; set; }
}
