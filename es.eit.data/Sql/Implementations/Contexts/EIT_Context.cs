using es.eit.Common.Infrastructure.Model;
using es.eit.data.Sql.Implementations.Contexts.Configuration;
using es.eit.data.Sql.Implementations.Contexts.Initializers;
using es.eit.data.Sql.Implementations.Contexts.Maps;
using es.eit.data.Sql.Interfaces.Contexts;
using es.eit.model.Entitities;
using System.Data.Entity;

namespace es.eit.data.Sql.Implementations.Contexts
{
    public partial class EIT_Context : DbContext, IEIT_Context
    {
        protected string _schema;

        public EIT_Context()
            : base( "name=EIT_Context" )
        {
            this._schema = ApplicationSettingsFactory.GetApplicationSettings().EIT_Schema;

            Database.SetInitializer<EIT_Context>( new SeedDatabaseInitializer() );

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.HasDefaultSchema( this._schema );

            Department_Map mappedDepartmentMap = new Department_Map();
            Person_Map mappedPersonMap = new Person_Map();

            modelBuilder.Configurations.Add( mappedDepartmentMap );
            modelBuilder.Configurations.Add( mappedPersonMap );
        }

        public new IDbSet<T> Set<T>() where T : class, IEntityBase
        {
            return base.Set<T>();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
