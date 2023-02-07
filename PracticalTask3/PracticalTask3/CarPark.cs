using PracticalTask3.Vehicles;
using PracticalTask3.Exceptions;

namespace PracticalTask3
{
    public class CarPark
    {
        private Dictionary<int, IVehicle> vehiclesInside = new();
        private int nextId = 0;

        public void AddAuto(IVehicle vehicle)
        {
            vehiclesInside.Add(nextId, vehicle);
            nextId++;
        }

        public void AddAuto(IEnumerable<IVehicle> vehicles)
        {
            foreach (IVehicle vehicle in vehicles) 
            {
                AddAuto(vehicle);
            }
        }

        public void UpdateAuto(int id, IVehicle vehicle) 
        {
            if (vehiclesInside.ContainsKey(id))
            {
                vehiclesInside[id] = vehicle;
            }
            else
            {
                throw new UpdateAutoException("ID doesn't exist.");
            }
        }

        public void RemoveAuto(int id) 
        {
            if (vehiclesInside.ContainsKey(id)) 
            {
                vehiclesInside.Remove(id);
            }
            else
            {
                throw new RemoveAutoException("ID doesn't exist.");
            }
        }

        public IEnumerable<IVehicle> GetAutoList()
        {
            return (from vehicle in vehiclesInside.Values select vehicle);
        }
    }
}
