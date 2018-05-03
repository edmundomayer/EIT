using System.Configuration;

namespace es.eit.Common.Infrastructure.Configuration
{
    public partial class ConfigApplicationSettings : IApplicationSettings
    {
        #region Implements Interface IApplicationSettings
        public string LogFileName
        {
            get { return ConfigurationManager.AppSettings[ "Common.Data.Properties.Settings.LogFileName" ]; }
        }
        #endregion Implements Interface IApplicationSettings
    }
}