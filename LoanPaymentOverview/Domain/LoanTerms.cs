namespace LoanPaymentOverview.Domain
{
    using System.Globalization;

    public class LoanTerms
    {
        public decimal AnnualInterestRate { get; set; }

        public int PaymentsPerYear { get; set; }

        public decimal AdminFeeRelative { get; set; }

        public decimal MaxAdminFee { get; set; }

        public override string ToString()
        {
            return $"Annual interest rate: {this.AnnualInterestRate.ToString("P0")}\n" +
                    $"Number of payments per year: {this.PaymentsPerYear.ToString()}\n" +
                    $"Administration fee: {this.AdminFeeRelative.ToString("P0")}\n" +
                    $"Maximal administration fee: {this.MaxAdminFee.ToString("C", CultureInfo.GetCultureInfo("da-DK"))}";
        }
    }
}