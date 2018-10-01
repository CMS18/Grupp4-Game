using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Room
    {
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public bool Visited { get; set; }
        public string ExamineDescription { get; set; }
      

        public List<Item> roomInventory = new List<Item>();
        public List<Exit> Exits = new List<Exit>();
        public List<RoomProp> RoomProps = new List<RoomProp>();



        public Room(string roomName, string roomDescription, string examineDescription, bool visited)
        {
            this.RoomName = roomName;
            this.RoomDescription = roomDescription;
            this.Visited = visited;
            this.ExamineDescription = examineDescription;
        }

        public void PrintRoomName()
        {
            Console.WriteLine(this.RoomName);
        }

        public void ShowDescription()
        {
            Console.Write(RoomDescription);
            Console.WriteLine();
            foreach (var item in roomInventory)
            {
                if(item.DroppedDescription.Length > 0)
                {
                    Console.WriteLine(item.DroppedDescription);
                }
            }
            foreach (var item in RoomProps)
            {
                Console.WriteLine(item.DroppedDescription);
            }
            Console.ResetColor();
        }
    }//Class
}//namespace
