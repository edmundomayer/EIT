using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Context;
using System;
using System.Data.Common;
using System.Data.Entity;

namespace es.eit.Common.Data.UnitsOfWork.Entity
{
    public abstract class GenericEntityUnitOfWorkBase<C, T> : GenericUnitOfWorkBase<C, T>
        where C : DbContext, IContextBase
        where T : class, IEntityBase
    {
        #region Internalas
        #endregion Internalas

        #region Constructors & Destructors
        public GenericEntityUnitOfWorkBase( C context )
            : base( context )
        { }
        #endregion Constructors & Destructors

        #region Properties
        #endregion Properties

        #region Methods
        protected int WrapIntoTransaction( Func<int> toDo )
        {
            DbTransaction transaction = null;

            return this.WrapIntoTransaction( toDo, ref transaction );
        }

        protected int WrapIntoTransaction( Func<int> toDo, ref DbTransaction transaction )
        {
            if ( transaction == null )
            {
                int result = 0;

                using ( var dbContextTransaction = ( ( DbContext ) this._context ).Database.BeginTransaction() )
                {
                    try
                    {
                        transaction = dbContextTransaction.UnderlyingTransaction;

                        result += toDo();

                        result += this._context.SaveChanges();
                    }
                    catch ( Exception _error )
                    {
                        dbContextTransaction.Rollback();
                        throw _error;
                    }

                    dbContextTransaction.Commit();
                }

                return result;
            }
            else
            {
                int result = 0;

                if ( ( ( DbContext ) this._context ).Database.CurrentTransaction == null )
                    ( ( DbContext ) this._context ).Database.UseTransaction( transaction );

                try
                {
                    result += toDo();

                    result += this._context.SaveChanges();
                }
                catch ( Exception _error )
                {
                    throw _error;
                }

                return result;
            }
        }
        #endregion Methods

        #region Events
        #endregion Events
    }
}

