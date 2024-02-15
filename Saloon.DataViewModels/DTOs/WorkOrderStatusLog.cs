using System;

namespace Saloon.DataViewModels.DTOs;

public partial class WorkOrderStatusLog
{
    public Guid Id { get; set; }

    public Guid WorkOrderId { get; set; }

    public Guid WorkOrderStatusId { get; set; }

    public DateTime ChangedOn { get; set; }

    public virtual WorkOrders WorkOrder { get; set; }

    public virtual WorkOrdersStatus WorkOrderStatus { get; set; }
}
