using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Exit
    {
        bool Locked { get; set;}
        public int DoorID { get; set; }
        public Room LeadsTo { get; set;}
      
        
        public Exit(bool Locked, int doorID, Room leadsTo)
        {
            this.Locked = Locked;
            this.DoorID = doorID;
            this.LeadsTo = leadsTo;
           
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
