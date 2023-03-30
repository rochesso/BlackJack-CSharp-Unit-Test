namespace BlackJackGame
{
    /// <summary>Creates a deck of 52 cards. Constructor ().</summary>
    public class Deck
    {
        private static readonly string[] s_suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
        private static readonly string[] s_ranks =
        {
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine",
            "Ten",
            "Jack",
            "Queen",
            "King",
            "Ace"
        };
        private List<Card> _deck = new List<Card>();
        private List<Card> _shuffledDeck = new List<Card>();

        public Deck()
        {
            foreach (string Suit in s_suits)
            {
                foreach (string Rank in s_ranks)
                {
                    Card newCard = new Card(Suit, Rank);
                    _deck.Add(newCard);
                }
            }

            Shuffle();
        }

        public List<Card> ShuffledDeck
        {
            get { return _shuffledDeck; }
        }

        /// <summary>Remove a card from the shuffled deck and return it.</summary>
        public Card Deal()
        {
            var card = _shuffledDeck[0];
            _shuffledDeck.RemoveAt(0);
            return card;
        }

        /// <summary>Shuffle all cards from the deck and save on _shuffledDeck</summary>
        private void Shuffle()
        {
            var random = new Random();
            var newShuffledDeck = new List<Card>();
            var listCount = _deck.Count;
            for (int i = 0; i < listCount; i++)
            {
                var randomElementInList = random.Next(0, _deck.Count);
                newShuffledDeck.Add(_deck[randomElementInList]);
                _deck.Remove(_deck[randomElementInList]);
            }
            _shuffledDeck = newShuffledDeck;
        }
    }
}
