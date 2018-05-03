using es.eit.Common.Infrastructure.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace es.eit.Common.Model.Interfaces.Common
{
    public interface IGenericUnitOfWorkCUDOperations<T>
        where T : class, IEntityBase
    {
        int AddAndSave( T item );
        int AddAndSave( IEnumerable<T> items );

        int UpdateAndSave( T item );
        int UpdateAndSave( IEnumerable<T> items );

        int RemoveAndSave( T item );
        int RemoveAndSave( IEnumerable<T> items );


        Task<int> AddAndSaveAsync( T item );
        Task<int> AddAndSaveAsync( IEnumerable<T> items );

        Task<int> UpdateAndSaveAsync( T item );
        Task<int> UpdateAndSaveAsync( IEnumerable<T> items );

        Task<int> RemoveAndSaveAsync( T item );
        Task<int> RemoveAndSaveAsync( IEnumerable<T> items );
    }
}
