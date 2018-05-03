using System;
using System.Runtime.Serialization;

namespace es.eit.Common.Infrastructure.CustomExceptions
{
    [Serializable]
    public class CustomFatalException : Exception
    {
        public CustomFatalException()
        { }

        public CustomFatalException( string message )
            : base( message )
        { }

        public CustomFatalException( SerializationInfo info, StreamingContext context )
            : base( info, context ) { }
    }
}
