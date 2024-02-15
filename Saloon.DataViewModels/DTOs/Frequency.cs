using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Frequency
{
    public Guid Id { get; set; }

    public int Hours { get; set; }

    public string Name { get; set; }

    public int TimeSpanValue { get; set; }

    public string TimeSpanUnit { get; set; }

    public virtual ICollection<Ip> Ip { get; } = new List<Ip>();

    public virtual ICollection<Route> Route { get; } = new List<Route>();
}
