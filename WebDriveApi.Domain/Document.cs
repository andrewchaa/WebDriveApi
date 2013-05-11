using System;

namespace WebDriveApi.Domain
{
    public class Document : DomainEntity
    {
        public virtual string Title { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime LastUpdate { get; set; }

        protected bool Equals(Document other)
        {
            return string.Equals(Title, other.Title) && string.Equals(FullName, other.FullName) && string.Equals(Name, other.Name) && LastUpdate.Equals(other.LastUpdate);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Document) obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ LastUpdate.GetHashCode();
                return hashCode;
            }
        }
    }
}
