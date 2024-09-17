using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace ExcelParser
{
    public class VehicleFuelStatistics
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private List<int> _refuels;
        private List<int> _travelsDistances;
        private List<double> _theoryConsumptions;

        private double _fuelConsumption;

        public VehicleFuelStatistics()
        {
            _name = " none ";
            _refuels = new List<int>();
            _travelsDistances = new List<int>();
            _theoryConsumptions = new List<double>();
            _fuelConsumption = 0;
        }

        public void AddRefuel(int value)
        {
            _refuels.Add(value);
        }
        
        public void AddTravel(int value)
        {
            _travelsDistances.Add(value);
        }

        public void SetFuelConsumption(double value)
        {
            _fuelConsumption = value;
        }

        public void PrintAll()
        {
            for (int i = 0; i < _travelsDistances.Count; i++)
            {
                Logger.Log("All data in " + _name);
                Console.WriteLine($"{_travelsDistances[i]}\t{_refuels[i]}");
            }
        }

        private void CalculateTheoryConsumption()
        {
            double consumptionBuf = 0f;
            int volumeBuf = 0;
            int distanceBuf = 0;
            int lastRefuelIndex = 0;
            
            for (int i = 0; i < _refuels.Count; i++)
            {
                if (_refuels[i] != 0)
                { 
                   if (distanceBuf != 0)
                   {
                       consumptionBuf = (double)(volumeBuf * 100) / distanceBuf;
                   }

                   for (int j = 0; j < i-lastRefuelIndex; j++)
                   {
                       _theoryConsumptions.Add(consumptionBuf);
                   }
                   
                   lastRefuelIndex = i;
                   volumeBuf = _refuels[i];
                   distanceBuf = _travelsDistances[i];
                }
                else
                {
                    distanceBuf += _travelsDistances[i];
                }
            }
        }
    }
}