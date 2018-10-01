using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.Diagnostics;

namespace Grupp4_Game
{
    class Game
    {
        public static Player player { get; set; }
        Room hallway;
        Room kitchen;
        Room outdoor;
        Room livingRoom;
        Room bathroom;

        Item kitchenKey;
        Item knife;
        Item beercan;
        Item wineBottle;
        RoomProp toilet;

        public bool GameisActive { get; set; }
        public List<Room> Rooms { get; set; }
        List<Item> roomInventory = new List<Item>();
        List<Item> playerInventory = new List<Item>();
        public string[] actionArray = { "GO", "LOOK", "MOVE", "SHOW", "OPEN", "DROP", "TAKE", "USE", "RIGHT", "BACK", "FORWARD", "LEFT" };
        public string userinput;

        public Game(string playerName)
        {
            Console.Clear();
            player = new Player(playerName);
            InitializeRooms();
            InitializeItem();
            InitializePlayer();
            TakeUserInput();
        }


        public void TakeUserInput()
        {
            do
            {
                if (player.CurrentPosition.Visited == false)
                {
                    player.CurrentPosition.ShowDescription();
                }
              
                player.CurrentPosition.Visited = true;

                userinput = GetUserInput();

                Console.ResetColor();
                string[] userInput = userinput.ToUpper().Split(' ');
                Switch(userInput);
            }
            while (true);
        }

        public void Switch(string[] userInput)
        {
            foreach (var word in userInput)
            {
                switch (word)
                {
                    case "HELP":
                        {
                            Console.WriteLine(@"The following commands exist: GO/MOVE, TAKE/GET/PICK, DROP, USE/OPEN, EXAMINE/INSPECT/LOOK, SHOW/INVENTORY.");
                            break;
                        }
                    case "GO":
                    case "MOVE":
                        {
                            player.Move(userInput);
                            break;
                        }
                    case "TAKE":
                    case "GET":
                    case "PICK":
                        {
                            player.PickUpItem(userInput);
                            break;
                        }
                    case "DROP":
                        player.DropItem(userInput);
                        break;
                    case "USE":
                    case "OPEN":
                        {
                            player.UseItem(userInput);
                            break;
                        }
                    case "EXAMINE":
                    case "INSPECT":
                    case "LOOK":
                        {
                            player.Examine(userInput);
                            break;
                        }
                    case "SHOW":
                    case "INVENTORY":
                        {
                            player.ShowInventory();
                            break;
                        }
                    default:
                        Console.WriteLine("Sorry, didn't understand that command. Try again.");
                        break;
                }
                break;
            }
        }

        public void InitializePlayer()
        {

            player.CurrentPosition = kitchen; //startposition
            livingRoom.Visited = false;

        }

        public void InitializeRooms()
        {
            #region Skapar upp alla rummen.
            List<Room> roomList = new List<Room>();

            hallway = new Room("Hallway", "You enter a hallway. To your left is the front door, the door in front of you seems to lead to the kitchen and to your right is a bathroom door. Duty calls but you sense a vague smell of no thank you from the bathroom door.", "You see the front door to your left, kitchen in front and bathroom to your right. Behind you is the living room where you woke up.", false);
            livingRoom = new Room("Living Room", "..Suddenly you wake up in a room that resembles a living room, but you've got no clue how you got there. You see several empty beer cans around the room, perhaps they tell a story? In front of you is a mysterious white door.", "The living room smells of beer and regrets.", true); //startposition
            kitchen = new Room("Kitchen", "You enter the kitchen and immediately get hangry.", "You're too hangry to hang out in this kitchen for much longer.", false);
            bathroom = new Room("Bathroom", "The first thing that comes to your mind as you enter the bathroom is \"Is this the start of a SAW movie? Sure smells like it\".", "Gosh.. that smell.", false);
            outdoor = new Room("Outdoors", "", "", false);

            roomList.Add(livingRoom);
            roomList.Add(hallway);
            roomList.Add(kitchen);
            roomList.Add(bathroom);
            roomList.Add(outdoor);
            #endregion
            #region Fyller rummen med Exits.
            hallway.Exits = new List<Exit>
            {
                { new Exit("Slightly less mysterious white door (Back)", false,1, livingRoom, "back", "door") },
                { new Exit("Kitchen door (Forward)", true, 2, kitchen, "forward", "door") },
                { new Exit("Stinky bathroom door (Right)", false, 3, bathroom, "right", "door") },
                { new Exit("Front door (Left)", true, 4, outdoor, "left", "door") }
            };
            livingRoom.Exits = new List<Exit>
            {
                { new Exit("Mysterious white door (Forward)", true, 1, hallway, "forward", "door") }
            };

            kitchen.Exits = new List<Exit>
            {
                { new Exit("Hallway door (Back)", false, 2, hallway, "back", "door") }
            };

            bathroom.Exits = new List<Exit>
            {
                {new Exit("Hallway door (Left)", false, 3, hallway, "left", "door") }
            };


            #endregion

            Rooms = roomList;
        }

        public void InitializeItem()
        {
            #region Skapar upp alla items.
            kitchenKey = new Key("Kitchen key", "", "You'd rather not examine this any further.", 2, "key");
            knife = new Item("Knife", "You see a shiny sharp knife on the floor. On the side it reads \"MORAKNIV\".", "A sharp knife, could definitely come to use.", "1", "knife");
            beercan = new Item("Beer can", "Next to you lies a half full beer can. It reads: \"Norrlands Guld\".", "I wouldn't want to drink this. Not sure why'd anyone would pick it up actually. Hmm..", "1", "can");
            wineBottle = new Item("Wine bottle", "A wine bottle lays on the floor. Your mind's telling you no, but your body's telling you yes.", "Perhaps you can drink this and forget about your sorrows.", "0", "bottle");
            toilet = new RoomProp("Toilet", "You see an unflushed toilet, who would do such a thing. It looks like there's something in it.", "While inspecting the disgusting toilet you see a key, dare you take it?", "toilet");

            livingRoom.roomInventory.Add(knife);
            livingRoom.roomInventory.Add(beercan);
            bathroom.roomInventory.Add(kitchenKey);
            player.keyList.Add((Key)kitchenKey);
            bathroom.RoomProps.Add(toilet);
            //kitchen.roomInventory.Add((Key)houseKey); // av fredrik
            kitchen.roomInventory.Add(wineBottle);

            #endregion

        }

        public string GetUserInput()
        {
            string userInput;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n> ");
            userInput = Console.ReadLine().ToUpper();
            Console.ResetColor();
            return userInput;
        }

        public static void GameCompleted()
        {
            PrintDramaticDots();
            Console.WriteLine("you leave the house and feel fresh air hitting your face, you're not sure when you last took a breath without feeling the smell of alcohol.");
            PrintDramaticDots();
            Console.WriteLine("time to leave, lucky coincidence you've got your SpaceX engineered Falcon Heavy!");
            PrintDramaticDots();
            Console.WriteLine("you jump into the rocket and fly away towards the vast space that is our universe..");
            PrintDramaticDots();
            Console.WriteLine("while enjoying the ride you see a Tesla Roadster inside the space shuttle..");
            PrintDramaticDots();
            Console.WriteLine("and obviously you try sitting in the drivers seat..");
            PrintDramaticDots();
            Console.WriteLine("a hatch opens and you're flung into outer space..");

            Thread.Sleep(2000);
            Console.WriteLine();
            SoundPlayer simpleSound = new SoundPlayer(@"groundcontrol.wav");
            simpleSound.Play();
            Console.WriteLine();

            StreamReader reader = new StreamReader("teslaroadster.txt");
            string line = "";
            int getrows = TotalLines("teslaroadster.txt");

            int TotalLines(string filePath)
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    int i = 0;
                    while (r.ReadLine() != null) { i++; }
                    return i;
                }
            }

            for (int i = 0; i < getrows; i++)
            {
                line = reader.ReadLine();
                Thread.Sleep(50);
                Console.WriteLine(line);
            }

            void PrintDramaticDots()
            {
                Thread.Sleep(3000);
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thanks for playing the game!");
            Console.WriteLine("Press enter to view the amazing gif..");
            Console.ReadLine();
            Process.Start(@"tesla.gif");
            Console.ReadLine();
        }
    } //class
} //namespace 



