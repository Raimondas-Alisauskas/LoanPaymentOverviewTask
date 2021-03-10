namespace LoanPaymentOverview.Helpers
{
    internal interface IInputValidator
    {
        bool IsCurrencyValid(string input, out decimal currency);

        bool IsPozitiveIntegerValid(string input, out int pozitiveInteger);
    }
}