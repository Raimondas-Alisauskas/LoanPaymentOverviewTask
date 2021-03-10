namespace LoanPaymentOverview.Outputs
{
    using LoanPaymentOverview.Domain;

    internal interface IOutput
    {
        void ShowLoanTerms(LoanTerms loanTerms);

        void ShowLoanPaymentOverview(OverviewDetails overviewDetails);
    }
}