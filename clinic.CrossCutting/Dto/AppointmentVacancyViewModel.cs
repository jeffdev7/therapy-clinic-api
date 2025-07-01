using System.ComponentModel.DataAnnotations;

namespace clinic.CrossCutting.Dto
{
    public class AppointmentVacancyViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public List<DateTime> AppointmentTime { get; set; }
    }
}
