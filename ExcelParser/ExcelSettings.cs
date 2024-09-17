using OfficeOpenXml;
using OfficeOpenXml.ExternalReferences;

namespace ExcelParser
{
    
    
    
    public static class ExcelSettings
    {
        public static ExcelRange NumericDataCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[5, 3, 27, 4];
        }
        
        public static ExcelRange ConstructionSitesCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[5, 5, 27, 5];
        }
        
        public static ExcelRange DateCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[5, 2, 27, 2];
        }
        
        
        public static bool IsVehicleSheet(ExcelWorksheet worksheet)
        {
            if (worksheet.Cells[2, 1].Value != null)
            {
                return true;
            }

            return false;
        }
    }
}