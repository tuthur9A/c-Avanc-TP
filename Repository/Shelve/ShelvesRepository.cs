using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using TP.Collection;
using TP.Data;
using TP.DTO;

namespace TP.Repository.Shelve
{
    /// <summary>
    /// Book service.
    /// </summary>
    public class ShelvesRepository : IShelvesRepository
    {
        private readonly MessagingDbContext _context;
        private readonly IMapper _mapper;
        private readonly FilterDefinitionBuilder<ShelveCollection> _builderFilter;

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public ShelvesRepository(MessagingDbContext context, IMapper mapper)
        {
            _context = context;
            _builderFilter = Builders<ShelveCollection>.Filter;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// Get By Id.
        /// </summary>
        /// <param name="id"></param>
        public async Task<ShelveDTO> GetShelveById(string id) {
            var applyFilter = _builderFilter.Where(book => book.Id == id);
            var result = await _context.ShelveCollection.Find(applyFilter).FirstOrDefaultAsync();
            return _mapper.Map<ShelveDTO>(result);
        }

        /// <summary>
        /// Get All.
        /// </summary>
        public async Task<IEnumerable<ShelveDTO>> GetAllShelves() {
            var applyFilter = _builderFilter.Empty;
            var result = await _context.ShelveCollection.Find(applyFilter).ToListAsync();
            return _mapper.Map<IEnumerable<ShelveDTO>>(result);
        }

        /// <summary>
        /// Add.
        /// </summary>
        /// <param name="shelve"></param>
        public async Task<ShelveDTO> AddShelve(ShelveCollection shelve) {
            var applyFilter = _builderFilter.Where(shelveInDb => shelveInDb.BookId == shelve.BookId);
            if (await _context.ShelveCollection.Find(applyFilter).FirstOrDefaultAsync() != null) {
                throw new ArgumentException("the shelve with bookId " + shelve.BookId + " is already in db");
            }
            await _context.ShelveCollection.InsertOneAsync(shelve);
            var bookInserted = await _context.ShelveCollection.Find(applyFilter).FirstOrDefaultAsync();
            return _mapper.Map<ShelveDTO>(bookInserted);
        }

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedShelve"></param>
        public async Task<ShelveDTO> UpdateShelve(string id, ShelveCollection updatedShelve) {
            var applyFilter = _builderFilter.Where(shelveInDb => shelveInDb.Id == id);
            if (await _context.ShelveCollection.Find(applyFilter).FirstOrDefaultAsync() == null) {
                throw new Exception("the book with Id " + id + " is not in DB");
            }
             var update = Builders<ShelveCollection>.Update
                .Set("book_id", updatedShelve.BookId );
                await _context.ShelveCollection.UpdateOneAsync(applyFilter, update);
                var result = await _context.ShelveCollection.Find(applyFilter).FirstOrDefaultAsync();
            return _mapper.Map<ShelveDTO>(result);
        }

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteShelveById(string id) {
            var applyFilter = _builderFilter.Where(bookInDb => bookInDb.Id == id);
            await _context.ShelveCollection.DeleteOneAsync(applyFilter);
        }

    }
}