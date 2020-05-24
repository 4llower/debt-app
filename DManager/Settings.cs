using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DManager
{
    static class Settings
    {
        public static string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DBContext.db");
    }
}
