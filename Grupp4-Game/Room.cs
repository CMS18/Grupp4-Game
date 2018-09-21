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

        public Room (string roomName, string roomDescription)
        {
            this.RoomName = roomName;
            this.RoomDescription = roomDescription;
        }
        List<Exit> Exits = new List<Exit>();  //ExitList : List<Exit>
        List<Item> RoomInventory = new List<Item>(); //RoomInventory List<item>
       
        public void ShowDescription()
        {

        }
        public void Inspect ()
        {

        }
       
        
        //Description
        //RoomInventory List<item>
        //ExitList : List<Exit>
        //ShowDiscription()
        //Inspect()

        //Exit
    }
}
