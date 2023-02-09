﻿using OopTask.CarParts;

namespace OopTask.Vehicles
{
    internal class ScooterBuilder : IVehicleBuilder
    {
        string vehicleName = "n/a";
        Engine engine = new();
        Chassis chassis = new();
        Transmission transmission = new();

        public void SetName(string name)
        {
            vehicleName = name;
        }

        public void SetEngine(Engine engine)
        {
            this.engine = engine;
        }

        public void SetChassis(Chassis chassis)
        {
            this.chassis = chassis;
        }

        public void SetTransmission(Transmission transmission)
        {
            this.transmission = transmission;
        }

        public IVehicle Build()
        {
            return new Scooter()
            {
                Name = vehicleName,
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission
            };
        }
    }
}
