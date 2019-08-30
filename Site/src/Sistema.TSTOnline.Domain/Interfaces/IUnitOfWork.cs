namespace Sistema.TSTOnline.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}