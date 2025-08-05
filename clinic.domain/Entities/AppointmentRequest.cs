using clinic.domain.ValueObject;

namespace clinic.domain.Entities
{
    public class AppointmentRequest : BaseEntity
    {
        public string ClientName { get; set; }
        public PhoneNumber Phone { get; set; }
        public TimeSlot RequestedTime { get; set; }
        public string UserId { get; set; }
        protected AppointmentRequest()
        {
        }
        public static AppointmentRequest Create(
            string ClientName,
            PhoneNumber Phone,
            TimeSlot RequestedTime) =>
            new()
            {
                ClientName = ClientName,
                Phone = Phone,
                RequestedTime = RequestedTime
            };
    }
}