namespace DevelopmentAndBuildToolsTask
{
    /// <summary>
    /// Contains logic for the calculation of maximum number of unequal consecutive characters.
    /// </summary>
    public class CharacterCalculator
    {
        public int CalculateUnequalConsecutiveAmount(string userInput)
        {
            IComparer comparer = new ComparerWithMemory(StrategiesOfComparison.AnyUnequalConsecutiveStrategy);

            if (userInput!= null && userInput.Length > 0)
            {
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    comparer.CompareAndAddResult(userInput[i], userInput[i + 1]);
                }          
            }

            return (comparer.GetCurrentResult()>1 ? comparer.GetCurrentResult() : 0);
        }

        public int CalculateConsecutiveIdenticalLatinLettersAmount(string userInput)
        {
            IComparer comparer = new ComparerWithMemory(StrategiesOfComparison.ConsecutiveIdenticalLatinLettersStrategy);

            if (userInput != null && userInput.Length > 0)
            {
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    comparer.CompareAndAddResult(userInput[i], userInput[i + 1]);
                }
            }

            return (comparer.GetCurrentResult() > 1 ? comparer.GetCurrentResult() : 0);
        }

        public int CalculateConsecutiveIdenticalDigitsAmount(string userInput)
        {
            IComparer comparer = new ComparerWithMemory(StrategiesOfComparison.ConsecutiveIdenticalDigitsStrategy);

            if (userInput != null && userInput.Length > 0)
            {
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    comparer.CompareAndAddResult(userInput[i], userInput[i + 1]);
                }
            }

            return (comparer.GetCurrentResult() > 1 ? comparer.GetCurrentResult() : 0);
        }
    }
}
