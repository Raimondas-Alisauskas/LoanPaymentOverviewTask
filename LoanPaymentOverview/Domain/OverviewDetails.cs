namespace LoanPaymentOverview.Domain
{
    using System.Globalization;

    public class OverviewDetails
    {
        public decimal LoanAmount { get; set; }

        public int DurationOfLoanInYears { get; set; }

        public decimal MonthlyPayment { get; set; }

        public decimal AmountPaidAsInterest { get; set; }

        public decimal AdministrativeFee { get; set; }

        public override string ToString()
        {
            return $"Loan amount: {this.LoanAmount.ToString("C", CultureInfo.GetCultureInfo("da-DK"))}\n" +
                    $"Duration of loan in years: {this.DurationOfLoanInYears.ToString()}\n" +
                    $"Monthly payment: {this.MonthlyPayment.ToString("C", CultureInfo.GetCultureInfo("da-DK"))}\n" +
                    $"Amount paid as interest: {this.AmountPaidAsInterest.ToString("C", CultureInfo.GetCultureInfo("da-DK"))}\n" +
                    $"Administrative fee: {this.AdministrativeFee.ToString("C", CultureInfo.GetCultureInfo("da-DK"))}";
        }
    }
}
