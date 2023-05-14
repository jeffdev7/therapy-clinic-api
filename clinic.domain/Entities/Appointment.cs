namespace clinic.domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime AppointmentTime { get; set; }

        public Appointment(int id, string? name, string? documentNumber, string? phone,
            string? email, DateTime appointmentTime)
        {
            Id = id;
            PatientName = name;
            DocumentNumber = documentNumber;
            Phone = phone;
            Email = email;
            AppointmentTime = appointmentTime;
        }

        public Appointment()
        {
        }
    }
}