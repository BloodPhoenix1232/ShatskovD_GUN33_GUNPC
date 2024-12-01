using System.Linq;
using System.Reflection;

namespace HomeWork6
{
    internal class Program
    {

        private class ListString // Задание 1
        {
            public List <string> strings = new List<string>() {"1", "2", "3"};

            public void TaskLoop()
            {
                while (true)
                {
                    Console.Write("Введите строку: ");
                    string newString = Console.ReadLine();
                    strings.Add(newString);
                    Console.WriteLine($"Новая строка {newString} добавлена на {strings.Count - 1} позицию.");
                    Console.Write("Your list: ");

                    foreach (string s in strings)
                    {
                        Console.Write(s + " || ");
                    }

                    Console.Write("\nВведите новую строку: ");
                    newString = Console.ReadLine();
                    strings.Insert(strings.Count / 2, newString);
                    Console.WriteLine($"Новая строка {newString} добавлена на {strings.Count / 2} позицию.");
                    Console.Write("Your list: ");

                    foreach (string s in strings)
                    {
                        Console.Write(s + " || ");
                    }

                    Console.Write("\nЕсли хотите завершить напишите 'exit', чтобы продолжить 'cont': ");
                    switch (Console.ReadLine())
                    {
                        case "exit":
                            return;
                        case "cont":
                            continue;
                    }
                }
            }
        }

        private class Journal // Задание 2
        {
            public Dictionary<string, int> journal = new Dictionary<string, int>();

            public void TaskLoop()
            {

                while (true)
                {
                    Console.Write("Введите имя студента: ");
                    string nameOfStudent = Console.ReadLine();

                    int mark;
                    do
                    {
                        Console.Write("Введите его оценку(от 2 до 5): ");
                        if (!int.TryParse(Console.ReadLine(), out mark))
                        {
                            Console.Write("Введена некорректная оценка!");
                        }
                    }
                    while (!(mark >= 2 && mark <= 5));

                    journal.Add(nameOfStudent, mark);
                    Console.Write("Введите имя студента, оценку которого вы хотите узнать: ");
                    nameOfStudent = Console.ReadLine();
                    if (journal.ContainsKey(nameOfStudent))
                    {
                        Console.WriteLine("Оценка вашего студента: " + journal[nameOfStudent]);
                    }
                    else
                    {
                        Console.WriteLine("Такого студента не существует");
                    }

                    Console.Write("\nЕсли хотите завершить напишите 'exit', чтобы продолжить 'cont': ");
                    switch (Console.ReadLine())
                    {
                        case "exit":
                            return;
                        case "cont":
                            continue;
                    }
                }
            }
        }

        private class DoubleLinkList // Задание 3
        {
            public LinkedList<int> list = new LinkedList<int>();

            public void TaskLoop()
            {
                while(true)
                {
                    Console.Write("Введите размер списка (от 3 до 6): ");

                    if (!(int.TryParse(Console.ReadLine(), out int lengthOfList)))
                    {
                        Console.WriteLine("Введено неверное значение");
                    }

                    for (int i = 0; i < lengthOfList; i++)
                    {
                        Console.Write("Введите целое число: ");
                        if (!int.TryParse(Console.ReadLine(), out int element))
                        {
                            Console.WriteLine("Введено неверное значение");
                        }
                        else
                        {
                            if (i % 2 == 0)
                            {
                                list.AddLast(element);
                            }
                            else
                            {
                                list.AddFirst(element);
                            }
                        }
                    }

                    Console.Write("\nYour list: ");
                    foreach (int i in list)
                    {
                        Console.Write(i + " || ");
                    }

                    Console.Write("\nYour list by descending: ");
                    foreach (int i in list.OrderDescending())
                    {
                        Console.Write(i + " || ");
                    }

                    list.Clear();

                    Console.Write("\nЕсли хотите завершить напишите 'exit', чтобы продолжить 'cont': ");
                    switch (Console.ReadLine())
                    {
                        case "exit":
                            return;
                        case "cont":
                            continue;
                    }
                }
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListString();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var listTask = new Journal();
            listTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var listTask = new DoubleLinkList();
            listTask.TaskLoop();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
            if (!int.TryParse(Console.ReadLine(), out int task) || task < 1 || task > 3)
            {
                Console.WriteLine("Введено неверное значение");
            }

            switch (task)
            {
                case 1:
                    CheckTaskFirst();
                    break;
                case 2:
                    CheckTaskSecond();
                    break;
                case 3:
                    CheckTaskThird();
                    break;
            }
        }
    }
}
