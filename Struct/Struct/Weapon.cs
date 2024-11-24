using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    internal class Weapon
    {
        public string Name { get; }
        public Interval Interval { get; private set; }
        public float Durability { get; }
        public Weapon(string name) 
        {
            Name = name;
            Durability = 1f;
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            Name = name;
            Interval = new Interval(minDamage, maxDamage);
        }

    }
}
