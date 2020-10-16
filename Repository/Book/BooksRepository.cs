using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using TP.Collection;
using TP.CustomException;
using TP.Data;
using TP.DTO;
using TP.Filters;

namespace TP.Repository.Book
{
    /// <summary>
    /// Book service.
    /// </summary>
    public class BooksRepository : IBooksRepository
    {
        private readonly MessagingDbContext _context;
        private readonly IMapper _mapper;
        private readonly FilterDefinitionBuilder<BookCollection> _builderFilter;

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public BooksRepository(MessagingDbContext context, IMapper mapper)
        {
            _context = context;
            _builderFilter = Builders<BookCollection>.Filter;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="id"></param>
        public async Task<BookDTO> GetBookById(string id) {
            var applyFilter = _builderFilter.Where(book => book.Id == id);
            var result = await _context.BookCollection.Find(applyFilter).FirstOrDefaultAsync();
            if (result is null) {
                throw new NotFoundException("the book id '" + id + "' can't be found");
            }
            return _mapper.Map<BookDTO>(result);
        }

        /// <summary>
        /// Consutructor.
        /// </summary>
        public async Task<IEnumerable<BookDTO>> GetAllBooks(BooksFilters filters) {
            var applyFilter = _builderFilter.Empty;
            if (filters.FilterByTitle != null ) {
                applyFilter = _builderFilter.Where(book => book.Title.Contains(filters.FilterByTitle));
                
            }
            var result = await _context.BookCollection.Find(applyFilter).SortBy(book => book.Authors).Skip(filters.pageSize * (filters.pageNumber - 1)).ToListAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(result);
        }

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="book"></param>
        public async Task<BookDTO> AddBook(BookCollection book) {
            var applyFilter = _builderFilter.Where(bookInDb => bookInDb.Title == book.Title);
            if (await _context.BookCollection.Find(applyFilter).FirstOrDefaultAsync() != null) {
                throw new AlreadyInDBException("the book " + book.Title + " is already in db");
            }
            await _context.BookCollection.InsertOneAsync(book);
            var bookInserted = await _context.BookCollection.Find(applyFilter).FirstOrDefaultAsync();
            return _mapper.Map<BookDTO>(bookInserted);
        }

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateBook"></param>
        public async Task<BookDTO> UpdateBook(string id, BookCollection updatedBook) {
            var applyFilter = _builderFilter.Where(bookInDb => bookInDb.Id == id);
            if (await _context.BookCollection.Find(applyFilter).FirstOrDefaultAsync() == null) {
                throw new NotFoundException("the book with Id " + id + " is not in DB");
            }
             var update = Builders<BookCollection>.Update
                .Set("title", updatedBook.Title )
                .Set("authors", updatedBook.Authors)
                .Set("averageRating", updatedBook.AverageRating )
                .Set("imageLinks", updatedBook.ImageLinks )
                .Set("industryIdentifiers", updatedBook.IndustryIdentifiers )
                .Set("infoLink", updatedBook.InfoLink)
                .Set("language", updatedBook.Language )
                .Set("pageCount", updatedBook.PageCount)
                .Set("previewLink", updatedBook.PreviewLink )
                .Set("printType", updatedBook.PrintType)
                .Set("publishedDate", updatedBook.PublishedDate )
                .Set("publisher", updatedBook.Publisher )
                .Set("ratingsCount", updatedBook.RatingsCount );
                await _context.BookCollection.UpdateOneAsync(applyFilter, update);
                var result = await _context.BookCollection.Find(applyFilter).FirstOrDefaultAsync();
            return _mapper.Map<BookDTO>(result);
        }

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteBookById(string id) {
            var applyFilter = _builderFilter.Where(bookInDb => bookInDb.Id == id);
            await _context.BookCollection.DeleteOneAsync(applyFilter);
        }

    }
}