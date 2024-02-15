using System;
using System.Collections.Generic;

namespace Saloon.DataViewModels.DTOs;

public partial class NotificationsSubscription
{
    public Guid Id { get; set; }

    public Guid NotificationsId { get; set; }

    public Guid AspNetUsersId { get; set; }

    public virtual AspNetUsers AspNetUsers { get; set; } = null!;

    public virtual Notifications Notifications { get; set; } = null!;
}
