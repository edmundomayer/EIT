using System.Collections.Generic;
using System.Runtime.Serialization;

namespace es.eit.application.Views.ComplexViews
{
    [DataContract]
    public class Persons_By_Department_View : By_Department_View<Person_View>
    {
        public Persons_By_Department_View()
        { }

        public Persons_By_Department_View( Department_View source )
            : base( source )
        { }

        [DataMember]
        public IEnumerable<Person_View> PersonList
        {
            get { return base.Items; }
            set { base.Items = value; }
        }

        public override string ToString()
        {
            return string.Format( "{0} - Persons: {1}",
                base.ToString(),
                ( this.PersonList != null ?
                    this.PersonList.ToString() :
                    "{empty}" ) );
        }
    }
}
