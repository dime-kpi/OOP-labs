using KR.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    internal class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();
        public AccountService _service { get; set; }

        public Account(AccountService service, int ID, string userName, string password, int gamesCount = 0)
        {
            _service = service;
            UserName = userName;
            Password = password;
            CurrentRating = 100;
            GamesCount = gamesCount;
            Id = ID;
        }
        public void OutPlayers()
        {
            Console.WriteLine($"\nPlayer name: {UserName}\nRating: {CurrentRating} \nRounds payed: {GamesCount}\n");
        }
        public void WinGame(Game game, string player, string isWin, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating += rating;
            GamesCount++;
            GameResults.Add(new GameResult(player, isWin, rating, gameIndex));
            _service.Update(this);
        }
        public void LoseGame(Game game, string player, string isWin, int gameIndex)
        {
            int rating = RatingCalc(game.getPlayRating(this));
            CurrentRating -= rating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GamesCount++;
            GameResults.Add(new GameResult(player, isWin, rating, gameIndex));
            _service.Update(this);
        }
        public virtual int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
