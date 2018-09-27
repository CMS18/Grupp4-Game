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
        public string MatchId { get; set; }
        public int KeyID { get; set; }
        public string itemType { get; set; }

        public Item(string itemname, string description, string examine, string matchID, string itemType)
        {
            this.ItemName = itemname;
            this.DroppedDescription = description;
            this.Examine = examine;
            this.MatchId = matchID;
            this.itemType = itemType;
        }
        
        public Item(string itemname, string description, string examine, int KeyID, string itemType)
        {
            this.ItemName = itemname;
            this.DroppedDescription = description;
            this.Examine = examine;
            this.KeyID = KeyID;
            this.itemType = itemType;
        }



    }

    /* class Key : Item
     {
         public int KeyID { get; set; }

         public Key(string itemname, string description, string examine, int keyID) : base(itemname, description, examine, 0)
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
     }*/
}
