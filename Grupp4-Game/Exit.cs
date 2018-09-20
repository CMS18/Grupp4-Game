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
        int DoorID { get; set; }

        public Exit(bool Locked, int doorID)
        {
            this.Locked = Locked;
            this.DoorID = doorID;
           

        }
        


    }
}
