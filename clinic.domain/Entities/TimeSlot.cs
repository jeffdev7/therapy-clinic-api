using System.ComponentModel.DataAnnotations.Schema;

namespace clinic.domain.Entities
{
    public class TimeSlot : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsBooked { get; set; } = false;
        public string UserId { get; set; }
        protected TimeSlot()
        {
        }
        public static TimeSlot Create(DateTime Start,
            DateTime End,
            bool IsBooked) =>
            new()
            {
                Start = Start,
                End = End,
                IsBooked = IsBooked
            };
    }
}