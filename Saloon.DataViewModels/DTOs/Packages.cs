using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Packages
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int MaxIp { get; set; }

    public int MaxFrequency { get; set; }

    public int MaxBranches { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual ICollection<CustomersSubscriptions> CustomersSubscriptions { get; } = new List<CustomersSubscriptions>();

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }
}
