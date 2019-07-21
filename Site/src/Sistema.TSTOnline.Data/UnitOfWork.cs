using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Data
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
    }
}