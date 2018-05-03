using System.Collections.Generic;

namespace es.eit.Common.Application.Validations
{
    public interface IViewValidatorBase<in T> : IViewValidatorBase
        where T : IValidableFieldsBase
    {
        IEnumerable<string> Validate( T t );
    }

    public interface IViewValidatorBase
    {
        IEnumerable<string> Validate( IValidableFieldsBase t );
    }
}
