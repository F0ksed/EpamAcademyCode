using PracticalTask3;
using PracticalTask3.Exceptions;

/// <summary>
/// Practical task 3. Assembles a list of vehicles and outputs it to the console.
/// </summary>
class CarParkLauncher
{
    static void Main()
    {
        CarPark carPark = new();
        carPark.AddAuto(ParkPopulator.Populate());
        foreach (var vehicle in carPark.GetAutoList())
        {
            Console.WriteLine(vehicle.GetInfo());
        }
    }
}
