﻿using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Job
{
    public long Id { get; set; }

    public long? StateId { get; set; }

    public string StateName { get; set; }

    public string InvocationData { get; set; }

    public string Arguments { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ExpireAt { get; set; }

    public virtual ICollection<JobParameter> JobParameter { get; } = new List<JobParameter>();

    public virtual ICollection<State> State { get; } = new List<State>();
}
