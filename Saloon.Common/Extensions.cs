using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Saloon.Common
{
    public static class Extensions
    {
        public static IEnumerable<T> ExceptThis<T, TKey>(this IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKey)
        {
            return from item in items
                   join otherItem in other on getKey(item)
                   equals getKey(otherItem) into tempItems
                   from temp in tempItems.DefaultIfEmpty()
                   where ReferenceEquals(null, temp) || temp.Equals(default(T))
                   select item;

        }

        //public static T DeepClone<T>(T obj)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, obj);
        //        ms.Position = 0;

        //        return (T)formatter.Deserialize(ms);
        //    }
        //}

        public static async Task<byte[]> ToCsvAync<T>(this List<T> list)
        {
            try
            {
                byte[] result;
                using (var memoryStream = new MemoryStream())
                {
                    using (var streamWriter = new StreamWriter(memoryStream))
                    {
                        using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture, leaveOpen: false))
                        {
                            csvWriter.WriteRecords(list);
                            streamWriter.Flush();
                            result = memoryStream.ToArray();
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> genericEnumerable)
        {
            return ((genericEnumerable == null) || (!genericEnumerable.Any()));
        }
        
        public static bool IsNullOrEmpty<T>(this ICollection<T> genericCollection)
        {
            if (genericCollection == null)
            {
                return true;
            }
            return genericCollection.Count < 1;
        }

    }
}
