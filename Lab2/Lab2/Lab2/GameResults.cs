namespace Lab2
{
    internal class GameResult
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
