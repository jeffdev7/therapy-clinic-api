using clinic.domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace clinic.data.DBConfiguration
{
    public sealed class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<AppointmentRequest> RequestedAppointments { get; set; }
        public DbSet<AppointmentVacancy> AppointmentsVacancies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public ApplicationContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentRequest>().HasData(AppointmentRequest.Create(
                "Joe",
                "23112312332",
                "13123123123",
                "joe@outlook.com",
                new DateTime(2023, 05, 05)));

            modelBuilder.Entity<AppointmentRequest>().HasData(AppointmentRequest.Create(
                "Cleo",
                "317762332",
                "5567677676",
                "cleo@live.com",
                new DateTime(2023, 05, 06)));

            modelBuilder.Entity<AppointmentVacancy>().HasData(AppointmentVacancy.Create(
                [new DateTime(2023, 05, 06, 12, 30,00),
                new DateTime(2023, 05, 05, 15, 00, 00),
                new DateTime(2023, 05, 10, 15, 45, 00)]));

            base.OnModelCreating(modelBuilder);
        }
    }
}