using System.ComponentModel.DataAnnotations;

namespace clinic.application.ViewModel
{
    public sealed class AppointmentViewModel
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}