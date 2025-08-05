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
        public AppointmentRequest GetAppointmentRequestById(Guid id)
        {
            return _context.RequestedAppointments
                 .Include(_ => _.RequestedTime)
                 .SingleOrDefault(_ => _.Id == id);
        }
        public async Task AddAppointment(AppointmentRequest appointmentRequest)
        {
            _context.Add(appointmentRequest);
            await _context.SaveChangesAsync();
        }
        public AppointmentRequest GetAppointmentById(Guid id)
        {
            var appointment = _context.RequestedAppointments.Where(p => p.Id == id).SingleOrDefault();
            return appointment!;
        }
        public async Task RemoveAppointmentRequest(AppointmentRequest appointment)
        {
            _context.RequestedAppointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }
}