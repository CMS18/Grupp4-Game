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
        public List<Key> keyList = new List<Key>();
        public Room CurrentPosition { get; set; }


        public Player(string name)
        {
            this.Name = name;
        }

        public void PickUpItem(string[] userinput)
        {
            userinput = userinput.Skip(1).ToArray();
            foreach (var item in CurrentPosition.roomInventory)
            {
                foreach (var word in userinput)
                {

                    if (item.ItemName.ToUpper().Contains(word))
                    {
                        Console.WriteLine("You picked up " + item.ItemName);
                        CurrentPosition.roomInventory.Remove(item);
                        inventoryList.Add(item);
                        return;
                    }
                }
            }
            Console.WriteLine("Can't pick that up.");

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
                Console.WriteLine("Your inventory is empty.");
            }
        }

        public void ExamineItem(string[] userinput) //titta närmre på föremål
        {
            if (userinput.Length <= 1)
            {
                Console.WriteLine("What do you want to examine?");
                return;
            }
            userinput = userinput.Skip(1).ToArray();

            foreach (var item in inventoryList) // för varje item i inventory
            {
                if (item.ItemName.ToUpper().Contains(userinput[0])) // om itemet är i inventoryn
                {
                    Console.WriteLine(item.Examine);
                    break;
                }

            }

            foreach (var roomitem in CurrentPosition.roomInventory) //för varje rumsitem
            {
                if (roomitem.ItemName.ToUpper().Contains(userinput[0])) //om itemet är i rummet
                {
                    Console.WriteLine(roomitem.Examine);
                    break;
                }

            }

            foreach (var roomProp in CurrentPosition.RoomProps)
            {
                if (roomProp.ItemName.ToUpper().Contains(userinput[0])) //om itemet är i rummet
                {
                    Console.WriteLine(roomProp.Examine);
                    break;
                }

            }
            foreach (var exit in CurrentPosition.Exits)
            {
              
                if (exit.LockType.ToUpper().Contains(userinput[0]))
                {
                    Console.WriteLine(exit.DoorDescription);
                    if (exit.Locked)
                    {
                        Console.WriteLine(exit.lockedInfo);
                    }
                    else Console.WriteLine("This door isn't locked.");
                    break;
                }
                    
                    
                
            }
        }

        public void Look() //titta i rummet
        {
            CurrentPosition.ShowDescription();
            Console.Write("Exits: \n");
            foreach (var exit in CurrentPosition.Exits)
            {
                Console.Write(exit.DoorDescription + ". ");
            }
        }

        public void CreateKey()
        {
            Item beerKey = new Key("Beer Key", " I see a weird key on the floor.", "This key shouldn't work but the force is strong within this key.", 1, "key");
            inventoryList.Add(beerKey);
            keyList.Add((Key)beerKey);
            Console.WriteLine("You created a key.");
        }

        public void UseItem(string[] userinput)
        {
            if (userinput.Length <= 1)
            {
                Console.WriteLine("What do you wanna use?");
                return;
            }

            foreach (var item in inventoryList)
            {
                if (userinput.Contains(item.ItemType.ToUpper())) // itemtype
                {
                    if (item.ItemName == "Wine bottle")
                    {
                        Puzzle puzzle = new Puzzle();
                        if (puzzle.SolvedPuzzle)
                        {
                            inventoryList.Remove(item);
                            return;
                        }
                    }


                    foreach (var exit in CurrentPosition.Exits) //om item på dörr
                    {
                        if (userinput.Contains(exit.LockType.ToUpper()))
                        {
                            foreach (var key in keyList)
                            {

                                if (exit.DoorID == key.KeyID) 
                                {
                                    exit.Locked = false;
                                    Console.WriteLine("The key fits, and the door unlocks.");
                                    inventoryList.Remove(item);
                                    keyList.Remove((Key)item);
                                    return;
                                }
                            }
                        }
                    }

                    foreach (var inventoryitem in inventoryList) //om item på ett annat item
                    {
                        if (inventoryitem.ItemName == item.ItemName) //om vi pekar på samma item så ta nästa
                        {
                            continue;
                        }
                        if (userinput.Contains(inventoryitem.ItemType.ToUpper()))
                        {
                            if (inventoryitem.MatchId == item.MatchId) //om itemsen matchar med varandra
                            {
                                inventoryList.Remove(item);
                                inventoryList.Remove(inventoryitem);
                                CreateKey();
                                return;
                            }
                            else
                                Console.WriteLine("These things don't match.");
                        }
                    }
                    Console.WriteLine("Cannot use this.");
                }
            }
            Console.WriteLine("Non such thing in your inventory.");
        }

        void DefaultAction()
        {
            Console.WriteLine("No exit that way.");
            Console.Write("I see the following exits: ");

            string comma = (CurrentPosition.Exits.Count == 1) ? "" : ", ";
            foreach (var exit in CurrentPosition.Exits)
            {
                Console.Write(exit.DoorDescription + comma);
            }
            Console.WriteLine(".");
        }

        public void Move(string[] userInput)
        {
            if (userInput.Length <= 1)
            {
                Console.WriteLine("Where do you wanna go?");
                return;
            }
            string direction = "";

            foreach (string word in userInput)
            {
                if (word == "FORWARD" || word == "LEFT" || word == "BACK" || word == "RIGHT")
                {
                    direction = word.ToLower();
                }
            }
            CheckDirection(direction); //istället för switch-case
        }

        public void CheckDirection(string direction) //istället för switch-case för direction
        {
            foreach (Exit exit in CurrentPosition.Exits)
            {
                if (exit.Direction == direction)
                {
                    if (exit.Locked == false)
                    {
                        CurrentPosition = exit.LeadsTo;

                        Console.Write("Moved to ");
                        CurrentPosition.PrintRoomName();
                        if (CurrentPosition.Visited)
                        {
                            Console.WriteLine(CurrentPosition.VisitedDescription);
                        }
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
            userinput = userinput.Skip(1).ToArray();
            foreach (var item in inventoryList)
            {
                if (item.ItemName.ToUpper().Contains(userinput[0]))
                {
                    Console.WriteLine("Dropped {0}.", item.ItemName);
                    inventoryList.Remove(item);
                    CurrentPosition.roomInventory.Add(item);
                    break;
                }

                else if (!inventoryList.Contains(item))
                {
                    Console.WriteLine("Couldn't find item {0} in inventory.", item.ItemName);
                }
            }
        }
    } //class
} //namespace

