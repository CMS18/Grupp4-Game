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



        public void PickUpItem(List<string> userinput)
        {
            foreach (var word in userinput)
            {

                foreach (var item in currentPosition.roomInventory)
                {
                    if (item.ItemName.ToLower().Contains(word.ToLower()))
                    {
                        Console.WriteLine("You picked up " + item.ItemName);
                        currentPosition.roomInventory.Remove(item);
                        inventoryList.Add(item);
                        break;
                    }
                }
            }

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
                Console.WriteLine("Your inventory is empty, pick up something");
            }

        }

        public void UseItem(List<string> userinput)
        {
          /*
                foreach (Item item in inventoryList) //för varje item i inventory
                {
                if (userinput.Contains(item.ItemName))
                {
                    
                }
                    if (item.ItemName.Contains(word)) //om itemnamn innehåller ordet från userinput
                    {
                        //kolla om föremålet är användbart
                        //
                    }

                }*/
           
        }


        public void Move(List<string> userInput)
        {
            string direction = "";

            foreach (string word in userInput)
            {
                if (word.ToLower() == "forward" || word.ToLower() == "left" || word.ToLower() == "back" || word.ToLower() == "right")
                {
                    direction = word.ToLower();
                }
            }


            switch (direction)
            {
                case "forward":
                    foreach (Exit exit in currentPosition.Exits)
                    {
                        if (exit.Direction == direction)
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition.Visited = true;
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
                    Console.WriteLine("No exit this way");
                    break;


                case "back":
                    foreach (Exit exit in currentPosition.Exits)
                    {
                        if (exit.Direction == direction)
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition.Visited = true;
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
                    Console.WriteLine("No exit this way");
                    break;




                case "right":
                    foreach (Exit exit in currentPosition.Exits)
                    {
                        if (exit.Direction == direction)
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition.Visited = true;
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
                    Console.WriteLine("No exit this way");
                    break;

                case "left":
                    foreach (Exit exit in currentPosition.Exits)
                    {
                        if (exit.Direction == direction)
                        {
                            if (exit.Locked == false)
                            {
                                currentPosition.Visited = true;
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
                    Console.WriteLine("No exit this way");
                    break;

                default:
                    DefaultAction();
                    break;
            }
        }
        void DefaultAction()
        {
            Console.WriteLine("No exit this way");
            Console.Write("Exits: ");
            foreach (var exit in currentPosition.Exits)
            {
                Console.Write(exit.DoorDescription + ", ");

            }
        }
        public void DropItem(List<string> userinput)
        {

            foreach (var word in userinput)
            {
                foreach (var item in inventoryList)
                {

                    if (item.ItemName.ToLower().Contains(word.ToLower())) //om listan innehåller 
                    {
                        Console.WriteLine("Dropped item {0}.", item.ItemName);
                        inventoryList.Remove(item);
                        break;

                    }

                    else if (!inventoryList.Contains(item)) // om listan inte innehåller itemet
                    {
                        Console.WriteLine("Couldn't find item {0} in inventory.", item.ItemName);
                    }
                }

            }
        }

        public void Look()
        {
            //Look
        }

    } //class
} //namespace
