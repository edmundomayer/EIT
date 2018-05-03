using es.eit.Common.Data.Context;
using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace es.eit.Common.Data.Repositories.Entity
{
    public class GenericEntityRepository_RO<T> : GenericRepositoryBase<T>, IGenericRepository_RO<T>
        where T : class, IEntityBase
    {
        #region Internal
        protected IEntityContextBase _context;
        protected IDbSet<T> _dbset;

        #endregion Internal

        #region Constructors & Destructors
        /// <summary>
        /// Entity Constructor
        /// </summary>
        /// <param name="context"></param>
        public GenericEntityRepository_RO( IEntityContextBase context )
        {
            this._context = context;
            this._dbset = this._context.Set<T>();
        }
        #endregion Constructors & Destructors

        #region Properties
        protected virtual IEntityContextBase Context
        {
            get { return this._context; }
        }
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events

        #region Implements Abstract Class GenericRepositoryBase<T>
        public override IQueryable<T> GetAll( Expression<Func<T, bool>> filter = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                int? skip = default( int? ),
                                                int? take = default( int? ),
                                                params Expression<Func<T, object>>[] navigationProperties )
        {
#if(DEBUG)
            ( ( DbContext ) this._context ).Database.Log = Console.Write;
#endif
            return base.GetQueryable( this._context.Set<T>(),
                                        filter,
                                        orderBy,
                                        skip,
                                        take,
                                        navigationProperties );
        }
        public override async Task<IEnumerable<T>> GetAllAsync( Expression<Func<T, bool>> filter = null,
                                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                int? skip = default( int? ),
                                                                int? take = default( int? ),
                                                                params Expression<Func<T, object>>[] navigationProperties )
        {
#if(DEBUG)
            ( ( DbContext ) this._context ).Database.Log = Console.Write;
#endif
            return await this.GetAll( filter,
                                        orderBy,
                                        skip,
                                        take,
                                        navigationProperties ).ToListAsync();
        }
        #endregion Implements Abstract Class GenericRepositoryBase<T>

        #region Implements Interface IGenericRepository_RO<T>
        #endregion Implements Interface IGenericRepository_RO<T>
    }
}
