using System;

namespace Saloon.DataViewModels.Common
{
    public class AuthToken
    {
        public Guid UserId { get; set; }
        public string DeviceToken { get; set; }
        public int DeviceTypeId { get; set; }
        public Guid RoleId { get; set; }
    }
}
