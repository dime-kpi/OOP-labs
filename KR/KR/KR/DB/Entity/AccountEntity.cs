﻿
namespace KR.DB.Entity
{
    internal class AccountEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResultEntity> GameResults { get; set; }
    }
}
