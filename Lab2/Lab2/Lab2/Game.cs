namespace Lab2
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }
        public Game(GameAccount player1, GameAccount player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public void PlayGame(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("Write rating: ");
            playRating = int.Parse(Console.ReadLine());
            while (playRating <= 0)
            {
                Console.WriteLine("Rating can`t be less than 0");
                playRating = int.Parse(Console.ReadLine());
            }
            Random random = new Random();
            int gameIndex = player1.GamesCount;
            int coin = random.Next(1, 3);
            if (coin == 1)
            {
                winner = player1.UserName;
                Console.WriteLine($"Player {player1.UserName} win");
                player1.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {player2.UserName} loose");
                player2.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
            if (coin == 2)
            {
                winner = player2.UserName;
                Console.WriteLine($"Player {player2.UserName} win");
                player2.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {player1.UserName} loose");
                player1.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
        }
        public virtual int getPlayRating(GameAccount player) { return playRating; }
    }
    class StandartGame : Game
    {
        public StandartGame(GameAccount player1, GameAccount player2) : base(player1, player2) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName)
            { return playRating; }
            if (player.UserName == player2.UserName)
            { return playRating; }
            return 0;
        }
    }
    class UnrankedGame : Game
    {
        public UnrankedGame(GameAccount player1, GameAccount player2) : base(player1, player2) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName) { return 0; }
            if (player.UserName == player2.UserName) { return 0; }
            return 0;
        }
    }
    class SafeGame : Game
    {
        public SafeGame(GameAccount player1, GameAccount player2) : base(player1, player2) { }
        public override int getPlayRating(GameAccount player)
        {
            if (player.UserName == player1.UserName && player.UserName == winner) { return playRating; }
            else if (player.UserName == player1.UserName && player.UserName != winner) { return 0; }

            if (player.UserName == player2.UserName && player.UserName == winner) { return playRating; }
            else if (player.UserName == player2.UserName && player.UserName != winner) { return 0; }

            return 0;
        }
    }

    class GameFactory
    {
        public Game CreateStandartGame(GameAccount player1, GameAccount player2)
        {
            return new StandartGame(player1, player2);
        }
        public Game CreateUnrankedGame(GameAccount player1, GameAccount player2)
        {
            return new UnrankedGame(player1, player2);
        }
        public Game CreateSafeGame(GameAccount player1, GameAccount player2)
        {
            return new SafeGame(player1, player2);
        }
    }
}
