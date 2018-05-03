using es.eit.Common.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace es.eit.Common.Infrastructure.Validations
{
    public abstract class ValidatorBase<T>
        where T : class, IEntityBase
    {
        #region Properties
        public class Rule
        {
            public Func<T, bool> Test { get; set; }

            public string Message { get; set; }
        }

        protected abstract IEnumerable<Rule> Rules { get; }
        #endregion Properties

        #region Methods
        public virtual IEnumerable<string> Validate( T t )
        {
            return this.Rules.Where( r => r.Test( t ) ).Select( r => r.Message );
        }
        #endregion Methods
    }
}
