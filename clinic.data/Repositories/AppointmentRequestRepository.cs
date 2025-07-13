using clinic.data.DBConfiguration;
using clinic.domain.Entities;
using clinic.domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public AppointmentRequest GetAppointmentRequestById(Guid id)
        {
            return _context.RequestedAppointments
                 .Include(_ => _.RequestedTime)
                 .SingleOrDefault(_ => _.Id == id);
        }

    }
}