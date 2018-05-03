namespace es.eit.Common.Infrastructure.Configuration
{
    public class GenericApplicationSettingsFactoryBase<T>
        where T : IApplicationSettingsBase, new()
    {
        #region Internals
        protected static T _applicattionSettings;
        #endregion Internals

        #region Constructors & Destructors
        static GenericApplicationSettingsFactoryBase()
        {
            _applicattionSettings = new T();
        }
        #endregion Constructors & Destructors

        #region Methods
        public static void InitializeApplicationSettingsFactory( T applicationSettings )
        {
            _applicattionSettings = applicationSettings;
        }

        public static T GetApplicationSettings()
        {
            return _applicattionSettings;
        }
        #endregion Methods
    }
}
