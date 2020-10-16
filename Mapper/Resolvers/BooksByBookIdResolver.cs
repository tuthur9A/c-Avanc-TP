
using System;
using System.Collections.Generic;
using AutoMapper;
using TP.Collection;
using TP.DTO;
using TP.Repository.Book;

namespace TP.Resolvers
{
    /// <summary>
    /// Book resolver By Id.
    /// </summary>
    public class BookByBookIdResolver : IValueResolver<ShelveCollection, ShelveDTO, IEnumerable<BookDTO>>
    {
        private readonly IBooksRepository _booksRepository;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="usersRepository"></param>
        /// <param name="botsRepository"></param>
        /// <param name="mapper"></param>
        public BookByBookIdResolver(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        }

        /// <summary>
        /// Resolve.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="sourceMember"></param>
        /// <param name="context"></param>
        /// <returns>UserSetting id</returns>
        public IEnumerable<BookDTO> Resolve(ShelveCollection source, ShelveDTO destination, IEnumerable<BookDTO> returnMember, ResolutionContext context)
        {
            var elem = new List<BookDTO>(){};
            foreach(var bookId in source.BookIds) {
                var book = _booksRepository.GetBookById(bookId).Result;
                elem.Add(book);
            }
            
            return elem;
        }
    }
}
