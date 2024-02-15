using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class City
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid ProvinceId { get; set; }
}
