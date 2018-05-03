using es.eit.Common.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace es.eit.Common.Model.Repositories
{
    public interface IGenericRepositoryBase<T> : IGenericRepositoryBase
        where T : class, IEntityBase
    {
        IEnumerable<T> GetAll( Expression<Func<T, bool>> filter = null,
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                int? skip = null,
                                int? take = null,
                                params Expression<Func<T, object>>[] navigationProperties );
        T GetById( object id, params Expression<Func<T, object>>[] navigationProperties );


        Task<IEnumerable<T>> GetAllAsync( Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            int? skip = null,
                                            int? take = null,
                                            params Expression<Func<T, object>>[] navigationProperties );
        Task<T> GetByIdAsync( object id, params Expression<Func<T, object>>[] navigationProperties );
    }

    public interface IGenericRepositoryBase : IDisposable
    {
        IEnumerable<IEntityBase> GetAll( Expression<Func<IEntityBase, bool>> filter = null,
                                            Func<IQueryable<IEntityBase>, IOrderedQueryable<IEntityBase>> orderBy = null,
                                            int? skip = null,
                                            int? take = null,
                                            params Expression<Func<IEntityBase, object>>[] navigationProperties );
        IEntityBase GetById( object id, params Expression<Func<IEntityBase, object>>[] navigationProperties );


        Task<IEnumerable<IEntityBase>> GetAllAsync( Expression<Func<IEntityBase, bool>> filter = null,
                                                        Func<IQueryable<IEntityBase>, IOrderedQueryable<IEntityBase>> orderBy = null,
                                                        int? skip = null,
                                                        int? take = null,
                                                        params Expression<Func<IEntityBase, object>>[] navigationProperties );
        Task<IEntityBase> GetByIdAsync( object id, params Expression<Func<IEntityBase, object>>[] navigationProperties );
    }
}
