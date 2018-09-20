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
        public Item(string itemname, string description)
        {
            this.ItemName = itemname;
            this.Description = description;
        }

        public void Use()
        {
            //Use()
        }

        public void Inspect ()
        {
            //Inspect()

        }

        //Key - HouseKey

        //Weapon - Type
    }
}
