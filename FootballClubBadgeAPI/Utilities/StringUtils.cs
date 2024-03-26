using System.Globalization;

namespace FootballClubBadgeAPI.Utilities
{
    public static class StringUtils
    {
        public static string ToTitleCase(this string input)
        {

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}
