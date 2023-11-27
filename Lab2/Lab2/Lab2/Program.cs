namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        public void Run()
        {
            Console.WriteLine("Input first player name: ");
            string firstPlayer = Console.ReadLine();
            GameAccount player1 = AccountChose(firstPlayer);
            Console.WriteLine("Input second player name: ");
            string secondPlayer = Console.ReadLine();
            GameAccount player2 = AccountChose(secondPlayer);
            string answer;
            do
            { 
                Console.WriteLine("------------------------------------------------");
                Game game = GameType(player1, player2);
                game.PlayGame(player1, player2);
                player1.OutPlayers();
                player2.OutPlayers();
                Console.WriteLine("Play again? (Y/N)");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
            Console.WriteLine("------------------------------------------------");
            player1.OutPlayers();
            player2.OutPlayers();
            Console.WriteLine("------------------------------------------------");
            player1.GetStats();
        }

        private static GameAccount AccountChose(string userName)
        {
            Console.WriteLine("Choose account type: \n1.StandartAccount \n2.HalfAccount \n3.2xAccount");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    return new StandartAccount(userName);
                case 2:
                    return new HalfAccount(userName);
                case 3:
                    return new x2Account(userName);
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return AccountChose(userName);
            }
        }

        private static Game GameType(GameAccount player1, GameAccount player2)
        {
            Console.WriteLine("Choose game type: \n1.StandartGame \n2.UnrankedGame \n3.SafeGame");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateStandartGame(player1, player2);
                case 2:
                    return factory.CreateUnrankedGame(player1, player2);
                case 3:
                    return factory.CreateSafeGame(player1, player2);
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return GameType(player1, player2);
            }
        }
    }
}
