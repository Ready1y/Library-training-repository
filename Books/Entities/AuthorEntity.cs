using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookEntity> Books { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AuthorEntity entity &&
                   Id.Equals(entity.Id) &&
                   Name == entity.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
