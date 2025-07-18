﻿using clinic.application.Services;
using clinic.application.Services.Interfaces;
using clinic.data.DBConfiguration;
using clinic.data.Repositories;
using clinic.domain.Repository.Interfaces;
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

            //service
            services.AddScoped<IAppointmentRequestServices, AppointmentRequestServices>();
            services.AddScoped<IScheduleServices, ScheduleServices>();
            services.AddScoped<ITimeSlotServices, TimeSlotServices>();

            services.AddDbContext<ApplicationContext>();
            //services.AddScoped<HttpContextAccessor>();

        }

    }
}
