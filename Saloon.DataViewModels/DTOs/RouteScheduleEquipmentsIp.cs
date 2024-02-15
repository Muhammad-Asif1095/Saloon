using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteScheduleEquipmentsIp
{
    public Guid Id { get; set; }

    public Guid Ipid { get; set; }

    public Guid RouteScheduleEquipmentsId { get; set; }

    public int Sequence { get; set; }

    public virtual ICollection<EquipmentInAlarmStateLogs> EquipmentInAlarmStateLogs { get; } = new List<EquipmentInAlarmStateLogs>();

    public virtual Ip Ip { get; set; }

    public virtual RouteScheduleEquipments RouteScheduleEquipments { get; set; }
}
