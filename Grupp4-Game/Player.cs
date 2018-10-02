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
            Name = name;
        }

        public void PickUpItem(string[] userinput)
        {
            bool success = false;
            userinput = userinput.Skip(1).ToArray();
            foreach (var item in CurrentPosition.roomInventory)
            {
                foreach (var word in userinput)
                {
                    if (item.ItemName.ToUpper().Contains(word))
                    {
                        if (word == "WINE" || word == "WINE BOTTLE" || word == "BOTTLE")
                        {
                            Puzzle puzzle = new Puzzle();
                            CurrentPosition.roomInventory.Remove(item);
                            return;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You picked up " + item.ItemName);
                        CurrentPosition.roomInventory.Remove(item);
                        inventoryList.Add(item);
                        Console.ResetColor();
                        success = true;
                        return;
                    }
                }
            }
            if (success == false)
            {
                Console.WriteLine("Can't pick that up.");
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
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Your inventory is empty.");
                Console.ResetColor();
            }
        }

        public void Examine(string[] userinput) //titta närmre på föremål
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

            if (userinput[0] == "ROOM")
            {
                Console.WriteLine(CurrentPosition.ExamineDescription);
                foreach (var item in CurrentPosition.roomInventory)
                {
                    Console.Write(item.DroppedDescription);
                }
                foreach (var item in CurrentPosition.RoomProps)
                {
                    Console.Write(item.DroppedDescription);
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public void Look() //titta i rummet
        {
            Console.WriteLine(CurrentPosition.ExamineDescription);

            List<string> exits = new List<string>();

            foreach (var exit in CurrentPosition.Exits)
            {
                exits.Add(exit.DoorDescription);
            }

            string result = string.Join(", ", exits);
            Console.Write(result + ".");
        }

        public void CreateKey()
        {
            Key beerKey = new Key("Beer Key", "You see a really weird key on the floor.", "It probably won't work but the force is strong within this key.", 1, "key");
            inventoryList.Add(beerKey);
            keyList.Add((Key)beerKey);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You created a mysterious key. Some would even consider it to be unnatural.");
            Console.ResetColor();
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
                   
                    foreach (var exit in CurrentPosition.Exits) //om item på dörr
                    {
                        if (userinput.Contains(exit.LockType.ToUpper()))
                        {
                            foreach (var key in keyList)
                            {
                                if (exit.DoorID == key.KeyID && inventoryList.Contains(key))
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
                }
            }
            Console.WriteLine("Can't do that, try something else.");

            //Console.WriteLine("No such thing in your inventory.");
        }

        void DefaultAction()
        {
            Console.WriteLine("No exit that way.");
            Console.Write("You see the following exits: \n");
            List<string> exits = new List<string>();

            foreach (var exit in CurrentPosition.Exits)
            {
                exits.Add(exit.DoorDescription);
            }

            string result = string.Join(", ", exits);
            Console.Write(result + ".");
            Console.WriteLine();
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
                        CurrentPosition.PrintRoomName();
                        if(CurrentPosition.RoomName.ToUpper() == "OUTDOORS")
                        {
                            Game.GameCompleted();
                            return;
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Dropped {0}.", item.ItemName);
                    inventoryList.Remove(item);
                    CurrentPosition.roomInventory.Add(item);
                    Console.ResetColor();
                    break;
                }

                else if (!inventoryList.Contains(item))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Couldn't find item {0} in inventory.", item.ItemName);
                    Console.ResetColor();
                }
            }
        }
    } //class
} //namespace

