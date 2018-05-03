using es.eit.Common.Infrastructure.Model;

namespace es.eit.Common.Model.Repositories
{
    public interface IGenericRepository_RO<T> : IGenericRepositoryBase<T>
        where T : class, IEntityBase
    { }
}
