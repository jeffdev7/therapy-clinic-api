using System.ComponentModel.DataAnnotations;

namespace clinic.CrossCutting.Dto
{
    public class ScheduleViewModel
    {
        [Key]
        public IEnumerable<TimeSlotViewModel> AvailableSlots { get; set; }
        public IEnumerable<AppointmentRequestViewModel> Appointments { get; set; }
    }
}
