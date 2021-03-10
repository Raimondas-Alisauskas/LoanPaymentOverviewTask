namespace LoanPaymentOverview.Tests.Core
{
    using System;
    using LoanPaymentOverview.Domain;
    using Xunit;

    public class LoanPaymentCalculatorInternalTests
    {
        [Fact]
        public void GetMonthlyPayment_ExpectedBehavior()
        {
            // Arrange
            var loanPaymentCalculatorInternal = new LoanPaymentCalculatorInternal();
            var loanAmount = 500000;
            var amountOfPayments = 120;
            var interestRatePerPayment = 0.05 / 12;

            // Act
            var result = loanPaymentCalculatorInternal.GetMonthlyPayment(
                loanAmount,
                amountOfPayments,
                interestRatePerPayment);

            Assert.Equal(5303.28m, Math.Round(result, 2));
        }

        [Theory]
        [InlineData(50, 1, 51, 50)]
        [InlineData(50, 1, 49, 49)]
        public void GetAdministrativeFeeTest_ExpectedBehavior(decimal loanAmount, decimal adminFeeRelative, decimal maxAdminFee, decimal fee)
        {
            // Arrange
            var loanPaymentCalculatorInternal = new LoanPaymentCalculatorInternal();

            // Act
            var result = loanPaymentCalculatorInternal.GetAdministrativeFee(
                loanAmount,
                adminFeeRelative,
                maxAdminFee);

            Assert.Equal(fee, result);
        }

        [Fact]
        public void GetLoanPaymentOverwiew_ExpectedBehavior()
        {
            // Arrange
            var loanPaymentCalculatorInternal = new LoanPaymentCalculatorInternal();
            var loanParameters = new LoanParameters
            {
                LoanAmount = 500000,
                DurationOfLoanInYears = 10,
            };

            var loanTerms = new LoanTerms
            {
                AnnualInterestRate = 0.05m,
                PaymentsPerYear = 12,
                AdminFeeRelative = 0.01m,
                MaxAdminFee = 10000,
            };

            // Act
            var result = loanPaymentCalculatorInternal.GetLoanPaymentOverwiew(
                loanParameters,
                loanTerms);

            // Assert
            Assert.Equal(500000, result.LoanAmount);
            Assert.Equal(10, result.DurationOfLoanInYears);
            Assert.Equal(5303.28m, result.MonthlyPayment);
            Assert.Equal(136393.09m, result.AmountPaidAsInterest);
            Assert.Equal(5000m, result.AdministrativeFee);
        }
    }
}
