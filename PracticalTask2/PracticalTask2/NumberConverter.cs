using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PracticalTask2
{
    /// <summary>
    /// Handles logic of number system conversion.
    /// </summary>
    internal class NumberConverter
    {
        ReadOnlyCollection<char> numerals = new(new List<char>
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' });

        /// <summary>
        /// Using the successive division method. Implemented vocabulary only handles base no more than 20.
        /// </summary>
        /// <param name="inputNumber">Int32. The number to be converted.</param>
        /// <param name="inputBase">Int32. Base the number should be converted to.</param>
        /// <returns>String of characters representing the number converted to requested base.</returns>
        public string ToBase(int inputNumber, int inputBase)
        {
            Stack<char> divisionResult = new();
            string output = (inputNumber >= 0) ? new("") : new("-");

            inputNumber = Math.Abs(inputNumber);
            if (inputBase <= 1 || inputBase > numerals.Count)
            {
                throw new ArgumentException("Invalid base value.");
            }

            if (inputBase != 10)
            {
                do
                {
                    divisionResult.Push(numerals[inputNumber % inputBase]);
                    inputNumber /= inputBase;
                } while (inputNumber >= inputBase);

                divisionResult.Push(numerals[inputNumber]);

                do
                {
                    output += divisionResult.Pop();
                } while (divisionResult.Count > 0);

                return output;
            }
            else
            {
                return inputNumber.ToString();
            }
        }
    }
}
