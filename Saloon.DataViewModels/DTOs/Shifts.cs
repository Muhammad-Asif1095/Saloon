using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Shifts
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid ShiftsTypeId { get; set; }

    public DateTime? StartsFrom { get; set; }

    public DateTime? EndsOn { get; set; }

    public int? Day { get; set; }

    public bool IsLockDown { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual ICollection<CustomersShifts> CustomersShifts { get; } = new List<CustomersShifts>();

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual ICollection<RouteShifts> RouteShifts { get; } = new List<RouteShifts>();

    public virtual ShiftsType ShiftsType { get; set; }
}
