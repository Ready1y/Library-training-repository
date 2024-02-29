using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;

namespace Books.Mappers
{
    public static class BookModelsToGenreEntities
    {
        public static List<GenreEntity> Convert(BookModel[] bookModels)
        {
            if (bookModels == null)
            {
                throw new ArgumentNullException(nameof(bookModels), "Book models are null");
            }

            List<GenreEntity> genreEntities = new List<GenreEntity>();

            foreach (BookModel bookModel in bookModels)
            {
                GenreEntity genreEntity = new GenreEntity();

                genreEntity.Id = Guid.NewGuid();

                genreEntity.Name = bookModel.Genre;

                genreEntity.Books = new List<BookEntity>();

                genreEntities.Add(genreEntity);
            }

            return genreEntities;
        }
    }
}
