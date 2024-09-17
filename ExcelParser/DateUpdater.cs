using System;
using OfficeOpenXml;

namespace ExcelParser
{
    public class DateUpdater
    {
        // Update dates in the Excel file
        public void UpdateDates(ExcelWorkbook workbook)
        {
            DateTime firstDayOfTheMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            firstDayOfTheMonth = firstDayOfTheMonth.AddMonths(2);
            foreach (var worksheet in workbook.Worksheets)
            {
                
                if (worksheet.Cells[2, 1].Value == null)
                {
                    continue;
                }
                
                DateTime dateBuf = firstDayOfTheMonth.AddMonths(-1);
                int i = 0;
                while (dateBuf < firstDayOfTheMonth)
                {
                    if (dateBuf.DayOfWeek.Equals(DayOfWeek.Saturday) || dateBuf.DayOfWeek.Equals(DayOfWeek.Sunday))
                    {
                        dateBuf = dateBuf.AddDays(1);
                        continue;
                    }
                    
                    worksheet.Cells[i+5, 2].Value = dateBuf;
                    
                    dateBuf = dateBuf.AddDays(1);
                    i++;
                }
            }
        }
    }
}