using es.eit.Common.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.application.Validations
{
    public class Default_Department_ValidationRules : ViewValidatorBase<IDepartment_ValidableFields>, IViewValidatorBase<IDepartment_ValidableFields>
    {
        #region Implements abstract class ViewValidatorBase<IDepartment_ValidableFields>
        protected override IEnumerable<ViewValidatorBase<IDepartment_ValidableFields>.Rule> Rules
        {
            get
            {
                return new Rule[] {
                                new Rule{ Test = new Func<IDepartment_ValidableFields,bool>( p => string.IsNullOrEmpty( p.Name ) ),
                                            Message = "Name can't be Null or Empty" },
                                new Rule{ Test = new Func<IDepartment_ValidableFields,bool>( p => !string.IsNullOrEmpty(p.Name) && p.Name.Length > 100 ),
                                            Message = "Name can't be larger than 100 characters" }
                };
            }
        }

        public override IEnumerable<IViewValidatorBase<IDepartment_ValidableFields>> IncludeValidators
        {
            get
            {
                return base.IncludeValidators;
            }
        }
        #endregion Implements abstract class ViewValidatorBase<IDepartment_ValidableFields>
    }
}
