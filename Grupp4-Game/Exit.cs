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
        int KeyID { get; set; }
        

        public Exit(bool Locked, int doorID, int keyID)
        {
            this.Locked = Locked;
            this.DoorID = doorID;
            this.KeyID = keyID;
        }
        public Exit (bool Locked, int doorID)
        {
            this.Locked = Locked;
            this.DoorID = doorID;
        }
        
    } //class
} //namespace
