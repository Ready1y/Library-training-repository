using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookEntity> Books { get; set; }

        public AuthorEntity(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
