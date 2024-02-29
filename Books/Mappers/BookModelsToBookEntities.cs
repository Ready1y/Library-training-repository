using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Mappers
{
    public static class BookModelsToBookEntities
    {
        public static List<BookEntity> Convert(BookModel[] bookModels, IReadOnlyList<GenreEntity> genreEntities, IReadOnlyList<AuthorEntity> authorEntities, IReadOnlyList<PublisherEntity> publisherEntities)
        {
            if(bookModels == null)
            {
                throw new ArgumentNullException(nameof(bookModels), "Book models are null");
            }

            if (genreEntities == null)
            {
                throw new ArgumentNullException(nameof(genreEntities), "Genre entities are null");
            }

            if (authorEntities == null)
            {
                throw new ArgumentNullException(nameof(authorEntities), "Author entities are null");
            }

            if (publisherEntities == null)
            {
                throw new ArgumentNullException(nameof(publisherEntities), "Publisher entities are null");
            }

            List<BookEntity> bookEntities = new List<BookEntity>();

            foreach (BookModel bookModel in bookModels)
            {
                BookEntity bookEntity = bookEntities.FirstOrDefault(book => book.Title == bookModel.Title && book.Pages == bookModel.Pages && book.ReleaseDate == bookModel.ReleaseDate);

                if (bookEntity == null)
                {
                    bookEntity = new BookEntity();

                    bookEntity.Id = Guid.NewGuid();
                    bookEntity.Title = bookModel.Title;
                    bookEntity.Pages = bookModel.Pages;
                    bookEntity.ReleaseDate = bookModel.ReleaseDate;

                    bookEntity.Genres = new List<GenreEntity>();
                    bookEntity.Genres.Add(genreEntities.FirstOrDefault(genre => genre.Name == bookModel.Genre));

                    bookEntity.Authors = new List<AuthorEntity>();
                    bookEntity.Authors.Add(authorEntities.FirstOrDefault(author => author.Name == bookModel.Author));

                    bookEntity.Publishers = new List<PublisherEntity>();
                    bookEntity.Publishers.Add(publisherEntities.FirstOrDefault(publisher => publisher.Name == bookModel.Publisher));

                    bookEntities.Add(bookEntity);
                }
                else
                {
                    bookEntity.Genres.Add(genreEntities.FirstOrDefault(genre => genre.Name == bookModel.Genre));

                    bookEntity.Authors.Add(authorEntities.FirstOrDefault(author => author.Name == bookModel.Author));

                    bookEntity.Publishers.Add(publisherEntities.FirstOrDefault(publisher => publisher.Name == bookModel.Publisher));
                }
            }

            return bookEntities;
        }
    }
}
