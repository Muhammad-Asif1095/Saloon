using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class Country
    {
        public Country()
        {
            ClientBank = new HashSet<ClientBank>();
            Province = new HashSet<Province>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ClientBank> ClientBank { get; set; }
        public virtual ICollection<Province> Province { get; set; }
    }
}
