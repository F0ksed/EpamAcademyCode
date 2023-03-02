namespace DevelopmentAndBuildToolsTask
{
    internal static class StrategiesOfComparison
    {
        internal static bool AnyUnequalConsecutiveStrategy(char first, char second)
        {
            return first != second;
        }

        internal static bool ConsecutiveIdenticalLatinLettersStrategy(char first, char second)
        {
            return first == second && 
                char.IsAscii(first) && char.IsAscii(second) && 
                char.IsLetter(first) && char.IsLetter(second);
        }

        internal static bool ConsecutiveIdenticalDigitsStrategy(char first, char second)
        {
            return first == second && 
                char.IsDigit(first) && char.IsDigit(second);
        }
    }
}
