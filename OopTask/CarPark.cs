using OopTask.Vehicles;
using OopTask.Exceptions;
using System.Reflection;

namespace OopTask
{
    public class CarPark
    {
        private Dictionary<int, IVehicle> vehiclesInside = new();
        private int nextId = 0;

        public void AddAuto(IVehicle vehicle)
        {
            try
            {
                vehiclesInside.Add(nextId, vehicle);
                nextId++;
            }
            catch 
            {
                throw new AddException();
            }
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

        public List<IVehicle> GetAutoByParameter(string parameter, string value)
        {
            List<IVehicle> fittingVehicles = new();
            List<string> decoupledParameters = new() { "" };
            object propinf;

            for (int i = 0; i < parameter.Length; i++)
            {
                if (parameter[i] != '.')
                {
                    decoupledParameters[^1] += parameter[i];
                }
                else
                {
                    decoupledParameters.Add("");
                }
            }

            foreach (var vehicle in vehiclesInside.Values)
            {
                propinf = GetProperty(decoupledParameters[0], vehicle);

                for (int i = 1; i < decoupledParameters.Count; i++) 
                {
                    propinf = GetProperty(decoupledParameters[i], propinf);
                }

                if (propinf.ToString() == value)
                {
                    fittingVehicles.Add(vehicle);
                }
            }
            return fittingVehicles;
        }

        private object? GetProperty(string property, object obj)
        {
        foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
        {
            if (propertyInfo.Name == property)
            {
                return propertyInfo.GetValue(obj);
            }
        }

        throw new GetAutoByParameterException("Property not found");
        }
    }
}
