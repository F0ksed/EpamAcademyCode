using PracticalTask3;
using PracticalTask3.Vehicles;

/// <summary>
/// Practical task 3. Assembles a list of vehicles and outputs it to the console.
/// </summary>
class CarParkLauncher
{
    static void Main()
    {
        CarPark carPark = new();
        carPark.AddAuto(ParkPopulator.Populate());

        for (int i = 0; i < carPark.GetSize(); 
            Console.WriteLine(carPark.GetAuto(i).GetInfo()), i++);
    }
}
