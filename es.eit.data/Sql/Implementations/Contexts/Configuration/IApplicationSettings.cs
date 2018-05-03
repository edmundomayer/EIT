using es.eit.Common.Infrastructure.Configuration;

namespace es.eit.data.Sql.Implementations.Contexts.Configuration
{
    public partial interface IApplicationSettings : IApplicationSettingsBase
    {
        string EIT_Schema { get; }
    }
}
