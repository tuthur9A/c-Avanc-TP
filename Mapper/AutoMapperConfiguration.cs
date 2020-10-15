using AutoMapper;
using TP.Mappers.Profiles.Book;

namespace Trizzy.API.Mappers.API.Mappers
{
    /// <summary>
    /// Auto Mapper configuration.
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Mapper configuration.
        /// </summary>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BookProfile());
            });
        }
    }
}
