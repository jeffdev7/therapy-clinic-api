using System.ComponentModel.DataAnnotations.Schema;

namespace clinic.domain.Entities
{
    public class TimeSlot : BaseEntity
    {
        [Column(TypeName = "timestamp without time zone")]
        public DateTime Start { get; set; }
        [Column(TypeName = "timestamp without time zone")]
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