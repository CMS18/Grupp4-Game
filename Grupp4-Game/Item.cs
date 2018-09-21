using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    
   class Item
    {
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int KeyID { get; set; }

        public Item(string itemname, string description) // två parametrar
        {
            this.ItemName = itemname;
            this.Description = description;
           
        }
        public Item (string itemname, string description, int keyID) // tre parametrar om nyckel
        {
            this.ItemName = itemname;
            this.Description = description;
            this.KeyID = keyID;

        }

        public void UseKey(Item key, Exit door) 
        {
            if (key.KeyID == door.DoorID)
            {
                Console.WriteLine("Nyckeln passar");
            }
            else Console.WriteLine("Nyckeln passar inte");
        }

        public void Inspect ()
        {
            //Inspect()

        }

        //Key - HouseKey

        //Weapon - Type
    }
}
