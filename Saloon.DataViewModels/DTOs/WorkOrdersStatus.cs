using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class WorkOrdersStatus
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<WorkOrderStatusLog> WorkOrderStatusLog { get; } = new List<WorkOrderStatusLog>();

    public virtual ICollection<WorkOrders> WorkOrders { get; } = new List<WorkOrders>();
}
