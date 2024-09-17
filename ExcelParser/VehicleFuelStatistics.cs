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
        private List<int> _theoryConsumption;

        private double _fuelConsumption;

        public VehicleFuelStatistics()
        {
            _name = " none ";
            _refuels = new List<int>();
            _travelsDistances = new List<int>();
            _theoryConsumption = new List<int>();
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
            Console.WriteLine(Name);
            for (int i = 0; i < _travelsDistances.Count; i++)
            {
                Console.WriteLine($"{_travelsDistances[i]}  {_refuels[i]}");
            }
        }

        private void CalculateTheoryConsumption()
        {
            int distSum = 0;
            foreach (var d in _travelsDistances)
            {
                distSum += d;
            }
            
        }
        
        
    }
}