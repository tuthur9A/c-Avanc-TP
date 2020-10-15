using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP.Collection;
using TP.DTO;

namespace TP.Repository.Book
{
    /// <summary>
    /// R client service interface.
    /// </summary>
    public interface IBooksRepository
    {
#pragma warning disable 1591
        Task<BookDTO> GetBookById(string id);
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<BookDTO> AddBook(BookCollection book);
        Task<BookDTO> UpdateBook(string id, BookCollection updatedBook);
        Task DeleteBookById(string id);
    }
}
