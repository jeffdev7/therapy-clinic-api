using System.ComponentModel.DataAnnotations;

namespace clinic.CrossCutting.Dto
{
    public class TimeSlotViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsBooked { get; set; } = false;
    }
    public class NewAppointmentTimeSlotViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public class AppointmentTimeSlotIndexViewModel
    {
        [Key]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
