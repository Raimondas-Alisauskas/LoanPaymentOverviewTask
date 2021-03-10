namespace LoanPaymentOverview
{
    using System;
    using LoanPaymentOverview.Domain;
    using LoanPaymentOverview.Outputs;

    internal class ConsloleOutput : IOutput
    {
        public void ShowLoanTerms(LoanTerms loanTerms)
        {
            Console.WriteLine($"\nLoan terms:");
            Console.WriteLine(loanTerms.ToString());
        }

        public void ShowLoanPaymentOverview(OverviewDetails overviewDetails)
        {
            Console.WriteLine("\nLoan payment overview:");
            Console.WriteLine(overviewDetails.ToString());
        }
    }
}