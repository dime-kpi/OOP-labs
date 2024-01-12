using KR.DB.Entity;

namespace KR.DB
{
    internal class DbContext
    {
        public List<GameEntity> Games { get; set; }
        public List<AccountEntity> Accounts { get; set; }

        public DbContext()
        {
            Games = new List<GameEntity>();
            Accounts = new List<AccountEntity>();
        }
    }
}
