using System;

namespace Saloon.DataViewModels.DTOs;

public partial class JobQueue
{
    public int Id { get; set; }

    public long JobId { get; set; }

    public string Queue { get; set; }

    public DateTime? FetchedAt { get; set; }
}
