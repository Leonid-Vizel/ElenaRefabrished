namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationContext Context { get; set; }
        Task SaveAsync(CancellationToken token = default);
    }
}
