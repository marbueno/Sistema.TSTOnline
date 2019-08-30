using Sistema.TSTOnline.Domain.Interfaces;

namespace Sistema.TSTOnline.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _dbContext;

        public UnitOfWork(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}