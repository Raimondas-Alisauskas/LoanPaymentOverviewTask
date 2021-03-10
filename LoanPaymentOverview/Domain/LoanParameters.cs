namespace LoanPaymentOverview.Domain
{
    using System.Globalization;

    public class LoanParameters
    {
        public decimal LoanAmount { get; set; } = 0;

        public int DurationOfLoanInYears { get; set; } = 0;

        public override string ToString()
        {
            return $"Loan amount: {this.LoanAmount.ToString("C", CultureInfo.GetCultureInfo("da-DK"))}\n" +
                    $"Duration of loan in years: {this.DurationOfLoanInYears.ToString()}";
        }
    }
}