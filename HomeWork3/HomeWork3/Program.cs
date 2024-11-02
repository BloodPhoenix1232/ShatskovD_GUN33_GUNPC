namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Fibonaccy
            int[] FibonaccyArray = new int[10];
            FibonaccyArray[0] = 0; FibonaccyArray[1] = 1;
            int index = 0;

            Console.Write("Задание 1: ");
            while (index < FibonaccyArray.Length)
            {
                if (index != 0 && index != 1)
                {
                    FibonaccyArray[index] = FibonaccyArray[index - 1] + FibonaccyArray[index - 2];
                    Console.Write(FibonaccyArray[index] + " ");
                }
                else 
                {
                    Console.Write(FibonaccyArray[index] + " ");
                }
                index++;
            }

            // Задание 2
            Console.Write("\nЗадание 2: ");
            for(int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }

            // Задание 3
            Console.WriteLine("\nЗадание 3:");
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(i * j + " ");
                }
                Console.WriteLine();
            }

            // Задание 4
            Console.WriteLine("Задание 4:");
            string password = "qwerty";
            string attempt;
            do
            {
                Console.Write("Your password: ");
                attempt = Console.ReadLine();
            }
            while (attempt != password);
            Console.WriteLine("Correct");
        }
    }
}