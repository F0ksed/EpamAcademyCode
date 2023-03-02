namespace DevelopmentAndBuildToolsTask
{
    /// <summary>
    /// Contains logic for the calculation of maximum number of unequal consecutive characters.
    /// </summary>
    internal class CharacterCalculator
    {
        public int CalculateUnequalConsecutiveAmount(string userInput)
        {
            Comparer comparer= new Comparer(StrategiesOfComparison.AnyUnequalConsecutiveStrategy);

            if (userInput.Length > 0)
            {
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    comparer.Compare(userInput[i], userInput[i + 1]);
                }          
            }

            return (comparer.GetResult()>1 ? comparer.GetResult() : 0);
        }

        public int CalculateConsecutiveIdenticalLatinLettersAmount(string userInput)
        {
            Comparer comparer = new Comparer(StrategiesOfComparison.ConsecutiveIdenticalLatinLettersStrategy);

            if (userInput.Length > 0)
            {
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    comparer.Compare(userInput[i], userInput[i + 1]);
                }
            }

            return (comparer.GetResult() > 1 ? comparer.GetResult() : 0);
        }

        public int CalculateConsecutiveIdenticalDigitsAmount(string userInput)
        {
            Comparer comparer = new Comparer(StrategiesOfComparison.ConsecutiveIdenticalDigitsStrategy);

            if (userInput.Length > 0)
            {
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    comparer.Compare(userInput[i], userInput[i + 1]);
                }
            }

            return (comparer.GetResult() > 1 ? comparer.GetResult() : 0);
        }
    }
}
