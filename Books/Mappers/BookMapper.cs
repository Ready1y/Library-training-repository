using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Mappers
{
    public static class BookMapper
    {
        public static IReadOnlyList<BookEntity> GetEntities(IReadOnlyList<BookModel> bookModels, IReadOnlyList<GenreEntity> genreEntities, IReadOnlyList<AuthorEntity> authorEntities, IReadOnlyList<PublisherEntity> publisherEntities)
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
                    bookEntity = GetEntity(bookModel, genreEntities, authorEntities, publisherEntities);

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

        public static List<BookModel> GetModels(IReadOnlyList<BookEntity> bookEntities)
        {
            if (bookEntities == null)
            {
                throw new ArgumentNullException(nameof(bookEntities), "Book entities are null");
            }

            List<BookModel> bookModels = new List<BookModel>(bookEntities.Count);

            foreach (BookEntity bookEntity in bookEntities)
            {
                BookModel bookModel = GetModel(bookEntity);

                bookModels.Add(bookModel);
            }

            return bookModels;
        }

        private static BookModel GetModel(BookEntity bookEntity)
        {
            BookModel bookModel = new BookModel();

            bookModel.Title = bookEntity.Title;
            bookModel.Pages = bookEntity.Pages;
            bookModel.ReleaseDate = bookEntity.ReleaseDate;

            StringBuilder genreStringBuilder = new StringBuilder();
            foreach (GenreEntity genreEntity in bookEntity.Genres)
            {
                genreStringBuilder.Append(genreEntity.Name);
                genreStringBuilder.Append(';');
            }
            bookModel.Genre = genreStringBuilder.Remove(genreStringBuilder.Length - 1, 1).ToString();

            StringBuilder authorStringBuilder = new StringBuilder();
            foreach (AuthorEntity authorEntity in bookEntity.Authors)
            {
                authorStringBuilder.Append(authorEntity.Name);
                authorStringBuilder.Append(';');
            }
            bookModel.Author = authorStringBuilder.Remove(authorStringBuilder.Length - 1, 1).ToString();

            StringBuilder publisherStringBuilder = new StringBuilder();
            foreach (PublisherEntity publisherEntity in bookEntity.Publishers)
            {
                publisherStringBuilder.Append(publisherEntity.Name);
                publisherStringBuilder.Append(';');
            }
            bookModel.Publisher = publisherStringBuilder.Remove(publisherStringBuilder.Length - 1, 1).ToString();

            return bookModel;
        }

        private static BookEntity GetEntity(BookModel bookModel, IReadOnlyList<GenreEntity> genreEntities, IReadOnlyList<AuthorEntity> authorEntities, IReadOnlyList<PublisherEntity> publisherEntities)
        {
            if (bookModel == null)
            {
                throw new ArgumentNullException(nameof(bookModel), "Book model is null");
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

            BookEntity bookEntity = new BookEntity();

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

            return bookEntity;
        }
    }
}
