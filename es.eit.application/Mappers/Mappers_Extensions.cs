using es.eit.application.Views;
using es.eit.application.Views.ComplexViews;
using es.eit.model.Entitities;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.application.Mappers
{
    public static class Mappers_Extensions
    {
        public static Department ConvertToModel( this Department_View source )
        {
            return new Department_Mappers().ConvertToModel( source );
        }

        public static Department_View ConvertToView( this Department source )
        {
            return new Department_Mappers().ConvertToView( source );
        }

        public static IEnumerable<Department> ConvertToModel( this IEnumerable<Department_View> source )
        {
            return new Department_Mappers().ConvertToModel( source ).ToList();
        }

        public static IEnumerable<Department_View> ConvertToView( this IEnumerable<Department> source )
        {
            return new Department_Mappers().ConvertToView( source ).ToList();
        }




        public static Person ConvertToModel( this Person_View source )
        {
            return new Person_Mappers().ConvertToModel( source );
        }

        public static Person_View ConvertToView( this Person source )
        {
            return new Person_Mappers().ConvertToView( source );
        }

        public static IEnumerable<Person> ConvertToModel( this IEnumerable<Person_View> source )
        {
            return new Person_Mappers().ConvertToModel( source ).ToList();
        }

        public static IEnumerable<Person_View> ConvertToView( this IEnumerable<Person> source )
        {
            return new Person_Mappers().ConvertToView( source ).ToList();
        }




        public static Persons_By_Department_View ConvertToPersons_By_DepartmentView( this Department source )
        {
            return new Persons_By_Department_Mappers().ConvertToView( source );
        }

        public static IEnumerable<Persons_By_Department_View> ConvertToPersons_By_DepartmentView( this IEnumerable<Department> source )
        {
            return new Persons_By_Department_Mappers().ConvertToView( source ).ToList();
        }
    }
}
