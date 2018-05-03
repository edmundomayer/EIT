using es.eit.application.Messages;
using es.eit.application.Views;
using es.eit.Common.Application.Services;
using System;

namespace es.eit.application.Services
{
    public interface IDepartment_Service : IServiceBase<Department_View>, IDisposable
    {
        Department_Response GetAll( Department_Request request );
        Department_Response GetById( Department_Request request );

        Department_Response Add( Department_Request request );
        Department_Response Remove( Department_Request request );
        Department_Response Update( Department_Request request );
    }
}
