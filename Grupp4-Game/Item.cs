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
        public string Examine { get; set; }

        public Item(string itemname, string description, string examine)
        {
            this.ItemName = itemname;
            this.Description = description;
            this.Examine = examine;
        }
    

        

        public void Inspect ()
        {
            //Inspect()

        }

        //Key - HouseKey

        //Weapon - Type
    }

    class Key : Item
    {
        public int KeyID { get; set; }

        public Key(string itemname, string description, string examine, int keyID) : base(itemname, description, examine)
        {
            this.ItemName = itemname;
            this.Description = description;
        }

        public void UseKey(Key key, Exit door)
        {
            if (key.KeyID == door.DoorID)
            {
                Console.WriteLine("Nyckeln passar");
            }
            else Console.WriteLine("Nyckeln passar inte");
        }
    }
}
