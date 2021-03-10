namespace LoanPaymentOverview.Inputs
{
    using System;
    using System.Globalization;
    using LoanPaymentOverview.Domain;
    using LoanPaymentOverview.Helpers;

    internal class ConsoleInput : IInput
    {
        private readonly IInputValidator validator;

        public ConsoleInput(IInputValidator validator)
        {
            this.validator = validator;
        }

        public LoanParameters GetLoanParameters()
        {
            Console.WriteLine("Please provide loan amount:");

            decimal loanAmount;
            while (!this.validator.IsCurrencyValid(Console.ReadLine(), out loanAmount))
            {
                Console.WriteLine("Please provide valid loan amount (12.345,67):");
            }

            Console.WriteLine($"Loan amount: {loanAmount.ToString("C", CultureInfo.GetCultureInfo("da-DK"))}");

            Console.WriteLine("Please provide duration of loan in years:");
            int durationOfLoanInYears;
            while (!this.validator.IsPozitiveIntegerValid(Console.ReadLine(), out durationOfLoanInYears))
            {
                Console.WriteLine("Please provide valid duration of loan in years (integer):");
            }

            Console.WriteLine($"Duration of loan in years: {durationOfLoanInYears}");

            return new LoanParameters
            {
                LoanAmount = loanAmount,
                DurationOfLoanInYears = durationOfLoanInYears,
            };
        }
    }
}