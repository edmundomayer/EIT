using es.eit.application.Validations;
using System.Runtime.Serialization;

namespace es.eit.application.Views
{
    [DataContract]
    public class Department_View : ViewBase, IDepartment_ValidableFields
    {
        [DataMember]
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format( "Name: {0}", this.Name );
        }
    }
}
