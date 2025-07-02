using System.ComponentModel.DataAnnotations;

namespace clinic.CrossCutting.Dto
{
    public class ScheduleViewModel
    {
        [Key]
        public IEnumerable<TimeSlotViewModel> AvailableSlots { get; set; }
        public IEnumerable<AppointmentRequestViewModel> Appointments { get; set; }
    }
    public class ScheduleAppointmentRequestViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan SlotDuration { get; set; }
        public bool IsBooked { get; set; } = false;
    }
}
