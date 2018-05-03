using es.eit.application.Validations;
using System;
using System.Runtime.Serialization;

namespace es.eit.application.Views
{
    [DataContract]
    public class Person_View : ViewBase, IPerson_ValidableFields
    {
        [DataMember]
        public int IdDepartment { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Nullable<DateTime> BirthDate { get; set; }

        [DataMember]
        public decimal Salary { get; set; }


        [DataMember]
        public virtual Department_View Department { get; set; }

        public override string ToString()
        {
            return string.Format( "Name: {0} - Department: {1}",
                this.Name,
                this.Department.ToString() );
        }
    }
}
