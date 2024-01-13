using System;

namespace Books.Classes
{
    public class DBInstruments
    {
        public static void AddBook(Context context, ModelOfBook book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book is null");
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(book), "Context is null");
            }

            Guid guidOfGenre = AddGenre(context, book.Genre);
            Guid guidOfAuthor = AddAuthor(context, book.Author);
            Guid guidOfPublisher = AddPublisher(context, book.Publisher);

            foreach(var bookInContext in context.Books.Local)
            {
                if (bookInContext.Title == book.Title && bookInContext.Pages == book.Pages && bookInContext.GenreId == guidOfGenre && bookInContext.PublisherId == guidOfPublisher && bookInContext.AuthorId == guidOfAuthor)
                {
                    return;
                }
            }

            Book newBook = new Book(Guid.NewGuid(), book.Title, book.Pages, guidOfGenre, guidOfAuthor, guidOfPublisher, book.ReleaseDate);
            context.Books.Add(newBook);
        }

        private static Guid AddGenre(Context context, string genreName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context is null");
            }

            if(genreName == null)
            {
                throw new ArgumentNullException(nameof(genreName), "Genre name is null");
            }

            bool IsExist = false;
            Guid guid = Guid.Empty;

            foreach(var genre in context.Genres.Local)
            {
                if(genre.Name == genreName)
                {
                    IsExist = true;

                    guid = genre.Id;

                    break;
                }
            }

            if(!IsExist){
                guid = Guid.NewGuid();

                Genre newGenre = new Genre(guid, genreName);

                context.Genres.Add(newGenre);
            }

            return guid;
        }

        private static Guid AddAuthor(Context context, string authorName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context is null");
            }

            if (authorName == null)
            {
                throw new ArgumentNullException(nameof(authorName), "Author name is null");
            }

            bool IsExist = false;
            Guid guid = Guid.Empty;

            foreach (var author in context.Authors.Local)
            {
                if (author.Name == authorName)
                {
                    IsExist = true;

                    guid = author.Id;

                    break;
                }
            }

            if (!IsExist)
            {
                guid = Guid.NewGuid();

                Author newAuthor = new Author(guid, authorName);

                context.Authors.Add(newAuthor);
            }

            return guid;
        }

        private static Guid AddPublisher(Context context, string publisherName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context is null");
            }

            if (publisherName == null)
            {
                throw new ArgumentNullException(nameof(publisherName), "Publisher name is null");
            }

            bool IsExist = false;
            Guid guid = Guid.Empty;

            foreach (var publisher in context.Publishers.Local)
            {
                if (publisher.Name == publisherName)
                {
                    IsExist = true;

                    guid = publisher.Id;

                    break;
                }
            }

            if (!IsExist)
            {
                guid = Guid.NewGuid();

                Publisher newPublisher = new Publisher(guid, publisherName);

                context.Publishers.Add(newPublisher);
            }

            return guid;
        }
    }
}
