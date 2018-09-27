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

        public Item(string itemName, string droppedDescription, string examine)
        {
            this.ItemName = itemName;
            this.DroppedDescription = droppedDescription;
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

        public Key(string itemname, string droppedDescription, string examine, int keyID) : base(itemname, droppedDescription, examine)
        {
            this.ItemName = itemname;
            this.DroppedDescription = droppedDescription;
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

    class RoomProp : Item
    {
        public RoomProp(string itemName, string droppedDescription, string examine) : base(itemName, droppedDescription, examine)
        {
            ItemName = itemName;
            DroppedDescription = droppedDescription;
            Examine = examine;
        }
    }
}
