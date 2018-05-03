//using es.docout.Common.Data.UnitsOfWork.Entity;
//using es.docout.Mosaico.Data.Oracle.Implementations.Contexts;
//using es.docout.Mosaico.Data.Oracle.Implementations.Repositories;
//using es.docout.Mosaico.Data.Oracle.Interfaces.Contexts;
//using es.docout.Mosaico.Model.Entities;
//using es.docout.Mosaico.Model.Repositories;
//using es.docout.Mosaico.Model.UnitsOfWork;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.Entity;
//using System.Threading.Tasks;

//namespace es.docout.Mosaico.Data.Oracle.Implementations.UnitsOfWork
//{
//    public class Simple_MapedDocument_ENTITY_UnitOfWork : GenericEntityUnitOfWorkBase<EIT_Context, MappedDocument>, ISimple_MapedDocument_UnitOfWork
//    {
//        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

//        #region Internals
//        private DbContextTransaction _mosaicoContextTransaction;

//        private IEIT_Context _mosaicoContext;

//        private IMappedDocument_Repository _mappedDocument_Repository;
//        private IStateHistoric_Repository _stateHistoric_Repository;
//        #endregion Internals

//        #region Constructors & Destructors
//        public Simple_MapedDocument_ENTITY_UnitOfWork()
//            : this( new EIT_Context() )
//        { }

//        public Simple_MapedDocument_ENTITY_UnitOfWork( IEIT_Context mosaicoContext )
//            : base( ( EIT_Context ) mosaicoContext )
//        {
//            this._mosaicoContext = mosaicoContext;

//            this._mappedDocument_Repository = new MappedDocument_ENTITY_Repository( this._mosaicoContext );
//            this._stateHistoric_Repository = new StateHistoric_ENTITY_Repository( this._mosaicoContext );
//        }
//        #endregion Constructors & Destructors

//        #region Properties
//        public IEIT_Context EIT_Context { get { return this._mosaicoContext; } }

//        public IMappedDocument_Repository MappedDocument_Repository { get { return this._mappedDocument_Repository; } }
//        public IStateHistoric_Repository StateHistoric_Repository { get { return this._stateHistoric_Repository; } }
//        #endregion Properties

//        #region Methods
//        #endregion Methods

//        #region Events
//        #endregion Events

//        #region Implements abstract class GenericEntityUnitOfWorkBase<EIT_Context, MappedDocument>
//        public override void Add( params MappedDocument[] items )
//        {
//            throw new NotImplementedException();
//        }

//        public override void Update( params MappedDocument[] items )
//        {
//            throw new NotImplementedException();
//        }

//        public override void Remove( params MappedDocument[] items )
//        {
//            throw new NotImplementedException();
//        }

//        public override int AddAndSave( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }

//        public override int UpdateAndSave( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }

//        public override int RemoveAndSave( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }

//        public override Task<int> AddAndSaveAsync( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }

//        public override Task<int> UpdateAndSaveAsync( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }

//        public override Task<int> RemoveAndSaveAsync( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }
//        #endregion Implements abstract class GenericEntityUnitOfWorkBase<EIT_Context, MappedDocument>

//        #region Implements interface IGL_ADAR_Mosaico_UnitOfWork
//        public int SaveChanges()
//        {
//            int result = 0;

//            result += this.EIT_Context.SaveChanges();

//            return result;
//        }
//        public void BeginTransaction( DbTransaction transaction )
//        {
//            ( ( DbContext ) this._mosaicoContext ).Database.UseTransaction( transaction );
//        }
//        public void BeginTransaction()
//        {
//            this._mosaicoContextTransaction = ( ( DbContext ) this._mosaicoContext ).Database.BeginTransaction();
//        }
//        public void CommitTransaction()
//        {
//            this._mosaicoContextTransaction.Commit();
//        }
//        public void RollbackTransaction()
//        {
//            this._mosaicoContextTransaction.Rollback();
//        }
//        #endregion Implements interface IGL_ADAR_Mosaico_UnitOfWork
//    }
//}
