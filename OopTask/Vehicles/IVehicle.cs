using OopTask.CarParts;

namespace OopTask.Vehicles
{
    /// <summary>
    /// Contains car parts and method for outputting information about them.
    /// </summary>
    public interface IVehicle
    {
        public string Name { get; init; }
        public Engine Engine { get; init; }
        public Chassis Chassis { get; init; }
        public Transmission Transmission { get; init; }

        public string GetInfo();
    }
}
