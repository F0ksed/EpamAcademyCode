namespace DevelopmentAndBuildToolsTask.Tests
{
    public class CalculateUnequalConsecutiveAmountTest
    {
        [Theory()]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("aa")]
        public void Input_Returns_Zero(string input)
        {
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 0;

            output = calculator.CalculateUnequalConsecutiveAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Theory()]
        [InlineData("ab")]
        [InlineData("Aa")]
        public void Two_Uneequals_Returns_Two(string input)
        {
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 2;

            output = calculator.CalculateUnequalConsecutiveAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact()]
        public void Three_Starts_With_Two_Equals_Returns_Two()
        {
            string input = "aab";
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 2;

            output = calculator.CalculateUnequalConsecutiveAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact()]
        public void Number_Special_Symbol_And_Space_Returns_Three()
        {
            string input = "4% ";
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 3;

            output = calculator.CalculateUnequalConsecutiveAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact()]
        public void Two_Unequal_Sets_Separated_By_Equals_Returns_Biggest_Amount()
        {
            string input = "accba";
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 3;

            output = calculator.CalculateUnequalConsecutiveAmount(input);

            Assert.Equal(expectedOutput, output);
        }
    }
}