using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Ip
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public Guid FrequencyId { get; set; }

    public bool BooleanExpectedValue { get; set; }

    public Guid EquipmentId { get; set; }

    public Guid IpFacultyId { get; set; }

    public Guid IpCriticalityId { get; set; }

    public Guid IpTypeId { get; set; }

    public Guid IpToolId { get; set; }

    public Guid IpDataTypeId { get; set; }

    public Guid IpEngineeringUnitId { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public Guid? DeletedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual AspNetUsers CreatedByNavigation { get; set; }

    public virtual AspNetUsers DeletedByNavigation { get; set; }

    public virtual Equipment Equipment { get; set; }

    public virtual Frequency Frequency { get; set; }

    public virtual ICollection<IpAnomalyRanges> IpAnomalyRanges { get; set; } = new List<IpAnomalyRanges>();

    public virtual IpCriticality IpCriticality { get; set; }

    public virtual IpDataType IpDataType { get; set; }

    public virtual IpEngineeringUnit IpEngineeringUnit { get; set; }

    public virtual IpFaculty IpFaculty { get; set; }

    public virtual ICollection<IpOptions> IpOptions { get; set; } = new List<IpOptions>();

    public virtual IpTools IpTool { get; set; }

    public virtual IpType IpType { get; set; }

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual ICollection<RouteEquipmentsIp> RouteEquipmentsIp { get; } = new List<RouteEquipmentsIp>();

    public virtual ICollection<RouteScheduleEquipmentIpData> RouteScheduleEquipmentIpData { get; } = new List<RouteScheduleEquipmentIpData>();

    public virtual ICollection<RouteScheduleEquipmentsIp> RouteScheduleEquipmentsIp { get; } = new List<RouteScheduleEquipmentsIp>();
}
