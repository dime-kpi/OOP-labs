using Lab3.DB.Service;

namespace Lab3
{
    abstract class Game
    {
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public int playRating { get; set; }
        public string winner { get; set; }
        public GameService _service { get; set; }
        public Game(GameAccount player1, GameAccount player2, GameService service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
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
                _service.Create(this);
                Console.WriteLine($"Player {player1.UserName} win");
                player1.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {player2.UserName} loose");
                player2.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
            if (coin == 2)
            {
                winner = player2.UserName;
                _service.Create(this);
                Console.WriteLine($"Player {player2.UserName} win");
                player2.WinGame(this, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine($"Player {player1.UserName} loose");
                player1.LoseGame(this, player1.UserName, player2.UserName, winner, gameIndex);
            }
        }
        public virtual int getPlayRating(GameAccount player) { return playRating; }
    }
}
