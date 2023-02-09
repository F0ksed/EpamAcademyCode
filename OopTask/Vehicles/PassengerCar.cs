using OopTask.CarParts;

namespace OopTask.Vehicles
{
    public class PassengerCar : IVehicle
    {
        public string Name { get; init; } = "n/a";
        public Engine Engine { get; init; } = new();
        public Chassis Chassis { get; init; } = new();
        public Transmission Transmission { get; init; } = new();

        public string GetInfo()
        {
            return (GetType().Name + " " + Name + Engine.GetDescription() +
                Chassis.GetDescription() + Transmission.GetDescription() + "\n");
        }
    }
}
