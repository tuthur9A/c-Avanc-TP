
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TP.Collection;
using TP.DTO;
using TP.Repository.Book;

namespace TP.Resolvers
{
    /// <summary>
    /// Book resolver By Id.
    /// </summary>
    public class BookByBookIdResolver : IValueResolver<ShelveCollection, ShelveDTO, BookDTO>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

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
        public BookDTO Resolve(ShelveCollection source, ShelveDTO destination, BookDTO returnMember, ResolutionContext context)
        {
            var book = _booksRepository.GetBookById(source.BookId).Result;
            return book;
        }
    }
}
