using es.eit.Common.Data.Repositories.Entity;
using es.eit.data.Sql.Implementations.Contexts;
using es.eit.model.Entitities;
using es.eit.model.Repositories;

namespace es.eit.data.Sql.Implementations.Repositories
{
    public class Person_ENTITY_Repository : GenericEntityRepository_RW<Person>, IPerson_Repository
    {
        #region Internal
        #endregion Internal

        #region Constructors & Destructors
        public Person_ENTITY_Repository()
            : base( new EIT_Context() )
        { }
        #endregion Constructors & Destructors

        #region Properties
        protected new EIT_Context Context
        {
            get { return ( EIT_Context ) base.Context; }
        }
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events

        #region Implements abstract class GenericEntityRepository_RW<Person>
        #endregion Implements abstract class GenericEntityRepository_RW<Person>

        #region Implements interface IPerson_Repository
        #endregion Implements interface IPerson_Repository
    }
}
