namespace Lab
{
    class Program
    {
        static void Main()
        {
            string answer;
            int rating;

            GameAccount Player1 = new();
            Console.WriteLine("Input name of first player: ");
            Player1.UserName = Console.ReadLine();
            Player1.CurrentRating = 100;
            GameAccount Player2 = new();
            Console.WriteLine("Input name of second player: ");
            Player2.UserName = Console.ReadLine();
            Player2.CurrentRating = 100;

            Console.WriteLine("------------------------------------------------");
            Player1.OutPlayers();
            Player2.OutPlayers();

            do
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Input the rating you are playing for:");
                rating = int.Parse(Console.ReadLine());
                while (rating <= 0)
                {
                    Console.WriteLine("Rating can`t be less than 0");
                    rating = int.Parse(Console.ReadLine());
                }
                Game game = new();
                game.PlayGame(Player1, Player2, rating);

                Console.WriteLine("Play again? (Y/N)");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
            Console.WriteLine("------------------------------------------------");
            Player1.GetStats();
            Console.WriteLine("------------------------------------------------");
            Player1.OutPlayers();
            Player2.OutPlayers();
        }
    }

    class Game
    {
        public void PlayGame(GameAccount player1, GameAccount player2, int rating)
        {
            //Coin flip game
            Random random = new();
            string winner = player1.UserName;
            int gameIndex = player1.GamesCount;
            int coin = random.Next(1, 3);
            if (coin == 1)
            {
                winner = player1.UserName;
                Console.WriteLine("Player 1 win");
                player1.WinGame(rating, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine("Player 2 loose");
                player2.LoseGame(rating, player2.UserName, player1.UserName, winner, gameIndex);
            }
            if (coin == 2)
            {
                winner = player2.UserName;
                Console.WriteLine("Player 2 win");
                player2.WinGame(rating, player2.UserName, player1.UserName, winner, gameIndex);
                Console.WriteLine("Player 1 loose");
                player1.LoseGame(rating, player1.UserName, player2.UserName, winner, gameIndex);
            }
        }
    }

    class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        public void OutPlayers()
        {
            Console.WriteLine($"\nPlayer name: {UserName}\nRating: {CurrentRating} \nRounds payed: {GamesCount}\n");
        }
        public void WinGame(int rating, string player1, string player2, string winner, int gameIndex)
        {
            GamesCount++;
            CurrentRating += rating;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }
        public void LoseGame(int rating, string player1, string player2, string winner, int gameIndex)
        {
            GamesCount++;
            CurrentRating -= rating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }
        public void GetStats()
        {
            foreach (GameResult result in GameResults)
            {
                Console.WriteLine($"Player {result.Player} vs player {result.Opponent}, Player {result.Winner} win, Played for {result.Rating} rating, Game №{result.GameIndex}");
            }
        }
    }

    class GameResult
    {
        public string Player { get; }
        public string Opponent { get; }
        public string Winner { get; }
        public int Rating { get; }
        public int GameIndex { get; }

        public GameResult(string player, string opponent, string winner, int rating, int gameIndex)
        {
            Player = player;
            Opponent = opponent;
            Winner = winner;
            Rating = rating;
            GameIndex = gameIndex;
        }
    }
}