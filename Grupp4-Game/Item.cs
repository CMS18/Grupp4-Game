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
        public string DroppedDescription { get; set; }
        public string Examine { get; set; }

        public Item(string itemname, string description, string examine)
        {
            this.ItemName = itemname;
            this.DroppedDescription = description;
            this.Examine = examine;
        }
    

        

        public void ExamineItem ()
        {
            Console.WriteLine(this.Examine);

        }

    }

    class Key : Item
    {
        public int KeyID { get; set; }

        public Key(string itemname, string description, string examine, int keyID) : base(itemname, description, examine)
        {
            this.ItemName = itemname;
            this.DroppedDescription = description;
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
