namespace BlackJackGame
{
    class Game
    {
        private Boolean _playing = true;
        private Deck _deck = new Deck();
        private Hand _player;
        private Hand _dealer;

        public Game(string player, string dealer)
        {
            _player = new Hand(player);
            _dealer = new Hand(dealer);
        }

        public Hand Player
        {
            get { return _player; }
        }
        public Hand Dealer
        {
            get { return _dealer; }
        }
        public Deck Deck
        {
            get { return _deck; }
        }
        public Boolean Playing
        {
            get { return _playing; }
        }

        public void HitOrStand(Hand hand)
        {
            while (true)
            {
                string input = "";
                while (input == "")
                {
                    Console.WriteLine("Hit or Stand? h/s:");
                    input = (Console.ReadLine() ?? string.Empty).ToLower();
                }
                if (input[0] == Convert.ToChar("h"))
                {
                    hand.Hit(_deck);
                }
                else if (input[0] == Convert.ToChar("s"))
                {
                    _playing = false;
                }
                else
                {
                    Console.WriteLine("Sorry, I did not understand! Enter h or s only!");
                    continue;
                }
                break;
            }
        }

        public void ShowSome()
        {
            Console.WriteLine($"{_dealer.Name} Hand:");
            _dealer.ShowOne();
            Console.WriteLine("");
            Console.WriteLine($"{_player.Name} Hand:");
            _player.ShowAll();
            Console.WriteLine("--------------");
        }

        public void ShowAll()
        {
            Console.WriteLine($"{_dealer.Name} Hand:");
            _dealer.ShowAll();
            Console.WriteLine("");
            Console.WriteLine($"{_player.Name} Hand:");
            _player.ShowAll();
            Console.WriteLine("--------------");
        }

        public void Push()
        {
            Console.WriteLine($"{_player.Name} and {_dealer.Name} tie! Push!");
        }
    }
}
