using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace FRDZSchool.DataAccess.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext Context { get; set; }

        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }

        public async Task MigrateAsync()
        {
            if ((await Context.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                await Context.Database.MigrateAsync();
            }
        }

        public async Task SaveAsync(CancellationToken token = default)
        {
            await Context.SaveChangesAsync(token);
        }

        public void SetNoTracking()
        {
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void RestoreTracking()
        {
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
