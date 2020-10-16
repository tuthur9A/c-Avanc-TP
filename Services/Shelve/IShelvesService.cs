using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP.Collection;
using TP.DTO;

namespace TP.Services.Shelve
{
    /// <summary>
    /// R client service interface.
    /// </summary>
    public interface IShelvesService
    {
#pragma warning disable 1591
        Task<ShelveDTO> GetShelve(string id);
        Task<IEnumerable<ShelveDTO>> GetShelves();
        Task<ShelveDTO> PostShelve(ShelveCreateDTO Shelve);
        Task<ShelveDTO> PutShelve(string id, ShelveCreateDTO updatedShelve);
        Task DeleteShelve(string id);
    }
}
