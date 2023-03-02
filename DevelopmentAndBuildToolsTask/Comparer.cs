namespace DevelopmentAndBuildToolsTask
{
    /// <summary>
    /// A sequential check of two elements, adding +1 if they are unequal.
    /// Returns current highest count on request of GetResult.
    /// </summary>
    internal class Comparer
    {
        int characterAmountCurrent, characterAmountMax;
        Func<char, char, bool> strategy;

        public Comparer(Func<char, char, bool> strategy) 
        {
            //"consecutive" means they can be either 0 or >=2 in number
            //so characterAmountCurrent should be at least 1 for non-empty input
            //and result in return 0 if it remains 1
            characterAmountCurrent = 1;
            characterAmountMax = 1;
            this.strategy = strategy;
        }

        public void Compare(char current, char next)
        {
            if (strategy(current, next))
            {
                characterAmountCurrent++;
            }
            else
            {
                if (characterAmountCurrent > characterAmountMax)
                {
                    characterAmountMax = characterAmountCurrent;
                }
                characterAmountCurrent = 1;
            }
        }

        public int GetResult()
        { 
            return (characterAmountMax > characterAmountCurrent ? characterAmountMax : characterAmountCurrent); 
        }

    }
}
