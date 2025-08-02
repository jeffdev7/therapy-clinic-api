using clinic.application.Services;
using clinic.application.Services.Interfaces;
using clinic.data.DBConfiguration;
using clinic.data.Repositories;
using clinic.domain.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace clinic.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //repo
            services.AddScoped<IAppointmentRequestRepository, AppointmentRequestRepository>();
            services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //service
            services.AddScoped<IAppointmentRequestService, AppointmentRequestService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ITimeSlotService, TimeSlotService>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<ApplicationContext>();
            services.AddScoped<HttpContextAccessor>();
        }
    }
}
