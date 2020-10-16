using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using TP.Collection;
using TP.CustomException;
using TP.DTO;
using TP.Filters;
using TP.Repository.Shelve;

namespace TP.Services.Shelve
{
    /// <summary>
    /// Book service.
    /// </summary>
    public class ShelvesService : IShelvesService
    {
        private readonly IShelvesRepository _shelvesRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="shelvesRepository"></param>
        /// <param name="mapper"></param>
        public ShelvesService(IShelvesRepository shelvesRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _shelvesRepository = shelvesRepository ?? throw new ArgumentNullException(nameof(shelvesRepository));
        }
        /// <summary>
        /// Get By Id.
        /// </summary>
        /// <param name="id"></param>
        public async Task<ShelveDTO> GetShelve(string id) {
            return await _shelvesRepository.GetShelveById(id);
        }

        /// <summary>
        /// Get All.
        /// </summary>
        public async Task<IEnumerable<ShelveDTO>> GetShelves(ShelvesFilters filters) {
            return await _shelvesRepository.GetAllShelves(filters);
        }

        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="shelve"></param>
        public async Task<ShelveDTO> PostShelve(ShelveCreateDTO shelve) {
            try
            {
                if (shelve.BookIds is null || shelve.BookIds.Count() == 0) {
                    throw new ArgumentNullException("bookIds is null");
                }
                
                return await _shelvesRepository.AddShelve(_mapper.Map<ShelveCollection>(shelve));
            }
            catch {
                throw;
            }
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedShelve"></param>
        public async Task<ShelveDTO> PutShelve(string id, ShelveCreateDTO updatedShelve) {
            if (id != updatedShelve.Id) {
                throw new BadRequestException("the id '" + id + "' is different of the DTO (dto id : '" + updatedShelve.Id + "') .");
            }
            return await _shelvesRepository.UpdateShelve(id, _mapper.Map<ShelveCollection>(updatedShelve));
        }

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteShelve(string id) {
            await _shelvesRepository.DeleteShelveById(id);
        }

    }
}