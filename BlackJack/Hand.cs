namespace BlackJackGame
{
    /// <summary>Creates an empty hand for a player. Constructor (string name).</summary>
    public class Hand
    {
        private List<Card> _cards = new List<Card>();
        private int _value = 0;
        private int _aces = 0;
        private string _name;

        public Hand(string name)
        {
            _name = name;
        }

        public int Value
        {
            get { return _value; }
        }
        public string Name
        {
            get { return _name; }
        }

        /// <summary>Add a card from a deck to your hand and adjust for ace.</summary>
        public void Hit(Deck deck)
        {
            var card = deck.Deal();
            AddCards(card);
            AdjustForAce();
        }

        public void ShowOne()
        {
            System.Console.WriteLine($"{_name}'s second card is {_cards[1]}");
        }

        /// <summary>Show all cards in your hand.</summary>
        public void ShowAll()
        {
            foreach (Card card in _cards)
            {
                card.PrintCard();
            }
        }

        /// <summary>Add a card to the player's hand and update the hand value.</summary>
        private void AddCards(Card card)
        {
            _cards.Add(card);
            _value += card.Value;
            if (card.Rank == "Ace")
            {
                _aces += 1;
            }
        }

        private void AdjustForAce()
        {
            while (_value > 21 && _aces > 0)
            {
                _value -= 10;
                _aces -= 1;
            }
        }
    }
}
