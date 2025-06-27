using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;

namespace clinic.data.Repositories
{
    public sealed class AppointmentRequestRepository : Repository<AppointmentRequest>, IAppointmentRequestRepository
    {
        public AppointmentRequestRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<AppointmentRequest> GetAppointments()
        {
            return _context.RequestedAppointments;
        }

    }
}