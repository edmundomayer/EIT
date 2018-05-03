using es.eit.Common.Infrastructure.Model;
using System.Collections.Generic;

namespace es.eit.Common.Infrastructure.Mappers
{
    public interface IReadOnlyMapperBase<V, M> : IReadOnlyMapperBase
        where V : class, IEntityBase
        where M : class
    {
        V ConvertToView( M source );
        IEnumerable<V> ConvertToView( IEnumerable<M> source );
    }

    public interface IReadOnlyMapperBase
    {
        object ConvertToView( object source );
        IEnumerable<object> ConvertToView( IEnumerable<object> source );
    }



    public interface IReadWriteMapperBase<V, M> : IReadWriteMapperBase, IReadOnlyMapperBase<V, M>
        where V : class, IEntityBase
        where M : class
    {
        M ConvertToModel( V source );
        IEnumerable<M> ConvertToModel( IEnumerable<V> source );
    }

    public interface IReadWriteMapperBase : IReadOnlyMapperBase
    {
        object ConvertToModel( object source );
        IEnumerable<object> ConvertToModel( IEnumerable<object> source );
    }
}
