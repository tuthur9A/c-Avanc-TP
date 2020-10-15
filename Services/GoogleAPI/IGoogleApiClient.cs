using System.Net.Http;
using System.Threading.Tasks;

namespace TP.Services.GoogleAPI
{
    /// <summary>
    /// R client service interface.
    /// </summary>
    public interface IGoogleAPIClientService
    {
#pragma warning disable 1591
        Task<string> Search(string text);
    }
}
