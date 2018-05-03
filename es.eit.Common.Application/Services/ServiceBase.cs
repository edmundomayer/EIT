using es.eit.Common.Application.Validations;
using es.eit.Common.Application.Views;
using es.eit.Common.Infrastructure.Mappers;
using es.eit.Common.Infrastructure.Validations;
using es.eit.Common.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.Common.Application.Services
{
    public class ServiceBase<T> : IServiceBase<T>
        where T : class, IViewBase
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        #region Internal
        protected IGenericRepositoryBase _repository;

        protected IReadOnlyMapperBase _mappers;

        protected IViewValidatorBase _validator;

        #endregion Internal

        #region Constructors & Destructors
        public ServiceBase()
        {

        }
        public ServiceBase( IGenericRepositoryBase repository,
                            IReadOnlyMapperBase mappers,
                            IViewValidatorBase validator )
        {
            this._repository = repository;
            this._mappers = mappers;
            this._validator = validator;
        }
        #endregion Constructors & Destructors

        #region Properties
        protected virtual IGenericRepositoryBase Repository
        {
            get { return this._repository; }
            set { this._repository = value; }
        }

        protected virtual IReadOnlyMapperBase Mappers
        {
            get { return this._mappers; }
            set { this._mappers = value; }
        }

        protected virtual IViewValidatorBase Validator
        {
            get { return this._validator; }
            set { this._validator = value; }
        }

        #endregion Properties

        #region Methods
        public IEnumerable<string> GetBrokenRules( IValidableFieldsBase item )
        {
            return this.GetBrokenRules( item, this._validator );
        }

        public IEnumerable<string> GetBrokenRules( IValidableFieldsBase item, IViewValidatorBase validator )
        {
            if ( item == null )
                throw new ArgumentException( "Null item can't be validated" );

            if ( validator == null )
                throw new ValidationException( "No Validator available" );

            List<string> result = new List<string>();

            result.AddRange( validator.Validate( item ) );

            return result;
        }

        protected void Validate( IValidableFieldsBase item )
        {
            this.Validate( item, this._validator );
        }

        protected void Validate( IValidableFieldsBase item, IViewValidatorBase validator )
        {
            var brokenRules = this.GetBrokenRules( item, validator );

            if ( brokenRules.Count() > 0 )
                throw new ValidationException( brokenRules.First() );
        }
        #endregion Methods

        #region Events
        #endregion Events


        #region Implements interface IServiceBase<T>
        public void Dispose()
        {
            if ( this.Repository != null )
                this.Repository.Dispose();
        }
        #endregion Implements interface IServiceBase<T>
    }
}
