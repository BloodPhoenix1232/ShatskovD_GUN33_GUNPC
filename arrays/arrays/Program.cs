namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Здесь массивы заданий 1-4
            int[] fib_array = new int[8];
            fib_array[0] = 0; fib_array[1] = 1;
            Console.Write("Числа Фибоначчи: ");
            for (int i = 0; i < fib_array.Count(); i++)
            {
                if (i != 0 && i != 1)
                {
                    fib_array[i] = fib_array[i - 1] + fib_array[i - 2];
                }
                Console.Write(fib_array[i] + " ");
            }

        }
    }
}