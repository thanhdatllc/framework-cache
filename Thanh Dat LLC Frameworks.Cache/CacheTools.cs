using System;
using System.IO;

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
                using (var reader = new StreamReader(fullPath))
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
                using (var reader = new StreamReader(fullPath))
                {
                    return reader.ReadToEnd();
                }
            }
            return null;
        }

        public static void SetCache(string fileName, string contents)
        {
            var fullPath = AppDomain.CurrentDomain.BaseDirectory + @"Caches\" + fileName;
            if (!File.Exists(fullPath)) File.Create(fullPath);
            using (var writer = new StreamWriter(fullPath, true))
            {
                writer.Write(contents, true);
            }
        }

        public static void SetCache(string path, string fileName, string contents)
        {
            var fullPath = path + fileName;
            if (!File.Exists(fullPath)) File.Create(fullPath);
            using (var writer = new StreamWriter(fullPath, true))
            {
                writer.Write(contents, true);
            }
        }

        public static void CheckCacheExpired(string fileName, int hourExpired)
        {
            var fullPath = AppDomain.CurrentDomain.BaseDirectory + @"Caches\" + fileName;
            if (File.Exists(fullPath))
            {
                var ts = DateTime.Now - File.GetLastAccessTime(fullPath);
                if (ts.Hours > hourExpired) File.Delete(fullPath);
            }
        }

        public static void CheckCacheExpired(string path, string fileName, int hourExpired)
        {
            var fullPath = path + fileName;
            if (File.Exists(fullPath))
            {
                var ts = DateTime.Now - File.GetLastAccessTime(fullPath);
                if (ts.Hours > hourExpired) File.Delete(fullPath);
            }
        }
    }
}