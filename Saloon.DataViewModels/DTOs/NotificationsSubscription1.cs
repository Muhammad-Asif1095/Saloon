using System;

namespace Saloon.DataViewModels.DTOs;

public partial class NotificationsSubscription1
{
    public Guid Id { get; set; }

    public Guid NotificationsId { get; set; }

    public Guid AspNetUsersId { get; set; }

    public virtual AspNetUsers AspNetUsers { get; set; }

    public virtual Notifications1 Notifications { get; set; }
}
