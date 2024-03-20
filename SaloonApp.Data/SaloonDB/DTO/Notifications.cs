using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class Notifications
    {
        public Notifications()
        {
            NotificationsSubscription = new HashSet<NotificationsSubscription>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<NotificationsSubscription> NotificationsSubscription { get; set; }
    }
}
