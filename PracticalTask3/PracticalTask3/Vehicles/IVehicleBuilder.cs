namespace PracticalTask3.Vehicles
{
    internal interface IVehicleBuilder
    {
        public void SetName(string name);
        public void SetEngine(int power, int volume, string type, string serial);
        public void SetChassis(int wheels, string vin, int load);
        public void SetTransmission(int gears, string type, string manufacturer);
        public IVehicle Build();
    }
}
