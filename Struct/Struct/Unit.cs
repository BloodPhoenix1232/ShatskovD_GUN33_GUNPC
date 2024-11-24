using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Struct
{
    internal class Unit
    {
        private float _health;

        public string Name { get; }

        public float Health => _health;

        public Interval Interval { get; }

        public float Armor { get; }

        public Unit() : this("Unknown Unit ")
        {
        }

        public Unit(string name)
        {
            Name = name;
            Armor = 0.6f;
        }

        public Unit(string name, int minDamage, int maxDamage)
        {
            Name = name;
            if(minDamage != 0)
            {
                minDamage = 0;
            }
            Interval = new Interval(minDamage, maxDamage);
            Armor = 0.6f;
        }

        public float GetRealHealth()
        {
            return (float)Health * (1f + Armor);
        }

        public bool SetDamage(int damage)
        {
            Console.Write("Здоровье - " + Health);
            _health = Health - damage * Armor;
            if (Health <= 0f)
            {
                Console.WriteLine("Unit dead");
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
