using es.eit.application;
using es.eit.application.Messages;
using es.eit.application.Services;
using es.eit.application.Views;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace es.eit.ws.Controllers.Api
{
    [EnableCorsAttribute( "*", "*", "*" )]
    public class PersonController : ApiController
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        IPerson_Service service = API.Container.GetInstance<IPerson_Service>();

        // GET api/<controller>
        public IEnumerable<Person_View> Get(string name)
        {
            var request = new Person_Request { Name = name };

            var result = service.GetByNameAndDepartment( request );

            return result.Items.Cast<Person_View>().ToList();
        }
    }
}