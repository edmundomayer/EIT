using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Context;
using es.eit.Common.Model.UnitsOfWork;

namespace es.eit.Common.Data.UnitsOfWork
{
    public interface IGenericUnitOfWork<C, T> : IGenericUnitOfWorkBase<T>
        where C : IContextBase
        where T : class, IEntityBase
    { }
}
