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

        public void GenerateTimeSlots(DateTime day, TimeSpan startTime, TimeSpan endTime, TimeSpan slotDuration)
        {
            AvailableSlots.Clear();
            DateTime current = day.Date + startTime;

            while (current + slotDuration <= day.Date + endTime)
            {
                AvailableSlots.Add(TimeSlot.Create(current, current + slotDuration, false));

                current = current + slotDuration;
            }
        }
        //private bool BookAppointment(DateTime start, string clientName, string documentNumber, string phone, string email)
        //{
        //    var slot = AvailableSlots.FirstOrDefault(s => s.Start == start && !s.IsBooked);
        //    if (slot == null) return false;

        //    slot.IsBooked = true;

        //    Appointments.Add(AppointmentRequest.Create(clientName, documentNumber, phone, email, start));

        //    return true;
        //}
        private List<TimeSlot> GetAvailableSlots()
        {
            return AvailableSlots.Where(s => !s.IsBooked).ToList();
        }
    }
}