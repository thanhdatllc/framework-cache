using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thanh_Dat_LLC_Frameworks.Cache
{
    public static class CacheTools
    {
        public static string GetCache(string fileName)
        {
            var fullPath = AppDomain.CurrentDomain.BaseDirectory + @"Caches\" + fileName;
            if (File.Exists(fullPath))
            {
                // Use StreamReader to consume the entire text file.
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    return reader.ReadToEnd();
                }
            }
            return null;
        }
        public static string GetCache(string path, string fileName)
        {
            var fullPath = path + fileName;
            if (File.Exists(fullPath))
            {
                // Use StreamReader to consume the entire text file.
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    return reader.ReadToEnd();
                }
            }
            return null;
        }
    }
}
