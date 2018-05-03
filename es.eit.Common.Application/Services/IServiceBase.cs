using es.eit.Common.Application.Validations;
using es.eit.Common.Application.Views;
using System.Collections.Generic;

namespace es.eit.Common.Application.Services
{
    public interface IServiceBase<T>
        where T : IViewBase
    {
        IEnumerable<string> GetBrokenRules( IValidableFieldsBase item );
        IEnumerable<string> GetBrokenRules( IValidableFieldsBase item, IViewValidatorBase validator );
    }
}
