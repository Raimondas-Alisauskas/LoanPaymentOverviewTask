namespace LoanPaymentOverview.Helpers
{
    using LoanPaymentOverview.Inputs;
    using LoanPaymentOverview.Outputs;
    using Microsoft.Extensions.DependencyInjection;

    public static class DIConfiguration
    {
        public static IServiceCollection AddDIConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IInput, ConsoleInput>();
            services.AddSingleton<IOutput, ConsloleOutput>();
            services.AddSingleton<ILoanPaymentCalculator, LoanPaymentCalculatorInternal>();
            services.AddSingleton<IInputValidator, InputValidator>();

            return services;
        }
    }
}
