namespace PracticalTask1
{
    /// <summary>
    /// Contains logic for the calculation of maximum number of unequal consecutive characters.
    /// </summary>
    internal class Calculator
    {
        /// <summary>
        /// A sequential check of all elements, adding +1 if they are unequal.
        /// </summary>
        /// <param name="userInput">A string of characters to be tallied.</param>
        /// <returns>Maximum number of unequal consecutive characters.</returns>
        public int CalculateCharacters(string userInput)
        {
            //"consecutive" means they can be either 0 or >=2 in number
            //so amount should be at least 1 for non-empty input
            //and result in return 0 if it remains 1
            int amount = 1;
            int amountMax = 1;

            if (userInput.Length > 0)
            {                
                for (int i = 0; i < userInput.Length - 1; i++)
                {
                    if (userInput[i] != userInput[i + 1])
                    {
                        amount++;
                    }
                    else if (amount > amountMax)
                    {
                        amountMax = amount;
                        amount = 1;
                    }
                }

                if (amount > amountMax)
                {
                    amountMax = amount;
                }           
            }

            return (amountMax>1 ? amountMax : 0);
        }
    }
}
