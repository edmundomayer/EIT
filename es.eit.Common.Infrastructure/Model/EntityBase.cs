using System.Runtime.Serialization;

namespace es.eit.Common.Infrastructure.Model
{
    [DataContract]
    public abstract class EntityBase<TId> : IEntityBase<TId>
        where TId : struct
    {
        #region Internals
        private TId _id;
        #endregion Internals

        #region Constructors & Destructors
        #endregion Constructors & Destructors

        #region Properties
        [DataMember]
        public virtual TId Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion Properties

        #region Methods
        public override bool Equals( object entity )
        {
            return ( entity != null ) &&
                ( entity.GetType() is EntityBase<TId> ) &&
                ( this.Id.Equals( ( ( EntityBase<TId> ) entity ).Id ) );
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==( EntityBase<TId> entity1, EntityBase<TId> entity2 )
        {
            if ( ( ( ( object ) entity1 ) == null ) && ( ( ( object ) entity2 ) == null ) )
                return true;
            if ( ( ( ( object ) entity1 ) == null ) || ( ( ( object ) entity2 ) == null ) )
                return false;
            if ( entity1.Id.ToString() == entity2.Id.ToString() )
                return true;

            return false;
        }

        public static bool operator !=( EntityBase<TId> entity1, EntityBase<TId> entity2 )
        {
            return !( entity1 == entity2 );
        }
        #endregion Methods

        #region Events
        #endregion Events


        #region Implements interface IEntityBase<TId>
        TId IEntityBase<TId>.Id
        {
            get { return this.Id; }
        }

        object IEntityBase.Id
        {
            get { return this.Id; }
        }
        #endregion Implements interface IEntityBase<TId>
    }
}
