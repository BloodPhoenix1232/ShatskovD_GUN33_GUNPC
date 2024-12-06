using Microsoft.VisualBasic;
using System.Text;

namespace HomeWork7
{
    internal class Program
    {
        static string ConcatenateStrings(string str1, string str2)
        {
            return str1 + str2;
        }

        static string GreetUser(string name, int age)
        {
            return $"Hello, {name}!\nYou are {age} years old.";
        }

        static string StringInfo(string str)
        {
            return $"{str.Count()}\t{str.ToUpper()}\t{str.ToLower()}";
        }

        static string FirstFiveSymbols(string str)
        {
            return str.Substring(0, 5);
        }

        static string ConcatenateAllStrings(string[] str)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                builder.Append(str[i]);
                builder.Append(' ');
            }
            return builder.ToString();
        }

        static string ReplaceWords(string str, string word1, string word2)
        {
            return str.Replace(word1, word2);
        }

        static void Main(string[] args)
        {
            string[] str = { "Hello", "world" };

            Console.WriteLine(ConcatenateStrings("My name is", " Dima")); //Задание 1
            Console.WriteLine(GreetUser("Дмитрий", 21)); //Задание 2
            Console.WriteLine(StringInfo("My String")); //Задание 3
            Console.WriteLine(FirstFiveSymbols("123456789")); //Задание 4
            Console.WriteLine(ConcatenateAllStrings(str)); //Задание 5
            Console.WriteLine(ReplaceWords("Hello, world", "world", "Dima")); //Задание 6
        }
    }
}
