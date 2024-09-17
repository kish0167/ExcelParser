using System;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace ExcelParser
{
    static class App
    {
        public static void Main(string[] args)
        {
            MonthlyFileUpdater updater = new MonthlyFileUpdater("D:/files/Учет топлива 0.3.xlsx");
            updater.Update();
        }
        
    }
    
    
}