using clinic.domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace clinic.data.DBConfiguration
{
    public sealed class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<AppointmentRequest> RequestedAppointments { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public ApplicationContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }
    }
}