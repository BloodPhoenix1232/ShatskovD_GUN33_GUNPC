using System.Text;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            int[] fib_array = new int[8];
            fib_array[0] = 0; fib_array[1] = 1;
            Console.Write("Числа Фибоначчи: ");

            for (var i = 0; i < fib_array.Count(); i++)
            {
                if (i != 0 && i != 1)
                {
                    fib_array[i] = fib_array[i - 1] + fib_array[i - 2];
                }
                Console.Write(fib_array[i] + " ");
            }

            // Задание 2
            string[] months = new string[] {"January", "February", "March", "April",
               "May", "June", "July", "August", 
                "September", "October", "November", "December" };

            Console.Write("\nМесяца: ");
            for(var i = 0; i < months.Length; i++)
            {
                Console.Write(months[i] + " ");
            }


            // Задание 3
            int[,] matrix = new int[,] { { 2, 3, 4 }, { 4, 9, 16 }, { 8, 27, 64 } };

            Console.WriteLine("\nMatrix: ");
            for(var i = 0; i < matrix.GetLength(0); i++)
            {
                for(var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }


            // Задание 4
            double[][] jagged_array = new double[][] { new double[] {1, 2, 3, 4, 5 }, new double[] {Math.Exp(1), Math.PI }, 
                new double[] {Math.Log10(1), Math.Log10(10), Math.Log10(100), Math.Log10(1000) } };

            for(var i = 0; i < jagged_array.GetLength(0); i++)
            {
                Console.Write("\nМассив [{0}]: ", i);
                for(var j = 0; j < jagged_array[i].Length; j++)
                {
                    Console.Write(jagged_array[i][j] + " ");
                }
            }


            // Задание 5
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };
            Array.Copy(array, array2, 2);

            Console.Write("\n\nResult of copy: ");
            for (var i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }


            // Задание 6
            Console.Write("\n\nResult of resize: ");
            Array.Resize(ref array, array.Length * 2);
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}