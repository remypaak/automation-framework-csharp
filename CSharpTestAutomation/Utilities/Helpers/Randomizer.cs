namespace CloseTestAutomation.Utilities.Helpers
{
    public class Randomizer
    {
        public static string GetRandomString(int length = 10)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string randomString = new string(Enumerable.Repeat(chars, length)
                                              .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        public static string GetRandomNumberString(int length = 10)
        {
            string digits = "0123456789";
            Random random = new Random();
            string randomNumberString = new string(Enumerable.Repeat(digits, length)
                                                  .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomNumberString;
        }
    }
}
