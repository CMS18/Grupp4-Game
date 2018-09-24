using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Game
    {
        public string[,] map = new string[3, 3]; //array för möjliga vägar

        public Game()
        {

        }
       
      
        public void Locations()
        {
            map[0, 1] = "START";
            map[1, 1] = "NORTH";
            map[1, 0] = "WEST";
            map[1, 2] = "EAST";
            map[2, 1] = "SOUTH";
        }
           
        

        //PlayerName
        //RoomList
        //Victory
        //PlayingGame()
    }
}
