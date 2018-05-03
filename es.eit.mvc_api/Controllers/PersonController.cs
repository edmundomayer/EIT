using es.eit.application;
using es.eit.application.Messages;
using es.eit.application.Services;
using es.eit.application.Views;
using System;
using System.Linq;
using System.Web.Mvc;

namespace es.eit.ws.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        IPerson_Service service = API.Container.GetInstance<IPerson_Service>();

        // GET: Person
        public ActionResult Index( int idDepartment )
        {
            var request = new Person_Request() { Id = idDepartment };

            var result = service.GetByIdDepartment( request );

            return View( result.Items.Cast<Person_View>() );
        }

        // GET: Person
        [Authorize]
        public ActionResult Search( string search )
        {
            var request = new Person_Request() { SearchCriteria = search };

            var result = service.GetAll( request );

            return View( result.Items.Cast<Person_View>() );
        }

        // GET: Person/Details/5
        public ActionResult Details( int id )
        {
            var request = new Person_Request { Id = id };

            var result = service.GetById( request );

            return View( result.Item );
        }

        // GET: Person/Create
        [Authorize( Roles = "Administrator" )]
        public ActionResult Create( int idDepartment )
        {
            Person_View fakePerson = null;

            var request = new Department_Request() { Id = idDepartment };

            using ( var DepartmentService = API.Container.GetInstance<IDepartment_Service>() )
            {
                var result = DepartmentService.GetById( request );

                fakePerson = new Person_View { Department = result.Item };
            }

            return View( fakePerson );
        }

        // POST: Person/Create
        [HttpPost]
        [Authorize( Roles = "Administrator" )]
        public ActionResult Create( Person_View item )
        {
            var request = new Person_Request { Item = item };

            var tempService = API.Container.GetInstance<IPerson_Service>();

            var validationErrorMessages = tempService.GetBrokenRules( item );

            if ( validationErrorMessages != null && validationErrorMessages.Count() > 0 )
            {
                using ( var DepartmentService = API.Container.GetInstance<IDepartment_Service>() )
                {
                    var DepartmentRequest = new Department_Request() { Id = item.IdDepartment };

                    var result = DepartmentService.GetById( DepartmentRequest );

                    item.Department = result.Item;
                }

                ModelState.AddModelError( "", validationErrorMessages.First() );
                return View( item );
            }

            try
            {
                var response = tempService.Add( request );

                return RedirectToAction( "Index", "Department" );
            }
            catch ( Exception _error )
            {
                log.Error( _error );

                return View();
            }
        }

        // GET: Person/Edit/5
        [Authorize( Roles = "Administrator" )]
        public ActionResult Edit( int id )
        {
            var request = new Person_Request { Id = id };

            var result = service.GetById( request );

            return View( result.Item );
        }

        // POST: Person/Edit/5
        [HttpPost]
        [Authorize( Roles = "Administrator" )]
        public ActionResult Edit( int id, Person_View item )
        {
            var request = new Person_Request { Item = item };

            var tempService = API.Container.GetInstance<IPerson_Service>();

            var validationErrorMessages = tempService.GetBrokenRules( item );

            if ( validationErrorMessages != null && validationErrorMessages.Count() > 0 )
            {
                ModelState.AddModelError( "", validationErrorMessages.First() );
                return View( item );
            }

            try
            {
                var response = tempService.Update( request );

                return RedirectToAction( "Index", "Department" );
            }
            catch ( Exception _error )
            {
                log.Error( _error );

                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete( int id )
        {
            var request = new Person_Request { Id = id };

            var result = service.GetById( request );

            return View( result.Item );
        }

        // POST: Person/Delete/5
        [HttpPost]
        [Authorize( Roles = "Administrator" )]
        public ActionResult Delete( int id, Person_View item )
        {
            try
            {
                var originalIdDepartment = item.IdDepartment;

                var request = new Person_Request { Item = item };

                var tempService = API.Container.GetInstance<IPerson_Service>();

                var response = tempService.Remove( request );

                return RedirectToAction( "Index", "Department" );
            }
            catch ( Exception _error )
            {
                log.Error( _error );

                return View();
            }
        }
    }
}
