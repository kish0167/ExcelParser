using System;
using System.Data;
using OfficeOpenXml;

namespace ExcelParser
{
    public class MonthlyFileUpdater
    {
        private string _sourceFile ;
        string archiveFolder = "D:/files/";

        public MonthlyFileUpdater(string sourceFile)
        {
            _sourceFile = sourceFile;
        }
        
        public void Update()
        {
            Logger.Log("Starting updating process...");

            ExcelFileManager fileManager = new ExcelFileManager(_sourceFile, archiveFolder + DateTime.Now.ToString() + ".xlsx");
            ExcelPackage package = fileManager.LoadExcelFile();
            ExcelWorkbook workbook = package.Workbook;
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            // Archive data
            fileManager.ArchiveData(package);
            Logger.Log("Data archived.");

            // Clean old data
            DataCleaner cleaner = new DataCleaner();
            cleaner.CleanOldData(workbook);
            Logger.Log("Old data cleaned.");

            // Update dates
            DateUpdater dateUpdater = new DateUpdater();
            dateUpdater.UpdateDates(workbook);
            Logger.Log("Dates updated.");

            // Save the cleaned and updated file
            fileManager.SaveExcelFile(package);
            Logger.Log("File saved.");

            Logger.Log("Updating complete.");
        }
    }
}