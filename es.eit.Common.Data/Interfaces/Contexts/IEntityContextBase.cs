using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Context;
using System.Data.Entity;

namespace es.eit.Common.Data.Context
{
    public interface IEntityContextBase : IContextBase
    {
        IDbSet<T> Set<T>() where T : class, IEntityBase;
    }
}
