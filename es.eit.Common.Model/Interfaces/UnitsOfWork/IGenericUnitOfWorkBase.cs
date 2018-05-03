using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Interfaces.Common;
using System;

namespace es.eit.Common.Model.UnitsOfWork
{
    public interface IGenericUnitOfWorkBase<T> : IGenericUnitOfWorkCUDOperations<T>, IDisposable
        where T : class, IEntityBase
    { }
}
