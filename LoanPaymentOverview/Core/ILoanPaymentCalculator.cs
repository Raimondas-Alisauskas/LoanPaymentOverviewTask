namespace LoanPaymentOverview
{
    using LoanPaymentOverview.Domain;

    internal interface ILoanPaymentCalculator
    {
        OverviewDetails GetLoanPaymentOverwiew(LoanParameters loanParameters, LoanTerms loanTerms);
    }
}