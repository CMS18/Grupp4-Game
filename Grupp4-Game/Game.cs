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
        RoomProp toilet;


        bool GameisActive { get; set; }
        public List<Room> Rooms { get; set; }
        List<Item> roomInventory = new List<Item>();
        List<Item> playerInventory = new List<Item>();
        public string[] actionArray = { "GO", "LOOK", "MOVE", "OPEN", "DROP", "TAKE", "USE", "RIGHT", "BACK", "FORWARD", "LEFT" };

        public Game()
        {
            InitializeRooms();
            InitializeItem();
            InitializePlayer();
            GameisActive = true;
            player.currentPosition.ShowDescription();
        }


        List<string> resultlist = new List<string>();

        public void TakeUserInput()
        {

            do
            {
                if (player.currentPosition.Visited == false)
                {
                    player.currentPosition.ShowDescription();
                }
                player.currentPosition.Visited = true;

                Console.Write("> ");
                string[] userInput = Console.ReadLine().ToUpper().Split(' ');
                resultlist = new List<string>(); //för att återställa listan vid nytt kommando
                foreach (var word in userInput)
                {
                    resultlist.Add(word);
                }

                /*  foreach (var word in userInput)
                  {
                      foreach (var action in actionArray)
                      {
                          if (word == action)
                          {
                              resultlist.Add(word);
                          }
                      }
                      foreach (Item item in player.currentPosition.roomInventory)
                      {
                          if (item.ItemName.ToLower().Contains(word.ToLower()))
                          {
                              resultlist.Add(word);
                          }
                      }

                  }
                  */
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
                    case "move":
                        player.Move(userInput);
                        break;
                    case "look":
                        player.Look();
                        break;
                    case "take":
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
                        /* case "open":
                                player.UseItem();
                                break;*/
                }
            }
        }
        public void InitializePlayer()
        {

            player.currentPosition = livingRoom;

        }
        public void InitializeRooms()
        {
            #region Skapar upp alla rummen.
            List<Room> roomList = new List<Room>();

            hallway = new Room("Hallway", "I enter a hallway, to my left is the front door, in front of me seems to be a kitchen and to my right i see a bathroom door. Duty calls but i sense a vague smell of no thank you from the bathroom door", "I see the front door to my left, kitchen in front of me and the toilet to my right.", false);
            livingRoom = new Room("Living Room", "..Suddenly i wake up in a room that resembles a living room, though i've got no clue how i got here.\n" +
                " I see several empty beer cans around the room, perhaps they tell a story? In front of me is a white door.\n", "The living room smells of beer and regrets.", true); //startposition
            kitchen = new Room("Kitchen", "I enter the kitchen and see a wine bottle, my mind's telling me no, but my body's telling me yes", "I'm too hungry to hang out in this kitchen for much longer.", false);
            bathroom = new Room("Bathroom", "The first thing that comes to my mind as i enter the bathroom is \"Is this the start of a SAW movie? Sure smells like it\".", "Gosh.. that smell.", false);
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
                { new Exit("Slightly less mysterious white door (BACK)", false,1, livingRoom, "back") },
                { new Exit("Kitchen door (FORWARD)", true, 2, kitchen, "forward") },
                { new Exit("Stinky bathroom door (RIGHT)", false, 3, bathroom, "right") },
                { new Exit("Front door (LEFT)", true, 4, outdoor, "left") }
            };
            livingRoom.Exits = new List<Exit>
            {
                { new Exit("Mysterious white door (FORWARD)", false, 1, hallway, "forward") }
            };

            kitchen.Exits = new List<Exit>
            {
                { new Exit("Hall door (BACK)", false, 2, hallway, "back") }
            };

            bathroom.Exits = new List<Exit>
            {
                {new Exit("Hall door (WEST)", false, 3, hallway, "left") }
            };


            #endregion

            Rooms = roomList;
        }

        public void InitializeItem()
        {
            #region Skapar upp alla items.
            outKey = new Key("Housekey", " On the floor lies a key, I get a sense of freedom when I see it.", " I think this key will help me get my butt outside this house", 4);
            kitchenKey = new Key("Kitchen key", "", "I'd rather not examine this any further.", 2);
            knife = new Item("Knife", " I see a shiny sharp knife on the floor. On the side I read \"MORAKNIV\".", "Maybe I can use this on something to create something new");
            beercan = new Item("Beer can", " On the table I see a half full beer can. It reads: \"Norrlands Guld\".", "Maybe I can create something from this ");
            beerKey = new Key("Beer Key", " I see a weird key on the floor", "This key shouldn't work but the force is strong within this key", 1);
            wineBottle = new Item("Winebottle", "\n A winebottle lays on the floor.", "Maybe I can drink this and forget about my sorrows, or I can break something with it");
            toilet = new RoomProp("Toilet", " I see an unflushed toilet, who would do such a thing. It looks like there's something in it. ", "While inspecting the disgusting toilet I see a key, dare I take it?");



            livingRoom.roomInventory.Add(knife);
            livingRoom.roomInventory.Add(beercan);
            bathroom.roomInventory.Add(kitchenKey);
            bathroom.RoomProps.Add(toilet);
            kitchen.roomInventory.Add(outKey);
            kitchen.roomInventory.Add(wineBottle);
            #endregion
        }


    } //class
} //namespace 



//PlayerName
//RoomList
//Victory
//PlayingGame()


