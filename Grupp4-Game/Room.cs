using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Room
    {
        string RoomName { get; set; }
        string RoomDescription { get; set; }
        public bool Visited { get; set; }


        public List<Item> roomInventory = new List<Item>();
        public List<Exit> Exits = new List<Exit>();



        public Room(string roomName, string roomDescription, bool visited)
        {
            this.RoomName = roomName;
            this.RoomDescription = roomDescription;
            this.Visited = visited;
        }

        public void PrintRoomName()
        {
            Console.WriteLine(this.RoomName);
        }

        public void ShowDescription()
        {
            Console.Write(this.RoomDescription);
            foreach (var item in roomInventory)
            {
                Console.Write(item.DroppedDescription);
            }
            Console.WriteLine();
        }

        public void Inspect()
        {
            ShowDescription();
            Console.WriteLine("Rummets inventory: ");
            foreach (Item item in roomInventory)
            {
                Console.WriteLine(item.ItemName);
            }
        }
        //Exit
    }//Class
}//namespace
