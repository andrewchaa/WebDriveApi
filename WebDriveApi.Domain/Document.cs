using System;

namespace WebDriveApi.Domain
{
    public class Document : DomainEntity
    {
        public virtual string FullName { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime LastUpdate { get; set; }
        public virtual long DownloadCount { get; set; }

        protected bool Equals(Document other)
        {
            return string.Equals(FullName, other.FullName) && string.Equals(Name, other.Name) && LastUpdate.Equals(other.LastUpdate) 
                && DownloadCount.Equals(other.DownloadCount);
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
                int hashCode = (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ LastUpdate.GetHashCode();
                hashCode = (hashCode*397) ^ DownloadCount.GetHashCode();
                return hashCode;
            }
        }
    }
}
