class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите первое число: ");
        if (!Int32.TryParse(Console.ReadLine(), out var value1))
        {
            Console.WriteLine("Not a number!");
            return;
        }
        Console.Write("Введите второе число: ");
        if (!Int32.TryParse(Console.ReadLine(), out var value2))
        {
            Console.WriteLine("Not a number!");
            return;
        }
        Console.Write("Введите операцию(&, |, ^): ");
        var s = Console.ReadLine();
        if(s.Length == 0 || s.Length > 1)
        {
            Console.WriteLine("Wrong sign");
            return;
        }

        switch(s[0])
        {
            case '&':
                Console.WriteLine("Result in 2  of {0} & {1} = {2}", value1, value2, Convert.ToString(value1 & value2, 2));
                Console.WriteLine("Result in 10 of {0} & {1} = {2}", value1, value2, Convert.ToString(value1 & value2, 10));
                Console.WriteLine("Result in 16 of {0} & {1} = {2}", value1, value2, Convert.ToString(value1 & value2, 16));
                break;
            case '|':
                Console.WriteLine("Result in 2 of {0} | {1} = {2}", value1, value2, Convert.ToString(value1 | value2, 2));
                Console.WriteLine("Result in 10 of {0} | {1} = {2}", value1, value2, Convert.ToString(value1 | value2, 10));
                Console.WriteLine("Result in 16 of {0} | {1} = {2}", value1, value2, Convert.ToString(value1 | value2, 16));
                break;
            case '^':
                Console.WriteLine("Result in 2 of {0} | {1} = {2}", value1, value2, Convert.ToString(value1 ^ value2, 2));
                Console.WriteLine("Result in 10 of {0} | {1} = {2}", value1, value2, Convert.ToString(value1 ^ value2, 10));
                Console.WriteLine("Result in 16 of {0} | {1} = {2}", value1, value2, Convert.ToString(value1 ^ value2, 16));
                break;
            default:
                Console.WriteLine("Wrong sign");
                break;
        }
    }
}