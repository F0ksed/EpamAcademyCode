using OopTask.Vehicles;
using OopTask.Exceptions;
using System.Reflection;

namespace OopTask
{
    public class CarPark
    {
        private Dictionary<int, IVehicle> vehiclesInside = new();
        private int nextId = 0;

        public void AddAuto(IVehicle addedVehicle)
        {
            foreach (IVehicle vehicle in vehiclesInside.Values)
            {
                if (vehicle.Engine.Serial == addedVehicle.Engine.Serial ||
                    vehicle.Chassis.Vin == addedVehicle.Chassis.Vin)
                {
                    throw new AddException("Similar car already exists.");
                }
            }

            vehiclesInside.Add(nextId, addedVehicle);
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
            return vehiclesInside.Values;
        }

        /// <summary>
        /// Searches all available vehicles for exact property values. Case sensitive. 
        /// </summary>
        /// <param name="parameter">Required property. Recognises dot operator for accessing lower level properties.</param>
        /// <param name="value">Value of the required property.</param>
        /// <returns>List of all fitting vehicles.</returns>
        public List<IVehicle> GetAutoByParameter(string parameter, string value)
        {
            List<IVehicle> fittingVehicles = new();
            object propertyInfo;
            string[] decoupledParameters = parameter.Split('.');

            foreach (var vehicle in vehiclesInside.Values)
            {
                propertyInfo = GetProperty(decoupledParameters[0], vehicle);

                for (int i = 1; i < decoupledParameters.Length; i++) 
                {
                    propertyInfo = GetProperty(decoupledParameters[i], propertyInfo);
                }

                if (propertyInfo.ToString() == value)
                {
                    fittingVehicles.Add(vehicle);
                }
            }
            return fittingVehicles;
        }

        /// <summary>
        /// Used to make a search loop in GetAutoByParameter.
        /// </summary>
        /// <exception cref="GetAutoByParameterException"></exception>
        private object GetProperty(string property, object obj)
        {
            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (propertyInfo.Name == property)
                {
                    if (propertyInfo.GetValue(obj) != null)
                    {
                        return propertyInfo.GetValue(obj);
                    }
                    else
                    {
                        throw new GetAutoByParameterException("Property is null.");
                    }
                }
            }

            throw new GetAutoByParameterException("Property not found.");
        }        
    }
}
