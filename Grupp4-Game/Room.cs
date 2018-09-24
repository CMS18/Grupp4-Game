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
        public int[] ArrayPosition { get; set; }
        //private Dictionary<Direction, Room> Exits1 { get => exits1; set => exits1 = value; }

        public List<Item> roomInventory = new List<Item>();
        public List<Exit> Exits = new List<Exit>();

        enum Direction
        {
            North,
            South,
            West,
            East,
            Up,
            Down
        }
        public Dictionary<Direction, Room> exits1 = new Dictionary<Direction, Room>();

        public Room (string roomName, string roomDescription, int[] arrayPosition) 
        {
            this.RoomName = roomName;
            this.RoomDescription = roomDescription;
            ArrayPosition = arrayPosition;

    }

    public void ShowDescription()
        {
            Console.WriteLine(this.RoomDescription);
        }

        public void Inspect ()
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
