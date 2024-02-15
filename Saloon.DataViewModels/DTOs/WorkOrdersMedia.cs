using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class WorkOrdersMedia
{
    public Guid Id { get; set; }

    public Guid WorkOrdersId { get; set; }

    public Guid MediaId { get; set; }

    public bool IsResolved { get; set; }

    public virtual Media Media { get; set; }

    public virtual WorkOrders WorkOrders { get; set; }
}
