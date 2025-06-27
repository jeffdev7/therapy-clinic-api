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
        public DateTime RequestedTime { get; set; }
    }
}
