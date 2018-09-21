using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Player
    {
        public string Name { get; set; }
        private readonly string name;
        List<Item> inventoryList = new List<Item>();

        public Player(string name)
        {
            this.name = name;
        }
        //Name
        //InventoryList
        //CurrentPosition
        public void PickUpItem()
        {
            //PickUpItem()
        }

        public void ShowInventory()
        {
            foreach (Item item in inventoryList)
            {
                Console.WriteLine(item);
            }
        }

        public void UseItem()
        {
            //UseItem()
        }

        public void Move()
        {
            //Move()
        }

        public void DropItem(string itemToDrop)
        {
            bool removedItem = false;
            foreach (Item item in inventoryList)
            {
                if (item.ItemName.ToLower() == itemToDrop.ToLower())
                {
                    Console.WriteLine("Dropped item {0}.", item.ItemName);
                    inventoryList.Remove(item);
                    removedItem = true;
                }
            }
            if (removedItem == false)
            {
                Console.WriteLine("Couldn't find item {0} in inventory.", itemToDrop);
            }
        }

        public void Look()
        {
            //Look
        }
    }
}
