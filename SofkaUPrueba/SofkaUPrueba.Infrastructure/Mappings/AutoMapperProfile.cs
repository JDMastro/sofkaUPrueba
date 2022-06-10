using AutoMapper;
using SofkaUPrueba.Core.DTOs;
using SofkaUPrueba.Core.Entities;

namespace SofkaUPrueba.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Players, PlayersDto>().ReverseMap();
            CreateMap<Players, LoginDto>().ReverseMap();
            CreateMap<History, HistoryDto>().ReverseMap();

            // CreateMap<PlayersDto, Players>();


        }
    }
}
