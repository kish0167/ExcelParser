using System;
using OfficeOpenXml;

namespace ExcelParser
{
    public class DataCleaner
    {
        // Remove data based on conditions, e.g., date thresholds
        public void CleanOldData(ExcelWorkbook workbook)
        {
            foreach (var worksheet in workbook.Worksheets)
            {
                if (worksheet.Cells[2,1].Value != null)
                {
                    worksheet.Cells[5, 3, 27, 4].Value = null;
                    worksheet.Cells[5, 5, 27, 5].Value = "-";
                }   
            }
        }
    }
}