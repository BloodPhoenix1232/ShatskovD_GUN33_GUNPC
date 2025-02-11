using Final_Task.Games;
using Final_Task.Games.BlackJack;
using Final_Task.Games.Dice;
using Final_Task.SaveLoadSystem;

namespace Final_Task.GameLoop
{
    internal class Casino : IGame
    {
        private int _casinoBank = 0;
        private int _playerBank = 0;
        private int _playerBet = 0;
        private int _casinoBet = 0;

        private CasinoGameBase _currentGame;
        public Casino()
        {
            StartGame();
        }

        public void StartGame()
        {
            Console.WriteLine("Добро пожаловать!");

            var pathToPlayerProfile = "D:/Desktop/Лабараторные/Курс/Final Task/text.txt";
            var pathToCasinoProfile = "D:/Desktop/Лабараторные/Курс/Final Task/text1.txt";

            var playerInfo = new FileSystemSaveLoadService(pathToPlayerProfile);
            string[] lines = playerInfo.LoadData<string>(pathToPlayerProfile).Split();

            var casinoInfo = new FileSystemSaveLoadService(pathToPlayerProfile);
            if (int.TryParse(casinoInfo.LoadData<string>(pathToCasinoProfile), out _casinoBank))
            {
                Console.WriteLine($"Банк казино: {_casinoBank}");
            }

            if (int.TryParse(lines[1], out _playerBank))
            {
                Console.WriteLine($"Здравствуйте, {lines[0]}. Ваш банк: {_playerBank}");
            }

            MakeBet();

            Console.WriteLine("Выберете игру: (1) - BlackJack, (2) - Dice ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                throw new Exception("Введено некорректное значение.");
            }


            switch (choice)
            {
                case 1:
                    _currentGame = new Blackjack(36);
                    break;
                case 2:
                    (int count, int minValue, int maxValue) = MakeDiceParameters();
                    _currentGame = new DiceGame(count, minValue, maxValue);
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильное значение.");
                    return;
            }

            _currentGame.OnWin += () => RaiseBank(_casinoBet);
            _currentGame.OnLoose += () => LoseBank(_casinoBet);
            _currentGame.OnDraw += () => DrawBank();

            _currentGame.PlayGame();

            Console.WriteLine("Спасибо за игру, до свидания.");

            playerInfo.SaveData($"{lines[0]} {_playerBank}", pathToPlayerProfile);
            casinoInfo.SaveData($"{_casinoBank}", pathToCasinoProfile);
        }

        private void MakeBet()
        {
            if (_playerBank <= 0)
            {
                Console.WriteLine("Ваш баланс меньше 0.");
            }
            else
            {
                Console.WriteLine($"Банк казино: {_casinoBank}");
                Console.Write("Введите ставку: ");

                while (!int.TryParse(Console.ReadLine(), out _playerBet) || _playerBet <= 0 || _playerBet > _playerBank)
                {
                    Console.WriteLine("Введено неверное значение. Ставка должна быть > 0 и не превышать ваш банк.");
                    Console.Write("Введите ставку: ");
                }

                if (_casinoBank < _playerBet)
                {
                    _casinoBet = _casinoBank;
                }
                else
                {
                    _casinoBet = _playerBet;
                }

                Console.WriteLine($"Ваша ставка: {_playerBet}");
            }
        }

        private (int, int, int) MakeDiceParameters()
        {
            Console.Write("Введите количество многогранников: ");
            if (!int.TryParse(Console.ReadLine(), out int count))
            {
                Console.WriteLine("Введено некорректное значение.");
            }

            Console.Write("Введите минимальное значение грани: ");
            if (!int.TryParse(Console.ReadLine(), out int minValue))
            {
                throw new WrongDiceNumberException(minValue);
            }

            Console.Write("Введите максимальное значение грани: ");
            if (!int.TryParse(Console.ReadLine(), out int maxValue))
            {
                throw new WrongDiceNumberException(maxValue);
            }

            return (count, minValue, maxValue);
        }
        private void RaiseBank(int bet)
        {
            _playerBank += bet;
            _casinoBank -= bet;

            Console.WriteLine($"Поздравляем, ваш текущий банк: {_playerBank}");
            if (_casinoBank <= 0)
            {
                Console.WriteLine("Вы разорили казино и на его месте построят новое.");
            }
        }

        private void LoseBank(int bet)
        {
            _playerBank -= bet;
            _casinoBank += bet;

            Console.WriteLine($"Увы, ваш банк: {_playerBank}");
            if (_playerBank < 0)
            {
                Console.WriteLine("No money? Kicked.");
            }
        }

        private void DrawBank()
        {
            Console.WriteLine("Ничья!");
        }
    }
}
