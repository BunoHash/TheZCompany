using AutoMapper;
using TheZ.Entities;
using TheZ.Shared.DataTransferObjects;

namespace TheZ.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForCtorParam("FullAddress",
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
        }
    }
}
