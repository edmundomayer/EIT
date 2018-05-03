using es.eit.application.Mappers;
using es.eit.application.Views.ComplexViews;
using es.eit.data.Sql.Implementations.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.Test.Application.Mappers
{
    [TestClass]
    public class Persons_By_Department_Mappers_Tests
    {
        [TestMethod]
        public void ConvertToView_Test()
        {
            Department_ENTITY_Repository repository = new Department_ENTITY_Repository();

            var result = repository.GetAll( navigationProperties: ( x => x.PersonList ) ).ConvertToPersons_By_DepartmentView().ToList();

            Assert.IsNotNull( result );
            Assert.IsTrue( result.Count() > 0 );
            Assert.IsInstanceOfType( result, typeof( IEnumerable<Persons_By_Department_View> ) );
            Assert.IsNotNull( result.First().PersonList );
            Assert.IsTrue( result.First().PersonList.Count() > 0 );
        }
    }
}
