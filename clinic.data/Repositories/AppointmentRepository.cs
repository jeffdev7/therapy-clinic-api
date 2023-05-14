using clinic.data.DBConfiguration;
using clinic.data.Repositories.Interfaces;
using clinic.domain.Entities;

namespace clinic.data.Repositories
{
    public sealed class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Appointment> GetAppointments()
        {
            return _context.Appointments;
        }
    }
}