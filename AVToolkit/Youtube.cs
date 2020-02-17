using System.Linq;
using System.Text.RegularExpressions;

namespace VD
{
    internal static class Youtube
    {
        private const string YoutubeLinkRegex =
            "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";

        internal static string GetVideoId(string input)
        {
            var regex = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
            foreach (Match match in regex.Matches(input))
                //Console.WriteLine(match);
            foreach (var groupdata in
                match.Groups.Cast<Group>().Where(groupdata => !groupdata.ToString().StartsWith("http://") &&
                                                              !groupdata.ToString().StartsWith("https://") &&
                                                              !groupdata.ToString().StartsWith("youtu") &&
                                                              !groupdata.ToString().StartsWith("www.")))
                return groupdata.ToString();
            return string.Empty;
        }
    }
}