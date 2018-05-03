using es.eit.Common.Application.Validations;

namespace es.eit.application.Validations
{
    public interface IDepartment_ValidableFields : IValidableFieldsBase<int>
    {
        string Name { get; set; }
    }
}
