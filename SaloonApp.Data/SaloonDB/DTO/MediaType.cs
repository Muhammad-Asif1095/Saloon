using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class MediaType
    {
        public MediaType()
        {
            MediaStore = new HashSet<MediaStore>();
            MediaTypesFormats = new HashSet<MediaTypesFormats>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MediaStore> MediaStore { get; set; }
        public virtual ICollection<MediaTypesFormats> MediaTypesFormats { get; set; }
    }
}
