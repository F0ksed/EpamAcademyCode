using OopTask.CarParts;

namespace OopTask.Vehicles
{
    internal interface IVehicleBuilder
    {
        public void SetName(string name);
        public void SetEngine(Engine engine);
        public void SetChassis(Chassis chassis);
        public void SetTransmission(Transmission transmission);
        public IVehicle Build();
    }
}
