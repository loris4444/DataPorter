using AutoMapper;
using DataPorter.Dto;
using DataPorter.Entity;

namespace DataPorter.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerBrowseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Denomination, opt => opt.MapFrom(src => src.Name + ' ' + src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.Company, opt => opt.Ignore());
            
            CreateMap<CustomerUpdateDto, Customer>()
                .ForMember(dest => dest.Company, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
