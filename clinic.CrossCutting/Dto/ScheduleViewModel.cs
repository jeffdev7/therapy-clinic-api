using clinic.domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace clinic.CrossCutting.Dto
{
    public class ScheduleViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public List<TimeSlot> AvailableSlots { get; set; }
        public List<AppointmentRequest> Appointments { get; set; }
    }
}
