using es.eit.application.Views.ComplexViews;
using es.eit.Common.Infrastructure.Mappers;
using es.eit.model.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.application.Mappers
{
    public class Persons_By_Department_Mappers : ReadOnlyMapperBase<Persons_By_Department_View, Department>
    {
        public override Persons_By_Department_View ConvertToView( Department source )
        {
            if ( source == null )
                throw new ArgumentNullException();

            return new Persons_By_Department_View( source.ConvertToView() )
            {
                PersonList = ( source.PersonList == null ? null : source.PersonList.ConvertToView() )
            };
        }

        public override IEnumerable<Persons_By_Department_View> ConvertToView( IEnumerable<Department> source )
        {
            return source.ToList().Select( p => this.ConvertToView( p ) );
        }
    }
}
