using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class SkipReasons
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid SkipReasonsCategoryId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual ICollection<RouteSchedule> RouteSchedule { get; } = new List<RouteSchedule>();

    public virtual ICollection<RouteScheduleEquipmentIpData> RouteScheduleEquipmentIpData { get; } = new List<RouteScheduleEquipmentIpData>();

    public virtual ICollection<RouteScheduleEquipments> RouteScheduleEquipments { get; } = new List<RouteScheduleEquipments>();

    public virtual SkipReasonCategory SkipReasonsCategory { get; set; }
}
