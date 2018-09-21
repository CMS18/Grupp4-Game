using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class WorldBuilder
    {
        List<Room> roomList = new List<Room>();

        public WorldBuilder()
        {
            RoomCreator();
        }
        private void RoomCreator()
        {
            Room livingRoom = new Room("Living Room", "Beskrivning");
            Room hall = new Room("Hall", "Beskrivning");
            Room kitchen = new Room("Kitchen", "Beskrivning");
            Room bathRoom = new Room("Bath Room", "Beskrivning");
            Room bedRoom = new Room("Bed Room", "Beskrivning");
            roomList.Add(livingRoom);
            roomList.Add(hall);
        }
        private void ItemCreator()
        {
            Player player = new Player("Bjrön");

            Room livingRoom = new Room("livingRoom", "desciprtion: the livingroom, access through door 1");
            Room Kitchen = new Room("Kitchen", "description: the kitchen, access through door 2");
            Room hall = new Room("Hall", "Hallen, description: first access");

            Item key = new Item("Nyckel", "Nyckel till dörr 1", 1);
            Item key2 = new Item("Nyckel2", "Nyckel till dörr 2", 2);
            Item boll = new Item("Testboll", "Kasta den i någons fönster");

            Exit Door = new Exit(true, 1, 1); //låst, ID 1
            Exit Door2 = new Exit(true, 2, 2); //låst, ID 2
            Exit Door3 = new Exit(false, 3); //olåst


            hall.Exits.Add(Door); //hallen har låst dörr till livingroom
            hall.Exits.Add(Door2); //hallen har låst dörr till kitchen

            hall.roomInventory.Add(boll);
            hall.roomInventory.Add(key); //hallen har nyckeln till kitchen
            Kitchen.roomInventory.Add(key2); // kitchen har nyckeln till livinroom

            hall.Inspect(); //inspektera hallen, beskrivning visas
            Console.WriteLine("press Enter to pick up item");
            Console.ReadLine();
            player.PickUpItem(key);  //plockar upp nyckeln
            Console.WriteLine("press Enter to drop item");
            Console.ReadLine();
            player.DropItem(key); //släpper nyckeln

            player.ShowInventory();
            Console.ReadLine();



        }

    } //class
} //namespace 
