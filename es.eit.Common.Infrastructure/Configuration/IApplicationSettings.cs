namespace es.eit.Common.Infrastructure.Configuration
{
    public partial interface IApplicationSettings : IApplicationSettingsBase
    {
        string LogFileName { get; }
    }
}
