using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteEquipments
{
    public Guid Id { get; set; }

    public Guid RouteId { get; set; }

    public Guid EquipmentId { get; set; }

    public int Sequence { get; set; }

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

    public virtual AspNetUsers LastModifiedByNavigation { get; set; }

    public virtual Route Route { get; set; }

    public virtual ICollection<RouteEquipmentsIp> RouteEquipmentsIp { get; set; } = new List<RouteEquipmentsIp>();
}
