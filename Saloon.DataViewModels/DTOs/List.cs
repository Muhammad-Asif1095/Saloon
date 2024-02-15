using System;

namespace Saloon.DataViewModels.DTOs;

public partial class List
{
    public long Id { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}
