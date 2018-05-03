using es.eit.application.Views;
using es.eit.Common.Application.Messages;
using System;

namespace es.eit.application.Messages
{
    public class Person_Response : ResponseBase<Person_View>
    {
        public Person_Response( Guid requestMessageId )
            : base( requestMessageId )
        { }
    }
}
