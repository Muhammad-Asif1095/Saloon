using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteScheduleEquipments
{
    public Guid Id { get; set; }

    public Guid RouteScheduleId { get; set; }

    public Guid EquipmentId { get; set; }

    public int Sequence { get; set; }

    public Guid? SkipReasonsId { get; set; }

    public DateTime? InspectionStartedAt { get; set; }

    public DateTime? InspectionEndedAt { get; set; }

    public string RecordedAtLat { get; set; }

    public string RecordedAtLong { get; set; }

    public virtual Equipment Equipment { get; set; }

    public virtual ICollection<EquipmentInAlarmStateLogs> EquipmentInAlarmStateLogs { get; } = new List<EquipmentInAlarmStateLogs>();

    public virtual RouteSchedule RouteSchedule { get; set; }

    public virtual ICollection<RouteScheduleEquipmentIpData> RouteScheduleEquipmentIpData { get; } = new List<RouteScheduleEquipmentIpData>();

    public virtual ICollection<RouteScheduleEquipmentsIp> RouteScheduleEquipmentsIp { get; set; } = new List<RouteScheduleEquipmentsIp>();

    public virtual SkipReasons SkipReasons { get; set; }
}
