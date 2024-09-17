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
            MonthlyFileUpdater updater = new MonthlyFileUpdater("D:/files/Учет топлива 0.3.xlsx", "D:/files/");
            //updater.Update();

            StatisticsFiller statisticsFiller = new StatisticsFiller("D:/files/Учет топлива 0.4.xlsx");
            statisticsFiller.FillStatistics();
            
            
        }
        
    }
    
    
}