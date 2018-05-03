using es.eit.Common.Application.Views;
using es.eit.Common.Infrastructure.Model;
using System;
using System.Collections.Generic;

namespace es.eit.Common.Application.Messages
{

    public class RequestBase<T> : EntityBase<int>
    where T : IViewBase
    {
        #region Internal
        private Guid _messageId;
        #endregion Internal

        #region Constructors & Destructors
        public RequestBase()
        {
            this._messageId = Guid.NewGuid();
        }
        #endregion Constructors & Destructors

        #region Properties
        public Guid MessageId { get { return this._messageId; } }

        public virtual T Item { get; set; }

        public virtual IEnumerable<T> Items { get; set; }
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events
    }
}
