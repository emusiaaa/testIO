using Workshop;

namespace WorkshopTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.SumString("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("1", 1)]
        [InlineData("225", 225)]
        public void SingleNumberReturnsValue(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12,12", 24)]
        [InlineData("1,13", 14)]
        [InlineData("0,4", 4)]
        public void StringSumComa(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n12", 24)]
        [InlineData("1\n13", 14)]
        [InlineData("0\n4", 4)]
        public void StringSumLineFeed(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n12,1", 25)]
        [InlineData("1,13\n2", 16)]
        [InlineData("0\n4,6", 10)]
        [InlineData("0\n4\n6", 10)]
        [InlineData("0,4,6", 10)]
        public void MultiSeparatedValues(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }
        [Theory]
        [InlineData("12\n12,-1")]
        [InlineData("-1,13\n2")]
        [InlineData("-12")]
        public void NegativeValueThrowsArgumentException(string str)
        {
            Assert.Throws<ArgumentException>(()=> StringCalculator.SumString(str));
        }

        [Theory]
        [InlineData("1020\n12,1", 13)]
        [InlineData("1,1311\n2", 3)]
        [InlineData("0\n4444,6", 6)]
        [InlineData("0\n4000\n6",6)]
        [InlineData("0,4,1001", 4)]
        [InlineData("1000", 1000)]
        [InlineData("1001", 0)]
        public void NumbersGreaterThan1000(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("//#\n1020\n12#1", 13)]
        [InlineData("//a\n1a1,1311\n2", 4)]
        [InlineData("//$\n1", 1)]
        public void CustomSeparator(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }
    }
}