using es.eit.Common.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.application.Validations
{
    public class Default_Person_ValidationRules : ViewValidatorBase<IPerson_ValidableFields>, IViewValidatorBase<IPerson_ValidableFields>
    {
        #region Implements abstract class ViewValidatorBase<IPerson_ValidableFields>
        protected override IEnumerable<ViewValidatorBase<IPerson_ValidableFields>.Rule> Rules
        {
            get
            {
                return new Rule[] {
                                new Rule{ Test = new Func<IPerson_ValidableFields,bool>( p => string.IsNullOrEmpty( p.Name ) ),
                                            Message = "Name can't be Null or Empty" },
                                new Rule{ Test = new Func<IPerson_ValidableFields,bool>( p => !string.IsNullOrEmpty(p.Name) && p.Name.Length > 100 ),
                                            Message = "Name can't be larger than 100 characters" },
                                new Rule{ Test = new Func<IPerson_ValidableFields,bool>( p => p.Salary == 0M ),
                                            Message = "Salary can't be zero" },
                                new Rule{ Test = new Func<IPerson_ValidableFields,bool>( p => p.IdDepartment == 0 ),
                                            Message = "Department must be specified" }
                };
            }
        }

        public override IEnumerable<IViewValidatorBase<IPerson_ValidableFields>> IncludeValidators
        {
            get
            {
                return base.IncludeValidators;
            }
        }
        #endregion Implements abstract class ViewValidatorBase<IPerson_ValidableFields>
    }
}
