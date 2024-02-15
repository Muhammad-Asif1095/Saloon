using Newtonsoft.Json;
using System;

namespace Saloon.DataViewModels.Common
{
    public class FileUrlResponce
    {
        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; } = "";

        [JsonProperty(PropertyName = "thumbnailUrl")]
        public string ThumbnailUrl { get; set; } = "";
        public Guid? ImageMediaId { get; set; } = null;
        public Guid? ImageThumbnailMediaId { get; set; } = null;
    }
}
