using PracticalTask3.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask3
{
    internal class CarPark
    {
        private Dictionary<int, IVehicle> vehiclesInside = new();
        private int id = 0;

        public void AddAuto(IVehicle vehicle)
        {
            vehiclesInside.Add(id, vehicle);
            id++;
        }

        public void AddAuto(List<IVehicle> vehicles)
        {
            foreach (IVehicle vehicle in vehicles) 
            {
                AddAuto(vehicle);
            }
        }

        public void UpdateAuto() 
        {

        }

        public void RemoveAuto() 
        { 

        }

        public IVehicle GetAuto(int id)
        {
            return vehiclesInside[id];
        }

        public int GetSize()
        {
            return vehiclesInside.Count;
        }

        public IVehicle GetAutoByParameter(string parameter, string value)
        {
            return null;
        }
    }
}
