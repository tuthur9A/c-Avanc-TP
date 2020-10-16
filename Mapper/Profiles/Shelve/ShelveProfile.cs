using AutoMapper;
using TP.Collection;
using TP.DTO;
using TP.Resolvers;

namespace TP.Mappers.Profiles.Shelve
{
    /// <Summary>
    /// Slider profile.
    /// </Summary>
    public class ShelveProfile : Profile
    {
        /// <Summary>
        /// Constructor
        /// </Summary>
        public ShelveProfile()
        {
            CreateMap<ShelveDTO, ShelveCollection>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Book.Id))
            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ShelveCollection, ShelveDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Book, opt => opt.MapFrom<BookByBookIdResolver>())
            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ShelveCreateDTO, ShelveCollection>();
            CreateMap<ShelveCollection, ShelveCreateDTO>();

        }
    }
}
