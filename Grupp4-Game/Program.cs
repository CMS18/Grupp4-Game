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
            //WorldBuilder??
            Item key = new Item("Nyckel", "Nyckel till dörr 1", 1);
            Item key2 = new Item("Nyckel2", "Nyckel till dörr 2", 2);
            Player player = new Player("Bjrön");
            Exit Door = new Exit(true,1, 1); //låst, ID 1
            Exit Door2 = new Exit(true, 2, 2);
            Exit Door3 = new Exit(false, 3);
            Room Kitchen = new Room("Kitchen", "beskrivnning");

            //Anropa klasser samt Meny 
        }
    }
}
