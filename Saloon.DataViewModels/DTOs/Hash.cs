﻿using System;

namespace Saloon.DataViewModels.DTOs;

public partial class Hash
{
    public string Key { get; set; }

    public string Field { get; set; }

    public string Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}
