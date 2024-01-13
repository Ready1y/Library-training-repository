using System;
using System.Collections.Generic;

namespace Books.Classes
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public Publisher(Guid id, string name) 
        {
            Id = id;   
            Name = name;
        }
    }
}
