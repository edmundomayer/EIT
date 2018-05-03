using es.eit.Common.Data.Context;
using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace es.eit.Common.Data.Repositories.Entity
{
    public class GenericEntityRepository_RW<T> : GenericEntityRepository_RO<T>, IGenericRepository_RW<T>
        where T : class, IEntityBase
    {
        #region Internal
        #endregion Internal

        #region Constructors & Destructors
        public GenericEntityRepository_RW( IEntityContextBase context )
            : base( context )
        { }
        #endregion Constructors & Destructors

        #region Properties
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events


        #region Implements interface IGenericRepository_RW<T>
        public virtual void Add( T item )
        {
            if ( item == null )
                return;

            this.Add( new List<T> { item } );
        }

        public virtual void Add( IEnumerable<T> items )
        {
            if ( items == null )
                return;

            foreach ( var item in items )
            {
                // No Detached validation because item is new and must be added

                ( ( DbContext ) base._context ).Entry( item ).State = EntityState.Added;
            }
        }

        public virtual void Update( T item )
        {
            if ( item == null )
                return;

            this.Update( new List<T> { item } );
        }

        public virtual void Update( IEnumerable<T> items )
        {
            if ( items == null )
                return;

            foreach ( var item in items )
            {
                if ( ( ( DbContext ) base._context ).Entry( item ).State == EntityState.Detached )
                    base._context.Set<T>().Attach( item );

                ( ( DbContext ) base._context ).Entry( item ).State = EntityState.Modified;
            }
        }

        public virtual void Remove( T item )
        {
            if ( item == null )
                return;

            this.Remove( new List<T> { item } );
        }

        public virtual void Remove( IEnumerable<T> items )
        {
            if ( items == null )
                return;

            foreach ( var item in items )
            {
                if ( ( ( DbContext ) base._context ).Entry( item ).State == EntityState.Detached )
                    base._context.Set<T>().Attach( item );

                ( ( DbContext ) base._context ).Entry( item ).State = EntityState.Deleted;
            }
        }

        public virtual int SaveChanges()
        {
            int result = 0;

            using ( var currentContext = ( DbContext ) base._context )
            {
#if ( DEBUG )
                currentContext.Database.Log = Console.Write;
#endif
                try
                {
                    result = currentContext.SaveChanges();
                }
                catch ( Exception _error )
                {
                    log.Error( string.Format( "Exception catched on SaveChanges with messag:\n{0}", _error.Message ) );

                    throw _error;
                }
            }

            log.Debug( string.Format( "SaveChange returning value: {0}", result ) );

            return result;
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            int result = 0;

            using ( var currentContext = ( DbContext ) base._context )
            {
#if ( DEBUG )
                currentContext.Database.Log = Console.Write;
#endif
                try
                {
                    result = await currentContext.SaveChangesAsync();
                }
                catch ( AggregateException ae )
                {
                    ae.Handle( ( x ) =>
                    {
                        log.Error( string.Format( "{0} catched on SaveChangesAsync with messag:\n{1}", x.GetType().ToString(), x.Message ) );

                        return false; // Let anything else stop the application.
                    } );
                }
            }

            log.Debug( string.Format( "SaveChangeAsync returning value: {0}", result ) );

            return result;
        }
        #endregion Implements interface IGenericRepository_RW<T>
    }
}
