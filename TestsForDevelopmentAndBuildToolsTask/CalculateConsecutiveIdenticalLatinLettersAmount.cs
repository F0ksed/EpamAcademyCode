namespace DevelopmentAndBuildToolsTask.Tests
{
    public class CalculateConsecutiveIdenticalLatinLettersAmountTest
    {
        [Theory()]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("ab")]
        [InlineData("„ˆ„ˆ")]
        [InlineData("%%")]
        [InlineData("Aa")]
        public void Input_Returns_Zero(string input)
        {
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 0;

            output = calculator.CalculateConsecutiveIdenticalLatinLettersAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact()]
        public void Two_Equal_Latin_Character_Returns_Two()
        {
            string input = "aa";
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 2;

            output = calculator.CalculateConsecutiveIdenticalLatinLettersAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact()]
        public void Two_Sets_Of_Equals_Separated_By_Unequal_Returns_Biggest_Amount()
        {
            string input = "aabaaa";
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 3;

            output = calculator.CalculateConsecutiveIdenticalLatinLettersAmount(input);

            Assert.Equal(expectedOutput, output);
        }
    }
}