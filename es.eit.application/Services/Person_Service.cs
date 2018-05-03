using es.eit.application.Mappers;
using es.eit.application.Messages;
using es.eit.application.Validations;
using es.eit.application.Views;
using es.eit.Common.Application.Services;
using es.eit.Common.Application.Validations;
using es.eit.Common.Infrastructure.Mappers;
using es.eit.model.Entitities;
using es.eit.model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.application.Services
{
    public class Person_Service : ServiceBase<Person_View>, IPerson_Service
    {
        #region Internalas
        #endregion Internalas

        #region Constructors & Destructors
        public Person_Service()
        { }

        public Person_Service( IPerson_Repository repository,
                                    IReadOnlyMapperBase<Person_View, Person> mappers,
                                    IViewValidatorBase<IPerson_ValidableFields> validator )
            : base( repository, mappers, validator )
        { }
        #endregion Constructors & Destructors

        #region Properties
        protected new virtual IPerson_Repository Repository
        {
            get { return ( IPerson_Repository ) base.Repository; }
            set { base.Repository = value; }
        }
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events

        #region Implements interface IPerson_Service
        public Person_Response GetByIdDepartment( Person_Request request )
        {
            if ( request == null )
                throw new ArgumentNullException();

            Person_Response response = new Person_Response( request.MessageId );

            response.Items = this.Repository.GetAll( filter: ( x => x.IdDepartment == request.Id ) ).ConvertToView();

            return response;
        }

        public Person_Response GetById( Person_Request request )
        {
            if ( request == null )
                throw new ArgumentNullException();

            Person_Response response = new Person_Response( request.MessageId );

            response.Item = this.Repository.GetById( id: request.Id,
                                                        navigationProperties: ( x => x.Department ) ).ConvertToView();

            return response;
        }

        public Person_Response GetByNameAndDepartment( Person_Request request )
        {
            if ( request == null )
                throw new ArgumentNullException();

            Person_Response response = new Person_Response( request.MessageId );

            response.Items = this.Repository.GetAll( filter: ( x => x.Name.ToUpper().Contains( request.Name.ToUpper() ) ||
                                                                    x.Department.Name.ToUpper().Contains( request.Name.ToUpper() ) ),
                                                        navigationProperties: ( x => x.Department ) ).ConvertToView();

            return response;
        }

        public Person_Response GetAll( Person_Request request )
        {
            if ( request == null )
                throw new ArgumentNullException();

            Person_Response response = new Person_Response( request.MessageId );

            if ( request.SearchCriteria == null )
                response.Items = this.Repository.GetAll( navigationProperties: ( x => x.Department ) ).ConvertToView();
            else
                response.Items = this.Repository.GetAll( filter: ( x => x.Name.Contains( request.SearchCriteria ) ||
                                                                          ( x.BirthDate != null && x.BirthDate.ToString().Contains( request.SearchCriteria ) ) ||
                                                                          x.Salary.ToString().Contains( request.SearchCriteria ) ),
                                                            navigationProperties: ( x => x.Department ) ).ConvertToView();

            return response;
        }



        public Person_Response Add( Person_Request request )
        {
            this.Validate( request.Item );

            Person_Response response = new Messages.Person_Response( request.MessageId );

            using ( var tempRepository = this.Repository )
            {
                var modelItems = ( request.Item != null ? new List<Person_View> { request.Item } : request.Items ).ConvertToModel();

                tempRepository.Add( modelItems );
                tempRepository.SaveChanges();

                if ( modelItems.Count() == 1 )
                    response.Item = modelItems.First().ConvertToView();
                else
                    response.Items = modelItems.ConvertToView();
            }

            response.Succeed = true;

            return response;
        }

        public Person_Response Update( Person_Request request )
        {
            Person_Response response = new Messages.Person_Response( request.MessageId );

            using ( var tempRepository = this.Repository )
            {
                var modelItems = ( request.Item != null ? new List<Person_View> { request.Item } : request.Items ).ConvertToModel();

                tempRepository.Update( modelItems );
                tempRepository.SaveChanges();

                if ( modelItems.Count() == 1 )
                    response.Item = modelItems.First().ConvertToView();
                else
                    response.Items = modelItems.ConvertToView();
            }

            response.Succeed = true;

            return response;
        }

        public Person_Response Remove( Person_Request request )
        {
            Person_Response response = new Messages.Person_Response( request.MessageId );

            using ( var tempRepository = this.Repository )
            {
                var modelItems = ( request.Item != null ? new List<Person_View> { request.Item } : request.Items ).ConvertToModel();

                tempRepository.Remove( modelItems );
                tempRepository.SaveChanges();
            }

            response.Succeed = true;

            return response;
        }
        #endregion Implements interface IPerson_Service
    }
}
