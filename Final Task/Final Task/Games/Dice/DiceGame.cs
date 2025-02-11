namespace Final_Task.Games.Dice
{
    internal class DiceGame : CasinoGameBase
    {
        private int _minValue;
        private int _maxValue;
        private int _countOfDice;

        private int _playerScore = 0;
        private int _computerScore = 0;

        public DiceGame(int countOfDice, int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _countOfDice = countOfDice;
            FactoryMethod();
        }

        private List<Dice> DiceList = new List<Dice>();

        public override void PlayGame()
        {
            CheckResult(GetScore(_playerScore), GetScore(_computerScore));
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _countOfDice; i++)
            {
                DiceList.Add(new Dice(_minValue, _maxValue));
            }
        }

        private int GetScore(int playerScore)
        {
            for (int i = 0; i < DiceList.Count; i++)
            {
                var dice = DiceList[i];
                playerScore += dice.Number;
            }

            return playerScore;
        }

        private void CheckResult(int playerScore, int computerScore)
        {
            Console.WriteLine($"Ваш результат: {playerScore}");
            Console.WriteLine($"Результат компьютера: {computerScore}");
            switch (playerScore.CompareTo(computerScore))
            {
                case 1:
                    OnWinInvoke();
                    break;
                case -1:
                    OnLooseInvoke();
                    break;
                case 0:
                    OnDrawInvoke();
                    break;
            }
        }
    }
}
