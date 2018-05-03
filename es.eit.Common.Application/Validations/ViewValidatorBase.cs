using es.eit.Common.Infrastructure.Validations;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.Common.Application.Validations
{
    public class ViewValidatorBase<T> : ValidatorBase<T>, IViewValidatorBase<T>
        where T : class, IValidableFieldsBase
    {
        #region Properties
        public virtual IEnumerable<IViewValidatorBase<T>> IncludeValidators
        {
            get { return null; }

        }
        #endregion Properties

        #region Implements abstract class ValidatorBase<T>
        public override IEnumerable<string> Validate( T t )
        {
            List<string> result = new List<string>();
            if ( this.IncludeValidators != null )
                result.AddRange( this.IncludeValidators.SelectMany( p => p.Validate( t ) ) );

            result.AddRange( base.Validate( t ) );

            return result;
        }

        #endregion Implements abstract class ValidatorBase<T>

        #region Implements interface IViewValidatorBase<T>
        IEnumerable<string> IViewValidatorBase.Validate( IValidableFieldsBase t )
        {
            return this.Validate( ( T ) t );
        }
        #endregion Implements interface IViewValidatorBase<T>

        protected override IEnumerable<Rule> Rules { get; }
    }
}
