using es.eit.application.Mappers;
using es.eit.application.Services;
using es.eit.application.Validations;
using es.eit.application.Views;
using es.eit.application.Views.ComplexViews;
using es.eit.Common.Application.Messages;
using es.eit.Common.Application.Validations;
using es.eit.Common.Data.Context;
using es.eit.Common.Infrastructure.Mappers;
using es.eit.data.Sql.Implementations.Contexts;
using es.eit.data.Sql.Implementations.Repositories;
using es.eit.data.Sql.Interfaces.Contexts;
using es.eit.model.Entitities;
using es.eit.model.Repositories;
using StructureMap;

namespace es.eit.application
{
    public class API
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                if ( API._container == null )
                    API.InitializeContainer();

                return API._container;
            }
        }

        private static void InitializeContainer()
        {
            _container = new Container( config =>
            {
                // Services
                //
                config.For<IDepartment_Service>().Use<Department_Service>()
                    .Ctor<IDepartment_Repository>().Is( p => p.GetInstance<IDepartment_Repository>() )
                    .Ctor<IReadOnlyMapperBase<Persons_By_Department_View, Department>>().Is( p => p.GetInstance<IReadOnlyMapperBase<Persons_By_Department_View, Department>>() )
                    .Ctor<IViewValidatorBase<IDepartment_ValidableFields>>().Is( p => p.GetInstance<IViewValidatorBase<IDepartment_ValidableFields>>() );

                config.For<IPerson_Service>().Use<Person_Service>()
                    .Ctor<IPerson_Repository>().Is( p => p.GetInstance<IPerson_Repository>() )
                    .Ctor<IReadOnlyMapperBase<Person_View, Person>>().Is( p => p.GetInstance<IReadOnlyMapperBase<Person_View, Person>>() )
                    .Ctor<IViewValidatorBase<IPerson_ValidableFields>>().Is( p => p.GetInstance<IViewValidatorBase<IPerson_ValidableFields>>() );

                // Repositories
                //
                config.For<IDepartment_Repository>().Use<Department_ENTITY_Repository>()
                    .Ctor<IEntityContextBase>().Is( p => p.GetInstance<IEIT_Context>() );

                config.For<IPerson_Repository>().Use<Person_ENTITY_Repository>()
                    .Ctor<IEntityContextBase>().Is( p => p.GetInstance<IEIT_Context>() );

                // Units Of Work
                //

                // Contexts
                //
                config.For<IEIT_Context>().Use<EIT_Context>();

                // Mappers
                //
                config.For<IReadOnlyMapperBase<Persons_By_Department_View, Department>>().Use<Persons_By_Department_Mappers>();

                config.For<IReadOnlyMapperBase<Person_View, Person>>().Use<Person_Mappers>();

                // Validators
                //
                config.For<IViewValidatorBase<IDepartment_ValidableFields>>().Use<Default_Department_ValidationRules>();

                config.For<IViewValidatorBase<IPerson_ValidableFields>>().Use<Default_Person_ValidationRules>();

                // Messages
                //
            } );
        }
    }
}
