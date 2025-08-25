using TrendyolSln.Application.Interfaces.Repositories;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Persistence.Context;
using TrendyolSln.Persistence.Repositories;

namespace TrendyolSln.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()=> await dbContext.DisposeAsync();

        public int Save()=>dbContext.SaveChanges();

        public async Task<int> saveAsync()=>await dbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=>new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=>new WriteRepository<T>(dbContext);
    }
}
