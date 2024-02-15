using System;
using System.IO;
using System.Threading.Tasks;
using Saloon.DataViewModels.Response.Admin.v1;

namespace Saloon.Services.Interface.v1.Common
{
    public interface IMediaHandlerService
    {
        Task<byte[]> GetMedia(string FullPath, string path, string filename);
        Task<string> UploadMedia(Stream data, string FullPath);
        Task<Guid> SaveMedia(string request, Guid MediaType);
        Task<MediaVM> GetMediaPath(Guid MediaId);
    }
}
