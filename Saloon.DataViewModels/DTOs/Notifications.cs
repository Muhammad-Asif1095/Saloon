using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Notifications
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<NotificationsSubscription> NotificationsSubscription { get; } = new List<NotificationsSubscription>();
}
