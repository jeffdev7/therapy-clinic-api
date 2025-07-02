namespace clinic.domain.Entities
{
    public class Schedule : BaseEntity
    {
        public List<TimeSlot> AvailableSlots { get; set; } = new List<TimeSlot>();
        public List<AppointmentRequest> Appointments { get; set; } = new List<AppointmentRequest>();

        public static Schedule Create(List<TimeSlot> AvailableSlots,
            List<AppointmentRequest> AppointmentRequests) =>
            new()
            {
                Appointments = AppointmentRequests,
                AvailableSlots = AvailableSlots
            };
    }
}