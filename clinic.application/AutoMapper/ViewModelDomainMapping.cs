using AutoMapper;
using clinic.CrossCutting.Dto;
using clinic.domain.Entities;

namespace clinic.application.AutoMapper
{
    public sealed class ViewModelDomainMapping : Profile
    {
        public ViewModelDomainMapping()
        {
            CreateMap<AppointmentRequestViewModel, AppointmentRequest>();
            CreateMap<GetAppointmentRequestViewModel, AppointmentRequest>();
            CreateMap<TimeSlotViewModel, TimeSlot>();
            CreateMap<NewAppointmentTimeSlotViewModel, TimeSlot>();

        }
    }
}