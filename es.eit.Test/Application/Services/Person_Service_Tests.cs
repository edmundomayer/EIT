using es.eit.application;
using es.eit.application.Messages;
using es.eit.application.Services;
using es.eit.application.Views;
using es.eit.Common.Infrastructure.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.Test.Application.Services
{
    [TestClass]
    public class Person_Service_Tests
    {
        [TestMethod]
        public void GetById()
        {
            Person_View data = null;

            using ( IPerson_Service service = API.Container.GetInstance<IPerson_Service>() )
            {
                var response = service.GetById( new Person_Request { Id = 1 } );

                data = response.Item;
            }

            Assert.IsNotNull( data );
            Assert.IsInstanceOfType( data, typeof( Person_View ) );
            Assert.IsNotNull( data.Department );
        }

        [TestMethod]
        public void GetByNameAndDepartment_Test()
        {
            IEnumerable<Person_View> data = null;

            using ( IPerson_Service service = API.Container.GetInstance<IPerson_Service>() )
            {
                var response = service.GetByNameAndDepartment( new Person_Request { Name = "arq" } ); // Department: Arquitectura initially 2 Persons

                data = response.Items.ToList();
            }

            Assert.IsNotNull( data );
            Assert.IsTrue( data.Count() >= 2 );
            Assert.IsInstanceOfType( data, typeof( IEnumerable<Person_View> ) );
            Assert.IsTrue( data.Count() > 0 );
            data.ToList().ForEach( x => Assert.IsNotNull( x.Department ) );
        }

        [TestMethod]
        public void GetAll_Test()
        {
            IEnumerable<Person_View> data = null;

            using ( IPerson_Service service = API.Container.GetInstance<IPerson_Service>() )
            {
                var response = service.GetAll( new Person_Request() );

                data = response.Items.ToList();
            }

            Assert.IsNotNull( data );
            Assert.IsInstanceOfType( data, typeof( IEnumerable<Person_View> ) );
            Assert.IsTrue( data.Count() > 0 );
            data.ToList().ForEach( x => Assert.IsNotNull( x.Department ) );
        }


        [TestMethod]
        [ExpectedException( typeof( ValidationException ), "Max lenght name 100 characters." )]
        public void Add_Fail_Test()
        {
            Person_View data = null;

            using ( IPerson_Service service = API.Container.GetInstance<IPerson_Service>() )
            {
                var request = new Person_Request
                {
                    Item = new Person_View
                    {
                        IdDepartment = 2,
                        Name = new string('x', 101),
                        BirthDate = null,
                        Salary = 25M
                    }
                };

                var response = service.Add( request ); // Throws validation exception
            }
        }

    }
}
