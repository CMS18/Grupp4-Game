using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp4_Game
{
    class WorldBuilder
    {
        List<Room> roomList = new List<Room>();

        public WorldBuilder()
        {
            RoomCreator();
        }
        private void RoomCreator()
        {
            Room livingRoom = new Room("Living Room", "Beskrivning");
            Room hall = new Room("Hall", "Beskrivning");
            Room kitchen = new Room("Kitchen", "Beskrivning");
            Room bathRoom = new Room("Bath Room", "Beskrivning");
            Room bedRoom = new Room("Bed Room", "Beskrivning");
            roomList.Add(livingRoom);
            roomList.Add(hall);
        }
        private void ItemCreator()
        {
            Item livingRoomKey = new Item("Living room Key", "Beskrivning", 1);
            
        }

    }
}
