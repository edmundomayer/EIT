using es.eit.application.Mappers;
using es.eit.application.Messages;
using es.eit.application.Validations;
using es.eit.application.Views;
using es.eit.application.Views.ComplexViews;
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
    public class Department_Service : ServiceBase<Department_View>, IDepartment_Service
    {
        #region Internalas
        #endregion Internalas

        #region Constructors & Destructors
        public Department_Service()
        { }

        public Department_Service( IDepartment_Repository repository,
                                    IReadOnlyMapperBase<Persons_By_Department_View, Department> mappers,
                                    IViewValidatorBase<IDepartment_ValidableFields> validator )
            : base( repository, mappers, validator )
        { }
        #endregion Constructors & Destructors

        #region Properties
        protected new virtual IDepartment_Repository Repository
        {
            get { return ( IDepartment_Repository ) base.Repository; }
            set { base.Repository = value; }
        }
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events

        #region Implements interface IDepartment_Service
        public Department_Response GetAll( Department_Request request )
        {
            if ( request == null )
                throw new ArgumentNullException();

            Department_Response response = new Department_Response( request.MessageId );

            response.Items = this.Repository.GetAll( navigationProperties: ( x => x.PersonList ) ).ConvertToPersons_By_DepartmentView();

            return response;
        }

        public Department_Response GetById( Department_Request request )
        {
            if ( request == null )
                throw new ArgumentNullException();

            Department_Response response = new Department_Response( request.MessageId );

            response.Item = this.Repository.GetById( id: request.Id, navigationProperties: ( x => x.PersonList ) ).ConvertToPersons_By_DepartmentView();

            return response;
        }



        public Department_Response Add( Department_Request request )
        {
            this.Validate( request.Item );

            Department_Response response = new Messages.Department_Response( request.MessageId );

            using ( var tempRepository = this.Repository )
            {
                var modelItems = ( request.Item != null ? new List<Department_View> { request.Item } : request.Items ).ConvertToModel();

                tempRepository.Add( modelItems );
                tempRepository.SaveChanges();

                if ( modelItems.Count() == 1 )
                    response.Item = modelItems.First().ConvertToPersons_By_DepartmentView();
                else
                    response.Items = modelItems.ConvertToPersons_By_DepartmentView();
            }

            response.Succeed = true;

            return response;
        }

        public Department_Response Update( Department_Request request )
        {
            Department_Response response = new Messages.Department_Response( request.MessageId );

            using ( var tempRepository = this.Repository )
            {
                var modelItems = ( request.Item != null ? new List<Department_View> { request.Item } : request.Items ).ConvertToModel();

                tempRepository.Update( modelItems );
                tempRepository.SaveChanges();

                if ( modelItems.Count() == 1 )
                    response.Item = modelItems.First().ConvertToPersons_By_DepartmentView();
                else
                    response.Items = modelItems.ConvertToPersons_By_DepartmentView();
            }

            response.Succeed = true;

            return response;
        }

        public Department_Response Remove( Department_Request request )
        {
            Department_Response response = new Messages.Department_Response( request.MessageId );

            using ( var tempRepository = this.Repository )
            {
                var modelItems = ( request.Item != null ? new List<Department_View> { request.Item } : request.Items ).ConvertToModel();

                tempRepository.Remove( modelItems );
                tempRepository.SaveChanges();
            }

            response.Succeed = true;

            return response;
        }
        #endregion Implements interface IDepartment_Service
    }
}
