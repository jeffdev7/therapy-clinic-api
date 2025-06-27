using clinic.data.DBConfiguration;

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
        public int GetTotalOfAppointments()
        {
            return _context.Appointments.Count();
        }
    }
}