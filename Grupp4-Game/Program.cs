using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game StartGame = new Game();

            //WorldBuilder??
            Item key = new Item("Nyckel", "Nyckel till dörr 1");
            Item key2 = new Item("Nyckel2", "Nyckel till dörr 2");
            Player player = new Player("Bjrön");
            Exit Door = new Exit();

            //Anropa klasser samt Meny
        }
    }
}
