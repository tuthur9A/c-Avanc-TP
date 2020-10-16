using System.Collections.Generic;
using System.Threading.Tasks;
using TP.DTO;
using TP.Filters;

namespace TP.Services.Shelve
{
    /// <summary>
    /// R client service interface.
    /// </summary>
    public interface IShelvesService
    {
#pragma warning disable 1591
        Task<ShelveDTO> GetShelve(string id);
        Task<IEnumerable<ShelveDTO>> GetShelves(ShelvesFilters filters);
        Task<IEnumerable<BookDTO>> SearchBooksInShelves(IEnumerable<BookDTO> resultSearch);
        Task<ShelveDTO> PostShelve(ShelveCreateDTO Shelve);
        Task<ShelveDTO> AddBookToShelve(string bookId, string shelveId);
        Task<ShelveDTO> DeleteBookFromShelve(string bookId, string shelveId);
        Task<ShelveDTO> PutShelve(string id, ShelveCreateDTO updatedShelve);
        Task DeleteShelve(string id);
    }
}
