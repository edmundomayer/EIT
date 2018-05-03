using es.eit.Common.Infrastructure.Model;
using es.eit.Common.Model.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace es.eit.Common.Data.Repositories.Text
{
    public abstract class GenericTextRepository_RO<T> : GenericRepositoryBase<T>, IGenericRepository_RO<T>
        where T : class, IEntityBase
    {
        #region Internal
        protected string _fullFileName;
        protected bool _includeHeader;
        #endregion Internal

        #region Constructors & Destructors

        /// <summary>
        /// Text File Constructor
        /// </summary>
        /// <param name="fullFileName">Full File Name to data file</param>
        public GenericTextRepository_RO( string fullFileName )
            : this( fullFileName, true )
        { }

        /// <summary>
        /// Text File Constructor
        /// </summary>
        /// <param name="fullFileName">Full File Name to data file</param>
        /// <param name="includeHeader">Indicate if data file contains Headers at first row (default true)</param>
        public GenericTextRepository_RO( string fullFileName, bool includeHeader )
        {
            this._fullFileName = fullFileName;
            this._includeHeader = includeHeader;
        }
        #endregion Constructors & Destructors

        #region Properties
        internal string FullFileName
        {
            get { return this._fullFileName; }
            set { this._fullFileName = value; }
        }

        internal bool IncludeHeader
        {
            get { return this._includeHeader; }
            set { this._includeHeader = value; }
        }
        #endregion Properties

        #region Methods
        public abstract T CreateRecord( string line );
        #endregion Methods

        #region Events
        #endregion Events

        #region Implements Abstract Class GenericRepositoryBase<T>
        public override IQueryable<T> GetAll( Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int? skip = default( int? ), int? take = default( int? ), params Expression<Func<T, object>>[] navigationProperties )
        {
            log.Info( string.Format( "Reading File: '{0}'", this.FullFileName ) );

            IEnumerable<string> AllLines = File.ReadAllLines( this._fullFileName )
                                                    .Skip( this._includeHeader ? 1 : 0 );

            var records = AllLines.Where( p => !string.IsNullOrEmpty( p ) )
                .Select( line =>
                {
                    return this.CreateRecord( line );
                } );

            return base.GetQueryable( records.AsQueryable(),
                                        filter,
                                        orderBy,
                                        skip,
                                        take,
                                        navigationProperties );
        }
        #endregion Implements Abstract Class GenericRepositoryBase<T>

        #region Implements interface IGenericRepository_RO<T>
        #endregion Implements interface IGenericRepository_RO<T>
    }
}