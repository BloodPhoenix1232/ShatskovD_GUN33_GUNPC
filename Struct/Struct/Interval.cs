using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct
{
    internal struct Interval
    {
        public int MinValue { get; }

        public int MaxValue { get; }

        Random random = new Random();
        public double Get
        {
            get
            {
                return random.NextDouble() * (MaxValue - MinValue) + MinValue;
            }
        }
        
        public Interval(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine("Некорректные входные данные.");
            }

            if (!(minValue >= 0))
            {
                minValue = 0;
                Console.WriteLine("Некорректные входные данные.");
            }

            if (!(maxValue >= 0))
            {
                maxValue = 0;
                Console.WriteLine("Некорректные входные данные.");
            }

            if(minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("Некорректные входные данные.");
            }

            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
