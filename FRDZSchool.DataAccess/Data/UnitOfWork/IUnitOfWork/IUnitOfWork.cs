using FRDZSchool.DataAccess.Data;

namespace FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationContext Context { get; set; }
        Task MigrateAsync();
        void SetNoTracking();
        void RestoreTracking();
        Task SaveAsync(CancellationToken token = default);
    }
}
