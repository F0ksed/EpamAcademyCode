using PracticalTask2;
using System.Diagnostics;
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
        int inputNumber = 0;
        int inputBase = 10;
        NumberConverter numberConverter = new ();

        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

        try
        {
            inputNumber = int.Parse(args[0]);
            inputBase = int.Parse(args[1]);
            if (args.Length != 2)
            {
                Console.WriteLine("Input only 2 values - " +
                    "the number to be converted and base.");
            }

            Console.WriteLine("{0} equals {1} in base {2}", 
                inputNumber, numberConverter.ToBase(inputNumber, inputBase), inputBase);
        }
        catch (FormatException e)
        {
            Trace.WriteLine(e);
        }
        catch (ArgumentException e)
        {
            Trace.WriteLine(e);
        }
    }  
}
