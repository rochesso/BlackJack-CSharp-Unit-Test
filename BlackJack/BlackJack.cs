namespace BlackJackGame
{
    static class BlackJack
    {
        private static Chips s_playerChips = new Chips();
        private static Chips s_dealerChips = new Chips();

        public static void Main()
        {
            Game game;
            while (true)
            {
                game = new Game("Arthur", "Dealer");

                CurrentGame(game);

                game.Player.Hit(game.Deck);
                game.Player.Hit(game.Deck);

                game.Dealer.Hit(game.Deck);
                game.Dealer.Hit(game.Deck);

                if ((s_dealerChips.Total <= 0) || (s_playerChips.Total <= 0))
                {
                    if (s_playerChips.Total <= 0)
                    {
                        Console.WriteLine($"{game.Player.Name} do not have more chips to play!");
                    }
                    else
                    {
                        Console.WriteLine($"{game.Dealer.Name} do not have more chips to play!");
                    }
                    break;
                }
                Console.WriteLine($"");
                while (true)
                {
                    if ((s_playerChips.Total > 0) && (s_dealerChips.Total > 0))
                    {
                        s_playerChips.TakeBet();
                        if (s_playerChips.Bet > s_dealerChips.Total)
                        {
                            Console.WriteLine($"{game.Dealer.Name} only has {s_dealerChips.Total}");
                            continue;
                        }
                        else
                        {
                            s_dealerChips.Bet = s_playerChips.Bet;
                            CurrentGame(game);
                            game.ShowSome();
                            break;
                        }
                    }
                }
                Console.WriteLine($"");
                while (game.Playing)
                {
                    game.HitOrStand(game.Player);
                    CurrentGame(game);
                    game.ShowSome();
                    if (game.Player.Value > 21)
                    {
                        CurrentGame(game);
                        game.ShowAll();
                        Console.WriteLine($"{game.Dealer.Name} wins!");
                        s_dealerChips.WinBet();
                        s_playerChips.LoseBet();
                        break;
                    }
                }
                if (game.Player.Value <= 21)
                {
                    while (game.Dealer.Value < game.Player.Value)
                    {
                        game.Dealer.Hit(game.Deck);
                    }
                    CurrentGame(game);
                    game.ShowAll();
                    if (game.Dealer.Value > 21)
                    {
                        Console.WriteLine($"{game.Player.Name} wins!");
                        s_playerChips.WinBet();
                        s_dealerChips.LoseBet();
                    }
                    else if (game.Dealer.Value > game.Player.Value)
                    {
                        Console.WriteLine($"{game.Dealer.Name} wins!");
                        s_dealerChips.WinBet();
                        s_playerChips.LoseBet();
                    }
                    else
                    {
                        game.Push();
                    }
                }
                Console.WriteLine("----------------");
                Console.WriteLine($"{game.Dealer.Name} total: {s_dealerChips.Total}");
                Console.WriteLine($"{game.Player.Name} total: {s_playerChips.Total}");

                string newGame = "";
                while (newGame == "")
                {
                    Console.WriteLine("Would you like to play again? y/n: ");
                    newGame = (Console.ReadLine() ?? string.Empty).ToLower();
                }
                if (newGame[0] == Convert.ToChar("y"))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
            }
            Console.WriteLine("----------------");
            Console.WriteLine($"{game.Dealer.Name} total: {s_dealerChips.Total}");
            Console.WriteLine($"{game.Player.Name} total: {s_playerChips.Total}");
        }

        /// <summary>Shows the current game information.</summary>
        private static void CurrentGame(Game game)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Welcome to BLACKJACK");
            Console.WriteLine("----------------");
            Console.WriteLine($"{game.Player.Name} vs {game.Dealer.Name}");
            Console.WriteLine("----------------");
            Console.WriteLine($"Dealer total: {s_dealerChips.Total}");
            Console.WriteLine($"Player total: {s_playerChips.Total}");
            Console.WriteLine("----------------");
        }
    }
}
