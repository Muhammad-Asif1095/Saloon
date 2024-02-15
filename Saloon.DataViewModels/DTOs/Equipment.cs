using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Equipment
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string ExternalCode { get; set; }

    public bool InAlarmingState { get; set; }

    public Guid EquipmentCriticalityId { get; set; }

    public Guid AssetId { get; set; }

    public Guid EquipmentTypeId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual Assets Asset { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual ICollection<DocumentsEquipment> DocumentsEquipment { get; } = new List<DocumentsEquipment>();

    public virtual EquipmentCriticality EquipmentCriticality { get; set; }

    public virtual ICollection<EquipmentInAlarmStateLogs> EquipmentInAlarmStateLogs { get; } = new List<EquipmentInAlarmStateLogs>();

    public virtual EquipmentTypes EquipmentType { get; set; }

    public virtual ICollection<Ip> Ip { get; } = new List<Ip>();

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual ICollection<RouteEquipments> RouteEquipments { get; } = new List<RouteEquipments>();

    public virtual ICollection<RouteScheduleEquipmentIpData> RouteScheduleEquipmentIpData { get; } = new List<RouteScheduleEquipmentIpData>();

    public virtual ICollection<RouteScheduleEquipments> RouteScheduleEquipments { get; } = new List<RouteScheduleEquipments>();

    public virtual ICollection<WorkOrders> WorkOrders { get; } = new List<WorkOrders>();
}
