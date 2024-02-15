using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteScheduleEquipmentIpData
{
    public Guid Id { get; set; }

    public Guid? BranchId { get; set; }

    public Guid? SectionId { get; set; }

    public Guid? SubSectionId { get; set; }

    public Guid? AssetId { get; set; }

    public Guid? EquipmentId { get; set; }

    public Guid IpId { get; set; }

    public Guid RouteScheduleEquipmentsId { get; set; }

    public Guid? SkipReasonsId { get; set; }

    public string Value { get; set; }

    public bool IsAnamoly { get; set; }

    public DateTime RecordedAt { get; set; }

    public virtual Assets Asset { get; set; }

    public virtual Branches Branch { get; set; }

    public virtual Equipment Equipment { get; set; }

    public virtual ICollection<EquipmentInAlarmStateLogs> EquipmentInAlarmStateLogs { get; } = new List<EquipmentInAlarmStateLogs>();

    public virtual Ip Ip { get; set; }

    public virtual ICollection<RouteScheduleEquipmentIpDataImages> RouteScheduleEquipmentIpDataImages { get; } = new List<RouteScheduleEquipmentIpDataImages>();

    public virtual RouteScheduleEquipments RouteScheduleEquipments { get; set; }

    public virtual Sections Section { get; set; }

    public virtual SkipReasons SkipReasons { get; set; }

    public virtual SubSections SubSection { get; set; }
}
