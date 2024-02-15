using System;

namespace Saloon.DataViewModels.DTOs;

public partial class Set
{
    public string Key { get; set; }

    public double Score { get; set; }

    public string Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}
