using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Grupp4_Game
{
    class Puzzle
    {
        public bool SolvedPuzzle = false;

        public Puzzle()
        {


             Console.WriteLine("Fredrik pops out from the bottle, \n" +
             "You must answer two questions before I let you out.. \n" +
             "First..");
            /*
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


         */
            string[] question = {"What is the name of the operator when you use \"Where\" in LINQ?",

                                 "What initialize a lambda expression?",

                                 "In which country lie Tesla headquarters?"};
            string[] answer = {"filter",

                               "=>",

                               "california"};

            Random rnd = new Random();

            int count = 3;

            do
            {
                
                
                int randomQuestion = rnd.Next(0, 3);

                string option = question[randomQuestion];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(option);
                Console.ResetColor();
                string choice = Console.ReadLine().ToLower();



                if (choice == answer[randomQuestion])

                {

                    Console.WriteLine("Congratz! You will live today and you also win my Tesla!" +

                                          "\nGo ahead and try it!");
                    SolvedPuzzle = true;
                    

                }

                else if (choice != answer[randomQuestion])

                {

                    count--;

                    Console.WriteLine("Wrong answer! You have: " + count + " left.");
                    continue;

                }

                else if (count == 0)

                {

                    Console.WriteLine("Game over! Now you have to start over for another question! HAHAHA!");

                    Console.WriteLine("BOOM! And there you faint away..");

                }



                Console.ReadLine();

            }
            while (!SolvedPuzzle);
    
    
       }
    }

}