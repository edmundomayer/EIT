using es.eit.data.Sql.Implementations.Repositories;
using es.eit.model.Entitities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.Test.Data.Repositories
{
    [TestClass]
    public class Department_ENTITY_Repository_Tests
    {
        [TestMethod]
        public void Department_GetAll_Test()
        {
            Department_ENTITY_Repository repository = new Department_ENTITY_Repository();

            var result = repository.GetAll( navigationProperties: ( x => x.PersonList ) ).ToList();

            Assert.IsNotNull( result );
            Assert.IsTrue( result.Count > 0 );
            Assert.IsNotNull( result.First().PersonList );
            Assert.IsTrue( result.First().PersonList.Count > 0 );
        }

        [TestMethod]
        public void Add_Test()
        {
            Department_ENTITY_Repository repository = new Department_ENTITY_Repository();

            var newDepartment = new Department { Id = 300, Name = "Added item" };

            using ( var tempRepository = new Department_ENTITY_Repository() )
            {
                tempRepository.Add( newDepartment );
                tempRepository.SaveChanges();
            }

            var result = repository.GetById( newDepartment.Id );

            Assert.IsNotNull( result );
            Assert.IsNull( result.PersonList );
        }

        [TestMethod]
        public void Add_Range()
        {
            Department_ENTITY_Repository repository = new Department_ENTITY_Repository();

            var newDepartments = new List<Department> { new Department { Name = "Added item 1" },
                                                new Department { Name = "Added item 2" },
                                                new Department { Name = "Added item 3" },
                                                new Department { Name = "Added item 4" }};

            using ( var tempRepository = new Department_ENTITY_Repository() )
            {
                tempRepository.Add( newDepartments );
                tempRepository.SaveChanges();
            }

            var newIds = newDepartments.Select( s => s.Id ).ToArray();

            var result = repository.GetAll( filter: ( x => newIds.Contains( x.Id ) ) ).ToList();

            Assert.IsNotNull( result );
            Assert.IsTrue( result.Count > 0 );
            Assert.IsNull( result.First().PersonList );
        }
    }
}
