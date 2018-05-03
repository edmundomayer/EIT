using es.eit.model.Entitities;
using System.Data.Entity.ModelConfiguration;

namespace es.eit.data.Sql.Implementations.Contexts.Maps
{
    class Department_Map : EntityTypeConfiguration<Department>
    {
        public Department_Map()
        {
            this.ToTable( "DEPARTMENTS" )
                .HasKey( x => x.Id );

            this.HasMany<Person>( x => x.PersonList )
                .WithRequired( x => x.Department )
                .HasForeignKey( x => x.IdDepartment );

            this.Property( x => x.Id )
                .HasDatabaseGeneratedOption( System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity );

            this.Property( x => x.Id ).HasColumnName( "ID" );
            this.Property( x => x.Name ).HasColumnName( "NAME" );
        }
    }
}
