using System.ComponentModel.DataAnnotations;

namespace clinic.CrossCutting.Dto
{
    public class AppointmentRequestViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public TimeSlotViewModel RequestedTime { get; set; }
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
