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
        Item beerCan;
        Item beerKey;
        Item wineBottle;
      

        bool GameisActive { get; set; }

        public List<Room> Rooms { get; set; }


        public string[,] map = new string[3, 3]; //array för möjliga vägar
        public string[] actionArray = { "GO", "LOOK", "MOVE", "OPEN", "DROP", "TAKE", "USE", "EAST", "SOUTH", "NORTH", "WEST", "LEFT", "RIGHT", "FORWARD", "BACK" };

        public Game()
        {
            InitializeRooms();
            InitializeItem();
            InitializePlayer();
            GameisActive = true;
        }


        List<string> resultlist = new List<string>();

        public void TakeUserInput()
        {
            do
            {
                player.currentPosition.ShowDescription();
                // string userInput = Console.ReadLine();
                string[] userInput = Console.ReadLine().ToUpper().Split(' ');


                foreach (var word in userInput)
                {
                    foreach (var item in actionArray)
                    {
                        if (word == item)
                        {
                            resultlist.Add(word);
                        }
                    }

                }


                foreach (var word in resultlist)
                {
                    Console.WriteLine(word);
                }
                Console.ReadLine();
                Switch(resultlist);

            }
            while (GameisActive);
        }



        public void Switch(List<string> userInput)
        {

            foreach (var word in userInput)
            {

                switch (word.ToLower())
                {
                    case "go":
                        player.Move(userInput);
                        break;

                        case "look":
                              player.currentPosition.ShowDescription();
                              break;

                         /* case "move":
                              player.Move(userInput[1]);
                              break;

                          case "open":
                              player.UseItem();
                              break;*/
                }
            }
        }
        public void InitializePlayer()
        {

            player.currentPosition = hallway;
        }
        public void InitializeRooms()
        {
            List<Room> roomList = new List<Room>();

            hallway = new Room("Hall", "Beskrivning Hall"); //startposition
            livingRoom = new Room("Living Room", "Beskrivning living room");
            kitchen = new Room("Kitchen", "Beskrivning kitchen");
            bathroom = new Room("Bathroom", "Beskrivning bathroom");
            outdoor = new Room("Bedroom", "Beskrivning Bedroom");
    
            roomList.Add(livingRoom);
            roomList.Add(hallway);
            roomList.Add(kitchen);
            roomList.Add(bathroom);
            roomList.Add(outdoor);
           
            #region Fyller rummen med Exits
            hallway.Exits = new List<Exit>
            {
                { new Exit("Slightly less mysterious white door (SOUTH)", false, 1, livingRoom, "SOUTH") },
                { new Exit("Kitchen door (NORTH)", false, 2, kitchen, "NORTH") },
                { new Exit("Stinky bathroom door (EAST)", false, 3, bathroom, "EAST") },
                { new Exit("Outdoor (WEST)", false, 4, outdoor, "WEST") }
            };
            livingRoom.Exits = new List<Exit>
            {
                { new Exit("Mysterious white door (NORTH)", true, 1, hallway, "NORTH") }
            };

            kitchen.Exits = new List<Exit>
            {
                { new Exit("Hall door (SOUTH)", false, 2, hallway, "SOUTH") }
            };

            bathroom.Exits = new List<Exit>
            {
                {new Exit("Hall door (WEST)", false, 3, hallway, "WEST") }
            };

          
            #endregion


            Rooms = roomList;
        }

        public void InitializeItem()
        {
            outKey = new Key("House key", " On the floor lies a key, I get a sense of freedom when I see it."," I think this key will help me get my butt outside this house", 4) ;
            kitchenKey = new Key("Kitchen key", " I see something shiny among the pieces of brown bits in the toilet.", "I'd rather not examine this any further.", 2);
            knife = new Item("Sharp Knife", " I see a shiny knife on the floor. On the side I read \"MORAKNIV\"", "Maybe I can use this on something to create something new");
            beerCan = new Item("Beer can", " On the table I see a half full beer can. It reads: \"Norrlands Guld\".", "Maybe I can create something from this ");
            beerKey = new Key("Beer Key", " I see a weird key on the floor", "This key shouldn't work but the force is strong within this key", 1);
            wineBottle = new Item("Wine bottle", " I see a winebottle.", "Maybe I can drink this and forget about my sorrows");

            livingRoom.roomInventory.Add(knife);
            livingRoom.roomInventory.Add(beerCan);
            bathroom.roomInventory.Add(kitchenKey);
            kitchen.roomInventory.Add(outKey);
            hallway.roomInventory.Add(wineBottle);


        }
       

    } //class
} //namespace 



//PlayerName
//RoomList
//Victory
//PlayingGame()


