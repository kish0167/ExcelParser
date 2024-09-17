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
                if (!ExcelSettings.IsVehicleSheet(worksheet))
                {
                    continue;
                }   
                ExcelSettings.NumericDataCells(worksheet).Value = null;
                ExcelSettings.ConstructionSitesCells(worksheet).Value = "-";
            }
        }
    }
}