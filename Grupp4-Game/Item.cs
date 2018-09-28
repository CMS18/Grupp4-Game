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
        public string ItemType { get; set; }
       
        public Item(string itemName, string droppedDescription, string examine, string matchID, string itemType)
        {
            this.ItemName = itemName;
            this.DroppedDescription = droppedDescription;
            this.Examine = examine;
            this.MatchId = matchID;
            this.ItemType = itemType;
        }
      
        public void ExamineItem ()
        {
            Console.WriteLine(this.Examine);
        }
    }

   class Key : Item
     {
         public int KeyID { get; set; }

        public Key(string itemname, string droppedDescription, string examine, int keyID, string itemtype) : base(itemname, droppedDescription, examine, "0", "key")
        {
            this.ItemName = itemname;
            this.DroppedDescription = droppedDescription;
            this.KeyID = keyID;
           this.ItemType = itemtype;
        }
    }
    
    class RoomProp : Item
    {
        public RoomProp(string itemName, string droppedDescription, string examine, string itemtype) : base(itemName, droppedDescription, examine, "0", "prop")
        {
            ItemName = itemName;
            DroppedDescription = droppedDescription;
            Examine = examine;
            ItemType = itemtype;
        }
    }
}
