using PracticalTask3.CarParts;

namespace PracticalTask3.Vehicles
{
    public class Bus : IVehicle
    {
        public string Name { get; init; } = "n/a";
        public string Type { get; init; }
        public Engine Engine { get; init; } = new();
        public Chassis Chassis { get; init; } = new();
        public Transmission Transmission { get; init; } = new();

        public Bus()
        {
            Type = GetType().Name;
        }

        public string GetInfo()
        {
            return (Type + " " + Name + Engine.GetDescription() +
                Chassis.GetDescription() + Transmission.GetDescription() + "\n");
        }
    }
}
