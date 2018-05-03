using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Common;
using System.Threading.Tasks;

namespace es.eit.Common.Model.Repositories
{
    public interface IGenericRepository_RW<T> : IGenericRepository_RO<T>, IGenericCUDOperations<T>
        where T : class, IEntityBase
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}