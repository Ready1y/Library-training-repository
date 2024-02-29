using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;

namespace Books.Mappers
{
    public static class BookModelsToAuthorEntities
    {
        public static List<AuthorEntity> Convert(BookModel[] bookModels)
        {
            if (bookModels == null)
            {
                throw new ArgumentNullException(nameof(bookModels), "Book models are null");
            }

            List<AuthorEntity> authorEntities = new List<AuthorEntity>();

            foreach (BookModel bookModel in bookModels)
            {
                AuthorEntity authorEntity = new AuthorEntity();

                authorEntity.Id = Guid.NewGuid();

                authorEntity.Name = bookModel.Author;

                authorEntity.Books = new List<BookEntity>();

                authorEntities.Add(authorEntity);
            }

            return authorEntities;
        }
    }
}
