using System.Collections.Generic;
using System.Linq;

namespace Adventure.Net
{
    public static class StringExtensions
    {
        public static IList<string> Tags(this string input)
            => input.Split(' ').Where(x => x.IsTag()).ToList();

        public static string F(this string input, params object[] args)
            => string.Format(input, args);

        public static bool HasValue(this string input)
            => !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);

        public static bool In(this string input, IList<string> values)
            => (values.Contains(input));

        public static bool IsTag(this string input)
            => input.StartsWith("<") && input.EndsWith(">");

        public static bool IsPreposition(this string input)
            => Prepositions.Contains(input);

        public static bool IsAction(this string input)
            => input.StartsWith("<<") && input.EndsWith(">>");

        public static bool IsMultiWord(this string input)
        {
            int start = input.IndexOf("[");
            return start >= 0 && input.IndexOf("]") > start;
        }
    }
}
