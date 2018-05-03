using es.eit.Common.Infrastructure.Model;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.Common.Infrastructure.Mappers
{
    public abstract class ReadOnlyMapperBase<V, M> : IReadOnlyMapperBase<V, M>
        where V : class, IEntityBase
        where M : class
    {
        #region Implements interface IReadOnlyMapper<V, M>
        public abstract V ConvertToView( M source );

        public virtual IEnumerable<V> ConvertToView( IEnumerable<M> source )
        {
            if ( source == null )
                return null;

            return source.Select( p => ConvertToView( p ) );
        }
        #endregion Implements interface IReadOnlyMapper<V, M>

        #region Implements interface IMaintenaceMapper
        V IReadOnlyMapperBase<V, M>.ConvertToView( M source )
        {
            return this.ConvertToView( source );
        }

        IEnumerable<V> IReadOnlyMapperBase<V, M>.ConvertToView( IEnumerable<M> source )
        {
            return this.ConvertToView( source );
        }

        object IReadOnlyMapperBase.ConvertToView( object source )
        {
            return this.ConvertToView( ( M ) source );
        }

        IEnumerable<object> IReadOnlyMapperBase.ConvertToView( IEnumerable<object> source )
        {
            return ( IEnumerable<object> ) this.ConvertToView( source.Cast<M>() );
        }
        #endregion Implements interface IMaintenaceMapper
    }

    public abstract class ReadWriteMapperBase<V, M> : ReadOnlyMapperBase<V, M>, IReadWriteMapperBase<V, M>
        where V : class, IEntityBase
        where M : class
    {
        #region Implements interface IMapper<V, M>

        public abstract M ConvertToModel( V source );

        public virtual IEnumerable<M> ConvertToModel( IEnumerable<V> source )
        {
            if ( source == null )
                return null;

            return source.Select( p => ConvertToModel( p ) );
        }
        #endregion Implements interface IMapper<V, M>

        #region Implements interface IMaintenaceMapper
        M IReadWriteMapperBase<V, M>.ConvertToModel( V source )
        {
            return this.ConvertToModel( source );
        }

        IEnumerable<M> IReadWriteMapperBase<V, M>.ConvertToModel( IEnumerable<V> source )
        {
            return this.ConvertToModel( source );
        }

        object IReadWriteMapperBase.ConvertToModel( object source )
        {
            return this.ConvertToModel( ( V ) source );
        }

        IEnumerable<object> IReadWriteMapperBase.ConvertToModel( IEnumerable<object> source )
        {
            return ( IEnumerable<object> ) this.ConvertToModel( source.Cast<V>() );
        }
        #endregion Implements interface IMaintenaceMapper
    }
}
