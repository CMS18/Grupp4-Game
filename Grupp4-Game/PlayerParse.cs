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
        //static int xCoord = 1;
        //static int yCoord = 1;
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

       /* public void Move(string direction)
        {
            if (map[yCoord, xCoord].Equals(direction))
            {
                Console.WriteLine("Cannot go there" + direction);
            }
            else if (direction.Equals("NORTH"))
            {
                if (xCoord == 0 || xCoord == 2)
                {
                    Console.WriteLine("Cannot go there:" + direction);
                }
                else
                {
                    yCoord--;
                    player.currentPosition = roomCollection[map[yCoord, xCoord]];
                    player.currentPosition.ShowDescription();
                }
            }
            else if (direction.Equals("WEST"))
            {
                if (yCoord == 0 || yCoord == 2)
                {
                    Console.WriteLine("Cannot go there" + direction);
                }
                else
                {
                    xCoord--;
                    player.currentPosition = roomCollection[map[yCoord, xCoord]];
                    player.currentPosition.ShowDescription();
                }
            }
            else if (direction.Equals("EAST"))
            {
                if (yCoord == 0 || yCoord == 2)
                {
                    Console.WriteLine("Cannot go there" + direction);
                }
                else
                {
                    xCoord++;
                    player.currentPosition = roomCollection[map[yCoord, xCoord]];
                    player.currentPosition.ShowDescription();
                }
            }
            else
            {
                if (xCoord == 0 || xCoord == 2)
                {
                    Console.WriteLine("Cannot go there" + direction);
                }
                else
                {
                    yCoord++;
                    player.currentPosition = roomCollection[map[yCoord, xCoord]];
                    player.currentPosition.ShowDescription();
                }
            }
        }
    }
}
*/