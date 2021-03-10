namespace LoanPaymentOverview
{
    using LoanPaymentOverview.Domain;
    using LoanPaymentOverview.Helpers;
    using LoanPaymentOverview.Inputs;
    using LoanPaymentOverview.Outputs;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddDIConfiguration()
                .BuildServiceProvider();

            var input = serviceProvider.GetService<IInput>();
            var output = serviceProvider.GetService<IOutput>();
            var loanPaymentCalculator = serviceProvider.GetService<ILoanPaymentCalculator>();

            var loanParameters = input.GetLoanParameters();
            var loanTerms = builder.GetSection("loanTerms").Get<LoanTerms>();

            var overviewDetails = loanPaymentCalculator.GetLoanPaymentOverwiew(loanParameters, loanTerms);

            output.ShowLoanTerms(loanTerms);
            output.ShowLoanPaymentOverview(overviewDetails);
        }
    }
}
