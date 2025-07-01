namespace clinic.domain.Entities
{
    public class AppointmentRequest : BaseEntity
    {
        public string? ClientName { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public TimeSlot RequestedTime { get; set; }
        protected AppointmentRequest()
        {
        }
        public static AppointmentRequest Create(string ClientName,
            string DocumentNumber,
            string Phone,
            string Email,
            TimeSlot RequestedTime) =>
            new()
            {
                ClientName = ClientName,
                DocumentNumber = DocumentNumber,
                Phone = Phone,
                Email = Email,
                RequestedTime = RequestedTime
            };
    }
}