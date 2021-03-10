namespace LoanPaymentOverview.Inputs
{
    using LoanPaymentOverview.Domain;

    internal interface IInput
    {
        LoanParameters GetLoanParameters();
    }
}