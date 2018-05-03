using System;
using System.Runtime.Serialization;

namespace es.eit.Common.Infrastructure.CustomExceptions
{
    [Serializable]
    public class CustomContinueException : Exception
    {
        public CustomContinueException()
        { }

        public CustomContinueException( string message )
            : base( message )
        { }

        public CustomContinueException( SerializationInfo info, StreamingContext context )
            : base( info, context ) { }
    }
}
