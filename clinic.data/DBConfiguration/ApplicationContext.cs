using clinic.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace clinic.data.DBConfiguration
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext>options) 
            :base(options){ }

        public ApplicationContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 1,
                PatientName = "Joe",
                DocumentNumber = "23112312332",
                Phone = "13123123123",
                Email = "joe@outlook.com",
                AppointmentTime = new DateTime(2023, 05, 05)
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 2,
                PatientName = "Light",
                DocumentNumber = "6969696332",
                Phone = "16799843",
                Email = "light@gmail.com",
                AppointmentTime = new DateTime(2023, 05, 10)
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                Id = 3,
                PatientName = "Cleo",
                DocumentNumber = "317762332",
                Phone = "5567677676",
                Email = "cleo@live.com",
                AppointmentTime = new DateTime(2023, 05, 06)
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}