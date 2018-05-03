using es.eit.application.Views;
using es.eit.Common.Application.Messages;
using System;

namespace es.eit.application.Messages
{
    public class Department_Response : ResponseBase<Department_View>
    {
        public Department_Response( Guid requestMessageId )
            : base( requestMessageId )
        { }
    }
}
