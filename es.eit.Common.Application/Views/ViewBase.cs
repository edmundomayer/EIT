using es.eit.Common.Infrastructure.Model;

namespace es.eit.Common.Application.Views
{
    public class ViewBase<T> : EntityBase<T>, IViewBase<T>
        where T : struct
    { }
}
