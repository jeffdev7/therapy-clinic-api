using clinic.application.ViewModel;
using clinic.domain.Entities;
using AutoMapper;

namespace clinic.application.AutoMapper
{
    public sealed class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping() 
        {
            CreateMap<Appointment, AppointmentViewModel>();        
        }
    }
}