using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Game
    {
        public string[,] locations = new string[3, 3]; //array för möjliga vägar

        public Game()
        {

        }
       
      
        public void Locations()
        {
            locations[0, 1] = "START";
            locations[1, 1] = "NORTH";
            locations[1, 0] = "WEST";
            locations[1, 2] = "EAST";
            locations[2, 1] = "SOUTH";
        }
           
        

        //PlayerName
        //RoomList
        //Victory
        //PlayingGame()
    }
}
