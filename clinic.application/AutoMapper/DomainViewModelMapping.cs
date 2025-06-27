using AutoMapper;
using clinic.CrossCutting.Dto;
using clinic.domain.Entities;

namespace clinic.application.AutoMapper
{
    public sealed class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping()
        {
            CreateMap<AppointmentRequest, AppointmentRequestViewModel>();
            CreateMap<AppointmentVacancy, AppointmentVacancyViewModel>();
        }
    }
}