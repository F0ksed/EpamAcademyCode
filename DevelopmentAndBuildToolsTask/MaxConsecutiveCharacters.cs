using DevelopmentAndBuildToolsTask;
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

        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"Maximum number of unequal consecutive characters in line {i + 1} " +
            $"is: {characterCalculator.CalculateAmount(args[i])}");
        }
    }
}
