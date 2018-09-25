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
        public List<Item> inventoryList = new List<Item>(); //InventoryList
        public Room currentPosition { get; set; }

        public Player(string name)
        {
            this.Name = name;

        }



        public void PickUpItem(Item item) //skickar in ett Item
        {
            /* currentroom.inventory remove...*/

            inventoryList.Add(item); //lägger till item i player inventory
            Console.WriteLine("Du plockade upp {0} till din inventory", item.ItemName);
            ShowInventory();

        }

        public void ShowInventory()
        {
            Console.WriteLine("Din inventory:");
            foreach (var item in inventoryList)
            {
                Console.WriteLine(item.ItemName);
            }
            if (inventoryList.Count == 0) // om inventoryn är tom
            {
                Console.WriteLine("Din inventory är tom");
            }

        }

        public void UseItem(Item item, Exit itemtwo)
        {

        }

        public void Move(List<string> userInput)
        {
            string direction = "";

            foreach (string word in userInput)
            {
                if (word.ToLower() == "north" || word.ToLower() == "west" || word.ToLower() == "south" || word.ToLower() == "east")
                {
                    direction = word.ToLower();
                }
            }


            switch (direction)
            {

                case "north":
                    foreach (var exit in currentPosition.Exits)
                    {
                        if (exit.Direction == "NORTH")
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition = exit.LeadsTo;
                                break;
                            }
                            else Console.WriteLine("This door is locked, info: " + exit.DoorDescription);
                        }

                    }
                    break;

                case "south":
                    foreach (var exit in currentPosition.Exits)
                    {
                        if (exit.Direction == "SOUTH")
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition = exit.LeadsTo;

                            }
                            else Console.WriteLine("This door is locked, info: ", exit.DoorDescription);
                        }
                    }
                    break;

                case "east":
                    foreach (var exit in currentPosition.Exits)
                    {
                        if (exit.Direction == "EAST")
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition = exit.LeadsTo;

                            }
                            else Console.WriteLine("This door is locked, info: ", exit.DoorDescription);
                        }
                    }
                    break;

                case "west":
                    foreach (var exit in currentPosition.Exits)
                    {
                        if (exit.Direction == "WEST")
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition = exit.LeadsTo;

                            }
                            else Console.WriteLine("This door is locked, info: ", exit.DoorDescription);
                        }
                    }
                    break;

                default:
                    Console.WriteLine("No exit this way");
                    Console.Write("Exits: ");
                    foreach (var exit in currentPosition.Exits)
                    {
                        Console.Write(exit.DoorDescription + ", ");

                    }
                    break;
            }
        }

        public void DropItem(Item itemToDrop)
        {

            foreach (Item item in inventoryList)
            {
                if (inventoryList.Contains(itemToDrop)) //om listan innehåller itemet
                {
                    Console.WriteLine("Dropped item {0}.", item.ItemName);
                    inventoryList.Remove(item);
                    break;

                }
                else if (!inventoryList.Contains(itemToDrop)) // om listan inte innehåller itemet
                {
                    Console.WriteLine("Couldn't find item {0} in inventory.", itemToDrop.ItemName);
                }
            }

        }

        public void Look()
        {
            //Look
        }

    } //class
} //namespace
