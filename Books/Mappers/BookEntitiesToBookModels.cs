using Books.Entities;
using Books.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Mappers
{
    public static class BookEntitiesToBookModels
    {
        public static List<BookModel> Convert(IReadOnlyList<BookEntity> bookEntities)
        {
            if(bookEntities == null)
            {
                throw new ArgumentNullException(nameof(bookEntities), "Book entities are null");
            }

            List<BookModel> bookModels = new List<BookModel>();

            foreach (BookEntity bookEntity in bookEntities)
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

                bookModels.Add(bookModel);
            }

            return bookModels;
        }
    }
}
