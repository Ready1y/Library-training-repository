using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;

namespace Books.Mappers
{
    public static class GenreMapper
    {
        public static IReadOnlyList<GenreEntity> GetEntities(IReadOnlyList<BookModel> bookModels)
        {
            if (bookModels == null)
            {
                throw new ArgumentNullException(nameof(bookModels), "Book models are null");
            }

            List<GenreEntity> genreEntities = new List<GenreEntity>(bookModels.Count);

            foreach (BookModel bookModel in bookModels)
            {
                GenreEntity genreEntity = GetEntity(bookModel);

                genreEntities.Add(genreEntity);
            }

            return genreEntities;
        }

        private static GenreEntity GetEntity(BookModel bookModel)
        {
            if(bookModel == null)
            {
                throw new ArgumentNullException(nameof(bookModel), "Book nodel is null");
            }

            GenreEntity genreEntity = new GenreEntity();

            genreEntity.Id = Guid.NewGuid();

            genreEntity.Name = bookModel.Genre;

            genreEntity.Books = new List<BookEntity>();

            return genreEntity;
        }
    }
}
