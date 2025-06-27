namespace clinic.domain.Entities
{
    public class AppointmentVacancy : BaseEntity
    {
        public IEnumerable<DateTime> AppointmentTime { get; set; }
        protected AppointmentVacancy()
        {
        }
        public static AppointmentVacancy Create(IEnumerable<DateTime> AppointmentTime) =>
            new()
            {
                AppointmentTime = AppointmentTime
            };
    }
}