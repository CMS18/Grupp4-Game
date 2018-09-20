using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class Player
    {
        string name { get; set; }
        List<Item> InventoryList = new List<Item>();
        
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
            //showInventory()
        }

        public void UseItem()
        {
            //UseItem()
        }

        public void Move()
        {
            //Move()
        }

        public void DropItem()
        {
            //DropItem()
        }

        public void Look()
        {
            //Look
        }
    }
    }
