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
        public string RoomExamine { get; set; }
        public bool Visited { get; set; }


        public List<Item> roomInventory = new List<Item>();
        public List<Exit> Exits = new List<Exit>();
        public List<RoomProp> RoomProps = new List<RoomProp>();


        public Room(string roomName, string roomDescription, string roomExamine, bool visited)
        {
            RoomName = roomName;
            RoomDescription = roomDescription;
            Visited = visited;
            RoomExamine = roomExamine;
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
            foreach (var item in RoomProps)
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
