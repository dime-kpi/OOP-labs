using KR.DB.Entity;
using KR.DB.Repository.Base;

namespace KR.DB.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        DbContext dbContext;
        public AccountRepository(DbContext context)
        {
            dbContext = context;
        }

        public void Create(AccountEntity entity)
        {
            dbContext.Accounts.Add(entity);
        }

        public List<AccountEntity> ReadAll()
        {
            return dbContext.Accounts;
        }

        public AccountEntity ReadById(int id)
        {
            return dbContext.Accounts[id];
        }
        public void Update(AccountEntity entity)
        {
            dbContext.Accounts.RemoveAt(entity.Id);
            dbContext.Accounts.Insert(entity.Id, entity);
        }

        public void Delete(AccountEntity entity)
        {
            dbContext.Accounts.RemoveAt(entity.Id);
            int NewId = 1;
            foreach (var gameAccount in dbContext.Accounts)
            {
                dbContext.Accounts[NewId].Id = NewId;
                NewId++;
            }
        }

        public List<GameResultEntity> GameResults(AccountEntity entity)
        {
            return entity.GameResults;
        }

        public void AddGameResult(GameResultEntity gameResult, AccountEntity entity)
        {
            dbContext.Accounts[entity.Id].GameResults.Add(gameResult);
        }
    }
}
