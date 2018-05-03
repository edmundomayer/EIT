
namespace es.eit.Common.Infrastructure.Model
{
    public interface IEntityBase<T> : IEntityBase
        where T : struct
    {
        new T Id { get; }
    }

    public interface IEntityBase
    {
        object Id { get; }
    }
}
