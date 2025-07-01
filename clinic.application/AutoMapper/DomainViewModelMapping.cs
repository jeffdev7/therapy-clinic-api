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
                .ForMember(dest => dest.RequestedTime, opt => opt.MapFrom(src => src.RequestedTime));
            CreateMap<AppointmentVacancy, AppointmentVacancyViewModel>();
            CreateMap<Schedule, ScheduleAppointmentRequestViewModel>();
            CreateMap<Schedule, ScheduleViewModel>();
            CreateMap<TimeSlot, TimeSlotViewModel>();
            CreateMap<TimeSlot, NewAppointmentTimeSlotViewModel>();
            CreateMap<AppointmentRequest, GetAppointmentRequestViewModel>();
        }
    }
}