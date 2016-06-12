namespace DomainModel.Helpers
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}