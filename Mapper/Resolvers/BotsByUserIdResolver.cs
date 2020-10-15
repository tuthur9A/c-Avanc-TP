
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using AutoMapper;
// using Trizzy.API.Dto.Bot;
// using Trizzy.API.Dto.Identity;
// using Trizzy.API.Entities.User;
// using Trizzy.API.Infrastructure.Exceptions;
// using Trizzy.API.Infrastructure.Repositories.Bot;
// using Trizzy.API.Infrastructure.Repositories.User;
// using Trizzy.API.Utils.API;

// namespace Trizzy.API.Mappers.Resolvers
// {
//     /// <summary>
//     /// Bots resolver by User.
//     /// </summary>
//     public class BotsByUserIdResolver : IMemberValueResolver<UserEntity, IdentityProfileDTO, int, IEnumerable<BotDTO>>
//     {
//         private readonly IUsersRepository _usersRepository;
//         private readonly IBotsRepository _botsRepository;
//         private readonly IMapper _mapper;

//         /// <summary>
//         /// Constructor.
//         /// </summary>
//         /// <param name="usersRepository"></param>
//         /// <param name="botsRepository"></param>
//         /// <param name="mapper"></param>
//         public BotsByUserIdResolver(IUsersRepository usersRepository, IBotsRepository botsRepository, IMapper mapper)
//         {
//             _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
//             _botsRepository = botsRepository ?? throw new ArgumentNullException(nameof(botsRepository));
//             _mapper = mapper;
//         }

//         /// <summary>
//         /// Resolve.
//         /// </summary>
//         /// <param name="source"></param>
//         /// <param name="destination"></param>
//         /// <param name="sourceMember"></param>
//         /// <param name="returnMember"></param>
//         /// <param name="context"></param>
//         /// <returns>UserSetting id</returns>
//         public IEnumerable<BotDTO> Resolve(UserEntity source, IdentityProfileDTO destination, int sourceMember, IEnumerable<BotDTO> returnMember, ResolutionContext context)
//         {
//             var user = _usersRepository.GetAsync(sourceMember).Result;

//             if (user == null)
//             {
//                 throw new NotFoundException(ExceptionMessageUtil.NOT_FOUND);
//             }

//             return _mapper.Map<IEnumerable<BotDTO>>(_botsRepository.GetAllByIdsAsync(user.Bots.Select(b => b.BotId)).Result);
//         }
//     }
// }
