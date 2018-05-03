using es.eit.application.Views;
using es.eit.Common.Infrastructure.Mappers;
using es.eit.model.Entitities;
using System;

namespace es.eit.application.Mappers
{
    public class Person_Mappers : ReadWriteMapperBase<Person_View, Person>
    {
        public override Person ConvertToModel( Person_View source )
        {
            if ( source == null )
                throw new ArgumentNullException();

            return new Person
            {
                Id = source.Id,
                IdDepartment = source.IdDepartment,
                Name = source.Name,
                BirthDate = source.BirthDate,
                Salary = source.Salary,
                Department = ( source.Department == null ? null : source.Department.ConvertToModel() )
            };
        }

        public override Person_View ConvertToView( Person source )
        {
            if ( source == null )
                throw new ArgumentNullException();

            return new Person_View
            {
                Id = source.Id,
                IdDepartment = source.IdDepartment,
                Name = source.Name,
                BirthDate = source.BirthDate,
                Salary = source.Salary,
                Department = ( source.Department == null ? null : source.Department.ConvertToView() )
            };
        }
    }
}
