namespace LoanPaymentOverview.Tests.Helpers
{
    using LoanPaymentOverview.Helpers;
    using Xunit;

    public class InputValidatorTests
    {
        [Theory]
        [InlineData("1.234,56", 1234.56, true)]
        [InlineData("1234,56", 1234.56, true)]
        [InlineData("1234", 1234, true)]
        [InlineData("0", 0, true)]

        [InlineData("1234,567", 1234.567, false)]
        [InlineData("1234,5", 1234.5, false)]
        [InlineData("", 0, false)]
        [InlineData("-1", -1, false)]
        [InlineData(".", 0, false)]
        public void IsCurrencyValid_StateUnderTest_ExpectedBehavior(string input, decimal output, bool valid)
        {
            // Arrange
            var inputValidator = new InputValidator();
            decimal currency;

            // Act
            var result = inputValidator.IsCurrencyValid(input, out currency);

            // Assert
            Assert.Equal(output, currency);
            Assert.Equal(valid, result);
        }

        [Theory]
        [InlineData("1", 1, true)]

        [InlineData("0", 0, false)]
        [InlineData("-1", -1, false)]
        [InlineData(".", 0, false)]
        public void IsIntegerValid_StateUnderTest_ExpectedBehavior(string input, int output, bool valid)
        {
            // Arrange
            var inputValidator = new InputValidator();
            int pozitiveInteger;

            // Act
            var result = inputValidator.IsPozitiveIntegerValid(input, out pozitiveInteger);

            // Assert
            Assert.Equal(output, pozitiveInteger);
            Assert.Equal(valid, result);
        }
    }
}
