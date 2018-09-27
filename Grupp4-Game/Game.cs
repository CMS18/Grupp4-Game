using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Game
    {
        Player player = new Player("NAMN");


        Room hallway;
        Room kitchen;
        Room outdoor;
        Room livingRoom;
        Room bathroom;

        Item outKey;
        Item kitchenKey;
        Item knife;
        Item beercan;
        Item beerKey;
        Item wineBottle;
        Item toilet;


        bool GameisActive { get; set; }
        public List<Room> Rooms { get; set; }
        List<Item> roomInventory = new List<Item>();
        List<Item> playerInventory = new List<Item>();
        public string[] actionArray = { "GO", "LOOK", "MOVE", "SHOW", "OPEN", "DROP", "TAKE", "USE", "RIGHT", "BACK", "FORWARD", "LEFT" };
        public string userinput;
        public Game()
        {
            InitializeRooms();
            InitializeItem();
            InitializePlayer();
            GameisActive = true;
            player.currentPosition.ShowDescription();
        }

        public void TakeUserInput()
        {
            do
            {
                if (player.currentPosition.Visited == false)
                {
                    player.currentPosition.ShowDescription();
                }
              
                while (true)
                {
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
                string[] userInput = userinput.ToUpper().Split(' ');

                Switch(userInput);
            }
            while (GameisActive);
        }


        public void Switch(string[] userInput)
        {
            foreach (var word in userInput)
            {
                switch (word.ToLower())
                {
                    case "go":
                        player.Move(userInput.ToList());
                        break;
                    case "move":
                        player.Move(userInput.ToList());
                        break;
                    case "look":
                        player.Look();
                        break;
                    case "take":
                        player.PickUpItem(userInput);
                        break;
                    case "get":
                        player.PickUpItem(userInput);
                        break;
                    case "pick":
                        player.PickUpItem(userInput);
                        break;
                    case "drop":
                        player.DropItem(userInput);
                        break;
                    case "use":
                        player.UseItem(userInput);
                        break;
                    case "examine":
                        player.ExamineItem(userInput);
                        break;
                    case "inspect":
                        player.ExamineItem(userInput);
                        break;
                    case "show":
                        player.ShowInventory();
                        break;

                    /* case "open":
                            player.UseItem();
                            break;*/
                    default:
                        Console.WriteLine("Sorry didn't understand that command..");
                        Console.WriteLine("Try again.");
                        break;
                }
                break;
            }
            
        }
        public void InitializePlayer()
        {

            player.currentPosition = livingRoom; //startposition

        }
        public void InitializeRooms()
        {
            List<Room> roomList = new List<Room>();

            hallway = new Room("Hall", "Now you're in a big hallway where you see three doors, one to your right, one to your left and one infront of you.", false);
            livingRoom = new Room("Living Room", "Waking up in a room you've never seen before, there's a white door in front of you.", true); //startposition
            kitchen = new Room("Kitchen", "This room has a window!! Maybe you should try and break it.", false);
            bathroom = new Room("Bathroom", "Gosh.. that smell.", false);
            outdoor = new Room("Outdoor", "You are OUT", false);

            roomList.Add(livingRoom);
            roomList.Add(hallway);
            roomList.Add(kitchen);
            roomList.Add(bathroom);
            roomList.Add(outdoor);

            #region Fyller rummen med Exits
            hallway.Exits = new List<Exit>
            {
                { new Exit("Slightly less mysterious white door (BACK)", false,1, livingRoom, "back", "door") },
                { new Exit("Kitchen door (FORWARD)", true, 2, kitchen, "forward", "door") },
                { new Exit("Stinky bathroom door (RIGHT)", false, 3, bathroom, "right", "door") },
                { new Exit("Outdoor (LEFT)", true, 4, outdoor, "left", "door") }
            };
            livingRoom.Exits = new List<Exit>
            {
                { new Exit("Mysterious white door (FORWARD)", true, 1, hallway, "forward", "door") }
            };

            kitchen.Exits = new List<Exit>
            {
                { new Exit("Hall door (BACK)", false, 2, hallway, "back", "door") }
            };

            bathroom.Exits = new List<Exit>
            {
                {new Exit("Hall door (WEST)", false, 3, hallway, "left","door") }
            };


            #endregion


            Rooms = roomList;
        }
        public void InitializeItem()
        {
            outKey = new Item("Housekey", " On the floor lies a key, I get a sense of freedom when I see it.", " I think this key will help me get my butt outside this house", 4, "key");
            kitchenKey = new Item("Kitchen key", "", "I'd rather not examine this any further.", 2, "key");
            knife = new Item("knife", " I see a shiny sharp knife on the floor. On the side I read \"MORAKNIV\".", "This can may be used on something to create something new", "1", "knife");
            beercan = new Item("Beer can", " On the table I see a half full beer can. It reads: \"Norrlands Guld\".", "With something sharp this beercan could become something else ", "1", "can");
            beerKey = new Item("Beer Key", " I see a weird key on the floor", "This key shouldn't work but the force is strong within this key", 1, "key");
            wineBottle = new Item("Winebottle", "\n A winebottle lays on the floor.", "Maybe I can drink this and forget about my sorrows", "0", "bottle");
            toilet = new Item("Toilet", " I see an unflushed toilet, who would do such a thing. It looks like there's something in it. ", "While inspecting the disgusting toilet I see a key, dare I take it?", "0", "toilet");


            livingRoom.roomInventory.Add(knife);
            livingRoom.roomInventory.Add(beercan);
            bathroom.roomInventory.Add(kitchenKey);
            bathroom.roomInventory.Add(toilet);
            kitchen.roomInventory.Add(outKey);
            kitchen.roomInventory.Add(wineBottle);


        }


    } //class
} //namespace 



//PlayerName
//RoomList
//Victory
//PlayingGame()


