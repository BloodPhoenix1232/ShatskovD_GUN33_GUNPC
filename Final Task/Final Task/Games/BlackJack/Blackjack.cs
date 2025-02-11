namespace Final_Task.Games.BlackJack
{
    internal class Blackjack : CasinoGameBase
    {
        public Blackjack(int cardCounter)
        {
            CheckParameter(cardCounter);

            _deckList = new List<Card>();
            _deck = new Queue<Card>();
            FactoryMethod();

            for (int j = 0; j < cardCounter; j++)
            {
                Shuffle();
            }
        }

        private Queue<Card> _deck;
        private List<Card> _deckList { get; }

        private readonly Random _random = new();

        private List<Card> _playerCards = new List<Card>();
        private List<Card> _computerCards = new List<Card>();

        private void CheckParameter(int value)
        {
            if(value <= 0)
            {
                throw new ArgumentException("Значение карт некорректно.");
            }
        }

        private void Shuffle()
        {
            int i = _random.Next(0, _deckList.Count - 1);
            _deck.Enqueue(_deckList[i]);
            _deckList.Remove(_deckList[i]);
        }
        public override void PlayGame()
        {

            _playerCards.Add(_deck.Dequeue());
            _playerCards.Add(_deck.Dequeue());

            _computerCards.Add(_deck.Dequeue());
            _computerCards.Add(_deck.Dequeue());

            Console.Write("Ваши карты: ||");
            ShowHand(_playerCards);
            Console.WriteLine($"\nВаши очки: {GetScore(_playerCards)}");

            Console.Write("\nКарты компьютера: ||");
            ShowHand(_computerCards);
            Console.WriteLine($"\nОчки компьютера: {GetScore(_computerCards)}");

            CheckResult(GetScore(_playerCards), GetScore(_computerCards));
        }

        private void CheckResult(int player1, int player2)
        {
            if (BustCheck(player1) && BustCheck(player2))
            {
                OnDrawInvoke();
            }
            else if (BustCheck(player1) && !BustCheck(player2))
            {
                OnLooseInvoke();
            }
            else if (!BustCheck(player1) && BustCheck(player2))
            {
                OnWinInvoke();
            }
            else
            {
                switch (player1.CompareTo(player2))
                {
                    case 1:
                        OnWinInvoke();
                        break;
                    case -1:
                        OnLooseInvoke();
                        break;
                    case 0:
                        if (_playerCards.Count < 3)
                        {
                            Console.WriteLine("\nЕщё по одной карте");
                            _playerCards.Add(_deck.Dequeue());
                            _computerCards.Add(_deck.Dequeue());

                            Console.Write("\nВаши карты: ||");
                            ShowHand(_playerCards);
                            Console.WriteLine($"\nВаши очки: {GetScore(_playerCards)}");

                            Console.Write("\nКарты компьютера: ||");
                            ShowHand(_computerCards);
                            Console.WriteLine($"\nОчки компьютера: {GetScore(_computerCards)}");

                            CheckResult(GetScore(_playerCards), GetScore(_computerCards));
                        }
                        else
                        {
                            OnDrawInvoke();
                        }
                        break;
                }
            }
        }

        private int GetScore(List<Card> cards)
        {
            int sum = 0;
            foreach (Card card in cards)
            {
                sum += card.GetCardValue();
            }
            return sum;
        }

        private void ShowHand(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.Write($"{card} ||");
            }
        }

        private bool BustCheck(int playerScore)
        {
            if (playerScore > 21) return true;
            else return false;
        }

        protected override void FactoryMethod()
        {
            foreach (Suits suit1 in Enum.GetValues(typeof(Suits)))
            {
                foreach (NumberOfCard numberOfCard1 in Enum.GetValues(typeof(NumberOfCard)))
                {
                    _deckList.Add(new Card(numberOfCard1, suit1));
                }
            }
        }

    }

}
