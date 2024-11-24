using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    internal struct Room
    {
        public Unit OccupiedUnit { get; }
        public Weapon Weapon { get; }

        public Room(Unit unit, Weapon weapon)
        {
            OccupiedUnit = unit;
            Weapon = weapon;
        }
    }
}
