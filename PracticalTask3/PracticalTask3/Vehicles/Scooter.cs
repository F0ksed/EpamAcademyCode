﻿using PracticalTask3.CarParts;

namespace PracticalTask3.Vehicles
{
    public class Scooter : IVehicle
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
