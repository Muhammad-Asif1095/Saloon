﻿namespace Saloon.DataViewModels.DTOs;

public partial class JobParameter
{
    public long JobId { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }

    public virtual Job Job { get; set; }
}
