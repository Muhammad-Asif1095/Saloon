using System;
using System.Collections.Generic;

namespace SaloonApp.Data.SaloonDB.DTO
{
    public partial class MediaTypesFormats
    {
        public Guid Id { get; set; }
        public Guid MediaTypesId { get; set; }
        public string MediaFormat { get; set; } = null!;

        public virtual MediaType MediaTypes { get; set; } = null!;
    }
}
