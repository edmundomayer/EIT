using es.eit.Common.Infrastructure.CustomExceptions;
using System.Configuration;

namespace es.eit.data.Sql.Implementations.Contexts.Configuration
{
    public partial class ConfigApplicationSettings : IApplicationSettings
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        #region Implements Interface IApplicationSettings
        public string EIT_Schema
        {
            get
            {
                string message = string.Format( "No se ha encontrado el AppSettings[es.docout.Mosaico.Data.Oracle.Implementations.Contexts.Configuration.EIT_Schema] en el fichero de configuración." );

                string result = ConfigurationManager.AppSettings[ "es.eit.Data.DefaultSchema" ];

                if ( result == null )
                {
                    log.Fatal( message );
                    throw new CustomFatalException( message );
                }

                return result;
            }
        }
        #endregion Implements Interface IApplicationSettings
    }
}