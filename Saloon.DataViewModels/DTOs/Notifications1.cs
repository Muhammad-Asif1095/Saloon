using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class Notifications1
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<NotificationsSubscription1> NotificationsSubscription1 { get; } = new List<NotificationsSubscription1>();
}
