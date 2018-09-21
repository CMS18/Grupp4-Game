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
        List<Exit> Exits = new List<Exit>();

        public WorldBuilder()
        {
            RoomCreator();
            ItemCreator();
        }
        public void RoomCreator()
        {
           /* Room livingRoom = new Room("Living Room", "tHrough door 1");
            Room hall = new Room("Hall", "beskrivning");
            Room kitchen = new Room("Kitchen", "through door 2");
            Room bathRoom = new Room("Bath Room", "Beskrivning");
            Room bedRoom = new Room("Bed Room", "Beskrivning");
            Room basement = new Room("Basement", "Beskrivning");
            roomList.Add(livingRoom);
            roomList.Add(hall);
            roomList.Add(kitchen);
            roomList.Add(bathRoom);
            roomList.Add(bedRoom);
            roomList.Add(basement);*/
        }
        private void ItemCreator() //Har hårdkodat här nedan
        {
            Player player = new Player("Bjrön");


            Room livingRoom = new Room("Living Room", "tHrough door 1");
            Room hall = new Room("Hall", "beskrivning");
            Room kitchen = new Room("Kitchen", "through door 2");
            Room bathRoom = new Room("Bath Room", "Beskrivning");
            Room bedRoom = new Room("Bed Room", "Beskrivning");
            Room basement = new Room("Basement", "Beskrivning");
            roomList.Add(livingRoom);
            roomList.Add(hall);
            roomList.Add(kitchen);
            roomList.Add(bathRoom);
            roomList.Add(bedRoom);
            roomList.Add(basement);

            Item key = new Item("Nyckel", "Nyckel till dörr 1", 1);
            Item key2 = new Item("Nyckel2", "Nyckel till dörr 2", 2);
            Item boll = new Item("Testboll", "Kasta den i ettt fönster");

            Exit Door = new Exit(true, 1, livingRoom); //låst, ID 1
            Exit Door2 = new Exit(true, 2, kitchen); //låst, ID 2
            Exit Door3 = new Exit(false, 3, bathRoom); //olåst, ID 3


            Exits.Add(Door); //hallen har låst dörr till livingroom
            hall.Exits.Add(Door2); //hallen har låst dörr till kitchen

            hall.roomInventory.Add(boll);
            hall.roomInventory.Add(key); //hallen har nyckeln till kitchen
            kitchen.roomInventory.Add(key2); // kitchen har nyckeln till livinroom

            hall.Inspect(); //inspektera hallen, beskrivning visas
            Console.WriteLine("press Enter to pick up item");
            Console.ReadLine();
            player.PickUpItem(key);  //plockar upp nyckeln
            Console.WriteLine("press enter to use it on door");
            Console.ReadLine();
            key.UseKey(key,Door);
            Console.WriteLine("press Enter to drop item");
            Console.ReadLine();
            player.DropItem(key); //släpper nyckeln

            player.ShowInventory();
            Console.ReadLine();
            Door.Inspect();
            Door3.Inspect();



        }

    } //class
} //namespace 
