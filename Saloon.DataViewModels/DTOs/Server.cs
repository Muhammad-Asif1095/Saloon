using System;

namespace Saloon.DataViewModels.DTOs;

public partial class Server
{
    public string Id { get; set; }

    public string Data { get; set; }

    public DateTime LastHeartbeat { get; set; }
}
