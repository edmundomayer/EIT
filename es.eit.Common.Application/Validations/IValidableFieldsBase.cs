using es.eit.Common.Application.Views;

namespace es.eit.Common.Application.Validations
{
    public interface IValidableFieldsBase<T> : IViewBase<T>, IValidableFieldsBase
        where T : struct
    { }

    public interface IValidableFieldsBase : IViewBase
    { }
}
