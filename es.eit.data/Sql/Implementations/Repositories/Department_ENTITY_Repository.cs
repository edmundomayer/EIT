using es.eit.Common.Data.Repositories.Entity;
using es.eit.data.Sql.Implementations.Contexts;
using es.eit.model.Entitities;
using es.eit.model.Repositories;

namespace es.eit.data.Sql.Implementations.Repositories
{
    public class Department_ENTITY_Repository : GenericEntityRepository_RW<Department>, IDepartment_Repository
    {
        #region Internal
        #endregion Internal

        #region Constructors & Destructors
        public Department_ENTITY_Repository()
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

        #region Implements abstract class GenericEntityRepository_RW<Department>
        #endregion Implements abstract class GenericEntityRepository_RW<Department>

        #region Implements interface IDepartment_Repository
        #endregion Implements interface IDepartment_Repository
    }
}
