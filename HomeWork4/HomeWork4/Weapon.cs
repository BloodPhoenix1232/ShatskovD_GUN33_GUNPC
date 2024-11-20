using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class Weapon
    {
        public string Name { get; }

        private int MinDamage {  get; set; }

        private int MaxDamage { get; set; }

        public float Durability { get; }
        public Weapon(string name) 
        {
            Name = name;
            Durability = 1f;
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            Name = name;
            SetDamageParams(minDamage, maxDamage);
        }

        private void SetDamageParams(int minDamage, int maxDamage)
        {
            
            if (minDamage > maxDamage)
            {
                (minDamage, maxDamage) = (maxDamage, minDamage);
                Console.WriteLine(minDamage + " " + maxDamage); 
                Console.WriteLine("У оружия '{0}' некорректные данные.", Name);
            }

            if(minDamage < 1)
            {
                minDamage = (int)1f;
                Console.WriteLine("Произошла форсированная установка минимального значения");
            }

            if(maxDamage <= 1)
            {
                maxDamage = 10;
            }
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }

    }
}
