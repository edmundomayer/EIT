//using es.docout.Common.Data.Context;
//using es.docout.Common.Data.UnitsOfWork.Entity;
//using es.docout.Mosaico.Data.Oracle.Implementations.Contexts;
//using es.docout.Mosaico.Data.Oracle.Implementations.Repositories;
//using es.docout.Mosaico.Model.Entities;
//using es.docout.Mosaico.Model.Helpers;
//using es.docout.Mosaico.Model.Repositories;
//using es.docout.Mosaico.Model.UnitsOfWork;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;

//namespace es.docout.Mosaico.Data.Oracle.Implementations.UnitsOfWork
//{
//    public class MappedDocument_ENTITY_UnitOfWork : GenericEntityUnitOfWorkBase<EIT_Context, MappedDocument>, IMappedDocument_UnitOfWork
//    {
//        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

//        #region Internals
//        private IMappedDocument_Repository _mappedDocumentRepository;
//        private IMappedPage_Repository _mappedPageRepository;
//        private IStateHistoric_Repository _statesHistoricRepository;
//        #endregion Internals

//        #region Constructors & Destructors
//        public MappedDocument_ENTITY_UnitOfWork()
//            : this( new EIT_Context() )
//        { }

//        public MappedDocument_ENTITY_UnitOfWork( IEntityContextBase context )
//            : base( ( EIT_Context ) context )
//        {

//            this._mappedDocumentRepository = new MappedDocument_ENTITY_Repository( this._context );
//            this._mappedPageRepository = new MappedPage_ENTITY_Repository( this._context );
//            this._statesHistoricRepository = new StateHistoric_ENTITY_Repository( this._context );
//        }
//        #endregion Constructors & Destructors

//        #region Properties
//        #endregion Properties

//        #region Methods
//        private int Add_Document_Pages( IEnumerable<MappedDocument> items )
//        {
//            int result = 0;

//            this._mappedDocumentRepository.Add( items );
//            this._mappedPageRepository.Add( items.SelectMany( p => p.MappedPageList ) );

//            return result;
//        }
//        private int Update_Document_Pages( IEnumerable<MappedDocument> items )
//        {
//            int result = 0;

//            var docIds = items.Select( doc => doc.Id );

//            var pags = items
//                        .SelectMany( doc => doc.MappedPageList )
//                        .Select( pag =>
//                        {
//                            pag.Id = 0;
//                            pag.MappedDocument = null;

//                            return pag;
//                        } ).ToList();

//            var docs = items
//                        .Select( doc =>
//                        {
//                            doc.MappedPageList = null;

//                            return doc;
//                        } ).ToList();

//            this._mappedPageRepository.Remove( this._context.mappedPage.Where( pag => docIds.Contains( pag.IdMappedDocument ) ) );
//            this._mappedDocumentRepository.Update( docs );
//            this._mappedPageRepository.Add( pags );

//            return result;
//        }
//        #endregion Methods

//        #region Implements abstract class GenericUnitOfWorkBase<Mosaico_Entities, MappedDocument>
//        [Obsolete( "Este método no está disponible en esta versión. Utilice 'AddAndSave( T item )' o 'int AddAndSave( IEnumerable<T> items )' en sus versiones síncronas o asíncronas.", true )]
//        public override void Add( params MappedDocument[] items )
//        {
//            throw new NotImplementedException();
//        }

//        [Obsolete( "Este método no está disponible en esta versión. Utilice 'UpdateAndSave( T item )' o 'int UpdateAndSave( IEnumerable<T> items )' en sus versiones síncronas o asíncronas.", true )]
//        public override void Update( params MappedDocument[] items )
//        {
//            throw new NotImplementedException();
//        }

//        [Obsolete( "Este método no está disponible en esta versión. Utilice 'RemoveAndSave( T item )' o 'int RemoveAndSave( IEnumerable<T> items )' en sus versiones síncronas o asíncronas.", true )]
//        public override void Remove( params MappedDocument[] items )
//        {
//            throw new NotImplementedException();
//        }


//        #region Sync Versions
//        public override int AddAndSave( IEnumerable<MappedDocument> items )
//        {
//            DbTransaction transaction = null;

//            return this.AddAndSave( null, null, 0, items, transaction );
//        }
//        public int AddAndSave( IEnumerable<MappedDocument> items, DbTransaction transaction )
//        {
//            return this.AddAndSave( null, null, 0, items, transaction );
//        }
//        public int AddAndSave( string ip, string userName, int state, IEnumerable<MappedDocument> items )
//        {
//            DbTransaction transaction = null;

//            return this.AddAndSave( ip, userName, state, items, transaction );
//        }
//        public int AddAndSave( string ip, string userName, int state, IEnumerable<MappedDocument> items, DbTransaction transaction )
//        {
//            if ( items.Any( d => d.Id != 0 ) )
//                throw new ArgumentException( string.Format( "No se puede agregar un MappedDocument con Id diferente de 0." ) );

//            return base.WrapIntoTransaction( () =>
//            {
//                int result = 0;

//                foreach ( var doc in items )
//                {
//                    this._context.mappedDocument.Add( doc );

//                    foreach ( var pag in doc.MappedPageList )
//                    {
//                        base._context.Entry( pag.PageType ).State = EntityState.Unchanged;
//                    }

//                    if ( userName != null )
//                    {
//                        var newHist = new StateHistoric
//                        {
//                            Id = 0,
//                            SourceIP = ip,
//                            UserName = userName,
//                            IdState = state,
//                            IdMappedDocument = doc.Id,
//                            Stamp = DateTime.Now,
//                        };

//                        if ( doc.StateHistoricList == null )
//                            doc.StateHistoricList = new List<StateHistoric>();

//                        doc.StateHistoricList.Add( newHist );

//                        base._context.Entry( newHist ).State = EntityState.Added;
//                    }
//                }

//                result = base._context.SaveChanges();

//                return result;
//            }, ref transaction );
//        }


//        public override int UpdateAndSave( IEnumerable<MappedDocument> items )
//        {
//            DbTransaction transaction = null;

//            return this.UpdateAndSave( null, null, 0, items, transaction );
//        }
//        public int UpdateAndSave( IEnumerable<MappedDocument> items, DbTransaction transaction )
//        {
//            return this.UpdateAndSave( null, null, 0, items, transaction );
//        }
//        public int UpdateAndSave( string ip, string userName, int state, IEnumerable<MappedDocument> items )
//        {
//            DbTransaction transaction = null;

//            return this.UpdateAndSave( ip, userName, state, items, transaction );
//        }
//        public int UpdateAndSave( string ip, string userName, int state, IEnumerable<MappedDocument> items, DbTransaction transaction )
//        {
//            if ( items.Any( d => d.Id == 0 ) )
//                throw new ArgumentException( string.Format( "No se puede modificar un MappedDocument con Id igual a 0." ) );

//            return base.WrapIntoTransaction( () =>
//            {
//                int result = 0;

//                IEnumerable<decimal> keepPagIdList = items
//                                                    .Where( d => d.MappedPageList.Count > 0 )
//                                                    .SelectMany( d => d.MappedPageList )
//                                                    .Where( p => p.Id != 0 )
//                                                    .Select( p => p.Id ).ToList();

//                // BEGIN - Simplify to update only modified items
//                //
//                var ids = items.Select( i => i.Id ).ToList();
//                var realDocs = base._context.mappedDocument
//                                    .Include( d => d.MappedPageList )
//                                    .Where( d => ids.Contains( d.Id ) )
//                                    .ToList();

//                // Fix input IdMappedDocument that is comming with 0
//                //
//                items = items.Select( d => 
//                {
//                    d.MappedPageList = d.MappedPageList.Select(p=> 
//                    {
//                        p.IdMappedDocument = d.Id;

//                        return p;
//                    } ).ToList();

//                    return d;
//                } ).ToList();

//                // Rebuild items to only-modified (document and/or pages)
//                //
//                // items = items.Where( d => !realDocs.Contains( d, new MappedDocument_EqualityComparer() ) ).ToList();

//                //
//                // END - Simplify to update only modified items


//                foreach ( var doc in items )
//                {
//                    var realDoc = realDocs // base._context.mappedDocument
//                                           //.Include( d => d.MappedPageList )
//                                    .FirstOrDefault( d => d.Id == doc.Id );

//                    var unKeepPagList = base._context.mappedPage
//                                        .Where( p => p.IdMappedDocument == doc.Id
//                                                     && ( !( keepPagIdList.Contains( p.Id ) ) ) ).ToList();

//                    foreach ( var pag in unKeepPagList )
//                    {
//                        realDoc.MappedPageList.Remove( pag );

//                        pag.PageType = null;
//                        var entity = base._context.mappedPage.Find( pag.Id );
//                        base._context.Entry( entity ).State = EntityState.Deleted;
//                    }


//                    // Rebuild pages to only-modified (document and/or pages)
//                    //
//                    var updatedPages = doc.MappedPageList.Where( p => !realDoc.MappedPageList.Contains( p, new MappedPage_EqualityComparer() ) ).ToList();



//                    foreach ( var pag in updatedPages ) // doc.MappedPageList )
//                    {
//                        pag.IdMappedDocument = doc.Id;

//                        if ( pag.Id == 0 )
//                        {
//                            base._context.Entry( pag ).State = EntityState.Added;
//                            base._context.Entry( pag.PageType ).State = EntityState.Unchanged;
//                        }
//                        else
//                        {
//                            base._context.Entry( pag.PageType ).State = EntityState.Unchanged;
//                            var entry = base._context.Set<MappedPage>().Find( pag.Id );
//                            base._context.Entry( entry ).CurrentValues.SetValues( pag );
//                        }
//                    }

//                    base._context.Entry( realDoc ).CurrentValues.SetValues( doc );
//                    base._context.Entry( realDoc ).State = EntityState.Modified;

//                    if ( userName != null )
//                    {
//                        var newHist = new StateHistoric
//                        {
//                            Id = 0,
//                            SourceIP = ip,
//                            UserName = userName,
//                            IdState = state,
//                            IdMappedDocument = doc.Id,
//                            Stamp = DateTime.Now,
//                            MappedDocument = realDoc
//                        };

//                        if ( doc.StateHistoricList == null )
//                            doc.StateHistoricList = new List<StateHistoric>();

//                        doc.StateHistoricList.Add( newHist );

//                        base._context.Entry( newHist ).State = EntityState.Added;
//                    }
//                }

//                result = base._context.SaveChanges();

//                return result;
//            }, ref transaction );
//        }


//        public override int RemoveAndSave( IEnumerable<MappedDocument> items )
//        {
//            return base.WrapIntoTransaction( () =>
//            {
//                int result = 0;

//                IEnumerable<decimal> keepPagIdList = items.SelectMany( d => d.MappedPageList ).Where( p => p.Id != 0 ).Select( p => p.Id ).ToList();

//                foreach ( var doc in items )
//                {
//                    var realDoc = base._context.mappedDocument
//                                    .Include( d => d.MappedPageList )
//                                    .Include( d => d.StateHistoricList )
//                                    .FirstOrDefault( d => d.Id == doc.Id );

//                    foreach ( var pag in doc.MappedPageList )
//                    {
//                        realDoc.MappedPageList.Remove( pag );

//                        var entry = base._context.mappedPage.Find( pag.Id );
//                        base._context.Entry( entry ).State = EntityState.Deleted;
//                    }


//                    if ( realDoc.StateHistoricList != null )
//                    {
//                        foreach ( var hist in doc.StateHistoricList )
//                        {
//                            realDoc.StateHistoricList.Remove( hist );

//                            var entry = base._context.statesHistoric.Find( hist.Id );
//                            base._context.Entry( entry ).State = EntityState.Deleted;
//                        }
//                    }

//                    base._context.Entry( realDoc ).State = EntityState.Deleted;
//                }

//                result = base._context.SaveChanges();

//                return result;
//            } );
//        }


//        public int AddOrUpdateAndSave( IEnumerable<MappedDocument> items )
//        {
//            DbTransaction transaction = null;

//            using ( this._context = new EIT_Context() )
//            {
//                return base.WrapIntoTransaction( () =>
//                {
//                    int result = 0;

//                    var toAdd = items.Where( doc => doc.Id == 0 );
//                    var toUpdate = items.Where( doc => doc.Id != 0 );

//                    result += this.UpdateAndSave( toUpdate, transaction );
//                    result += this.AddAndSave( toAdd, transaction );

//                    return result;
//                }, ref transaction );
//            }
//        }
//        public int AddOrUpdateAndSave( string ip, string userName, int state, IEnumerable<MappedDocument> items )
//        {
//            DbTransaction transaction = null;

//            using ( this._context = new EIT_Context() )
//            {
//                return base.WrapIntoTransaction( () =>
//                {
//                    int result = 0;

//                    var toAdd = items.Where( doc => doc.Id == 0 );
//                    var toUpdate = items.Where( doc => doc.Id != 0 );

//                    result += this.UpdateAndSave( ip, userName, state, toUpdate, transaction );
//                    result += this.AddAndSave( ip, userName, state, toAdd, transaction );

//                    return result;
//                }, ref transaction );
//            }
//        }

//        public IEnumerable<MappedDocument> AddOrUpdateAndSaveReturn( string ip, string userName, int state, IEnumerable<MappedDocument> items )
//        {
//            DbTransaction transaction = null;

//            using ( this._context = new EIT_Context() )
//            {
//                var res = base.WrapIntoTransaction( () =>
//                {
//                    int result = 0;

//                    var toAdd = items.Where( doc => doc.Id == 0 );
//                    var toUpdate = items.Where( doc => doc.Id != 0 );

//                    result += this.UpdateAndSave( ip, userName, state, toUpdate, transaction );
//                    result += this.AddAndSave( ip, userName, state, toAdd, transaction );

//                    return result;
//                }, ref transaction );
//            }

//            return items.ToList();
//        }
//        #endregion Sync Versions

//        #region Async Versions
//        public override Task<int> AddAndSaveAsync( MappedDocument item )
//        {
//            throw new NotImplementedException();
//        }
//        public override Task<int> AddAndSaveAsync( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }

//        public override Task<int> UpdateAndSaveAsync( MappedDocument item )
//        {
//            throw new NotImplementedException();
//        }
//        public override Task<int> UpdateAndSaveAsync( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }

//        public override Task<int> RemoveAndSaveAsync( MappedDocument item )
//        {
//            throw new NotImplementedException();
//        }
//        public override Task<int> RemoveAndSaveAsync( IEnumerable<MappedDocument> items )
//        {
//            throw new NotImplementedException();
//        }
//        #endregion Async Versions

//        #endregion Implements interface IMappedDocument_UnitOfWork
//    }
//}
