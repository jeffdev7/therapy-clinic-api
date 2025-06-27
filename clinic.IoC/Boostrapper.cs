using clinic.application.Services;
using clinic.application.Services.Interfaces;
using clinic.data.DBConfiguration;
using clinic.data.Repositories;
using clinic.domain.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace clinic.IoC
{
    public class Boostrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //repo
            services.AddScoped<IAppointmentRequestRepository, AppointmentRequestRepository>();
            services.AddScoped<IAppointmentVacancyRepository, AppointmentVacancyRepository>();

            //service
            services.AddScoped<IAppointmentRequestServices, AppointmentRequestServices>();
            services.AddScoped<IAppointmentVacancyServices, AppointmentVacancyServices>();

            services.AddDbContext<ApplicationContext>();
            //services.AddScoped<HttpContextAccessor>();

        }

    }
}
