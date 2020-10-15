using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP.DTO;

namespace TP.Services.Book
{
    /// <summary>
    /// R client service interface.
    /// </summary>
    public interface IBooksService
    {
#pragma warning disable 1591
        Task<BookDTO> GetBook(string id);
        Task<IEnumerable<BookDTO>> GetBooks();
        Task<BookDTO> PostBook(BookDTO book);
        Task<BookDTO> PutBook(string id, BookDTO updatedBook);
        Task DeleteBook(string id);
    }
}
