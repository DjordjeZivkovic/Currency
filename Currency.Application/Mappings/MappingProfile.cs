using AutoMapper;
using Currency.Domain.Dtos;
using Currency.Domain.Models;

namespace Currency.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rate, RateDto>().ReverseMap();
        }
    }
}
