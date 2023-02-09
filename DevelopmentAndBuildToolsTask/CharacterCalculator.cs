namespace DevelopmentAndBuildToolsTask
{
    /// <summary>
    /// Contains logic for the calculation of maximum number of unequal consecutive characters.
    /// </summary>
    internal class CharacterCalculator
    {
        /// <summary>
        /// A sequential check of all elements, adding +1 if they are unequal.
        /// </summary>
        /// <param name="userInput">A string of characters to be tallied.</param>
        /// <returns>Maximum number of unequal consecutive characters.</returns>
        public int CalculateAmount(string userInput)
        {
            //"consecutive" means they can be either 0 or >=2 in number
            //so characterAmountCurrent should be at least 1 for non-empty input
            //and result in return 0 if it remains 1
            int characterAmountCurrent = 1;
            int characterAmountMax = 1;

            if (userInput.Length > 0)
            {                
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    if (userInput[i] != userInput[i + 1])
                    {
                        characterAmountCurrent++;
                    }
                    else if (characterAmountCurrent > characterAmountMax)
                    {
                        characterAmountMax = characterAmountCurrent;
                        characterAmountCurrent = 1;
                    }
                }

                if (characterAmountCurrent > characterAmountMax)
                {
                    characterAmountMax = characterAmountCurrent;
                }           
            }

            return (characterAmountMax>1 ? characterAmountMax : 0);
        }
    }
}
