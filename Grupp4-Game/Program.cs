using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "A hungover adventure.";

            Console.Write("Welcome to \"A hungover adventure\"." +
                "\nPlease enter your name to start the game: ");
            Game StartGame = new Game(Console.ReadLine());




        }
    }
} 
