namespace BlackJackGame
{
    /// <summary>Used to keep track of a player's chips.</summary>
    class Chips
    {
        private int _total;
        private int _bet;

        public Chips(int total = 100)
        {
            _total = total;
            _bet = 0;
        }

        public int Bet
        {
            get { return _bet; }
            set { _bet = value; }
        }
        public int Total
        {
            get { return _total; }
        }

        /// <summary>Add the bet to the total.</summary>
        public void WinBet()
        {
            _total += _bet;
        }

        /// <summary>Subtract the bet from the total.</summary>
        public void LoseBet()
        {
            _total -= _bet;
        }

        /// <summary>Get the user input and set as bet.</summary>
        public void TakeBet()
        {
            while (true)
            {
                int bet;
                try
                {
                    Console.WriteLine("Enter your bet:");
                    bet = Convert.ToInt32(Console.ReadLine());
                    if (bet <= 0)
                    {
                        Console.WriteLine("Sorry, try a number greater than 0!");
                    }
                    else if (bet > _total)
                    {
                        Console.WriteLine(
                            $"Sorry, you do not have enough chips! You have: {_total}"
                        );
                    }
                    else
                    {
                        _bet = bet;
                        break;
                    }
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Sorry, please provide an integer");
                }
            }
        }
    }
}
