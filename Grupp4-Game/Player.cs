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

        public void PickUpItem(string[] userinput)
        {
            bool success = false;

            foreach (var word in userinput)
            {
                foreach (var item in currentPosition.roomInventory)
                {
                    if (item.ItemName.ToLower().Contains(word.ToLower()))
                    {
                        Console.WriteLine("You picked up " + item.ItemName);
                        currentPosition.roomInventory.Remove(item);
                        inventoryList.Add(item);
                        success = true;
                        break;
                    }
                }
            }
            if(success == false)
            {
                Console.WriteLine("Can't pick up that");

            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("Your inventory:");
            foreach (var item in inventoryList)
            {
                Console.WriteLine(item.ItemName);
            }
            if (inventoryList.Count == 0) // om inventoryn är tom
            {
                Console.WriteLine("Your inventory is empty, pick up something");
            }
        }

        public void ExamineItem(string[] userinput) //titta närmre på föremål
        {
            foreach (var roomitem in currentPosition.roomInventory) //för varje rumsitem
            {
                if (userinput.Contains(roomitem.ItemName.ToUpper())) //om itemet är i rummet
                {
                    Console.WriteLine(roomitem.Examine);
                    break;
                }

                foreach (var item in inventoryList) // för varje item i inventory
                {
                    if (userinput.Contains(item.ItemName.ToUpper()))
                    {
                        Console.WriteLine(item.Examine);
                        break;
                    }
                }
            }

            foreach (var roomProp in currentPosition.RoomProps)
            {
                if (userinput.Contains(roomProp.ItemName.ToUpper())) //om itemet är i rummet
                {
                    Console.WriteLine(roomProp.Examine);
                    break;
                }
            }
        }

        public void Look() //titta i rummet
        {
            currentPosition.ShowDescription();
            Console.Write("Exits: \n");
            foreach (var exit in currentPosition.Exits)
            {
                Console.Write(exit.DoorDescription + ". ");
            }
        }

        public void CreateKey()
        {
            Item beerKey = new Key("Beer Key", " I see a weird key on the floor", "This key shouldn't work but the force is strong within this key", 1);
            inventoryList.Add(beerKey);
        }

        public void UseItem(string[] userinput)
        {
            foreach (var item in inventoryList)
            {
                if (userinput.Contains(item.ItemName.ToUpper()))
                {
                    if (item.ItemName == "wine" || item.ItemName == "bottle")
                    {
                        //fredrik kommer och frågar om pussel
                    }

                    foreach (var exit in currentPosition.Exits)
                    {
                        if (userinput.Contains(exit.DoorDescription.ToUpper()))
                        {
                            //if (exit.DoorID == item.KeyID)
                            //{
                            //    exit.Locked = false;
                            //    Console.WriteLine("Unlocked.");
                            //    inventoryList.Remove(item);
                            //}
                        }
                    }
                }
            }
        }

        void DefaultAction()
        {
            Console.WriteLine("No exit that way.");
            Console.Write("I see the following exits: ");

            string comma = (currentPosition.Exits.Count == 1) ? "" : ", ";
            foreach (var exit in currentPosition.Exits)
            {
                Console.Write(exit.DoorDescription + comma);
            }
            Console.WriteLine(".");
        }

        public void Move(string[] userInput)
        {
            string direction = "";

            foreach (string word in userInput)
            {
                if (word == "forward" || word == "left" || word == "back" || word == "right")
                {
                    direction = word.ToLower();
                }
            }
            CheckDirection(direction); //istället för switch-case
        }

        public void CheckDirection(string direction) //istället för switch-case för direction
        {
            foreach (Exit exit in currentPosition.Exits)
            {
                if (exit.Direction == direction)
                {
                    if (exit.Locked == false)
                    {
                        currentPosition = exit.LeadsTo;

                        Console.Write("Moved to ");
                        currentPosition.PrintRoomName();
                        return;
                    }
                    else
                    {
                        Console.WriteLine(exit.lockedInfo);
                        return;
                    }
                }
                else continue;
            }
            DefaultAction();
        }

        public void DropItem(string[] userinput)
        {
            foreach (var item in inventoryList)
            {
                if (userinput.Contains(item.ItemName.ToUpper())) //om listan innehåller 
                {
                    Console.WriteLine("Dropped item {0}.", item.ItemName);
                    inventoryList.Remove(item);
                    currentPosition.roomInventory.Add(item);
                    break;
                }

                else if (!inventoryList.Contains(item)) // om listan inte innehåller itemet
                {
                    Console.WriteLine("Couldn't find item {0} in inventory.", item.ItemName);
                }
            }
        }
    } //class
} //namespace

