using InterfacesAndAbstractClassesTask;
/// <summary>
/// Practical task 4. Provides assess to different flyers,
/// each exposing flyto and getflytime methods.
/// Provides a way to imput sequential commands from the command line.
/// </summary>
class FlyingObjects
{
    static void Main(string[] args)
    {
        IFlyable flyingObject;
        List<(string, Coordinate)> instructions = new();

        if (args.Length < 5) 
        {
            Console.WriteLine("Enter an object(bird, plane, drone) and a list of commands(flyto, getflytime)" +
                " with corresponding set of XYZ coordinates for each.");
            return;
        }

        switch (args[0].ToLower())
        {
            case "bird":
                {
                    flyingObject = new Bird(new Coordinate());
                    break;
                }
            case "plane":
                {
                    flyingObject = new Plane(new Coordinate());
                    break;
                }
            case "drone":
                {
                    flyingObject = new Drone(new Coordinate());
                    break;
                }
            default: 
                {
                    Console.WriteLine("Object not found.");
                    return;
                }
        }

        try
        {
            for (int i = 1; i< args.Length; i+=4) 
            {
                instructions.Add((args[i], new Coordinate(double.Parse(args[i+1]),
                    double.Parse(args[i + 2]), double.Parse(args[i + 3]))));
            }
        } 
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        foreach (var instruction in instructions)
        {
            switch (instruction.Item1)
            {
                case "flyto":
                    {
                        flyingObject.FlyTo(instruction.Item2);
                        break;
                    }
                case "getflytime":
                    {
                        flyingObject.GetFlyTime(instruction.Item2);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("No method found.");
                        return;
                    }
            }
        }

        Console.ReadKey();
    }
}
