using System;

namespace Saloon.DataViewModels.DTOs;

public partial class EquipmentInAlarmStateLogs
{
    public Guid Id { get; set; }

    public Guid EquipmentId { get; set; }

    public bool InAlarmState { get; set; }

    public decimal? Mttr { get; set; }

    public DateTime? EquipmentInAlarmStateLogDate { get; set; }

    public Guid? EquipmentInAlarmStateLogId { get; set; }

    public Guid? RouteId { get; set; }

    public Guid? RouteScheduleId { get; set; }

    public Guid? RouteScheduleEquipmentsId { get; set; }

    public Guid? RouteScheduleEquipmentsIpid { get; set; }

    public Guid? RouteScheduleEquipmentIpDataId { get; set; }

    public Guid? WorkOrdersId { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime CreatedOnDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public Guid? DeletedBy { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual Equipment Equipment { get; set; }

    public virtual Route Route { get; set; }

    public virtual RouteSchedule RouteSchedule { get; set; }

    public virtual RouteScheduleEquipmentIpData RouteScheduleEquipmentIpData { get; set; }

    public virtual RouteScheduleEquipments RouteScheduleEquipments { get; set; }

    public virtual RouteScheduleEquipmentsIp RouteScheduleEquipmentsIp { get; set; }

    public virtual AspNetUsers UpdatedByNavigation { get; set; }

    public virtual WorkOrders WorkOrders { get; set; }
}
