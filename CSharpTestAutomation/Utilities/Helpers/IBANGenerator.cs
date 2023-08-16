using System.Numerics;
using System.Text;

namespace CloseTestAutomation.Utilities.Helpers
{
    public static class IBANGenerator
    {
        public static string GenerateIban(string countryCode = "NL", string bankCode = "RABO", string branchCode = "0000", int accountNumberLength = 9)
        {
            Random random = new Random();
            string accountNumber = new string(Enumerable.Range(0, accountNumberLength).Select(_ => (char)('0' + random.Next(0, 10))).ToArray());

            string iban = bankCode + branchCode + accountNumber + countryCode + "00";

            StringBuilder convertedIban = new StringBuilder();
            foreach (char c in iban)
            {
                if (char.IsLetter(c))
                {
                    convertedIban.Append(c - 'A' + 10);
                }
                else
                {
                    convertedIban.Append(c);
                }
            }

            BigInteger ibanNumber = BigInteger.Parse(convertedIban.ToString());
            int checkDigits = 98 - (int)(ibanNumber % 97);

            string ibanResult = countryCode + checkDigits.ToString("D2") + bankCode + branchCode + accountNumber;

            return ibanResult;
        }
    }
}