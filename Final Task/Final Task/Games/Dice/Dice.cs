namespace Final_Task.Games.Dice
{
    public class Dice
    {
        private readonly Random _random = new();
        public int Number
        {
            get { return _random.Next(_min, _max); }
        }

        private int _min;
        private int _max;

        public Dice(int min, int max)
        {
            try
            {
                if (min < 1 || min > int.MaxValue)
                {
                    throw new WrongDiceNumberException(min);
                }

                _min = min;
            }
            catch (WrongDiceNumberException ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }


            try
            {
                if (max < 1 || max > int.MaxValue)
                {
                    throw new WrongDiceNumberException(max);
                }

                _max = max;
            }
            catch (WrongDiceNumberException ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
