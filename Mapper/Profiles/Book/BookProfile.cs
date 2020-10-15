using AutoMapper;
using TP.Collection;
using TP.DTO;

namespace TP.Mappers.Profiles.Book
{
    /// <Summary>
    /// Slider profile.
    /// </Summary>
    public class BookProfile : Profile
    {
        /// <Summary>
        /// Constructor
        /// </Summary>
        public BookProfile()
        {
            CreateMap<BookDTO, BookCollection>();
            CreateMap<BookCollection, BookDTO>();

            CreateMap<ImageLinkDTO, ImageLinkCollection>();
            CreateMap<ImageLinkCollection, ImageLinkDTO>();

            CreateMap<IndustryIdentifierDTO, IndustryIdentifierCollection>();
            CreateMap<IndustryIdentifierCollection, IndustryIdentifierDTO>();

        }
    }
}
