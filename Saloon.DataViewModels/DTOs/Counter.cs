using System;

namespace Saloon.DataViewModels.DTOs;

public partial class Counter
{
    public string Key { get; set; }

    public int Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}
