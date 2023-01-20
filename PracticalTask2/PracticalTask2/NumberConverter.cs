using System.Collections.ObjectModel;

namespace PracticalTask2
{
    /// <summary>
    /// Handles logic of number system conversion.
    /// </summary>
    internal class NumberConverter
    {
        /// <summary>
        /// Using the successive division method. Implemented vocabulary only handles base no more than 20.
        /// </summary>
        /// <param name="inputNumber">Int32. The number to be converted.</param>
        /// <param name="inputBase">Int32. Base the number should be converted to.</param>
        /// <returns>String of characters representing the number converted to requested base.</returns>
        public string ToBase(int inputNumber, int inputBase)
        {
            var numerals = new ReadOnlyCollection<char>(new List<char>
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' });
            List<char> divisionResult = new();
            string output = (inputNumber > 0) ? new("") : new("-");

            inputNumber = Math.Abs(inputNumber);
            if (inputBase <= 1 || inputBase > 20)
            {
                inputBase = 10;
                throw new Exception("Invalid base value.");
            }

            if (inputBase != 10)
            {
                do
                {
                    divisionResult.Add(numerals[inputNumber % inputBase]);
                    inputNumber /= inputBase;
                } while (inputNumber >= inputBase);

                divisionResult.Add(numerals[inputNumber]);

                for(int i = divisionResult.Count - 1; i >= 0; i--)
                {
                    output += divisionResult[i];
                }

                return output;
            }
            else
            {
                return inputNumber.ToString();
            }
        }
    }
}
