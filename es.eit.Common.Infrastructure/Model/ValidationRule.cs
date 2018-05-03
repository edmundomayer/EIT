namespace es.eit.Common.Infrastructure.Model
{
    public class ValidationRule
    {
        #region Internals

        private string _id;
        private string _propertyName;
        private string _rule;

        #endregion Internals

        #region Constructors & Destructors

        public ValidationRule( string propertyName, string rule )
        {
            this._propertyName = propertyName;
            this._rule = rule;
        }

        public ValidationRule( string id, string propertyName, string rule )
            : this( propertyName, rule )
        {
            this._id = id;
        }

        #endregion Constructors & Destructors

        #region Properties

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        public string Rule
        {
            get { return _rule; }
            set { _rule = value; }
        }

        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events
    }
}
