using AutoMapper;
using clinic.CrossCutting.Dto;
using clinic.domain.Entities;

namespace clinic.application.AutoMapper
{
    public sealed class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping()
        {
            CreateMap<AppointmentRequest, AppointmentRequestViewModel>()
                .ForMember(dest => dest.RequestedTime, opt => opt.MapFrom(src => src.RequestedTime)).ReverseMap();
            //CreateMap<TimeSlot, TimeSlotViewModel>().ReverseMap();
            //CreateMap<TimeSlot, NewAppointmentTimeSlotViewModel>().ReverseMap();
            CreateMap<AppointmentRequest, GetAppointmentRequestViewModel>().ReverseMap();
            CreateMap<AppointmentRequest, AppointmentRequestIndexViewModel>().ReverseMap();

            CreateMap<TimeSlot, TimeSlotViewModel>().ReverseMap()
                .ForMember(dest => dest.Start, opt => opt.MapFrom(src =>
                    src.Start.Kind == DateTimeKind.Unspecified
                        ? DateTime.SpecifyKind(src.Start, DateTimeKind.Utc) : src.Start))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src =>
                    src.End.Kind == DateTimeKind.Unspecified
                        ? DateTime.SpecifyKind(src.End, DateTimeKind.Utc) : src.End));

            CreateMap<TimeSlot, NewAppointmentTimeSlotViewModel>().ReverseMap()
               .ForMember(dest => dest.Start, opt => opt.MapFrom(src =>
                   src.Start.Kind == DateTimeKind.Unspecified
                       ? DateTime.SpecifyKind(src.Start, DateTimeKind.Utc) : src.Start))
               .ForMember(dest => dest.End, opt => opt.MapFrom(src =>
                   src.End.Kind == DateTimeKind.Unspecified
                       ? DateTime.SpecifyKind(src.End, DateTimeKind.Utc) : src.End));

        }
    }
}