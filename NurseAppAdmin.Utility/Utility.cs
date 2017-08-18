<<<<<<< HEAD:NurseAppAdmin.Utility/Utility.cs
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurseAppAdmin.Utility
{
    public class Utility
    {
        public static string GetFileContent(string FilePath)
        {
            string result;
            using (StreamReader streamReader = new StreamReader(FilePath, Encoding.UTF8))
            {
                result = streamReader.ReadToEnd();
            }
            return result;            
        }

        public static string GetAppConfigValues(string Key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
        }

        public static string GetDatabaseconnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnectionstring"].ConnectionString;
        }

        public static void WriteFile(string filePath,string data)
        {
            using (StreamWriter fileStream = new StreamWriter(filePath, true))
            {
                fileStream.WriteLine(data); // Write the text
            }
        }

    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectNAPI.Utility
{
    public class Utility
    {
        public static string GetFileContent(string FilePath)
        {
            string result;
            using (StreamReader streamReader = new StreamReader(FilePath, Encoding.UTF8))
            {
                result = streamReader.ReadToEnd();
            }
            return result;            
        }

        public static string GetAppConfigValues(string Key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
        }

        public static string GetDatabaseconnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnectionstring"].ConnectionString;
        }

        public static void WriteFile(string filePath,string data)
        {
            using (StreamWriter fileStream = new StreamWriter(filePath, true))
            {
                fileStream.WriteLine(data); // Write the text
            }
        }

    }
}
>>>>>>> origin/master:ConnectNAPI.Utility/Utility.cs
