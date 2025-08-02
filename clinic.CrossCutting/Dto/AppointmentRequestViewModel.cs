using System.ComponentModel.DataAnnotations;

namespace clinic.CrossCutting.Dto
{
    public class AppointmentRequestViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
        public NewAppointmentTimeSlotViewModel RequestedTime { get; set; }
    }
    public class AppointmentRequestIndexViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public AppointmentTimeSlotIndexViewModel RequestedTime { get; set; }
    }
    public class GetAppointmentRequestViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public TimeSlotViewModel RequestedTime { get; set; }
    }
}
