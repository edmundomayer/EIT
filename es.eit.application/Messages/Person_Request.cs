using es.eit.application.Views;
using es.eit.Common.Application.Messages;
using System;

namespace es.eit.application.Messages
{
    public class Person_Request : RequestBase<Person_View>
    {
        public string Name { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public decimal Salary { get; set; }


        public string SearchCriteria { get; set; }
    }
}
