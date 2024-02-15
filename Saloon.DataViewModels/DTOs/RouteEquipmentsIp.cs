using System;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteEquipmentsIp
{
    public Guid Id { get; set; }

    public Guid Ipid { get; set; }

    public Guid RouteEquipmentsId { get; set; }

    public int Sequence { get; set; }

    public virtual Ip Ip { get; set; }

    public virtual RouteEquipments RouteEquipments { get; set; }
}
