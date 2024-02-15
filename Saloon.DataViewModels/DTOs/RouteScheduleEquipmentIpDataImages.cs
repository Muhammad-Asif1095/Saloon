using System;

namespace Saloon.DataViewModels.DTOs;

public partial class RouteScheduleEquipmentIpDataImages
{
    public Guid Id { get; set; }

    public Guid RouteScheduleEquipmentIpDataId { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime CreatedOnDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string DeletedBy { get; set; }

    public Guid? ImageMediaId { get; set; }

    public Guid? ImageThumbnailMediaId { get; set; }

    public virtual Media ImageMedia { get; set; }

    public virtual Media ImageThumbnailMedia { get; set; }

    public virtual RouteScheduleEquipmentIpData RouteScheduleEquipmentIpData { get; set; }
}
