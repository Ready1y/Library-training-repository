using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class GenreEntity : IEquatable<object>, IEquatable<GenreEntity>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookEntity> Books { get; set; }

        public bool Equals(GenreEntity genreEntity)
        {
            if (genreEntity == null)
            {
                return false;
            }

            return Id.Equals(genreEntity.Id)
                && Name == genreEntity.Name
            ;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GenreEntity);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
