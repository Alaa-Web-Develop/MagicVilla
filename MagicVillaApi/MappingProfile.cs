using AutoMapper;
using MagicVillaApi.Dto;
using MagicVillaApi.Models;

namespace MagicVillaApi
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<Villa,VillaCreateDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

        }
    }
}
