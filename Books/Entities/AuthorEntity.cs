using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookEntity> Books { get; set; }

        public bool Equals(AuthorEntity authorEntity)
        {
            if(authorEntity == null)
            {
                return false;
            }

            return Id.Equals(authorEntity.Id) &&
                    Name == authorEntity.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is AuthorEntity))
            {
                return false;
            }

            return Equals((AuthorEntity)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
