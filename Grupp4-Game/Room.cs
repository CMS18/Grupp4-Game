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
        public List<Item> roomInventory = new List<Item>(); //Room items, varför read-only? går ej att fylla
        public List<Exit> Exits = new List<Exit>();  //Exit list, samma sak med denna
       
        public Room (string room, string roomdescription) 
        {
            this.RoomName = room.ToString();
            this.RoomDescription = roomdescription;
            
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
