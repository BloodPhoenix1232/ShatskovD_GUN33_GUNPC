using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Unit
    {
        private float _health;

        public string Name { get; }

        public float Health => _health;

        public int Damage {  get; }

        public float Armor { get; }

        public Unit() : this("Unknown Unit ")
        {
        }

        public Unit(string name)
        {
            Name = name;
            Damage = 5;
            Armor = 0.6f;
        }

        public float GetRealHealth()
        {
            return (float) Health *  (1f + Armor);
        }

        public bool SetDamage(int damage)
        {
            Console.Write("Здоровье - " + Health);
            _health = Health - damage * Armor;
            if(Health <= 0f)
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
