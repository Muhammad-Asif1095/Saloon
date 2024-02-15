using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Saloon.Common
{
    public static class CommonStatic
  {
    public static bool isGuid(string value)
    {
      Guid x;
      return Guid.TryParse(value, out x);
    }

        public static void SaveFile(string path, IFormFile file) {

            try
            {
                var dir = Path.GetDirectoryName(path);
                if(!Directory.Exists(path))
                    Directory.CreateDirectory(dir);

                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    file.CopyTo(fileStream);
                }
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public static void DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
