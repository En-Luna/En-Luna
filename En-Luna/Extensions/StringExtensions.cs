using System.Text.RegularExpressions;

namespace En_Luna.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string s, string compare)
        {
            return s?.Equals(compare, StringComparison.OrdinalIgnoreCase) ?? false;
        }

        public static bool ContainsIgnoreCase(this string s, string compare)
        {
            return s.Contains(compare, StringComparison.OrdinalIgnoreCase);
        }

        public static string  RemoveDigits(this string key)
        {
            return Regex.Replace(key, @"\d", "");
        }
    }
}
