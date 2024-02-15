using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteSchedule
{
    public Guid Id { get; set; }

    public Guid RouteId { get; set; }

    public Guid RouteScheduleStatusId { get; set; }

    public Guid? SkipReasonId { get; set; }

    public Guid AssignedTo { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime StartsFrom { get; set; }

    public DateTime EndsOn { get; set; }

    public DateTime? InspectionStartedAt { get; set; }

    public DateTime? InspectionEndedAt { get; set; }

    public bool IsMarked { get; set; }

    public virtual AspNetUsers AssignedToNavigation { get; set; }

    public virtual ICollection<EquipmentInAlarmStateLogs> EquipmentInAlarmStateLogs { get; } = new List<EquipmentInAlarmStateLogs>();

    public virtual Route Route { get; set; }

    public virtual ICollection<RouteScheduleEquipments> RouteScheduleEquipments { get; set; } = new List<RouteScheduleEquipments>();

    public virtual RouteScheduleStatus RouteScheduleStatus { get; set; }

    public virtual SkipReasons SkipReason { get; set; }
}
