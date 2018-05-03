using System;

namespace es.eit.Common.Infrastructure.Validations
{
    public class ValidationException : Exception
    {
        #region Constructors & Destructors
        public ValidationException()
           : base()
        { }

        public ValidationException( string message )
            : base( message )
        { }
        #endregion Constructors & Destructors
    }
}
