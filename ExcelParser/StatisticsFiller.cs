using OfficeOpenXml;

namespace ExcelParser
{
    public class StatisticsFiller
    {
        private string _sourceFile;

        public StatisticsFiller(string sourceFile)
        {
            _sourceFile = sourceFile;
        }

        public void FillStatistics()
        {
            Logger.Log("Loading excel file...");
            ExcelFileManager fileManager = new ExcelFileManager(_sourceFile);
            ExcelWorkbook workbook = fileManager.LoadExcelFile().Workbook;
            
            Logger.Log("Reading data...");
            foreach (var worksheet in workbook.Worksheets)
            {
                if (!ExcelSettings.IsVehicleSheet(worksheet))
                {
                    continue;
                }
                
                
            }


        }
    }
}