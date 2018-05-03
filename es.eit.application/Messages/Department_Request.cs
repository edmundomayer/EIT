using es.eit.application.Views;
using es.eit.Common.Application.Messages;

namespace es.eit.application.Messages
{
    public class Department_Request : RequestBase<Department_View>
    {
        public string Name { get; set; }
    }
}
