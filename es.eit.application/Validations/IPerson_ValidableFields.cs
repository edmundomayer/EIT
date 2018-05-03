using es.eit.application.Views;
using es.eit.Common.Application.Validations;

namespace es.eit.application.Validations
{
    public interface IPerson_ValidableFields : IValidableFieldsBase<int>
    {
        int IdDepartment { get; set; }
        string Name { get; set; }
        decimal Salary { get; set; }
    }
}
