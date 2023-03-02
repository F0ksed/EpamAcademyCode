using DevelopmentAndBuildToolsTask;
/// <summary>
/// Practical task 1. Takes user input and returns maximum number of unequal consecutive characters.
/// Extended as per Unit test framework task with maximum number of consecutive identical letters of the Latin alphabet
/// and maximum number of consecutive identical digits.
/// </summary>
class MaxConsecutiveCharacters
{
    static void Main()
    {
        CharacterCalculator characterCalculator = new ();

        Console.WriteLine("Type exit to finish the process.");
        while (true) 
        {
            Console.Write("Input command: ");
            switch (Console.ReadLine().ToLower()) 
            {
                case "exit":
                    {
                        return;
                    }
                case "unequal characters":
                    {
                    Console.Write("Input string: ");
                    Console.WriteLine("Maximum number of unequal consecutive characters is: " +  
                        $"{characterCalculator.CalculateUnequalConsecutiveAmount(Console.ReadLine())}");
                        break;
                    }
                case "identical latin letters":
                    {
                        Console.Write("Input string: ");
                        Console.WriteLine("Maximum number of identical consecutive latin letters is: " +
                            $"{characterCalculator.CalculateConsecutiveIdenticalLatinLettersAmount(Console.ReadLine())}");
                        break;
                    }
                case "identical digits":
                    {
                        Console.Write("Input string: ");
                        Console.WriteLine("Maximum number of identical consecutive digits is: " +
                            $"{characterCalculator.CalculateConsecutiveIdenticalDigitsAmount(Console.ReadLine())}");
                        break;
                    }
                default: 
                    {
                        Console.WriteLine("Unequal characters, identical latin letters and identical digits are available. ");
                        break;
                    }
            }
        }
    }
}
