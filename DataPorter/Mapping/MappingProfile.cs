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
                .ForMember(dest => dest.Denomination, opt => opt.MapFrom(src => src.Name + ' ' + src.Surname))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            CreateMap<CustomerCreateDto, Customer>()
                .ForMember(dest => dest.Company, opt => opt.Ignore())
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src =>
                DateOnly.ParseExact(src.Birthdate, "yyyy-MM-dd")));

            CreateMap<CustomerUpdateDto, Customer>()
                .ForMember(dest => dest.Birthdate,
                    opt => {
                        opt.Condition(src => !string.IsNullOrEmpty(src.Birthdate));
                        opt.MapFrom(src => DateOnly.ParseExact(src.Birthdate!, "yyyy-MM-dd"));
                    })
                .ForMember(dest => dest.Company, opt => opt.Ignore())
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
