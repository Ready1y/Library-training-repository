using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;

namespace Books.Mappers
{
    public static class BookModelsToPublisherEntities
    {
        public static List<PublisherEntity> Convert(BookModel[] bookModels)
        {
            if (bookModels == null)
            {
                throw new ArgumentNullException(nameof(bookModels), "Book models are null");
            }

            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();

            foreach (BookModel bookModel in bookModels)
            {
                PublisherEntity publisherEntity = new PublisherEntity();

                publisherEntity.Id = Guid.NewGuid();

                publisherEntity.Name = bookModel.Publisher;

                publisherEntity.Books = new List<BookEntity>();

                publisherEntities.Add(publisherEntity);
            }

            return publisherEntities;
        }
    }
}
