using System;

namespace Saloon.DataViewModels.DTOs;

public partial class AggregatedCounter
{
    public string Key { get; set; }

    public long Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}
