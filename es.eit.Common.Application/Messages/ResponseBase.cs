using es.eit.Common.Infrastructure.Model;
using System;
using System.Collections.Generic;

namespace es.eit.Common.Application.Messages
{
    public class ResponseBase<T> : EntityBase<Guid>
        where T : class
    {
        #region Internal
        private Guid _messageId;
        #endregion Internal

        #region Constructors & Destructors
        public ResponseBase( Guid requestMessageId )
        {
            this._messageId = requestMessageId;
        }

        #endregion Constructors & Destructors

        #region Properties
        public Guid MessageId { get { return this._messageId; } }

        public virtual bool Succeed { get; set; }

        public virtual T Item { get; set; }

        public virtual IEnumerable<T> Items { get; set; }
        public string Message { get; set; }
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Events
        #endregion Events
    }
}
