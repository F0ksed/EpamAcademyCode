﻿using OopTask.CarParts;
using OopTask.Exceptions;

namespace OopTask.Vehicles
{
    internal class TruckBuilder : IVehicleBuilder
    {
        string? vehicleName;
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
            if (vehicleName == null)
            {
                throw new InitializationException("Vehicle's name cannot be empty.");
            }
            return new Truck()
            {
                Name = vehicleName,
                Engine = engine,
                Chassis = chassis,
                Transmission = transmission
            };
        }
    }
}
