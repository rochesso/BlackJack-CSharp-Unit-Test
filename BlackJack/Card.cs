namespace BlackJackGame
{
    /// <summary>Creates a single card. Constructor (string suit, string rank).</summary>
    public class Card
    {
        private static readonly Dictionary<String, int> s_values = new Dictionary<string, int>()
        {
            { "Two", 2 },
            { "Three", 3 },
            { "Four", 4 },
            { "Five", 5 },
            { "Six", 6 },
            { "Seven", 7 },
            { "Eight", 8 },
            { "Nine", 9 },
            { "Ten", 10 },
            { "Jack", 10 },
            { "Queen", 10 },
            { "King", 10 },
            { "Ace", 11 }
        };
        private string _suit;
        private string _rank;
        private int _value;

        public Card(string suit, string rank)
        {
            _suit = suit;
            _rank = rank;
            _value = s_values[rank];
        }

        public int Value
        {
            get { return _value; }
        }
        public string Rank
        {
            get { return _rank; }
        }

        public void PrintCard()
        {
            System.Console.WriteLine($"{_rank} of {_suit} [{_value}]");
        }

        public override string ToString()
        {
            return _rank + " of " + _suit;
        }
    }
}
