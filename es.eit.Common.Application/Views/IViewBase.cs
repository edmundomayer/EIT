using es.eit.Common.Infrastructure.Model;

namespace es.eit.Common.Application.Views
{
    public interface IViewBase<T> : IEntityBase<T>, IViewBase
        where T : struct
    {
    }

    public interface IViewBase : IEntityBase
    { }
}
