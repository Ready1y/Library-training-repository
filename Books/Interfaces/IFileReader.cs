using Books.Models;
using System.Collections.Generic;

namespace Books.Interfaces
{
    public interface IFileReader
    {
        IReadOnlyList<BookModel> Read(string filePath);
    }
}