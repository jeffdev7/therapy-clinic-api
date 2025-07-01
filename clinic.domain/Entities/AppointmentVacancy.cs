namespace clinic.domain.Entities
{
    public class AppointmentVacancy : BaseEntity
    {
        public List<DateTime> AppointmentTime { get; set; }
        protected AppointmentVacancy()
        {
        }
        public static AppointmentVacancy Create(List<DateTime> AppointmentTime) =>
            new()
            {
                AppointmentTime = AppointmentTime
            };
    }
}