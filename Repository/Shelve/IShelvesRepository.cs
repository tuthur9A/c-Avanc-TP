using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP.Collection;
using TP.DTO;

namespace TP.Repository.Shelve
{
    /// <summary>
    /// R client service interface.
    /// </summary>
    public interface IShelvesRepository
    {
#pragma warning disable 1591
        Task<ShelveDTO> GetShelveById(string id);
        Task<IEnumerable<ShelveDTO>> GetAllShelves();
        Task<ShelveDTO> AddShelve(ShelveCollection Shelve);
        Task<ShelveDTO> UpdateShelve(string id, ShelveCollection updatedShelve);
        Task DeleteShelveById(string id);
    }
}
