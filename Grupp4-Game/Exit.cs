using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Exit
    {
        public bool Locked { get; set;}
        public string lockedInfo = "Door handle wont budge, you'll need a key to unlock this door.";
        public string Direction { get; set; }
        public int DoorID { get; set; }
        public string LockType { get; set; }
        public Room LeadsTo { get; set;}
        public string DoorDescription { get; set; }


        public Exit(string doorDescription, bool Locked, int doorID, Room leadsTo, string direction, string locktype)
        {
            this.Locked = Locked;
            this.DoorID = doorID;
            this.LeadsTo = leadsTo;
            this.DoorDescription = doorDescription;
            this.Direction = direction;
            this.LockType = locktype;
           
        }
    } //class
} //namespace
