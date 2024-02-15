using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Saloon.Common;
using Saloon.Data.Context;
using Saloon.DataViewModels.DTOs;
using Saloon.DataViewModels.Response.Admin.v1;
using Saloon.Services.Interface.v1.Common;

namespace Saloon.Services.Implementation.v1.Common
{
    public class MediaHandlerService : IMediaHandlerService
    {
        public async Task<byte[]> GetMedia(string FullPath, string path, string filename)
        {
            try
            {
                var formattedPath = path.Replace("\\", "/").TrimStart(new[] { '/' });
                (BlobClient blobClient, string liveURI) = GetBlobContainerClient(filename);
                var data = new byte[] { };
                using (var stream = new MemoryStream())
                {
                    await blobClient.DownloadToAsync(stream);
                    data = stream.ToArray();
                    stream.Close();
                    await stream.FlushAsync();
                }
                return data;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<string> UploadMedia(Stream data, string FullPath)
        {
            try
            {
                (BlobClient blobClient, string liveURI) = GetBlobContainerClient(FullPath);
                data.Position = 0;
                await blobClient.UploadAsync(data, true);
                return liveURI;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        private (BlobClient client, string path) GetBlobContainerClient(string fileURI)
        {
            var accountName = CommonAppConfig.GetKey("StorageAccountName");
            var accountKey = CommonAppConfig.GetKey("StorageAccountKey");
            if (string.IsNullOrEmpty(accountKey))
            {
                throw new Exception("No account key found");
            }

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);

            string dfsUri = $"{CommonAppConfig.GetKey("StorageAccountUrl")}/{fileURI.TrimStart(new[] { '/' })}";

            var dataLakeServiceClient = new BlobClient(new Uri(dfsUri), sharedKeyCredential);
            return (dataLakeServiceClient, dfsUri);
        }

        public async Task<Guid> SaveMedia(string liveUrl, Guid MediaType)
        {
            try
            {
                using (var db = new SaloonDbContext())
                {
                    var newMediaStoreId = SystemGlobal.GetId();

                    //await db.Media.AddAsync(new Media
                    //{
                    //    Id = newMediaStoreId,
                    //    MediaUri = liveUrl,
                    //    MediaTypeId = MediaType
                    //});

                    //await db.SaveChangesAsync();
                    return newMediaStoreId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<MediaVM> GetMediaPath(Guid MediaId)
        {
            try
            {
                //using (var db = new SaloonDbContext())
                //{
                //    return await db.Media.Where(x => x.Id.Equals(MediaId)).Select(y => new MediaVM
                //    {
                //        Id = y.Id,
                //        MediaUri = y.MediaUri,
                //        MediaTypeId = y.MediaTypeId,
                //    }).FirstOrDefaultAsync();
                return  new MediaVM();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
