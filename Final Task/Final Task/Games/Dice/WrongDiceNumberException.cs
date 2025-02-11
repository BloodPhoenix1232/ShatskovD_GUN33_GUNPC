namespace Final_Task.Games.Dice
{
    class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int number)
        {
            Console.WriteLine($"Ваше значение {number} не принадлежит диапозону [1, {int.MaxValue}]");
        }
    }
}
