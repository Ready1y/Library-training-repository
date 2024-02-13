using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class PublisherEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookEntity> Books { get; set; }
    }
}
