using es.eit.Common.Infrastructure.Model;
using System;
using System.Collections.Generic;

namespace es.eit.Common.Model.Common
{
    public interface IGenericCUDOperations<T>
        where T : class, IEntityBase
    {
        void Add( T item );
        void Add( IEnumerable<T> items );

        void Update( T item );
        void Update( IEnumerable<T> items );

        void Remove( T item );
        void Remove( IEnumerable<T> items );
    }
}
