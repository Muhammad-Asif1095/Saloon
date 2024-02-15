using System;

namespace Saloon.DataViewModels.DTOs;

public partial class CustomersShifts
{
    public Guid Id { get; set; }

    public Guid ShiftsId { get; set; }

    public Guid CustomersId { get; set; }

    public virtual Customers Customers { get; set; }

    public virtual Shifts Shifts { get; set; }
}
