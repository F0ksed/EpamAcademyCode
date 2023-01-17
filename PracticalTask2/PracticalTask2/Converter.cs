using System.Collections.ObjectModel;

namespace PracticalTask2
{
    /// <summary>
    /// Handles logic of number system conversion.
    /// </summary>
    internal class Converter
    {
        /// <summary>
        /// Using the successive division method. Implemented vocabulary only handles base no more than 20.
        /// </summary>
        /// <param name="inNum">Int32. The number to be converted.</param>
        /// <param name="inBase">Int32. Base the number should be converted to.</param>
        /// <returns>String of characters representing the number converted to requested base.</returns>
        public string ToBase(int inNum, int inBase)
        {
            var numerals = new ReadOnlyCollection<char>(new List<char>
                { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' });
            List<char> result = new();
            string output = (inNum > 0) ? new("") : new("-");

            inNum = Math.Abs(inNum);
            if (inBase <= 1 || inBase > 20)
            {
                inBase = 10;
                throw new Exception("Invalid base value.");
            }

            if (inBase != 10)
            {
                do
                {
                    result.Add(numerals[inNum % inBase]);
                    inNum /= inBase;
                } while (inNum >= inBase);

                result.Add(numerals[inNum]);

                for(int i = result.Count - 1; i >= 0; i--)
                {
                    output += result[i];
                }

                return output;
            }
            else
            {
                return inNum.ToString();
            }
        }
    }
}
