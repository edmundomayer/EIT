using System;
using System.Runtime.Serialization;

namespace es.eit.Common.Infrastructure.CustomExceptions
{
    [Serializable]
    public class CustomCancelException : Exception
    {
        public CustomCancelException()
        { }

        public CustomCancelException( string message )
            : base( message )
        { }

        public CustomCancelException( SerializationInfo info, StreamingContext context )
            : base( info, context ) { }
    }
}
