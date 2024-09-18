using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.Xml;
using ExcelParser.Properties;
using OfficeOpenXml;
using OfficeOpenXml.ExternalReferences;

namespace ExcelParser
{
    enum ConfigTypes
    {
        NumericDataCells = 0,
        ConstructionSitesCells = 1,
        DateCells = 2,
        TravelDistancesCells = 3,
        RefuelsDataCells = 4,
        ConsumptionDataCells = 5,
        NameCells = 6
    }

    public static class ExcelSettings
    {
        private static List<string> _locationsInExcel;
        
        private const string ConfigFileName = "config.txt";

        public static ExcelRange NumericDataCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[_locationsInExcel[(int)ConfigTypes.NumericDataCells]];
        }

        public static ExcelRange ConstructionSitesCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[_locationsInExcel[(int)ConfigTypes.ConstructionSitesCells]];
        }

        public static ExcelRange DateCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[_locationsInExcel[(int)ConfigTypes.DateCells]];
        }

        public static ExcelRange TravelsDistancesCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[_locationsInExcel[(int)ConfigTypes.TravelDistancesCells]];
        }

        public static ExcelRange RefuelsDataCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[_locationsInExcel[(int)ConfigTypes.RefuelsDataCells]];
        }

        public static ExcelRange ConsumptionDataCells(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[_locationsInExcel[(int)ConfigTypes.ConsumptionDataCells]];
        }

        public static ExcelRange NameCell(ExcelWorksheet worksheet)
        {
            return worksheet.Cells[_locationsInExcel[(int)ConfigTypes.NameCells]];
        }



        public const int Rows = 23;

        public static bool IsVehicleSheet(ExcelWorksheet worksheet)
        {
            if (worksheet.Cells[_locationsInExcel[(int)ConfigTypes.NameCells]].Value != null)
            {
                return true;
            }

            return false;
        }


        public static void LoadSettings()
        {
            Logger.Log("Loading config file...");
            string configs = TxtHandler.ReadConfigFile(ConfigFileName);

            string[] lines = configs.Split('\n');

            _locationsInExcel = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                _locationsInExcel.Add("A1");
            }
            
            foreach (string option in lines)
            {
                foreach (var configType in Enum.GetValues(typeof(ConfigTypes)))
                {
                    if (option.Contains(configType.ToString()))
                    {
                        string[] separateOption = option.Replace('\r', '-').Split('-');
                        ConfigTypes a = (ConfigTypes)Enum.Parse(typeof(ConfigTypes), separateOption[0]);
                        _locationsInExcel[(int)a] = separateOption[1];
                    }
                }
                
            }
            
            Logger.Log("Configs loaded.");
        }
    }
}
