using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    static class PlayerParse
    {
        private const string PlayerOptions = @"\|drop|use|look|take|go|examine|read|pickup|inventory|\b";

        public static string ToPlayerAction(this string input)
        {
            Regex regex = new Regex(PlayerOptions);
            Match match = regex.Match(input);
            return match.Success ? match.Value : null;
        }

        public static bool CheckValue(string compare, string compareTo)
        {
            var arrayValue = compare.Split(' ').ToArray();
            return arrayValue.Any(t => compareTo.ToLower().Contains(t.ToLower()));
        }
    }
}
