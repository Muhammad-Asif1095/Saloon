using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Branches
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Code { get; set; }

    public Guid CustomerId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual ICollection<AspNetUsers> AspNetUsers { get; } = new List<AspNetUsers>();

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual Customers Customer { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual ICollection<RouteScheduleEquipmentIpData> RouteScheduleEquipmentIpData { get; } = new List<RouteScheduleEquipmentIpData>();

    public virtual ICollection<Sections> Sections { get; } = new List<Sections>();
}
