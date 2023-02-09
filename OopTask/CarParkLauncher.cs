using OopTask;
using OopTask.Exceptions;
using OopTask.Vehicles;
using OopTask.CarParts;
using System.Diagnostics;

/// <summary>
/// Practical task 3. Assembles a list of vehicles and outputs it to the console.
/// </summary>
class CarParkLauncher
{
    static void Main(string[] args)
    {
        CarPark carPark = new();
        carPark.AddAuto(ParkPopulator.Populate());
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

        try
        {
            switch (args[0])
            {
                case "listall":
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
                    PassengerCarBuilder demoCarBuilder = new();
                    demoCarBuilder.SetEngine(new Engine());
                    demoCarBuilder.SetChassis(new Chassis());
                    demoCarBuilder.SetTransmission(new Transmission());
                    carPark.AddAuto(demoCarBuilder.Build());

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
