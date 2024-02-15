using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Media
{
    public Guid Id { get; set; }

    public string MediaUri { get; set; }

    public Guid MediaTypeId { get; set; }

    public virtual ICollection<AspNetUsers> AspNetUsersImageMedia { get; } = new List<AspNetUsers>();

    public virtual ICollection<AspNetUsers> AspNetUsersImageThumbnailMedia { get; } = new List<AspNetUsers>();

    public virtual ICollection<Customers> Customers { get; } = new List<Customers>();

    public virtual ICollection<Documents> Documents { get; } = new List<Documents>();

    public virtual MediaType MediaType { get; set; }

    public virtual ICollection<RouteScheduleEquipmentIpDataImages> RouteScheduleEquipmentIpDataImagesImageMedia { get; } = new List<RouteScheduleEquipmentIpDataImages>();

    public virtual ICollection<RouteScheduleEquipmentIpDataImages> RouteScheduleEquipmentIpDataImagesImageThumbnailMedia { get; } = new List<RouteScheduleEquipmentIpDataImages>();

    public virtual ICollection<WorkOrdersMedia> WorkOrdersMedia { get; } = new List<WorkOrdersMedia>();
}
