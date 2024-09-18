﻿using System.IO;
using System.Reflection;

namespace ExcelParser.Properties
{
    public class TxtHandler
    {
        public static string ReadConfigFile(string fileName)
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string configFilePath = Path.Combine(exeDirectory, fileName);
            
            if (File.Exists(configFilePath))
            {
                return File.ReadAllText(configFilePath);
            }
           
            Logger.Log(fileName + " failed to load!");
            return "";
        }
    }
}