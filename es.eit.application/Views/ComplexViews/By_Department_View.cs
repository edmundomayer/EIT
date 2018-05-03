using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace es.eit.application.Views.ComplexViews
{
    [DataContract]
    public abstract class By_Department_View<T> : Department_View
        where T : ViewBase
    {
        public By_Department_View()
        { }

        public By_Department_View( Department_View source )
        {
            if ( source == null )
                throw new ArgumentNullException();

            this.Id = source.Id;
            this.Name = source.Name;
        }

        protected virtual IEnumerable<T> Items { get; set; }
    }
}
