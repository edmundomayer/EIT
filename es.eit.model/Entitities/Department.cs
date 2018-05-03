using System.Collections.Generic;

namespace es.eit.model.Entitities
{
    public class Department : ModelBase
    {
        public string Name { get; set; }
        public virtual ICollection<Person> PersonList { get; set; }

        public override string ToString()
        {
            return string.Format( "Name: {0}",
                this.Name );
        }
    }
}
