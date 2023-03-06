namespace DevelopmentAndBuildToolsTask.Tests
{
    public class CalculateConsecutiveIdenticalDigitsAmountTest
    {
        [Theory()]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("aa")]
        public void Input_Returns_Zero(string input)
        {
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 0;

            output = calculator.CalculateConsecutiveIdenticalDigitsAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact()]
        public void Two_Equal_Digits_Returns_Two()
        {
            string input = "11";
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 2;

            output = calculator.CalculateConsecutiveIdenticalDigitsAmount(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact()]
        public void Two_Sets_Of_Equals_Separated_By_Unequal_Returns_Biggest_Amount()
        {
            string input = "112111";
            CharacterCalculator calculator = new();
            int output;
            int expectedOutput = 3;

            output = calculator.CalculateConsecutiveIdenticalDigitsAmount(input);

            Assert.Equal(expectedOutput, output);
        }
    }
}
