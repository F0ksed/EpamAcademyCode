using PracticalTask3.CarParts;

namespace PracticalTask3.Vehicles
{
    internal class PassengerCarBuilder: IVehicleBuilder
    {
        string vehicleName = "n/a";
        int enginePower = 0;
        int engineVolume = 0;
        string engineType = "n/a";
        string engineSerial = "n/a";
        int chassisWheels = 0;
        string chassisVin = "n/a";
        int chassisLoad = 0;
        int transmissionGears = 0;
        string transmissionType = "n/a";
        string transmissionManufacturer = "n/a";

        public void SetName(string name)
        { 
            vehicleName = name; 
        }

        public void SetEngine(int power, int volume, string type, string serial)
        {
            enginePower = power;
            engineVolume = volume;
            engineType = type;
            engineSerial = serial;
        }

        public void SetChassis(int wheels, string vin, int load)
        {
            chassisWheels = wheels;
            chassisVin = vin;
            chassisLoad = load;
        }

        public void SetTransmission(int gears, string type, string manufacturer)
        {
            transmissionGears = gears;
            transmissionType = type;
            transmissionManufacturer = manufacturer;
        }

        public IVehicle Build() 
        {
            return new PassengerCar()
            {
                Name = vehicleName,
                Engine = new Engine { Power = enginePower, Volume = engineVolume, 
                    Serial = engineSerial, Type = engineType },
                Chassis = new Chassis { Wheels = chassisWheels, Vin = chassisVin, Load = chassisLoad },
                Transmission = new Transmission {Gears = transmissionGears, 
                    Type = transmissionType, Manufacturer = transmissionManufacturer }
            };
        }
    }
}
