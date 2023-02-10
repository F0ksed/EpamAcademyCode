using OopTask;
using OopTask.Exceptions;
using OopTask.Vehicles;
using OopTask.CarParts;
using System.Diagnostics;

/// <summary>
/// Practical task 3. Assembles a list of vehicles and provides IO commands.
/// Extended with exceptions for practical task 6.
/// </summary>
class CarParkLauncher
{
    static void Main(string[] args)
    {
        CarPark carPark = new();
        carPark.AddAuto(ParkPopulator.Populate());
        IVehicleBuilder carBuilder;
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

        //for the sake of demonstartion
        carBuilder = new PassengerCarBuilder();
        carBuilder.SetName("Mitsubishi Lancer");
        carBuilder.SetEngine(new Engine() { Power = 86, Volume = 1998, Type = "diesel", Serial = "4BT39C70D5" });
        carBuilder.SetChassis(new Chassis() { Wheels = 4, Vin = "WP0CA29924S650563", Load = 720 });
        carBuilder.SetTransmission(new Transmission() { Gears = 5, Type = "manual", Manufacturer = "Mitsubishi" });

        try
        {
            switch (args[0])
            {
                case "GetInfo":
                {
                    foreach (IVehicle vehicle in carPark.GetAutoList())
                    {
                        Console.WriteLine(vehicle.GetInfo());
                    }
                    break;
                }
                case "GetAutoByParameter":
                {
                    foreach (IVehicle vehicle in carPark.GetAutoByParameter(args[1], args[2]))
                    {
                        Console.WriteLine(vehicle.GetInfo());
                    }
                    break;
                }
                case "RemoveAuto":
                {
                    carPark.RemoveAuto(int.Parse(args[1]));

                    foreach (IVehicle vehicle in carPark.GetAutoList())
                    {
                        Console.WriteLine(vehicle.GetInfo());
                    }
                    break;
                }
                case "AddAuto":
                {
                    carPark.AddAuto(carBuilder.Build());

                    foreach (IVehicle vehicle in carPark.GetAutoList())
                    {
                        Console.WriteLine(vehicle.GetInfo());
                    }
                    break;
                }
                case "UpdateAuto":
                {
                    carPark.UpdateAuto(int.Parse(args[1]), carBuilder.Build());

                    foreach (IVehicle vehicle in carPark.GetAutoList())
                    {
                        Console.WriteLine(vehicle.GetInfo());
                    }
                    break;
                }
            }
        }
        catch (Exception e) when (e is RemoveAutoException || 
                                  e is AddException ||
                                  e is GetAutoByParameterException || 
                                  e is UpdateAutoException || 
                                  e is InitializationException)
        {
            Trace.WriteLine(e);
        }
    }
}
