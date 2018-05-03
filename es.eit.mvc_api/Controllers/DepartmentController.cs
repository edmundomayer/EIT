using es.eit.application;
using es.eit.application.Messages;
using es.eit.application.Services;
using es.eit.application.Views.ComplexViews;
using System;
using System.Linq;
using System.Web.Mvc;

namespace es.eit.ws.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        IDepartment_Service service = API.Container.GetInstance<IDepartment_Service>();

        // GET: Department
        public ActionResult Index()
        {
            var request = new Department_Request();

            var result = service.GetAll( request );

            return View( result.Items.Cast<Persons_By_Department_View>() );
        }

        // GET: Department/Details/5
        public ActionResult Details( int id )
        {
            var request = new Department_Request { Id = id };

            var result = service.GetById( request );

            return View( result.Item );
        }

        // GET: Department/Create
        [Authorize( Roles = "Administrator" )]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [Authorize( Roles = "Administrator" )]
        public ActionResult Create( Persons_By_Department_View item )
        {
            var request = new Department_Request { Item = item };

            using ( var tempService = API.Container.GetInstance<IDepartment_Service>() )
            {
                var validationErrorMessages = tempService.GetBrokenRules( item );

                if ( validationErrorMessages != null && validationErrorMessages.Count() > 0 )
                {
                    ModelState.AddModelError( "", validationErrorMessages.First() );
                    return View( item );
                }

                try
                {
                    var response = tempService.Add( request );

                    return RedirectToAction( "Index" );
                }
                catch ( Exception _error )
                {
                    log.Error( _error );

                    return View();
                }
            }
        }

        // GET: Department/Edit/5
        [Authorize( Roles = "Administrator" )]
        public ActionResult Edit( int id )
        {
            var request = new Department_Request { Id = id };

            var result = service.GetById( request );

            return View( result.Item );
        }

        // POST: Department/Edit/5
        [HttpPost]
        [Authorize( Roles = "Administrator" )]
        public ActionResult Edit( int id, Persons_By_Department_View item )
        {
            var request = new Department_Request { Item = item };

            var tempService = API.Container.GetInstance<IDepartment_Service>();

            var validationErrorMessages = tempService.GetBrokenRules( item );

            if ( validationErrorMessages != null && validationErrorMessages.Count() > 0 )
            {
                ModelState.AddModelError( "", validationErrorMessages.First() );
                return View( item );
            }

            try
            {
                var response = tempService.Update( request );

                return RedirectToAction( "Index" );
            }
            catch ( Exception _error )
            {
                log.Error( _error );

                return View();
            }
        }

        // GET: Department/Delete/5
        [Authorize( Roles = "Administrator" )]
        public ActionResult Delete( int id )
        {
            var request = new Department_Request { Id = id };

            var result = service.GetById( request );

            return View( result.Item );
        }

        // POST: Department/Delete/5
        [HttpPost]
        [Authorize( Roles = "Administrator" )]
        public ActionResult Delete( int id, Persons_By_Department_View item )
        {
            try
            {
                var request = new Department_Request { Item = item };

                var tempService = API.Container.GetInstance<IDepartment_Service>();

                var response = tempService.Remove( request );

                return RedirectToAction( "Index" );
            }
            catch ( Exception _error )
            {
                log.Error( _error );

                return View();
            }
        }
    }
}
