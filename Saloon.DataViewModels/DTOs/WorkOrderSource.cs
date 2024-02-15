using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class WorkOrderSource
{
    public Guid SourceId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<WorkOrders> WorkOrders { get; } = new List<WorkOrders>();
}
