namespace Lab2
{
    internal class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        public GameAccount(string userName)
        {
            UserName = userName;
            CurrentRating = 100;
            GamesCount = 0;
        }
        public void OutPlayers()
        {
            Console.WriteLine($"\nPlayer name: {UserName}\nRating: {CurrentRating} \nRounds payed: {GamesCount}\n");
        }
        public void WinGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating += rating;
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }
        public void LoseGame(Game game, string player1, string player2, string winner, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating -= rating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GamesCount++;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }
        public void GetStats()
        {
            foreach (GameResult result in GameResults)
            {
                Console.WriteLine($"Player {result.Player} vs player {result.Opponent}, Player {result.Winner} win, Played for {result.Rating} rating, Game №{result.GameIndex}");
            }
        }
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
    class StandartAccount : GameAccount
    {
        public StandartAccount(string userName) : base(userName) { }
        public override int RatingCalc(int rating)
        {
            return rating;
        }
    }
    class HalfAccount : GameAccount
    {
        public HalfAccount(string userName) : base(userName) { }
        public override int RatingCalc(int rating)
        {
            return rating/2;
        }
    }
    class x2Account : GameAccount
    {
        public x2Account(string userName) : base(userName) { }
        public override int RatingCalc(int rating)
        {
            return rating*2;
        }
    }
}
