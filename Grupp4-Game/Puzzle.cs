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
            Key houseKey;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fredrik pops out from the bottle, \n" +
            "You must answer two questions before I let you out.. \n" +
            "First..");
            Console.ResetColor();

            string[] question = {"What is the name of the operator when you use \"Where\" in LINQ?",

                                 "What initialize a lambda expression?",

                                 "In which country lie Tesla headquarters?"};
            string[] answer = {"filter",

                               "=>",

                               "california"};

            Random rnd = new Random();
            int count = 3;
            string guess;
            int CompletedQuestion = 0;
            do
            {
                
                for (int i = 0; i < question.Length; i++)
                {
                    if (CompletedQuestion == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Congratz! You will live today and you also win my Tesla!" +
                                         "\nGo ahead and try it!" +
                                          "\n Here you get a key");
                        SolvedPuzzle = true;
                        houseKey = new Key("House key", "", "I think this key will help me get my butt outside this house.", 4, "key");
                        Game.player.keyList.Add(houseKey);
                        Game.player.inventoryList.Add(houseKey);
                        Console.ResetColor();
                        return;
                    }
                    if(count==0)
                    {
                        Console.WriteLine("Game over! Now you have to start over for another question! HAHAHA!");

                        Console.WriteLine("BOOM! And there you faint away..");
                        Console.ReadLine();

                    }
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(question[i]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("> ");
                        guess = Console.ReadLine();
                        Console.ResetColor();
                        if (string.IsNullOrWhiteSpace(guess) || int.TryParse(guess, out int wrong))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Guess with letters");
                            Console.ResetColor();
                            continue;
                        }
                        break;
                    }

                    if (guess.ToLower() == answer[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        CompletedQuestion++;
                        Console.WriteLine($" Your guess is right! {CompletedQuestion} / 3 guesses.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        count--;
                        Console.WriteLine(" Wrong guess! You have totally: " + count + " tries left.");
                        Console.ResetColor();
                        i--; 
                    }
                }
            }
            while (!SolvedPuzzle);


        }
    }

}