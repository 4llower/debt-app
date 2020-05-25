using System;
using System.IO;

namespace DManager
{
    internal static class Settings
    {
        public static string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DBContext.db");
    }
}
