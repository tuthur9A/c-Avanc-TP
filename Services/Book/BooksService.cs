using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TP.Collection;
using TP.DTO;
using TP.Repository.Book;

namespace TP.Services.Book
{
    /// <summary>
    /// Book service.
    /// </summary>
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Consutructor.
        /// </summary>
        /// <param name="booksRepository"></param>
        /// <param name="mapper"></param>
        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// get book by id.
        /// </summary>
        /// <param name="id"></param>
        public async Task<BookDTO> GetBook(string id) {
            return await _booksRepository.GetBookById(id);
        }
        /// <summary>
        /// get books .
        /// </summary>
        public async Task<IEnumerable<BookDTO>> GetBooks() {
            return await _booksRepository.GetAllBooks();
        }
        /// <summary>
        /// post book .
        /// </summary>
        /// <param name="book"></param>
        public async Task<BookDTO> PostBook(BookDTO book) {
            try {
                return await _booksRepository.AddBook(_mapper.Map<BookCollection>(book));
            }
            catch {
                throw;
            }
            
        }

        /// <summary>
        /// put book by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBook"></param>
        public async Task<BookDTO> PutBook(string id, BookDTO updatedBook) {
            return await _booksRepository.UpdateBook(id, _mapper.Map<BookCollection>(updatedBook));
        }

        /// <summary>
        /// delet book by id.
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteBook(string id) {
            await _booksRepository.DeleteBookById(id);
        }
    }
}