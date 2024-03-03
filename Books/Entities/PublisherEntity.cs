using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class PublisherEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookEntity> Books { get; set; }

        public bool Equals(PublisherEntity publisherEntity)
        {
            if (publisherEntity == null)
            {
                return false;
            }

            return Id.Equals(publisherEntity.Id) && 
                    Name == publisherEntity.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PublisherEntity))
            {
                return false;
            }

            return Equals((PublisherEntity)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
