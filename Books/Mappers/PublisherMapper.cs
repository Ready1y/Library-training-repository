using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;

namespace Books.Mappers
{
    public static class PublisherMapper
    {
        public static IReadOnlyList<PublisherEntity> GetEntities(IReadOnlyList<BookModel> bookModels)
        {
            if (bookModels == null)
            {
                throw new ArgumentNullException(nameof(bookModels), "Book models are null");
            }

            List<PublisherEntity> publisherEntities = new List<PublisherEntity>(bookModels.Count);

            foreach (BookModel bookModel in bookModels)
            {
                PublisherEntity publisherEntity = GetEntity(bookModel);

                publisherEntities.Add(publisherEntity);
            }

            return publisherEntities;
        }

        private static PublisherEntity GetEntity(BookModel bookModel)
        {
            if (bookModel == null)
            {
                throw new ArgumentNullException(nameof(bookModel), "Book nodel is null");
            }

            PublisherEntity publisherEntity = new PublisherEntity();

            publisherEntity.Id = Guid.NewGuid();

            publisherEntity.Name = bookModel.Publisher;

            publisherEntity.Books = new List<BookEntity>();

            return publisherEntity;
        }
    }
}
