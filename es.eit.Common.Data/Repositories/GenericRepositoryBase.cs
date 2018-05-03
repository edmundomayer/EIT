using es.eit.Common.Data.Helpers;
using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace es.eit.Common.Data.Repositories
{
    public abstract class GenericRepositoryBase<T> : IGenericRepositoryBase<T>
        where T : class, IEntityBase
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        #region Internal
        protected bool _disposed = false;
        #endregion Internal

        #region Constructors & Destructors
        public GenericRepositoryBase()
        { }
        #endregion Constructors & Destructors

        #region Properties
        #endregion Properties

        #region Methods
        protected virtual IQueryable<T> GetQueryable( IQueryable<T> sourceQuery,
                                                        Expression<Func<T, bool>> filter = null,
                                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                        int? skip = null,
                                                        int? take = null,
                                                        params Expression<Func<T, object>>[] navigationProperties )
        {
            return this.GetQueryable<T>( sourceQuery: sourceQuery,
                                            filter: filter,
                                            orderBy: orderBy,
                                            skip: skip,
                                            take: take,
                                            navigationProperties: navigationProperties );
        }

        protected virtual IQueryable<TEntity> GetQueryable<TEntity>( IQueryable<TEntity> sourceQuery,
                                                                        Expression<Func<TEntity, bool>> filter = null,
                                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                        int? skip = null,
                                                                        int? take = null,
                                                                        params Expression<Func<TEntity, object>>[] navigationProperties )
            where TEntity : class, IEntityBase
        {
            if ( sourceQuery == null )
                throw new ArgumentException( "sourceQuery can't be null" );

            IQueryable<TEntity> query = sourceQuery;

            foreach ( Expression<Func<TEntity, object>> navigationProperty in navigationProperties )
                query = query.Include<TEntity, object>( navigationProperty );

            if ( filter != null )
            {
                query = query.Where( filter );
            }

            if ( orderBy != null )
            {
                query = orderBy( query );
            }

            if ( skip.HasValue )
            {
                query = query.Skip( skip.Value );
            }

            if ( take.HasValue )
            {
                query = query.Take( take.Value );
            }

            this.RepositoryLog( query.ToString() );

            return query;
        }

        protected virtual void RepositoryLog( string logMessage )
        {
            log.Debug( string.Format( "{0}", logMessage ) );
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( !this._disposed )
            {
                if ( disposing )
                {
                    // actions to do...
                }
            }

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
        #endregion Methods

        #region Events
        #endregion Events


        #region Implements interface IGenericRepositoryBase<T>
        public abstract IQueryable<T> GetAll( Expression<Func<T, bool>> filter = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                int? skip = null,
                                                int? take = null,
                                                params Expression<Func<T, object>>[] navigationProperties );
        public abstract Task<IEnumerable<T>> GetAllAsync( Expression<Func<T, bool>> filter = null,
                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                            int? skip = null,
                                                            int? take = null,
                                                            params Expression<Func<T, object>>[] navigationProperties );

        public virtual T GetById( object id,
                                    params Expression<Func<T, object>>[] navigationProperties )
        {
            if ( id == null )
                throw new ArgumentException( string.Format( "Id parameter can't be null" ) );

            return GetAll( filter: ( p => p.Id == id ),
                            orderBy: null,
                            skip: null,
                            take: null,
                            navigationProperties: navigationProperties ).FirstOrDefault();
        }

        public virtual async Task<T> GetByIdAsync( object id,
                                                    params Expression<Func<T, object>>[] navigationProperties )
        {
            if ( id == null )
                throw new ArgumentException( string.Format( "Id parameter can't be null" ) );

            return await GetAll( filter: ( p => p.Id == id ),
                                    orderBy: null,
                                    skip: null,
                                    take: null,
                                    navigationProperties: navigationProperties ).FirstOrDefaultAsync();
        }


        IEnumerable<T> IGenericRepositoryBase<T>.GetAll( Expression<Func<T, bool>> filter,
                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                                                            int? skip,
                                                            int? take,
                                                            params Expression<Func<T, object>>[] navigationProperties )
        {
            return this.GetAll( filter: filter,
                                        orderBy: orderBy,
                                        skip: skip,
                                        take: take,
                                        navigationProperties: navigationProperties );
        }

        IEnumerable<IEntityBase> IGenericRepositoryBase.GetAll( Expression<Func<IEntityBase, bool>> filter,
                                                                Func<IQueryable<IEntityBase>, IOrderedQueryable<IEntityBase>> orderBy,
                                                                int? skip,
                                                                int? take,
                                                                params Expression<Func<IEntityBase, object>>[] navigationProperties )
        {
            Expression<Func<T, bool>> strongFilter = ( Expression<Func<T, bool>> ) new ReturnTypeVisitor<T, bool>().Visit( filter );
            Expression<Func<T, object>>[] strongNavigationProperties = ( navigationProperties == null ?
                                                                            null :
                                                                            navigationProperties.Select( np => ( Expression<Func<T, object>> ) new ReturnTypeVisitor<T, object>().Visit( np ) ).ToArray() );
            Func<IQueryable<T>, IOrderedQueryable<T>> strongOrderBy = null;

            if ( orderBy != null )
                strongOrderBy = ( t => ( orderBy == null ? null : ( IOrderedQueryable<T> ) orderBy( t ).Cast<T>() ) );


            return this.GetAll( filter: strongFilter,
                                        orderBy: strongOrderBy,
                                        skip: skip,
                                        take: take,
                                        navigationProperties: strongNavigationProperties );
        }

        IEntityBase IGenericRepositoryBase.GetById( object id,
                                                        params Expression<Func<IEntityBase, object>>[] navigationProperties )
        {
            Expression<Func<T, object>>[] strongNavigationProperties = ( navigationProperties == null ?
                                                                            null :
                                                                            navigationProperties.Select( np => ( Expression<Func<T, object>> ) new ReturnTypeVisitor<T, object>().Visit( np ) ).ToArray() );

            return this.GetById( id, strongNavigationProperties );
        }


        async Task<IEnumerable<IEntityBase>> IGenericRepositoryBase.GetAllAsync( Expression<Func<IEntityBase, bool>> filter, Func<IQueryable<IEntityBase>, IOrderedQueryable<IEntityBase>> orderBy, int? skip, int? take, params Expression<Func<IEntityBase, object>>[] navigationProperties )
        {
            Expression<Func<T, bool>> strongFilter = ( Expression<Func<T, bool>> ) new ReturnTypeVisitor<T, bool>().Visit( filter );
            Expression<Func<T, object>>[] strongNavigationProperties = ( navigationProperties == null ?
                                                                            null :
                                                                            navigationProperties.Select( np => ( Expression<Func<T, object>> ) new ReturnTypeVisitor<T, object>().Visit( np ) ).ToArray() );
            Func<IQueryable<T>, IOrderedQueryable<T>> strongOrderBy = null;

            if ( orderBy != null )
                strongOrderBy = ( t => ( orderBy == null ? null : ( IOrderedQueryable<T> ) orderBy( t ).Cast<T>() ) );

            return await GetAllAsync( filter: strongFilter,
                                        orderBy: strongOrderBy,
                                        skip: skip,
                                        take: take,
                                        navigationProperties: strongNavigationProperties );
        }

        async Task<IEntityBase> IGenericRepositoryBase.GetByIdAsync( object id, params Expression<Func<IEntityBase, object>>[] navigationProperties )
        {
            Expression<Func<T, object>>[] strongNavigationProperties = ( navigationProperties == null ?
                                                                            null :
                                                                            navigationProperties.Select( np => ( Expression<Func<T, object>> ) new ReturnTypeVisitor<T, object>().Visit( np ) ).ToArray() );

            return await this.GetByIdAsync( id, strongNavigationProperties );
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }
        #endregion Implements interface IGenericRepositoryBase<T>
    }
}