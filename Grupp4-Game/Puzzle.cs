using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Puzzle
    {
        public Puzzle()
        {
            Console.WriteLine("Fredrik begins to open the bottle of wine and serve");
            Console.WriteLine("You must answer two questions before I let you out.." +
                              "\nFirst..");
            Console.WriteLine("What is the name of the operator when you use \"Where\" in LINQ?");
            string answer1 = Console.ReadLine().ToLower();


            int count = 0;
            if (count == 3)
            {
                Console.WriteLine("Game over for you my friend! I will never let you out until you score all questions!" + 
                    "\nFredrik force you to drink up all the liquor until you faint..");
            }
            if (answer1 == "filter")
            {
                Console.WriteLine("Correct! Now the last question..");
            }
            else
            {
                count++;
                Console.WriteLine("Wrong! You have " + count + " tries left");
            }
               
        }


        /*var Q1 = "";
        var Q2 = "";
        var Q3 = "";

        Random rnd = new Random();
        int count = 3;

        string[] question = {"What is the name of the operator when you use \"Where\" in LINQ?",
                                 "What initialize a lambda expression?",
                                 "In which country lie Tesla headquarters?"};


        string[] answer = {"Filter",
                               "=>",
                               "California"};


        int randomQuestion = rnd.Next(0, 3);
        string option = question[randomQuestion];

        Console.WriteLine(option);

            string choice = Console.ReadLine().ToLower();

            if (choice == answer[])
            {
                Console.WriteLine("Congratz! You will live today and you also win my Tesla!" +
                                      "\nGo ahead and try it!");
            }
            else if (choice != answer[])
            {
                 count--;
                 Console.WriteLine("Wrong answer! You have: " + count + " left.");
            }
            else if (count == 0)
            {
                 Console.WriteLine("Game over! Now you have to start over for another question! HAHAHA!");
                 Console.WriteLine("BOOM! And there you faint away..");
            }

            Console.ReadLine();*/
    }
}
