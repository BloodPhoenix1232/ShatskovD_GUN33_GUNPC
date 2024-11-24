using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    internal class Dungeon
    {
        public Room[] _rooms = new Room[5];

        public Dungeon() 
        {
            {
                _rooms[0] = new Room(new Unit("Шаман", 0, 5), new Weapon("Посох", 2, 5));
                _rooms[1] = new Room(new Unit("Скелет - лучник", 0, 3), new Weapon("Лук", 1, 3));
                _rooms[2] = new Room(new Unit("Стражник", 0, 4), new Weapon("Меч", 2, 4));
                _rooms[3] = new Room(new Unit("Огр", 0, 5), new Weapon("Дубина", 1, 5));
                _rooms[4] = new Room(new Unit("Слизень", 0, 2), new Weapon("Кинжал", 3, 4));
            };
        }

        public void ShowRooms()
        {
            for (int i = 0; i < _rooms.Length; i++)
            {
                var room = _rooms[i];
                Console.WriteLine("Unit of room {0}: {1}", (i + 1), room.OccupiedUnit.Name);
                Console.WriteLine("Weapon of room {0}: {1}", (i + 1), room.Weapon.Name);
                Console.WriteLine("—");
            }
        }
    }
}
