using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Province
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;
}
