using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class UserType
    {
        public UserType()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
