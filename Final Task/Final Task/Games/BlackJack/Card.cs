namespace Final_Task.Games.BlackJack
{
    public class Card
    {
        public NumberOfCard NumberOfCard { get; }
        public Suits SuitOfCard { get; }

        public Card(NumberOfCard numberOfCard, Suits suitOfCard)
        {
            NumberOfCard = numberOfCard;
            SuitOfCard = suitOfCard;
        }

        public override string ToString()
        {
            return $"{NumberOfCard} of {SuitOfCard}";
        }

        public int GetCardValue()
        {
            return NumberOfCard switch
            {
                NumberOfCard.Ace => 11,
                NumberOfCard.Jack => 10,
                NumberOfCard.Queen => 10,
                NumberOfCard.King => 10,
                NumberOfCard.Six => 6,
                NumberOfCard.Seven => 7,
                NumberOfCard.Eight => 8,
                NumberOfCard.Nine => 9,
                NumberOfCard.Ten => 10,
                _ => throw new ArgumentOutOfRangeException(nameof(NumberOfCard), "Неизвестное значение карты")
            };
        }
    }
}
