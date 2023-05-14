using AutoMapper;
using clinic.application.ViewModel;
using clinic.domain.Entities;

namespace clinic.application.AutoMapper
{
    public sealed class ViewModelDomainMapping : Profile
    { 
        public ViewModelDomainMapping() 
        {
            CreateMap<AppointmentViewModel, Appointment>();
        }

    }
}