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

        public Room (string roomname, string roomdescription)
        {
            this.RoomName = roomname;
            this.RoomDescription = roomdescription;
        }
        List<Exit> Exits = new List<Exit>();
        //RoomInventory List<item>
        //ExitList : List<Exit>
        public void ShowDescription()
        {

        }
        public void Inspect ()
        {

        }
       

        //Exit
    }
}
