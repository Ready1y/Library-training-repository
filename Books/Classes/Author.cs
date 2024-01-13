using System;
using System.Collections.Generic;

namespace Books.Classes
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public Author(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
