using es.eit.application.Views;
using es.eit.Common.Infrastructure.Mappers;
using es.eit.model.Entitities;
using System;

namespace es.eit.application.Mappers
{
    public class Department_Mappers : ReadWriteMapperBase<Department_View, Department>
    {
        public override Department ConvertToModel( Department_View source )
        {
            if ( source == null )
                throw new ArgumentNullException();

            return new Department
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        public override Department_View ConvertToView( Department source )
        {
            if ( source == null )
                throw new ArgumentNullException();

            return new Department_View
            {
                Id = source.Id,
                Name = source.Name
            };
        }
    }
}
