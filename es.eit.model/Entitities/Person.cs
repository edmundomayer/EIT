using es.eit.Common.Infrastructure.Model;
using System;

namespace es.eit.model.Entitities
{
    public class Person : EntityBase<int>
    {
        public int IdDepartment { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public decimal Salary { get; set; }

        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return string.Format( "Name: {0} - Department: {1}",
                this.Name,
                this.Department.ToString() );
        }
    }
}
