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

       
        public List<Item> roomInventory = new List<Item>();
        public List<Exit> Exits = new List<Exit>(); 
       
        public Room (string roomName, string roomDescription) 
        {
            this.RoomName = roomName;
            this.RoomDescription = roomDescription;
           
            
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
