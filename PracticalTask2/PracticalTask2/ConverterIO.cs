using PracticalTask2;
/// <summary>
/// Practical Task 2. Takes 2 input values and converts first to the base of second.
/// </summary>
class ConverterIO
{
    /// <summary>
    /// Entrance point, checks user input and passes it to the calculator to convert.
    /// </summary>
    /// <param name="args">Uses first two input values, ignores the rest.</param>
    static void Main(string[] args)
    {
        int inNum = 0;
        int inBase = 10;
        Converter converter = new Converter();

        try
        {
            inNum = int.Parse(args[0]);
            inBase = int.Parse(args[1]);
            if (args.Length != 2)
            {
                Console.WriteLine("Input only 2 values - " +
                    "the number to be converted and base.");
            }

            Console.WriteLine("{0} equals {1} in base {2}", 
                inNum, converter.ToBase(inNum, inBase), inBase);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }  
}
