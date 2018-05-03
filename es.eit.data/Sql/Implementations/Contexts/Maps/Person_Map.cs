using es.eit.model.Entitities;
using System.Data.Entity.ModelConfiguration;

namespace es.eit.data.Sql.Implementations.Contexts.Maps
{
    class Person_Map : EntityTypeConfiguration<Person>
    {
        public Person_Map()
        {
            this.ToTable( "PERSONS" )
                .HasKey( x => x.Id );

            this.Property( x => x.Id )
                .HasDatabaseGeneratedOption( System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity );

            this.Property( x => x.Id ).HasColumnName( "ID" );
            this.Property( x => x.IdDepartment ).HasColumnName( "ID_DEPARTMENT" );
            this.Property( x => x.Name ).HasColumnName( "NAME" );
            this.Property( x => x.BirthDate ).HasColumnName( "BIRTH_DATE" );
            this.Property( x => x.Salary ).HasColumnName( "SALARY" );
        }
    }
}
