using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class WorldBuilder
    {

        public WorldBuilder()
        {
        }

        public List<Room> RoomCreator()
        {
            List<Room> roomList = new List<Room>();


            Room livingRoom = new Room("Living Room", "Beskrivning living room", new int[]{ 2, 1 });
            Room hall = new Room("Hall", "Beskrivning Hall", new int[] { 1, 1 });
            Room kitchen = new Room("Kitchen", "Beskrivning kitchen", new int[] { 0, 1 });
            Room bathroom = new Room("Bathroom", "Beskrivning bathroom", new int[] { 1, 2 });
            Room bedroom = new Room("Bedroom", "Beskrivning Bedroom", new int[] { 1, 0 });
            // Room basement = new Room("Basement", "Beskrivning Basement"); //Vet inte om vi kommer använda denna
            roomList.Add(livingRoom);
            roomList.Add(hall);
            roomList.Add(kitchen);
            roomList.Add(bathroom);
            roomList.Add(bedroom);
            //roomList.Add(basement);
            #region Fyller rummen med Exits
            livingRoom.Exits = new List<Exit>
            {
                { new Exit("Mysterious white door", true, 1, hall) }
            };

            hall.Exits = new List<Exit>
            {
                { new Exit("Slightly less mysterious white door", false, 1, livingRoom) },
                { new Exit("Kitchen door", false, 2, kitchen) },
                { new Exit("Stinky bathroom door", false, 3, bathroom) },
                { new Exit("Bedroom door", false, 4, bedroom) }
            };
            kitchen.Exits = new List<Exit>
            {
                { new Exit("Hall door", false, 2, hall) }
            };

            bathroom.Exits = new List<Exit>
            {
                {new Exit("Hall door", false, 3, hall) }
            };

            bedroom.Exits = new List<Exit>
            {
                { new Exit("Hall door", false, 4, hall) }
            };
            #endregion


            return roomList;
        }
        private List<Item> ItemCreator() //Har hårdkodat här nedan
        {

            //Item key = new Item("Nyckel", "Nyckel till dörr 1", 1);
            //Item key2 = new Item("Nyckel2", "Nyckel till dörr 2", 2);
            //Item boll = new Item("Testboll", "Kasta den i ettt fönster");

            //Exit Door = new Exit(true, 1, livingRoom); //låst, ID 1
            //Exit Door2 = new Exit(true, 2, kitchen); //låst, ID 2
            //Exit Door3 = new Exit(false, 3, bathRoom); //olåst, ID 3


            //Exits.Add(Door); //hallen har låst dörr till livingroom
            //hall.Exits.Add(Door2); //hallen har låst dörr till kitchen

            //hall.roomInventory.Add(boll);
            //hall.roomInventory.Add(key); //hallen har nyckeln till kitchen
            //kitchen.roomInventory.Add(key2); // kitchen har nyckeln till livinroom

            //hall.Inspect(); //inspektera hallen, beskrivning visas
            //Console.WriteLine("press Enter to pick up item");
            //Console.ReadLine();
            //player.PickUpItem(key);  //plockar upp nyckeln
            //Console.WriteLine("press enter to use it on door");
            //Console.ReadLine();
            //key.UseKey(key,Door);
            //Console.WriteLine("press Enter to drop item");
            //Console.ReadLine();
            //player.DropItem(key); //släpper nyckeln

            //player.ShowInventory();
            //Console.ReadLine();
            //Door.Inspect();
            //Door3.Inspect();

        }

    } //class
} //namespace 
