using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;

namespace Books.Mappers
{
    public static class AuthorMapper
    {
        public static IReadOnlyList<AuthorEntity> GetEntities(IReadOnlyList<BookModel> bookModels)
        {
            if (bookModels == null)
            {
                throw new ArgumentNullException(nameof(bookModels), "Book models are null");
            }

            List<AuthorEntity> authorEntities = new List<AuthorEntity>(bookModels.Count);

            foreach (BookModel bookModel in bookModels)
            {
                AuthorEntity authorEntity = GetEntity(bookModel);

                authorEntities.Add(authorEntity);
            }

            return authorEntities;
        }
        
        private static AuthorEntity GetEntity(BookModel bookModel)
        {
            if (bookModel == null)
            {
                throw new ArgumentNullException(nameof(bookModel), "Book nodel is null");
            }

            AuthorEntity authorEntity = new AuthorEntity();

            authorEntity.Id = Guid.NewGuid();

            authorEntity.Name = bookModel.Author;

            authorEntity.Books = new List<BookEntity>();

            return authorEntity;
        }
    }
}
