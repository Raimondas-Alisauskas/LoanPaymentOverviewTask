namespace LoanPaymentOverview.Helpers
{
using System.Globalization;
using System.Text.RegularExpressions;

public class InputValidator : IInputValidator
    {
        public bool IsCurrencyValid(string input, out decimal currency)
        {
            var regex = @"^([0-9]{1,3}.([0-9]{3}.)*[0-9]{3}|[0-9]+)(,[0-9][0-9])?$";
            bool isValid = Regex.IsMatch(input, regex);

            bool isParsed = decimal.TryParse(input, NumberStyles.Currency, CultureInfo.GetCultureInfo("da-DK"), out currency);

            return isValid && isParsed;
        }

        public bool IsPozitiveIntegerValid(string input, out int pozitiveInteger)
        {
            bool isParsed = int.TryParse(input, out pozitiveInteger);
            bool isValid = pozitiveInteger > 0;

            return isValid && isParsed;
        }
    }
}
