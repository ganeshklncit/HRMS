using AutoMapper;
using HRMS.Web.Data;
using HRMS.Web.Models.LeaveTypes;
using Microsoft.CodeAnalysis.Options;

namespace HRMS.Web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>()
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));

            CreateMap<LeaveTypeCreateVM, LeaveType>()
                .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Days)); 

            CreateMap<LeaveType, LeaveTypeEditVM>()
               .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays))
               .ReverseMap(); 
        }
    }
}
