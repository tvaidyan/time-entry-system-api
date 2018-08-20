using System;
using AutoMapper;

namespace PtcRefunds
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<CreateEmployeeViewModel, Employee>()
                        .ForMember(dest => dest.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.Email.ToUpper()))
            .ForMember(dest => dest.CreatedDate, opt => opt.UseValue<DateTime>(DateTime.Now))
            .ForMember(dest => dest.UpdatedDate, opt => opt.UseValue<DateTime>(DateTime.Now))
            .ForMember(dest => dest.IsDeleted, opt => opt.UseValue<bool>(false))
            .ForMember(dest => dest.IsVisible, opt => opt.UseValue<bool>(true));
        }
    }
}