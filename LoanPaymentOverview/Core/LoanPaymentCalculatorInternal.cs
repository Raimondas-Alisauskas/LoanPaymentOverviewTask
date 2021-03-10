namespace LoanPaymentOverview
{
    using System;
    using LoanPaymentOverview.Domain;

    public class LoanPaymentCalculatorInternal : ILoanPaymentCalculator
    {
        public OverviewDetails GetLoanPaymentOverwiew(LoanParameters loanParameters, LoanTerms loanTerms)
        {
            var loanAmount = loanParameters.LoanAmount;
            var durationOfLoan = loanParameters.DurationOfLoanInYears;
            var annualInterestRate = loanTerms.AnnualInterestRate;
            var paymentsPerYear = loanTerms.PaymentsPerYear;
            var adminFeeRelative = loanTerms.AdminFeeRelative;
            var maxAdminFee = loanTerms.MaxAdminFee;

            var amountOfPayments = durationOfLoan * paymentsPerYear;
            var interestRatePerPayment = annualInterestRate / paymentsPerYear;
            var monthlyPayment = this.GetMonthlyPayment((double)loanAmount, amountOfPayments, (double)interestRatePerPayment);
            var totalAmmountPayed = monthlyPayment * amountOfPayments;
            var amountPaidAsInterest = totalAmmountPayed - loanAmount;
            var administrativeFee = this.GetAdministrativeFee(loanAmount, adminFeeRelative, maxAdminFee);

            return new OverviewDetails
            {
                LoanAmount = loanAmount,
                DurationOfLoanInYears = durationOfLoan,
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                AmountPaidAsInterest = Math.Round(amountPaidAsInterest, 2),
                AdministrativeFee = Math.Round(administrativeFee, 2),
            };
        }

        public decimal GetMonthlyPayment(double loanAmount, int amountOfPayments, double interestRatePerPayment)
        {
            var monthlyPayment = loanAmount * interestRatePerPayment * Math.Pow(1 + interestRatePerPayment, amountOfPayments)
                    / (Math.Pow(1 + interestRatePerPayment, amountOfPayments) - 1);
            return (decimal)monthlyPayment;
        }

        public decimal GetAdministrativeFee(decimal loanAmount, decimal adminFeeRelative, decimal maxAdminFee)
        {
            var relativeFee = loanAmount * adminFeeRelative;

            return (relativeFee < maxAdminFee) ? relativeFee : maxAdminFee;
        }
    }
}