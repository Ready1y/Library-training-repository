using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class PublisherEntity : IEquatable<object>, IEquatable<PublisherEntity>
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

            return Id.Equals(publisherEntity.Id)
                && Name == publisherEntity.Name
            ;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PublisherEntity);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
