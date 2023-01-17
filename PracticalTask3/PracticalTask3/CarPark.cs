using PracticalTask3;
using PracticalTask3.Vehicles;

/// <summary>
/// Practical task 3. Assembles a list of vehicles and outputs it to the console.
/// </summary>
class CarPark
{
    static void Main()
    {
        List<IVehicle> vehicles = ParkPopulator.Populate();

        for (int i = 0; i < vehicles.Count; 
            Console.WriteLine(vehicles[i].GetInfo()), i++);
    }
}
