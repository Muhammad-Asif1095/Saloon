﻿using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class DeviceTypes
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public DateTime CreatedOnDate { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedOn { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<UserDeviceInformations> UserDeviceInformations { get; } = new List<UserDeviceInformations>();
}
