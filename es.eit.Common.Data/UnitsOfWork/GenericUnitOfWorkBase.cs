using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace es.eit.Common.Data.UnitsOfWork
{
    public abstract class GenericUnitOfWorkBase<C, T> : IGenericUnitOfWork<C, T>
        where C : IContextBase
        where T : class, IEntityBase
    {
        #region Internal
        private bool disposed = false;
        protected C _context;
        #endregion Internal

        #region Constructors & Destructors
        public GenericUnitOfWorkBase( C context )
        {
            this._context = context;
        }
        #endregion Constructors & Destructors

        #region Properties
        #endregion Properties

        #region Methods
        [Obsolete( "Este método no está disponible en esta versión. Utilice 'AddAndSave( T item )' o 'int AddAndSave( IEnumerable<T> items )' en sus versiones síncronas o asíncronas.", true )]
        public abstract void Add( params T[] items );

        [Obsolete( "Este método no está disponible en esta versión. Utilice 'UpdateAndSave( T item )' o 'int UpdateAndSave( IEnumerable<T> items )' en sus versiones síncronas o asíncronas.", true )]
        public abstract void Update( params T[] items );

        [Obsolete( "Este método no está disponible en esta versión. Utilice 'RemoveAndSave( T item )' o 'int RemoveAndSave( IEnumerable<T> items )' en sus versiones síncronas o asíncronas.", true )]
        public abstract void Remove( params T[] items );

        public virtual int AddAndSave( T item )
        {
            return this.AddAndSave( new List<T> { item } );
        }

        public abstract int AddAndSave( IEnumerable<T> items );


        public virtual int UpdateAndSave( T item )
        {
            return this.UpdateAndSave( new List<T> { item } );
        }

        public abstract int UpdateAndSave( IEnumerable<T> items );

        public virtual int RemoveAndSave( T item )
        {
            return this.RemoveAndSave( new List<T> { item } );
        }

        public abstract int RemoveAndSave( IEnumerable<T> items );

        public virtual Task<int> AddAndSaveAsync( T item )
        {
            return this.AddAndSaveAsync( new List<T> { item } );
        }

        public abstract Task<int> AddAndSaveAsync( IEnumerable<T> items );

        public virtual Task<int> UpdateAndSaveAsync( T item )
        {
            return this.UpdateAndSaveAsync( new List<T> { item } );
        }

        public abstract Task<int> UpdateAndSaveAsync( IEnumerable<T> items );

        public virtual Task<int> RemoveAndSaveAsync( T item )
        {
            return this.RemoveAndSaveAsync( new List<T> { item } );
        }

        public abstract Task<int> RemoveAndSaveAsync( IEnumerable<T> items );

        protected virtual void Dispose( bool disposing )
        {
            if ( !this.disposed )
            {
                if ( disposing )
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
        #endregion Methods

        #region Events
        #endregion Events


        #region Implements interface IGenericUnitOfWork<C, T>
        #endregion Implements interface IGenericUnitOfWork<C, T>
    }
}
