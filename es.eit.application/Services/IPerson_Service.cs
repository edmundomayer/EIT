using es.eit.application.Messages;
using es.eit.application.Views;
using es.eit.Common.Application.Services;
using System;

namespace es.eit.application.Services
{
    public interface IPerson_Service : IServiceBase<Person_View>, IDisposable
    {
        Person_Response GetByIdDepartment( Person_Request request );
        Person_Response GetById( Person_Request request );
        Person_Response GetByNameAndDepartment( Person_Request request );
        Person_Response GetAll( Person_Request request );

        Person_Response Add( Person_Request request );
        Person_Response Remove( Person_Request request );
        Person_Response Update( Person_Request request );
    }
}
