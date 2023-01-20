using PracticalTask1;
/// <summary>
/// Practical task 1. Takes user input and returns maximum number of unequal consecutive characters.
/// </summary>
class MaxConsecutiveCharacters
{
    static void Main(string[] args)
    {
        CharacterCalculator characterCalculator = new ();

        if (args.Length == 0 ) 
        {
            Console.WriteLine("Input characters to be calculated.");            
        }

        for (int i = 0; i < args.Length; Console.WriteLine(
            "Maximum number of unequal consecutive characters in line {0} is: {1}",
            i + 1, characterCalculator.CalculateAmount(args[i])), 
            i++);
    }
}
