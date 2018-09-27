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
        public string lockedInfo = "This door is locked, needs some kind of key";
        public string Direction { get; set; }
        public int DoorID { get; set; }
        public Room LeadsTo { get; set;}
        public string DoorDescription { get; set; }


        public Exit(string doorDescription, bool Locked, int doorID, Room leadsTo, string direction)
        {
            this.Locked = Locked;
            this.DoorID = doorID;
            this.LeadsTo = leadsTo;
            this.DoorDescription = doorDescription;
            this.Direction = direction;
           
        }

        public void Inspect()
        {
            if (this.Locked)
            {
                Console.WriteLine("Den här dörren är låst");
            }
            else
            {
                Console.WriteLine("Du kan öppna den här dörren");
            }
        }
        
    } //class
} //namespace
