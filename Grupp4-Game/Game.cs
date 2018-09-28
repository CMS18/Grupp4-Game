﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //Item beerKey;
        Item wineBottle;
        RoomProp toilet;

        bool GameisActive { get; set; }
        public List<Room> Rooms { get; set; }
        List<Item> roomInventory = new List<Item>();
        List<Item> playerInventory = new List<Item>();
        public string[] actionArray = { "GO", "LOOK", "MOVE", "SHOW", "OPEN", "DROP", "TAKE", "USE", "RIGHT", "BACK", "FORWARD", "LEFT" };
        public string userinput;
        public Game()
        {
            player = new Player("namn");
            Console.Title = "A hungover adventure";
            InitializeRooms();
            InitializeItem();
            InitializePlayer();
            GameisActive = true;
           
            player.CurrentPosition.ShowDescription();
            player.CurrentPosition.Visited = true;

        }
        
        public void TakeUserInput()
        {
            do
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.Write("> ");
                    userinput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(userinput) || int.TryParse(userinput, out int wrong))
                    {
                        Console.WriteLine("Only letters please");
                    }
                    else
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                string[] userInput = userinput.ToUpper().Split(' ');
                Switch(userInput);
                Console.ResetColor();
            }
            while (GameisActive);
        }


        public void Switch(string[] userInput)
        {
            foreach (var word in userInput)
            {
                switch (word)
                {
                    case "GO":
                    case "MOVE":
                        {
                            player.Move(userInput);
                            break;
                        }
                    case "LOOK":
                        player.Look();
                        break;
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
                        {
                            player.ExamineItem(userInput);
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

            player.CurrentPosition = livingRoom; //startposition

        }
        public void InitializeRooms()
        {
            #region Skapar upp alla rummen.
            List<Room> roomList = new List<Room>();

            hallway = new Room("Hallway", "I enter a dark, big and kinda empty hallway. To my left I see a big door which seems to be the front door. \n" + 
                "In front of me seems to be a kitchen door and to my right I see a wideopen bathroom door leading into more darkness.\n" +
                "Duty calls but I sense a vague smell of no thank you from the bathroom door", "I see the front door to my left, kitchen in front of me and the bathroom to my right.", false);
            livingRoom = new Room("Living Room", "..Suddenly I wake up in a room that resembles a living room, though I've got no clue how I got here.\n" +
                " I see several empty beer cans around the room, perhaps they tell a story? In front of me is a white door.", "The living room smells of beer and regrets.", false); //startposition
            kitchen = new Room("Kitchen", "I enter the kitchen and see a full wine bottle, my mind's telling me no, but my body's telling me yes", "I'm too hangry to hang out in this kitchen for much longer.", false);
            bathroom = new Room("Bathroom", "The first thing that comes to my mind as I enter the bathroom is \"Is this the start of a SAW movie?\n" +
                "Sure smells like it\".", "Gosh.. that smell.", false);

            outdoor = new Room("Outdoor", "FREDOOOOOOOOOOOOOOOOOOOOOM!!!!!!!", "", false);

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
                { new Exit("Hall door (Back)", false, 2, hallway, "back", "door") }
            };

            bathroom.Exits = new List<Exit>
            {
                {new Exit("Hall door (West)", false, 3, hallway, "left", "door") }
            };


            #endregion

            Rooms = roomList;
        }
        public void InitializeItem()
        {
            #region Skapar upp alla items.
            kitchenKey = new Key("Kitchen key", "", "I'd rather not examine this any further.", 2, "key");
            knife = new Item("Knife", " I see a shiny sharp knife on the floor. On the side I read \"MORAKNIV\".", "A sharp knife, could definitely come to use.", "1", "knife");
            beercan = new Item("Beer can", "\n On the table I see a half full beer can. It reads: \"Norrlands Guld\".", "Maybe I can create something from this.", "1", "can");
            wineBottle = new Item("Wine bottle", "\n A winebottle lays on the floor.", "Maybe I can drink this and forget about my sorrows, or I can just smash it at my head", "0", "bottle");
            toilet = new RoomProp("Toilet", " I see an unflushed toilet, who would do such a thing. It looks like there's something in it. ", "While inspecting the disgusting toilet I see a key, dare I take it?", "toilet");



            livingRoom.roomInventory.Add(knife);
            livingRoom.roomInventory.Add(beercan);
            bathroom.roomInventory.Add(kitchenKey);
            player.keyList.Add((Key)kitchenKey);
            bathroom.RoomProps.Add(toilet);
            //kitchen.roomInventory.Add((Key)houseKey); // av fredrik
            kitchen.roomInventory.Add(wineBottle);

            #endregion
        }
    } //class
} //namespace 



