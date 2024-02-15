using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Route
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid AssignedTo { get; set; }

    public Guid FrequencyId { get; set; }

    public Guid RouteStatusId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers AssignedToNavigation { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual ICollection<EquipmentInAlarmStateLogs> EquipmentInAlarmStateLogs { get; } = new List<EquipmentInAlarmStateLogs>();

    public virtual Frequency Frequency { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual ICollection<RouteEquipments> RouteEquipments { get; set; } = new List<RouteEquipments>();

    public virtual ICollection<RouteSchedule> RouteSchedule { get; } = new List<RouteSchedule>();

    public virtual ICollection<RouteShifts> RouteShifts { get; } = new List<RouteShifts>();

    public virtual RouteStatus RouteStatus { get; set; }
}
