using System.Threading.Tasks;
using TP.Filters;

namespace TP.Services.GoogleAPI
{
    /// <summary>
    /// R client service interface.
    /// </summary>
    public interface IGoogleAPIClientService
    {
#pragma warning disable 1591
        Task<string> Search(GoogleAPIFilters filters);
    }
}
