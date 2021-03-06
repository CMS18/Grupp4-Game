﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Puzzle
    {
        private bool GameWon { get; set; }
        private string Answer { get; set; }
        private int Chances { get; set; }
        private int CompletedQuestions = 0;

        string[] question = {
                "Which car brand is the coolest one? (Sorry Samie I don't think you can get this one right).",
                "If you use .OrderBy(), what can you use afterwards to customise the order even further?",
                "Which default value does a string have?",
            };

        string[] answer = {
                "tesla",
                ".thenby()",
                "null"
            };

        string[] hint =
        {
            "The answer rhymes with \"besla\".",
                "First I wanna order by this, and then by that..",
                "When I eat too much my stomach gets full, and a strings default value is.."
        };


        public Puzzle()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"metalgearsolid.wav");
            simpleSound.Play();
            Chances = 4;
            Console.ResetColor();
            Console.WriteLine("A wild Fredrik Haglund appears from behind the kitchen door!\n" +
            "\"Riddle me this!\" he says as he pulls up a sheet of paper with something written on it.");
            PlayPuzzle();
        }

        public void PlayPuzzle()
        {
            Console.WriteLine("The rules are simple. You've got " + Chances + " lives and if you manage to answer all 3 questions correctly i'll give you the house key.");
            Console.WriteLine();
            do
            {
                for (int i = 0; i < question.Length; i++)
                {
                    if (Chances == 0)
                    {
                        PuzzleGameOver();
                        break;
                    }
                    if (CompletedQuestions == 3)
                    {
                        Console.WriteLine("Congratulations! You won the grand prize, the house key! Oh and also I'll throw in something extra for you effort.");
                        GivePrizes();
                        return;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(question[i]);
                    Console.ResetColor();

                    if (GetUserInput() == answer[i])
                    {
                        Console.WriteLine("Correct! Next question.");
                        CompletedQuestions++;
                        continue;
                    }
                    else
                    {
                        Chances--;
                        Console.WriteLine("Wrong answer! Hint: " + hint[i]);
                        i--;
                    }
                }

            }
            while (Chances > 0);

           
        }

        public string GetUserInput()
        {
            string userInput;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n> ");
            userInput = Console.ReadLine().ToLower();
            Console.ResetColor();
            return userInput;

        }

        public void PuzzleGameOver()
        {
            Console.WriteLine();
            Console.WriteLine("Game over! \nSince i can't give you an F (Seeing as we're in a game), i'll just challenge you to drink this whole wine bottle.");

            do
            {
                Console.WriteLine("So what do you say? Are you up for the challenge? Yes or no?");
                string userInput = GetUserInput();

                if (userInput == "no")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(1000);
                        Console.Write(".");
                    }

                    Console.Write("what's wrong McFly? Oh err i mean " + Game.player.Name + ". ..Chicken? \n");

                    if (GetUserInput() == "nobody calls me chicken")
                    {
                        ExtraPuzzle(true);
                        break;
                    }
                    else
                    {
                        ExtraPuzzle(false);
                        break;
                    }
                }
                else if (userInput == "yes")
                {
                    ExtraPuzzle(true);
                    break;
                }

            } while (true);
        }

        public void ExtraPuzzle(bool drankWine)
        {
            if (drankWine == true)
            {
                Console.WriteLine("You finish the whole bottle of wine. It actually tastes amazing, so you feel pretty great about the whole situation.");
                PrintDramaticDots1();
                Console.WriteLine("and then you pass out..");
                Console.WriteLine();

                PrintDramaticDots2();
            }
            else
            {
                Console.WriteLine("The horror of drinking free wine makes you really scared as you make a turn, ready to run for your life. But like the chicken you are you slip and fall, hitting your head against the floor..");
                
                PrintDramaticDots1();
                Console.WriteLine("and then you pass out..");
                Console.WriteLine();

                PrintDramaticDots2();
            }

            Console.WriteLine("you wake up, you see Fredrik standing right next to you as he shouts: \"What comes after Pang?!\"");

            do
            {
                string userinput = GetUserInput();
                if (userinput == "boom" || userinput == "bom")
                {
                    Console.WriteLine("Even with a screaming headache you manage to solve the riddle.");
                    Console.WriteLine("Good job! Here's your grand prize, the house key. Oh and also i'll throw in something extra for you effort. Also, i'm keeping this wine.");
                    GivePrizes();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong answer, try again!");
                }
            } while (true);

        }

        private void GivePrizes()
        {
            Key houseKey = new Key("House Key", "The front door key lies on the floor.", "This will open the front door", 4, "key");
            Game.player.inventoryList.Add(houseKey);
            Game.player.keyList.Add(houseKey);

            Item rocket = new Item("SpaceX engineered Falcon Heavy", "Not every day you see a Falcon Heavy lying around. Strange.", "Now THIS could come in handy!!!","","");
            Game.player.inventoryList.Add(rocket);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You picked up " + houseKey.ItemName);
            Console.WriteLine("You picked up " + rocket.ItemName);
            Console.ResetColor();

        }

        private void PrintDramaticDots1()
        {
            Thread.Sleep(5000);
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }
        private void PrintDramaticDots2()
        {
            Thread.Sleep(5000);
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }
    }

}